using DevExpress.XtraReports.UI;
using Infragistics.Win.UltraWinEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JWMSH
{
    public partial class WorkTrackDeliveryOrder : Form
    {
        /// <summary>
        /// 客户名
        /// </summary>
        private string _cCusCode;


        private string _outType;

        private string _cDepCode;

        private string _lid;

        private string _cMaker;
        public WorkTrackDeliveryOrder()
        {
            InitializeComponent();
        }

        private void WorkTrackDeliveryOrder_Load(object sender, EventArgs e)
        {
            proDeliveryDetailTableAdapter.Connection.ConnectionString = BaseStructure.WmsCon;
            if (string.IsNullOrEmpty(_lid))
            {
                SetPanelVlaue("", "btnLast");
            }
            else
            {
                SetPanelVlaue(_lid);
            }

            //智能匹配数据源
            var cmd = new SqlCommand("select top 100 cCode from ProDelivery order by AutoID desc");
            cmd.Parameters.AddWithValue("@cCode", txtQuery.Text);
            var wf = new WmsFunction(BaseStructure.WmsCon);
            txtQuery.DataSource = wf.GetSqlTable(cmd);


            //初始化表格功能控件
            tsgfMain.FormId = Name.GetHashCode().ToString(CultureInfo.CurrentCulture);
            tsgfMain.FormName = Text;
            tsgfMain.Constr = BaseStructure.WmsCon;
            tsgfMain.GetGridStyle(tsgfMain.FormId);
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
            lblAutoID.Text = "";
            lblcState.Text = "";

            //清空制单人等信息
            dataBiDetail.ProDeliveryDetail.Rows.Clear();
        }
        private void biAddNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ResetNull();
            SetControlEnable();
            dtpdDate.Value = DateTime.Now.Date;
            dtpOrderDate.Value = DateTime.Now.Date;
            dtpDeliveryDate.Enabled = true;
            dtpDeliveryDate.Value = DateTime.Now.Date;
            dtpDeliveryDate.Checked = false;
        }

        private void biEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblAutoID.Text))
            {
                if (lblcState.Text.StartsWith("已导入"))
                {
                    MessageBox.Show(@"已导入ERP的单据不允许修改!", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                SetControlEnable();//启用所有输入框和保存按钮
            }
            else
            {
                MessageBox.Show(@"未指定单据，请检查后再试!", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void biDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(lblAutoID.Text))
            {
                MessageBox.Show(@"未指定单据，请检查后再试!", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show(@"确实要删除吗!", @"提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                DialogResult.Yes)
                return;
            using (var con = new SqlConnection(BaseStructure.WmsCon))
            {
                con.Open();
                using (var cmd = new SqlCommand("DeleteProDelivery") { CommandType = CommandType.StoredProcedure, Connection = con })
                {
                    cmd.Parameters.AddWithValue("@AutoID", lblAutoID.Text);
                    try
                    {
                        if (cmd.ExecuteNonQuery() > 1)
                        {
                            MessageBox.Show(@"删除成功!");
                            SetPanelVlaue("", "btnLast");
                        }
                        else
                        {
                            MessageBox.Show(@"删除失败，请查找原因!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(@"删除失败!" + ex.Message);
                    }
                }
            }
        }

        private void biGiveup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetControlDisable();//取消就是撤消此次修改。
            if (string.IsNullOrEmpty(lblAutoID.Text))
            {
                SetPanelVlaue("", "btnLast");
            }
            else
            {
                SetPanelVlaue(lblAutoID.Text);
            }
        }


        /// <summary>
        /// 禁用所有输入框和保存按钮
        /// </summary>
        private void SetControlDisable()
        {

            biSave.Enabled = false;//在不可编辑下保存按钮不可用
            biGiveup.Enabled = false;//在不可编辑下取消按钮不可用
            biAddNew.Enabled = true;//在不可编辑下新增按钮可用
            biEdit.Enabled = true;//在不可编辑下修改按钮可用
            biDelete.Enabled = true;
            utxtcCusName.Enabled = false;
            dtpdDate.Enabled = false;
            dtpDeliveryDate.Enabled = false;

            txtcMemo.Enabled = false;

        }

        /// <summary>
        /// 启用所有新增和更新控件时使用的输入和保存按钮
        /// </summary>
        private void SetControlEnable()
        {

            biSave.Enabled = true; //在可编辑下保存按钮可用
            biGiveup.Enabled = true; //在可编辑下取消按钮可用
            biAddNew.Enabled = false; //在可编辑下新增按钮不可用
            biEdit.Enabled = false; //在可编辑下修改按钮不可用
            biDelete.Enabled = false;
            utxtcCusName.Enabled = true;
            dtpdDate.Enabled = true;


            txtcMemo.Enabled = true;
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
                    sqlcmd.CommandText = "select top 1 * from ProDelivery order by AutoID desc";
                    break;
                case "btnFirst":
                    sqlcmd.CommandText = "select top 1 * from ProDelivery order by AutoID";
                    break;
                case "btnPre":
                    if (string.IsNullOrEmpty(lId))
                    {
                        MessageBox.Show(@"已到首页");
                        return;
                    }
                    sqlcmd.CommandText = "select top 1 * from ProDelivery where AutoID<@AutoID order by AutoID desc";
                    sqlcmd.Parameters.AddWithValue("@AutoID", lId);
                    break;
                case "btnNext":
                    if (string.IsNullOrEmpty(lId))
                    {
                        MessageBox.Show(@"已到末页");
                        return;
                    }
                    sqlcmd.CommandText = "select top 1 * from ProDelivery where AutoID>@AutoID order by AutoID";
                    sqlcmd.Parameters.AddWithValue("@AutoID", lId);
                    break;
                case "":
                    sqlcmd.CommandText = "select top 1 * from ProDelivery where AutoID=@AutoID";
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
                        //获取所有取得的数据并显示
                        lblAutoID.Text = dr["AutoID"].ToString();
                        lblcState.Text = dr["cVerifyState"].ToString();
                        txtcCode.Text = dr["cCode"].ToString();
                        utxtcCusName.Text = dr["cCusName"].ToString();
                        _cCusCode = dr["cCusCode"].ToString();
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

                        txtcMemo.Text = dr["cMemo"].ToString();
                        cbxcOrderType.Text = dr["cOrderType"].ToString();
                        if (string.IsNullOrEmpty(dr["OrderDate"].ToString()))
                        {
                            dtpOrderDate.Checked = false;
                            dtpOrderDate.Value = DateTime.Now;
                        }
                        else
                        {
                            dtpOrderDate.Checked = true;
                            dtpOrderDate.Value = (DateTime)dr["OrderDate"];
                        }
                        if (string.IsNullOrEmpty(dr["DeliveryDate"].ToString()))
                        {
                            dtpDeliveryDate.Checked = false;
                            dtpDeliveryDate.Value = DateTime.Now;
                        }
                        else
                        {
                            dtpDeliveryDate.Checked = true;
                            dtpDeliveryDate.Value = (DateTime)dr["DeliveryDate"];
                        }
                        
                        _outType = dr["cOutType"].ToString();
                        _cDepCode = dr["cDepCode"].ToString();
                        utecDepName.Text = dr["cDepName"].ToString();
                        _cMaker = dr["cMaker"].ToString();
                        //获取子表
                        proDeliveryDetailTableAdapter.Fill(dataBiDetail.ProDeliveryDetail, int.Parse(lblAutoID.Text));
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
            //if (string.IsNullOrEmpty(utxtcCusName.Text))
            //    return "客户";
            //if (string.IsNullOrEmpty(utecDepName.Text))
            //    return "送货单位";
            if (cbxcOrderType.SelectedIndex < 0)
                return "单据类型";
            return string.Empty;
        }

        /// <summary>
        /// 审核
        /// </summary>
        private void Approve()
        {
            var cmd = new SqlCommand("ApproveProDelivery") { CommandType = CommandType.StoredProcedure };
            var prs = new[]
                {
                    new SqlParameter("@AutoID",lblAutoID.Text),
                    new SqlParameter("@cHandler",BaseStructure.LoginName) 
                };
            cmd.Parameters.AddRange(prs);
            var wf = new WmsFunction(BaseStructure.WmsCon);
            if (wf.ExecSqlCmd(cmd))
            {
                SetPanelVlaue(lblAutoID.Text);
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (biSave.Enabled)
            {
                MessageBox.Show(@"请取消编辑后再翻页!", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var btn = (Button)sender;
            SetPanelVlaue(lblAutoID.Text, btn.Name);
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
                    bool bNew;
                    if (string.IsNullOrEmpty(lblAutoID.Text))
                    {
                        cmd.CommandText = "AddProDelivery";
                        var idParameter = new SqlParameter("@AutoID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        var cBoNoParameter = new SqlParameter("@cCode", SqlDbType.NVarChar, 20)
                        {
                            Direction = ParameterDirection.Output
                        };
                        bNew = true;
                        //获取id的返回值和采购订单号的返回值
                        cmd.Parameters.Add(idParameter);
                        cmd.Parameters.Add(cBoNoParameter);
                    }
                    else
                    {
                        bNew = false;
                        cmd.CommandText = "EditProDelivery";
                        cmd.Parameters.AddWithValue("@AutoID", lblAutoID.Text);
                    }

                    //赋参数
                    cmd.Parameters.AddWithValue("@dDate", dtpdDate.Value);
                    cmd.Parameters.AddWithValue("@cOrderCode", "");
                    cmd.Parameters.AddWithValue("@cCusCode", _cCusCode);
                    cmd.Parameters.AddWithValue("@cCusName", utxtcCusName.Text);
                    cmd.Parameters.AddWithValue("@cMemo", txtcMemo.Text);
                    cmd.Parameters.AddWithValue("@cMaker",BaseStructure.LoginName);
                    cmd.Parameters.AddWithValue("@cOrderType", cbxcOrderType.Text);
                    cmd.Parameters.AddWithValue("@OrderDate", dtpOrderDate.Value);
                    cmd.Parameters.AddWithValue("@DeliveryDate", dtpDeliveryDate.Value);
                    
                    cmd.Parameters.AddWithValue("@cDepCode", _cDepCode);
                    cmd.Parameters.AddWithValue("@cDepName", utecDepName.Text);
                    cmd.Parameters.AddWithValue("@cOutType", _outType);
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
                            if (string.IsNullOrEmpty(lblAutoID.Text))
                            {
                                lblAutoID.Text = cmd.Parameters["@AutoID"].Value.ToString();
                                txtcCode.Text = cmd.Parameters["@cCode"].Value.ToString();
                            }
                        }
                        else
                        {
                            return;
                        }

                        try
                        {
                            //提交子表
                           
                            //提交主表
                            tran.Commit();
                            lblcState.Text = @"未审";
                            if (bNew)
                            {
                                Approve();
                            }
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

        private void utxtcCusName_EditorButtonClick(object sender, EditorButtonEventArgs e)
        {
            using (var sc = new SelectCustomer())
            {
                if (sc.ShowDialog() == DialogResult.Yes)
                {
                    _cCusCode = sc.CCusCode;
                    utxtcCusName.Text = sc.CCusName;
                }
            }
        }

        private void utecDepName_EditorButtonClick(object sender, EditorButtonEventArgs e)
        {
            using (var sc = new SelectWarehouse())
            {
                if (sc.ShowDialog() == DialogResult.Yes)
                {
                    _cDepCode = sc.CWhCode;
                    utecDepName.Text = sc.CWhName;
                }
            }
        }

        private void biPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintDialog("print");
        }
        /// <summary>
        /// 打印操作
        /// </summary>
        /// <param name="p"></param>
        private void PrintDialog(string p)
        {
            var xtreport = new XtraReport();
            // _btApp = new BarTender.Application();
            //判断当前打印模版路径是否存在
            var temPath = Application.StartupPath + @"\Stencil\TrackDeliveryOrder.repx";

            if (!File.Exists(temPath))
            {
                MessageBox.Show(@"当前路径下的打印模版文件不存在!", @"异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                xtreport.Name = "TrackDeliveryOrder";
                xtreport.ShowDesigner();
                return;
            }
            xtreport.LoadLayout(temPath);
            DLL.DllWorkPrintLabel.SetParametersValue(xtreport, "cCode", txtcCode.Text);
            DLL.DllWorkPrintLabel.SetParametersValue(xtreport, "cOrderType", cbxcOrderType.Text);
            DLL.DllWorkPrintLabel.SetParametersValue(xtreport, "cCusName", utxtcCusName.Text);
            DLL.DllWorkPrintLabel.SetParametersValue(xtreport, "dDate", dtpdDate.Text);
            DLL.DllWorkPrintLabel.SetParametersValue(xtreport, "OrderDate", dtpOrderDate.Text);
            DLL.DllWorkPrintLabel.SetParametersValue(xtreport, "DeliveryDate", dtpDeliveryDate.Text);
            DLL.DllWorkPrintLabel.SetParametersValue(xtreport, "cDepName", utecDepName.Text);
            //模板赋值
            switch (p)
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


        private void biPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintDialog("preview");
        }

        private void biDesign_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintDialog("design");
        }
    }
}
