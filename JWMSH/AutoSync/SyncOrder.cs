using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoSync
{
    public partial class SyncOrder : Form
    {
        public SyncOrder()
        {
            InitializeComponent();
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timerSpan_Tick(object sender, EventArgs e)
        {
            var tSpan = DateTime.Now - dtpStartTime.Value;
            lblTimeSpan.Text = tSpan.Days.ToString(CultureInfo.InvariantCulture) + @"天"
                + tSpan.Hours + @"小时" + tSpan.Minutes + @"分钟" + tSpan.Seconds + @"秒";
        }

        private void timerExec_Tick(object sender, EventArgs e)
        {
            GetSyncTable();
            if (dsOrder.Wms_M_Order == null || dsOrder.Wms_M_Order.Rows.Count<1)
            {
                return;
            }

            ExecUpload();

        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private void GetSyncTable()
        {
            //var wmf = new WmsFunction(Properties.Settings.Default.SqlServer);
            //var cmd = new SqlCommand("select * from WMS_M_Order where isnull(bUpdate,0)=0");
            //var dt = wmf.GetSqlTable(cmd);

            //return dt;
            dsOrder.Wms_M_Order.Rows.Clear();
            wms_M_OrderTableAdapter.Connection.ConnectionString = Properties.Settings.Default.SqlServer;
            wms_M_OrderTableAdapter.Fill(dsOrder.Wms_M_Order);
        }

        private void VLogError(string vRoutine, string vErrorDesc)
        {
            if (!Directory.Exists(Application.StartupPath + @"\Log\"))
                Directory.CreateDirectory(Application.StartupPath + @"\Log\");
    
            TextWriter tw = new StreamWriter(Application.StartupPath + @"\Log\EasTrx.log", true);
            tw.WriteLine("*********" + DateTime.Now);
            tw.WriteLine("Routine : " + vRoutine);
            tw.WriteLine("Error : " + vErrorDesc);
            tw.Close();
        }

        private void btnSaveTime_Click(object sender, EventArgs e)
        {
            timerExec.Interval = (int)nudTimeSpan.Value * 60000;
        }

        private void SyncOrder_SizeChanged(object sender, EventArgs e)
        {
            //判断是否选择的是最小化按钮 
            if (WindowState == FormWindowState.Minimized)
            {

                //隐藏任务栏区图标 
                this.ShowInTaskbar = false;
                //图标显示在托盘区 
                nfiMain.Visible = true;
            }
        }

        private void nfiMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //判断是否已经最小化于托盘 
            if (WindowState == FormWindowState.Minimized)
            {
                //还原窗体显示 
                WindowState = FormWindowState.Normal;
                //激活窗体并给予它焦点 
                this.Activate();
                //任务栏区显示图标 
                this.ShowInTaskbar = true;
                //托盘区图标隐藏 
                nfiMain.Visible = false;
            }
        }

        private void SyncOrder_Load(object sender, EventArgs e)
        {
            
            tstxtServer.Text = Properties.Settings.Default.SqlServer;
            //记录开始的时间
            dtpStartTime.Value = DateTime.Now;

            timerExec.Interval = (int)nudTimeSpan.Value * 60000;
            timerExec.Enabled = true;
            GetSyncTable();
            ExecUpload();
        }




        private void ExecUpload()
        {

            lblLastTime.Text = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            var stw = new Stopwatch();
            stw.Start();


            //如果没有任何未入库的单据,则直接退出
            if (dsOrder.Wms_M_Order ==null|| dsOrder.Wms_M_Order.Count < 1)
                return;
            var iSumSucces = 0;
            var iSumFail = 0;


            #region for New Order
            for (var iFor = 0; iFor < dsOrder.Wms_M_Order.Rows.Count; iFor++)
            {
                var cGuid = dsOrder.Wms_M_Order.Rows[iFor]["cGuid"].ToString();
                //先判断子表是否有数据
                var dtDetail = GetDetail(dsOrder.Wms_M_Order.Rows[iFor]["cTable"].ToString(), cGuid);
                if (dtDetail == null || dtDetail.Rows.Count < 1)
                    continue;
                var cType = dsOrder.Wms_M_Order.Rows[iFor]["cType"].ToString();
                var billMainCmd = string.Empty;
                var billEntrycmd = string.Empty;


                //判断出入库类型
                if (cType.Equals("成品入库"))
                {
                    billMainCmd = "develop_StockBill";
                    billEntrycmd = "develop_StockBillEntry";
                }
                else if (cType.Equals("采购入库"))
                {
                    billMainCmd = "develop_StockBill_Purchase";
                    billEntrycmd = "develop_StockBillEntry_Purchase";
                }
                else if (cType.Equals("销售出库"))
                {
                    billMainCmd = "develop_StockBill_Delivery";
                    billEntrycmd = "develop_StockBillEntry_Delivery";
                }


                if (string.IsNullOrEmpty(billMainCmd))
                {
                    continue;
                }

                //执行写入入库单操作
                //先插入入库单主表,获取入库单内码和入库单号
                string fBillNo;
                using (var con = new SqlConnection(Properties.Settings.Default.KisServer))
                {
                    con.Open();
                    var tran = con.BeginTransaction();
                    using (var cmdMain = con.CreateCommand())
                    {
                        cmdMain.Transaction = tran;
                        cmdMain.CommandType = CommandType.StoredProcedure;
                        //如果主表写入成功,则返回FBillNo和FinterID
                        int finterId;
                        //先获取最大ID号
                        cmdMain.CommandText = "GetICMaxNum";
                        cmdMain.Parameters.AddWithValue("@TableName", "ICStockBill");
                        cmdMain.Parameters.Add(new SqlParameter("@FInterID", SqlDbType.Int, 32));
                        cmdMain.Parameters["@FInterID"].Direction = ParameterDirection.Output;
                        cmdMain.Parameters.AddWithValue("@Increment", 1);
                        cmdMain.Parameters.AddWithValue("@UserID", 16422);
                        try
                        {
                            cmdMain.ExecuteNonQuery();
                            finterId = (int)cmdMain.Parameters["@FInterID"].Value;

                        }
                        catch (Exception)
                        {
                            tran.Rollback();
                            return;
                        }

                        if (finterId < 1)
                        {
                            //如果返回id不正确,回滚
                            tran.Rollback();
                            return;
                        }

                        cmdMain.CommandText = billEntrycmd;





                        //写入入库单子表
                        for (var i = 0; i < dtDetail.Rows.Count; i++)
                        {
                            //先清除传入的参数
                            cmdMain.Parameters.Clear();
                            cmdMain.Parameters.AddWithValue("@FInterID", finterId);
                            cmdMain.Parameters.AddWithValue("@FBrNo", 0);
                            cmdMain.Parameters.AddWithValue("@FItemID", dtDetail.Rows[i]["FitemID"]);
                            cmdMain.Parameters.AddWithValue("@FEntryID", i + 1);
                            cmdMain.Parameters.AddWithValue("@FQty", dtDetail.Rows[i]["iQuantity"]);
                            cmdMain.Parameters.AddWithValue("@Fnote",
                                                              "时间" + DateTime.Now.ToString(CultureInfo.CurrentCulture));
                            cmdMain.Parameters.AddWithValue("@FSPNumber", dtDetail.Rows[i]["FSPNumber"]);

                            if (cType.Equals("采购入库"))
                            {
                                cmdMain.Parameters.AddWithValue("@FSourceEntryID", dtDetail.Rows[i]["FEntryID"]);
                                cmdMain.Parameters.AddWithValue("@cOrderNumber", dtDetail.Rows[i]["cOrderNumber"]);
                            }
                            try
                            {
                                cmdMain.ExecuteNonQuery();

                            }
                            catch (Exception ex)
                            {
                                VLogError(DateTime.Now+"子表",ex.Message);
                                //插入子表有任何异常,回滚
                                tran.Rollback();
                                return;
                            }
                        }


                        cmdMain.CommandText = billMainCmd;
                        cmdMain.Parameters.Clear();
                        cmdMain.Parameters.AddWithValue("@FInterID", finterId);
                        cmdMain.Parameters.Add(new SqlParameter("@FBillNo", SqlDbType.NVarChar, 255));
                        cmdMain.Parameters["@FBillNo"].Direction = ParameterDirection.Output;

                        try
                        {
                            cmdMain.ExecuteNonQuery();
                            fBillNo = cmdMain.Parameters["@FBillNo"].Value.ToString();
                        }
                        catch (Exception)
                        {
                            //如果执行失败,回滚
                            tran.Rollback();
                            return;
                        }
                        try
                        {
                            if (UpdateStatus(cGuid, fBillNo))
                            {
                                dsOrder.Wms_M_Order.Rows[iFor]["bUpdate"] = 1;
                                tran.Commit();
                                iSumSucces =iSumSucces+ 1;
                            }
                            else
                            {
                                tran.Rollback();
                            }
                        }
                        catch (Exception ex)
                        {
                            VLogError(DateTime.Now + "提交", ex.Message);
                            tran.Rollback();
                            return;
                        }
                    }


                }

            }
            #endregion

            stw.Stop();
            //显示执行一次用时的时间
            lblCostTime.Text = stw.Elapsed.Milliseconds.ToString(CultureInfo.InvariantCulture) + @"毫秒";
            var sfun = new WmsFunction(Properties.Settings.Default.SqlServer);
            using (var lcmd = new SqlCommand("AddLogAction"))
            {
                lcmd.CommandType= CommandType.StoredProcedure;
                lcmd.Parameters.AddWithValue("@cFunction", "执行同步");
                lcmd.Parameters.AddWithValue("@cDescription", "此次成功同步数:" + iSumSucces + "失败数量:" + iSumFail + "开始时间:"
                                                           + lblLastTime.Text + "用时:" + lblCostTime.Text);
                sfun.Sqlexcuate(lcmd);
            }
        }

        private DataTable GetDetail(string cTable, string cGuid)
        {
            var wmf = new WmsFunction(Properties.Settings.Default.SqlServer);
            var cmd = new SqlCommand("select * from " + cTable + " where  cGuid=@cGuid");
            cmd.Parameters.AddWithValue("@cGuid", cGuid);
            var dt = wmf.GetSqlTable(cmd);

            return dt;
        }


        private bool UpdateStatus(string cGuid, string cOrderNumber)
        {
            var wmf = new WmsFunction(Properties.Settings.Default.SqlServer);
            var cmd = new SqlCommand("update Wms_M_Order set cOrderNumber=@cOrderNumber,bUpdate=1 where cGuid=@cGuid");
            cmd.Parameters.AddWithValue("@cGuid", cGuid);
            cmd.Parameters.AddWithValue("@cOrderNumber", cOrderNumber);
            return wmf.ExecSqlCmd(cmd);
        }

    }
}
