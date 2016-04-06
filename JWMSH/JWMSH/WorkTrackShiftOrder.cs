using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using JWMSH.DLL;

namespace JWMSH
{
    public partial class WorkTrackShiftOrder : Form
    {
        private DataTable BomList;

        private long bomID;

        private string _lid;

        private string _FitemId;


        /// <summary>
        /// 打印模版路径
        /// </summary>
        private string _cTempletFileName;

        /// <summary>
        /// 打印模版路径
        /// </summary>
        private string _cCaption;

        /// <summary>
        /// 打印机
        /// </summary>
        private string _cPrinter;



        /// <summary>
        /// 打印模版路径
        /// </summary>
        private string _RmcTempletFileName;

        /// <summary>
        /// 打印模版路径
        /// </summary>
        private string _RmcCaption;

        /// <summary>
        /// 打印机
        /// </summary>
        private string _RmcPrinter;


        public WorkTrackShiftOrder()
        {
            InitializeComponent();
        }

        public WorkTrackShiftOrder(string lid)
        {
            InitializeComponent();
            _lid = lid;
        }


        public DLL.DataInventory.BomDetailDataTable GetBomDetail()
        {
            return dataInventory.BomDetail;
        }

        public DLL.DataInventory.ShiftDetailDataTable GetShiftDetail()
        {
            return dataInventory.ShiftDetail;
        }

        public int GetProductQuantity()
        {
            int iQuantity;
            if (int.TryParse(uneiQuantity.Value.ToString(), out iQuantity))
                return iQuantity;
            return 1;
        }


        private void WorkTrackShiftOrder_Load(object sender, EventArgs e)
        {
            GetProduct();
            if (string.IsNullOrEmpty(_lid))
            {
                SetPanelVlaue("", "btnLast");
            }
            else
            {
                SetPanelVlaue(_lid);
            }

            lblTitleMain.btnFirst.Click += btnFirst_Click;
            lblTitleMain.btnNext.Click += btnFirst_Click;
            lblTitleMain.btnPre.Click += btnFirst_Click;
            lblTitleMain.btnLast.Click += btnFirst_Click;

            DllWorkPrintLabel.GetTemplet("班次制单模板", ref _cCaption, ref _cPrinter, ref _cTempletFileName);

            DllWorkPrintLabel.GetTemplet("原料标签", ref _RmcCaption, ref _RmcPrinter, ref _RmcTempletFileName);

            biEditPrinter.Caption = _cPrinter;
            biEditTemplet.Caption = _cCaption;

            biRmTemplet.Caption = _RmcCaption;
            biRmPrinter.Caption = _RmcPrinter;

            rm_ProduceDetailTableAdapter.Connection.ConnectionString = Properties.Settings.Default.BCon;
            bomDetailTableAdapter.Connection.ConnectionString = Properties.Settings.Default.BCon;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (biSave.Enabled)
            {
                MessageBox.Show(@"请取消编辑后再翻页!", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var btn = (Button)sender;
            SetPanelVlaue(lblTitleMain.lblAutoID.Text, btn.Name);
        }

        private void GetProduct()
        {
            var cmd = new SqlCommand("Select * from Bom");
            var wf = new WmsFunction(BaseStructure.WmsCon);
            BomList = wf.GetSqlTable(cmd);
            txtcInvCode.DataSource = BomList;
            var cmdVendor = new SqlCommand("select FNumber,FName from t_Department order by FNumber");
            wf.Constr = BaseStructure.KisConstring;
            txtcDept.DataSource = wf.GetSqlTable(cmdVendor);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int iQuantity;
            if (uneiQuantity.Value==null||!int.TryParse(uneiQuantity.Value.ToString(), out iQuantity))
            {
                MessageBox.Show(@"请先选择数量");
                uneiQuantity.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtcInvCode.Text)||string.IsNullOrEmpty(utecInvName.Text))
            {
                MessageBox.Show(@"请先选择产品");
                return;
            }
            using (var skcs = new SelectKisCurrectStock(this))
            {
                skcs.ShowDialog();}
        }

        private void txtcInvCode_RowSelected(object sender, Infragistics.Win.UltraWinGrid.RowSelectedEventArgs e)
        {
            var uRow = e.Row;
            if (uRow == null || uRow.Index <= -1) 
                return;
            if (!long.TryParse(uRow.Cells["AutoID"].Value.ToString(), out bomID))
            {
                return;
            }
            _FitemId = uRow.Cells["cFitemID"].Value.ToString();dataInventory.BomDetail.Rows.Clear();
            bomDetailTableAdapter.Fill(dataInventory.BomDetail, bomID);
            txtcInvStd.Text = uRow.Cells["cInvStd"].Value.ToString();
            utecInvName.Text = uRow.Cells["cInvName"].Value.ToString();
            txtcFullName.Text = uRow.Cells["cFullName"].Value.ToString();
        }

        private void biAddNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ResetNull();
            lblTitleMain.lblAutoID.Text = "";
            lblTitleMain.lblcSerialNumber.Text = "";
            SetControlEnable();
        }


        private void ResetNull()
        {
            foreach (Control ctrl in ugbxMain.Controls)
            {
                if (ctrl is TextBox || ctrl is UltraComboEditor || ctrl is UltraTextEditor)
                {
                    ctrl.Text = "";
                }
                else if (ctrl is UltraNumericEditor)
                {
                    var uctr = ctrl as UltraNumericEditor;
                    uctr.Value = null;

                }

            }
            txtcInvCode.Text = "";
            lblTitleMain.lblAutoID.Text = "";
            //清空制单人等信息
            dataInventory.BomDetail.Rows.Clear();
            dataInventory.Rm_ProduceDetail.Rows.Clear();
        }

        /// <summary>
        /// 启用所有新增和更新控件时使用的输入和保存按钮
        /// </summary>
        private void SetControlEnable()
        {
            foreach (Control ctrl in ugbxMain.Controls)
            {
                if (ctrl is Label || ctrl is UltraLabel)
                {
                    continue;
                }
                ctrl.Enabled = true;
            }
            biSave.Enabled = true; //在可编辑下保存按钮可用
            biGiveup.Enabled = true; //在可编辑下取消按钮可用
            biAddNew.Enabled = false; //在可编辑下新增按钮不可用
            biEdit.Enabled = false; //在可编辑下修改按钮不可用
            biDelete.Enabled = false;

        }

        /// <summary>
        /// 禁用所有输入框和保存按钮
        /// </summary>
        private void SetControlDisable()
        {
            foreach (Control ctrl in ugbxMain.Controls)
            {
                if (ctrl is Label || ctrl is UltraLabel)
                {
                    continue;
                }
                ctrl.Enabled = false;
            }

            biSave.Enabled = false;//在不可编辑下保存按钮不可用
            biGiveup.Enabled = false;//在不可编辑下取消按钮不可用
            biAddNew.Enabled = true;//在不可编辑下新增按钮可用
            biEdit.Enabled = true;//在不可编辑下修改按钮可用
            biDelete.Enabled = true;
        }

        private void biEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblTitleMain.lblAutoID.Text))
            {
                SetControlEnable();//启用所有输入框和保存按钮
                txtcInvCode.Enabled = false;
                utecInvName.Enabled = false;
            }
            else
            {
                MessageBox.Show(@"未指定数据，请检查后再试!", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void biGiveup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetControlDisable();//取消就是撤消此次修改。
            if (string.IsNullOrEmpty(lblTitleMain.lblAutoID.Text))
            {
                SetPanelVlaue("", "btnLast");
            }
            else
            {
                SetPanelVlaue(lblTitleMain.lblAutoID.Text);
            }
        }


        /// <summary>
        /// 进行数据库数据定位显示
        /// </summary>
        /// <param name="lId"></param>
        /// <param name="llocation"></param>
        public void SetPanelVlaue(string lId, string llocation = "")
        {
            var sqlcmd = new SqlCommand();
            switch (llocation)
            {
                case "btnLast":
                    sqlcmd.CommandText = "select top 1 * from Shift order by AutoID desc";
                    break;
                case "btnFirst":
                    sqlcmd.CommandText = "select top 1 * from Shift order by AutoID";
                    break;
                case "btnPre":
                    if (string.IsNullOrEmpty(lId))
                    {
                        MessageBox.Show(@"已到首页");
                        return;
                    }
                    sqlcmd.CommandText = "select top 1 * from Shift where AutoID<@AutoID order by AutoID desc";
                    sqlcmd.Parameters.AddWithValue("@AutoID", lId);
                    break;
                case "btnNext":
                    if (string.IsNullOrEmpty(lId))
                    {
                        MessageBox.Show(@"已到末页");
                        return;
                    }
                    sqlcmd.CommandText = "select top 1 * from Shift where AutoID>@AutoID order by AutoID";
                    sqlcmd.Parameters.AddWithValue("@AutoID", lId);
                    break;
                case "":
                    sqlcmd.CommandText = "select top 1 * from Shift where AutoID=@AutoID";
                    sqlcmd.Parameters.AddWithValue("@AutoID", lId);
                    break;
            }

            using (var con = new SqlConnection(BaseStructure.WmsCon))
            {
                sqlcmd.Connection = con;
                con.Open();
                #region 读取数据库中数据
                using (var dr = sqlcmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        if (!long.TryParse(dr["BomID"].ToString(), out bomID))
                        {
                            MessageBox.Show(@"BomID 绑定异常，退出跳转！");
                            return;
                        }
                        //获取所有取得的数据并显示
                        lblTitleMain.lblAutoID.Text = dr["AutoID"].ToString();
                        lblTitleMain.lblcSerialNumber.Text = dr["cSerialNumber"].ToString();
                        _FitemId = dr["cFitemId"].ToString();

                        
                        txtcOrderNumber.Text = dr["cOrderNumber"].ToString();
                        txtFBatchNo.Text = dr["FBatchNo"].ToString();
                        uneiQuantity.Text = dr["iQuantity"].ToString();
                        if (string.IsNullOrEmpty(dr["dDate"].ToString()))
                        {
                            dtpdDate.Checked = false;
                            dtpdDate.Value = DateTime.Now;
                        }
                        else
                        {
                            dtpdDate.Checked = true;
                            dtpdDate.Value = (DateTime)dr["dDate"];
                        }
                        txtcInvCode.Text = dr["cInvCode"].ToString();
                        utecInvName.Text = dr["cInvName"].ToString();
                        txtcInvStd.Text = dr["cInvStd"].ToString();
                        txtcFullName.Text = dr["cFullName"].ToString();
                        txtcDept.Text = dr["cDeptName"].ToString();
                        txtcMemo.Text = dr["cMemo"].ToString();
                        rm_ProduceDetailTableAdapter.Fill(dataInventory.Rm_ProduceDetail, lblTitleMain.lblcSerialNumber.Text);
                        bomDetailTableAdapter.Fill(dataInventory.BomDetail, bomID);
                    }
                    else
                    {
                        switch (llocation)
                        {
                            case "btnPre":
                                MessageBox.Show(@"已经是首页");
                                break;
                            case "btnNext":
                                MessageBox.Show(@"已经是末页");
                                break;
                            default:
                                MessageBox.Show(@"无记录");
                                //ResetNull();
                                //SetControlDisable();
                                break;
                        }

                    }
                #endregion
                }
            }

        }

        /// <summary>
        /// 判断什么未填写,返回对应的标签
        /// </summary>
        /// <returns></returns>
        private string CheckNull()
        {
            if (string.IsNullOrEmpty(txtcInvCode.Text))
                return "编码";
            if (string.IsNullOrEmpty(txtcOrderNumber.Text))
                return "客户订单号";
            if(string.IsNullOrEmpty(txtFBatchNo.Text))
            {
                return "生产批号";
            }
            if (!dtpdDate.Checked)
                return "日期";var cmdInvCode = new SqlCommand("select * from t_icItem where FNumber=@FNumber");
            cmdInvCode.Parameters.AddWithValue("@FNumber", txtcInvCode.Value);
            var wfun = new WmsFunction(BaseStructure.KisConstring);
            if (!wfun.BoolExistTable(cmdInvCode))
            {
                return @"编码不正确,编码";
            }
            //if (dataInventory.ShiftDetail.Rows.Count < 1)
            //    return "子件";
            return uneiQuantity.Value == null || string.IsNullOrEmpty(uneiQuantity.Value.ToString()) ? "数量" : string.Empty;
        }

        private void biEditTemplet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var st = new Base_Templet(true, "班次制单模板"))
            {
                if (st.ShowDialog() == DialogResult.Yes)
                {
                    biEditTemplet.Caption = st.URow.Cells["cCaption"].Value.ToString();
                    _cCaption = st.URow.Cells["cCaption"].Value.ToString();
                    _cTempletFileName = st.URow.Cells["cTempletPath"].Value.ToString();
                    biEditPrinter.Caption = st.URow.Cells["cPrinter"].Value.ToString();
                    _cPrinter = st.URow.Cells["cPrinter"].Value.ToString();
                }
            }
        }

        private void biSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //判断什么为填写
            var nullstr = CheckNull();
            if (!string.IsNullOrEmpty(nullstr))
            {
                MessageBox.Show(nullstr + @"必填,请填写完成!", @"必填", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var con = new SqlConnection(BaseStructure.WmsCon))
            {
                using (var cmd = new SqlCommand { CommandType = CommandType.StoredProcedure, Connection = con })
                {
                    if (string.IsNullOrEmpty(lblTitleMain.lblAutoID.Text))
                    {
                        cmd.CommandText = "proc_ShiftInsert";
                        var idParameter = new SqlParameter("@AutoID", SqlDbType.BigInt)
                        {
                            Direction = ParameterDirection.Output
                        };
                        var cBoNoParameter = new SqlParameter("@cSerialNumber", SqlDbType.NVarChar, 150)
                        {
                            Direction = ParameterDirection.Output
                        };
                        //获取id的返回值和采购订单号的返回值
                        cmd.Parameters.Add(idParameter);
                        cmd.Parameters.Add(cBoNoParameter);
                    }
                    else
                    {
                        cmd.CommandText = "proc_ShiftUpdate";
                        cmd.Parameters.AddWithValue("@AutoID", lblTitleMain.lblAutoID.Text);
                    }

                    //赋参数
                    cmd.Parameters.AddWithValue("@BomID", bomID);
                    cmd.Parameters.AddWithValue("@cFitemID", _FitemId);
                    cmd.Parameters.AddWithValue("@cInvCode", txtcInvCode.Text);
                    cmd.Parameters.AddWithValue("@cInvName", utecInvName.Text);
                    cmd.Parameters.AddWithValue("@cInvStd", txtcInvStd.Text);
                    cmd.Parameters.AddWithValue("@cFullName", txtcFullName.Text);
                    cmd.Parameters.AddWithValue("@cOrderNumber", txtcOrderNumber.Text);
                    cmd.Parameters.AddWithValue("@FBatchNo", txtFBatchNo.Text);
                    cmd.Parameters.AddWithValue("@iQuantity", GetProductQuantity());
                    cmd.Parameters.AddWithValue("@dDate", dtpdDate.Value.Date);
                    cmd.Parameters.AddWithValue("@cDeptName", txtcDept.Text);
                    
                    cmd.Parameters.AddWithValue("@cMemo", txtcMemo.Text);
                    con.Open();
                    using (var tran = con.BeginTransaction())
                    {
                        int ieffect;
                        cmd.Transaction = tran;
                        try
                        {
                            ieffect = cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }
                        //判断是否是真的完成了主表的写入
                        if (ieffect > 0)
                        {
                            if (string.IsNullOrEmpty(lblTitleMain.lblAutoID.Text))
                            {
                                lblTitleMain.lblAutoID.Text = cmd.Parameters["@AutoID"].Value.ToString();
                                lblTitleMain.lblcSerialNumber.Text = cmd.Parameters["@cSerialNumber"].Value.ToString();
                            }
                        }
                        else
                        {
                            MessageBox.Show(@"保存失败，", @"失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        uGridRawMaterial.UpdateData();
                        //重新赋值一下行号/单据号给子表
                        //for (var i = 0; i < dataInventory.ShiftDetail.Rows.Count; i++)
                        //{
                        //    var dr = dataInventory.ShiftDetail.Rows[i];
                        //    if (dr.RowState == DataRowState.Deleted)
                        //        continue;
                        //    dr["cSerialNumber"] = lblTitleMain.lblcSerialNumber.Text;

                        //}
                        //将改变提交到内存表
                        uGridRawMaterial.UpdateData();
                        try
                        {
                            //提交子表
                            //提交主表
                            tran.Commit();
                            MessageBox.Show(@"保存成功", @"成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            SetControlDisable();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        private void biPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintDialog("print");
        }

        private void biPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintDialog("preview");
        }

        private void biDesign_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintDialog("design");
        }


        public void PrintDialog(string operation)
        {
            var xtreport = new XtraReport();
            // _btApp = new BarTender.Application();
            //判断当前打印模版路径是否存在
            var _cTempletFileName = Application.StartupPath + @"\Label\班次制令单.repx";
            var temPath = _cTempletFileName;      //Application.StartupPath + @"\Label\" +  _cTempletFileName;

            if (!File.Exists(temPath))
            {
                MessageBox.Show(@"当前路径下的打印模版文件不存在!", @"异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                xtreport.ShowDesigner();
                return;
            }
            xtreport.LoadLayout(temPath);
            xtreport.PrinterName = _cPrinter;
            xtreport.RequestParameters = false;
            xtreport.ShowPrintStatusDialog = false;
            xtreport.ShowPrintMarginsWarning = false;

            //模板赋值
            DllWorkPrintLabel.SetParametersValue(xtreport, "cSerialNumber", lblTitleMain.lblcSerialNumber.Text);
            DllWorkPrintLabel.SetParametersValue(xtreport, "cInvCode", txtcInvCode.Text);
            DllWorkPrintLabel.SetParametersValue(xtreport, "cInvName", utecInvName.Text);
            DllWorkPrintLabel.SetParametersValue(xtreport, "cInvStd", txtcInvStd.Text);
            DllWorkPrintLabel.SetParametersValue(xtreport, "cFullName", txtcFullName.Text);
            DllWorkPrintLabel.SetParametersValue(xtreport, "cOrderNuber", txtcOrderNumber.Text);
            DllWorkPrintLabel.SetParametersValue(xtreport, "FBatchNo", txtFBatchNo.Text);
            DllWorkPrintLabel.SetParametersValue(xtreport, "iQuantity", uneiQuantity.Value);
            DllWorkPrintLabel.SetParametersValue(xtreport, "cDepartment", txtcDept.Text);
            DllWorkPrintLabel.SetParametersValue(xtreport, "dDate", dtpdDate.Value.ToShortDateString());
            DllWorkPrintLabel.SetParametersValue(xtreport, "cMemo", txtcMemo.Text);
            xtreport.DataSource = dataInventory.BomDetail;
            //模板赋值
            switch (operation)
            {
                case "print":
                    xtreport.Print();
                    break;
                case "design":
                    xtreport.ShowDesigner();
                    break;
                case "preview":
                    xtreport.ShowPreview();
                    break;
            }

        }

        private void biRmTemplet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var st = new Base_Templet(true, "原料标签"))
            {
                if (st.ShowDialog() == DialogResult.Yes)
                {
                    biRmTemplet.Caption = st.URow.Cells["cCaption"].Value.ToString();
                    _RmcCaption = st.URow.Cells["cCaption"].Value.ToString();
                    _RmcTempletFileName = st.URow.Cells["cTempletPath"].Value.ToString();
                    biRmPrinter.Caption = st.URow.Cells["cPrinter"].Value.ToString();
                    _RmcPrinter = st.URow.Cells["cPrinter"].Value.ToString();
                }
            }
        }

        private void uGridShiftDetail_DoubleClickCell(object sender, Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs e)
        {
            var wf = new WmsFunction(BaseStructure.WmsCon);
            var cmd = new SqlCommand("select * from RmLabel where cInvCode=@cInvCode and cLotNo=@cLotNo");
            cmd.Parameters.AddWithValue("@cInvCode", e.Cell.Row.Cells["cInvCode"].Value.ToString());
            cmd.Parameters.AddWithValue("@cLotNo", e.Cell.Row.Cells["FBatchNo"].Value.ToString());

            var dt = wf.GetSqlTable(cmd);
            if (dt==null||dt.Rows.Count<1)
            {
                MessageBox.Show(@"当前批号，未在原料标签打印记录中，请手动在原料标签打印中，打印!", @"异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                return;
            }
            PrintDialogRm("print", e.Cell.Row, dt);
        }


        public void PrintDialogRm(string operation,Infragistics.Win.UltraWinGrid.UltraGridRow uRow,DataTable dt)
        {
            var xtreport = new XtraReport();
            // _btApp = new BarTender.Application();
            //判断当前打印模版路径是否存在
            //var _RmcTempletFileName = Application.StartupPath + @"\Label\班次制令单.repx";
            var temPath = _RmcTempletFileName;     //_cTempletFileName;      //Application.StartupPath + @"\Label\" +   _cTempletFileName;

            if (!File.Exists(temPath))
            {
                MessageBox.Show(@"当前路径下的打印模版文件不存在!", @"异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                xtreport.ShowDesigner();
                return;
            }
            xtreport.LoadLayout(temPath);
            xtreport.PrinterName = _cPrinter;
            xtreport.RequestParameters = false;
            xtreport.ShowPrintStatusDialog = false;
            xtreport.ShowPrintMarginsWarning = false;

            var cFitemID = uRow.Cells["cFitemID"].Value.ToString();
            var cLotNo = uRow.Cells["FBatchNo"].Value.ToString();
            var cDefine2 = dt.Rows[0]["cDefine2"].ToString();
            var cSerialNumber = dt.Rows[0]["cSerialNumber"].ToString();
            var cInvCode = dt.Rows[0]["cInvCode"].ToString();
            var cInvName = dt.Rows[0]["cInvName"].ToString();
            var dDate= dt.Rows[0]["dDate"].ToString();
            var cInvStd = dt.Rows[0]["cInvStd"].ToString();
            var cFullName = dt.Rows[0]["cFullName"].ToString();
            var iQuantity = uRow.Cells["iQuantity"].Value.ToString();
            var cMemo = dt.Rows[0]["cMemo"].ToString();
            var cDefine1 = dt.Rows[0]["cDefine1"].ToString();

            //模板赋值
            DllWorkPrintLabel.SetParametersValue(xtreport, "cSerialNumber", lblTitleMain.lblcSerialNumber.Text);
            DllWorkPrintLabel.SetParametersValue(xtreport, "cBarCode", "R*" + cFitemID + "*L*" + cLotNo + "*S*" + cSerialNumber + ";" + cDefine2);
            DllWorkPrintLabel.SetParametersValue(xtreport, "cInvCode", cInvCode);
            DllWorkPrintLabel.SetParametersValue(xtreport, "cInvName", cInvName);
            DllWorkPrintLabel.SetParametersValue(xtreport, "dDate", dDate);
            DllWorkPrintLabel.SetParametersValue(xtreport, "cInvStd", cInvStd);
            DllWorkPrintLabel.SetParametersValue(xtreport, "cFullName", txtcFullName.Text);
            DllWorkPrintLabel.SetParametersValue(xtreport, "cVendor", cFullName);
            DllWorkPrintLabel.SetParametersValue(xtreport, "cLotNo", cLotNo);
            DllWorkPrintLabel.SetParametersValue(xtreport, "iQuantity", iQuantity);
            DllWorkPrintLabel.SetParametersValue(xtreport, "cMemo", cMemo);
            DllWorkPrintLabel.SetParametersValue(xtreport, "cDefine1", cDefine1);
            if (dtpdDate.Checked)
                DllWorkPrintLabel.SetParametersValue(xtreport, "cVendorDate", dtpdDate.Value);
            //模板赋值
            switch (operation)
            {
                case "print":
                    xtreport.Print();
                    break;
                case "design":
                    xtreport.ShowDesigner();
                    break;
                case "preview":
                    xtreport.ShowPreview();
                    break;
            }

        }
    }
}
