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
using DevExpress.XtraReports.UI;
using JWMSH.DLL;

namespace JWMSH
{
    public partial class WorkTrackProductLabelPrint : Form
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


        public WorkTrackProductLabelPrint()
        {
            InitializeComponent();
        }


        public WorkTrackProductLabelPrint(string lid)
        {
            InitializeComponent();
            _lid = lid;
        }

        private void biExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void WorkTrackProductLabelPrint_Load(object sender, EventArgs e)
        {
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

            DllWorkPrintLabel.GetTemplet("产成品标签", ref _cCaption, ref _cPrinter, ref _cTempletFileName);

            biEditPrinter.Caption = _cPrinter;
            biEditTemplet.Caption = _cCaption;

            //初始化表格功能控件
            tsgfMain.FormId = Name.GetHashCode().ToString(CultureInfo.CurrentCulture);
            tsgfMain.FormName = Text;
            tsgfMain.Constr = BaseStructure.WmsCon;
            tsgfMain.GetGridStyle(tsgfMain.FormId);

            shiftDetailTableAdapter.Connection.ConnectionString = Properties.Settings.Default.BCon;
            bomDetailTableAdapter.Connection.ConnectionString = Properties.Settings.Default.BCon;
        }


        private void btnFirst_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            SetPanelVlaue(lblTitleMain.lblAutoID.Text, btn.Name);
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
                        txtFBatchNo.Text = dr["FBatchNo"].ToString();
                        txtcInvCode.Text = dr["cInvCode"].ToString();
                        utecInvName.Text = dr["cInvName"].ToString();
                        txtcInvStd.Text = dr["cInvStd"].ToString();
                        txtcFullName.Text = dr["cFullName"].ToString();
                        txtcDept.Text = dr["cDeptName"].ToString();
                        txtcMemo.Text = dr["cMemo"].ToString();
                        shiftDetailTableAdapter.Fill(dataInventory.ShiftDetail, lblTitleMain.lblcSerialNumber.Text);
                        productLabelTableAdapter.Fill(dataInventory.ProductLabel, lblTitleMain.lblcSerialNumber.Text);
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
            if (!dtpdDate.Checked)
                return "日期"; var cmdInvCode = new SqlCommand("select * from t_icItem where FNumber=@FNumber");
            cmdInvCode.Parameters.AddWithValue("@FNumber", txtcInvCode.Value);
            var wfun = new WmsFunction(BaseStructure.KisConstring);
            if (!wfun.BoolExistTable(cmdInvCode))
            {
                return @"编码不正确,编码";
            }
            if (dataInventory.ShiftDetail.Rows.Count < 1)
                return "子件";
            return uneiQuantity.Value == null || string.IsNullOrEmpty(uneiQuantity.Value.ToString()) ? "数量" : string.Empty;
        }


        private void biAddNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //判断什么为填写
            var nullstr = CheckNull();
            if (!string.IsNullOrEmpty(nullstr))
            {
                MessageBox.Show(nullstr + @" 数据异常，请先完成班次制令单后，
再操作此功能", @"错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (
                var wpc = new WorkTrackProductLabelCreate(txtcInvCode.Text, utecInvName.Text, txtcOrderNumber.Text,
                    dtpdDate.Value.ToShortDateString()))
            {
                if (wpc.ShowDialog() != DialogResult.Yes)
                    return;
                var wf=new WmsFunction(BaseStructure.WmsCon);
                var cmd = new SqlCommand("proc_GenerateProductLabel"){CommandType = CommandType.StoredProcedure};
                cmd.Parameters.AddWithValue("@cSerialNumber", lblTitleMain.lblcSerialNumber.Text);
                cmd.Parameters.AddWithValue("@iQuantity", wpc.Quantity);
                cmd.Parameters.AddWithValue("@SerialQty", wpc.SerialQty);
                cmd.Parameters.AddWithValue("@cMemo", wpc.Memo);
                wf.ExecSqlCmd(cmd);
                productLabelTableAdapter.Fill(dataInventory.ProductLabel, lblTitleMain.lblcSerialNumber.Text);}
        }

        private void biEditTemplet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var st = new Base_Templet(true, "产成品标签"))
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

        public void PrintDialog(string operation)
        {
            var xtreport = new XtraReport();
            // _btApp = new BarTender.Application();
            //判断当前打印模版路径是否存在
            var temPath = _cTempletFileName;     //_cTempletFileName;      //Application.StartupPath + @"\Label\" +   _cTempletFileName;

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
            DllWorkPrintLabel.SetParametersValue(xtreport, "cBarCode", "P*" + _FitemId + "*L*" + txtFBatchNo.Text + "*S*" );
            DllWorkPrintLabel.SetParametersValue(xtreport, "cInvCode", txtcInvCode.Text);
            DllWorkPrintLabel.SetParametersValue(xtreport, "cInvName", utecInvName.Text);
            DllWorkPrintLabel.SetParametersValue(xtreport, "cInvStd", txtcInvStd.Text);
            DllWorkPrintLabel.SetParametersValue(xtreport, "cFullName", txtcFullName.Text);
            DllWorkPrintLabel.SetParametersValue(xtreport, "iQuantity", uneiQuantity.Value);
            DllWorkPrintLabel.SetParametersValue(xtreport, "cMemo", txtcMemo.Text);
            DllWorkPrintLabel.SetParametersValue(xtreport, "dDate", dtpdDate.Value.ToShortDateString());
            DllWorkPrintLabel.SetParametersValue(xtreport, "cOrderNumber", txtcOrderNumber.Text);
            xtreport.DataSource = GetPrintData();
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

        private DataTable GetPrintData()
        {
            var cmd = new SqlCommand("select * from View_ProductLabel where cSerialNumber=@cSerialNumber");
            cmd.Parameters.AddWithValue("@cSerialNumber", lblTitleMain.lblcSerialNumber.Text);
            var wf=new WmsFunction(BaseStructure.WmsCon);
            return wf.GetSqlTable(cmd);}

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

    }
}
