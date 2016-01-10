using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;
using JWMSH.DLL;
using DevExpress.XtraReports.UI;

namespace JWMSH
{
    public partial class WorkRmLabelPrint : Form
    {
        private DataTable _dtRawMaterial;

        private string _lid;

        private string _DefaultLoc;
        private string _DefaultSP;

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

        public WorkRmLabelPrint()
        {
            InitializeComponent();
        }
        public WorkRmLabelPrint(string lid)
        {
            InitializeComponent();
            _lid = lid;
        }

        private void WorkRmLabelPrint_Load(object sender, EventArgs e)
        {
            GetRawMaterial();

            pageChange.Constr = BaseStructure.WmsCon;
            pageChange.GetRecord();

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

            DllWorkPrintLabel.GetTemplet("原料标签", ref _cCaption, ref _cPrinter, ref _cTempletFileName);

            biEditPrinter.Caption = _cPrinter;
            biEditTemplet.Caption = _cCaption;

            //初始化表格功能控件
            tsgfMain.FormId = Name.GetHashCode().ToString(CultureInfo.CurrentCulture);
            tsgfMain.FormName = Text;
            tsgfMain.Constr = BaseStructure.WmsCon;
            tsgfMain.GetGridStyle(tsgfMain.FormId);
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
                    sqlcmd.CommandText = "select top 1 * from RmLabel order by AutoID desc";
                    break;
                case "btnFirst":
                    sqlcmd.CommandText = "select top 1 * from RmLabel order by AutoID";
                    break;
                case "btnPre":
                    if (string.IsNullOrEmpty(lId))
                    {
                        MessageBox.Show(@"已到首页");
                        return;
                    }
                    sqlcmd.CommandText = "select top 1 * from RmLabel where AutoID<@AutoID order by AutoID desc";
                    sqlcmd.Parameters.AddWithValue("@AutoID", lId);
                    break;
                case "btnNext":
                    if (string.IsNullOrEmpty(lId))
                    {
                        MessageBox.Show(@"已到末页");
                        return;
                    }
                    sqlcmd.CommandText = "select top 1 * from RmLabel where AutoID>@AutoID order by AutoID";
                    sqlcmd.Parameters.AddWithValue("@AutoID", lId);
                    break;
                case "":
                    sqlcmd.CommandText = "select top 1 * from RmLabel where AutoID=@AutoID";
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
                        lblTitleMain.lblAutoID.Text = dr["AutoID"].ToString();
                        lblTitleMain.lblcSerialNumber.Text = dr["cSerialNumber"].ToString();
                        _FitemId = dr["FitemId"].ToString();
                        txtcLotNo.Text = dr["cLotNo"].ToString();
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
                        txtcVendor.Text = dr["cVendor"].ToString();
                        txtcMemo.Text = dr["cMemo"].ToString();                    }
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
        /// 打印操作
        /// </summary>
        /// <param name="operation"></param>
        public void PrintDialog(string operation)
        {
            var xtreport = new XtraReport();
            // _btApp = new BarTender.Application();
            //判断当前打印模版路径是否存在
            var temPath = Application.StartupPath + @"\Label\" + _cTempletFileName;

            if (!File.Exists(temPath))
            {
                MessageBox.Show(@"当前路径下的打印模版文件不存在!", @"异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                xtreport.ShowDesigner();
                return;
            }
            xtreport.LoadLayout(temPath);
            xtreport.PrinterName = _cPrinter;
            xtreport.PrintingSystem.StartPrint += PrintingSystem_StartPrint;
            xtreport.RequestParameters = false;
            xtreport.ShowPrintStatusDialog = false;
            xtreport.ShowPrintMarginsWarning = false;
            
            //模板赋值
            DllWorkPrintLabel.SetParametersValue(xtreport, "cSerialNumber", lblTitleMain.lblcSerialNumber.Text);
            DllWorkPrintLabel.SetParametersValue(xtreport, "cBarCode", "R*" + _FitemId + "*L*" + txtcLotNo.Text + "*S*" + lblTitleMain.lblcSerialNumber.Text);
            DllWorkPrintLabel.SetParametersValue(xtreport, "cInvCode", txtcInvCode.Text);
            DllWorkPrintLabel.SetParametersValue(xtreport, "cInvName", utecInvName.Text);
            DllWorkPrintLabel.SetParametersValue(xtreport, "cInvStd", txtcInvStd.Text);
            DllWorkPrintLabel.SetParametersValue(xtreport, "cFullName", txtcFullName.Text);
            DllWorkPrintLabel.SetParametersValue(xtreport, "cVendor", txtcVendor.Text);
            DllWorkPrintLabel.SetParametersValue(xtreport, "cLotNo", txtcLotNo.Text);
            DllWorkPrintLabel.SetParametersValue(xtreport, "iQuantity", uneiQuantity.Value);
            DllWorkPrintLabel.SetParametersValue(xtreport, "cMemo", txtcMemo.Text);

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
        private void PrintingSystem_StartPrint(object sender, DevExpress.XtraPrinting.PrintDocumentEventArgs e)
        {
            short iCopies;
            if (short.TryParse(beiCopies.EditValue.ToString(), out iCopies))
                e.PrintDocument.PrinterSettings.Copies = iCopies;
            else
            {
                e.PrintDocument.PrinterSettings.Copies = 1;
            }
        }

        private void GetRawMaterial()
        {
            var cmd = new SqlCommand("select FItemID,FNumber,FName,FModel,FFullName,FDefaultLoc,FSPID from t_icItem order by FitemID ");
            var wf=new WmsFunction(BaseStructure.KisConstring);
            _dtRawMaterial = wf.GetSqlTable(cmd);
            txtcInvCode.DataSource = _dtRawMaterial;
            var cmdVendor = new SqlCommand("select FNumber,FName,FAddress from t_Supplier order by FNumber");
            txtcVendor.DataSource = wf.GetSqlTable(cmdVendor);
        }

        private void biExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void biExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsgfMain.SaveExcel2003();
        }

        private void biAddNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DllWorkPrintLabel.ResetNull(ugbxMain);
            lblTitleMain.lblAutoID.Text = "";
            lblTitleMain.lblcSerialNumber.Text = "";
            SetControlEnable();
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
        /// 判断什么未填写,返回对应的标签
        /// </summary>
        /// <returns></returns>
        private string CheckNull()
        {
            if (string.IsNullOrEmpty(txtcInvCode.Text))
                return "编码";
            if (string.IsNullOrEmpty(txtcLotNo.Text))
                return "批号";
            if (!dtpdDate.Checked)
                return "日期";
            var cmdInvCode = new SqlCommand("select * from t_icItem where FNumber=@FNumber");
            cmdInvCode.Parameters.AddWithValue("@FNumber", txtcInvCode.Value);
            var wfun = new WmsFunction(BaseStructure.KisConstring);
            if (!wfun.BoolExistTable(cmdInvCode))
            {
                return @"编码不正确,编码";
            }
            return uneiQuantity.Value == null || string.IsNullOrEmpty(uneiQuantity.Value.ToString()) ? "数量" : string.Empty;
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


            if (!WmsFunction.IsNumAndEnCh(txtcLotNo.Text))
            {
                MessageBox.Show(@"请输入正确的批次格式，只允许有数字与字母");
                return;
            }

            using (var con = new SqlConnection(BaseStructure.WmsCon))
            {
                using (var cmd = new SqlCommand { CommandType = CommandType.StoredProcedure, Connection = con })
                {
                    if (string.IsNullOrEmpty(lblTitleMain.lblAutoID.Text))
                    {
                        cmd.CommandText = "proc_Bar_RawMaterialInsert";
                        var idParameter = new SqlParameter("@AutoID", SqlDbType.Int)
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
                        cmd.CommandText = "proc_Bar_RawMaterialUpdate";
                        cmd.Parameters.AddWithValue("@AutoID", lblTitleMain.lblAutoID.Text);
                    }

                    //赋参数
                    cmd.Parameters.AddWithValue("@FitemID", _FitemId);
                    cmd.Parameters.AddWithValue("@cLotNo", txtcLotNo.Text);
                    cmd.Parameters.AddWithValue("@iQuantity", uneiQuantity.Value);
                    cmd.Parameters.AddWithValue("@dDate", dtpdDate.Value);
                    cmd.Parameters.AddWithValue("@cInvCode", txtcInvCode.Text);
                    cmd.Parameters.AddWithValue("@cInvName", utecInvName.Text);
                    cmd.Parameters.AddWithValue("@cInvStd", txtcInvStd.Text);
                    cmd.Parameters.AddWithValue("@cFullName", txtcFullName.Text);
                    cmd.Parameters.AddWithValue("@cVendor", txtcVendor.Text);
                    cmd.Parameters.AddWithValue("@cMemo", txtcMemo.Text);
                    cmd.Parameters.AddWithValue("@cDefaultLoc", _DefaultLoc);
                    cmd.Parameters.AddWithValue("@cDefaultSP", _DefaultSP);con.Open();

                    try
                    {
                        var ieffect = cmd.ExecuteNonQuery();
                        //判断是否是真的完成了主表的写入
                        if (ieffect > 0)
                        {
                            if (string.IsNullOrEmpty(lblTitleMain.lblAutoID.Text))
                            {
                                lblTitleMain.lblAutoID.Text = cmd.Parameters["@AutoID"].Value.ToString();
                                lblTitleMain.lblcSerialNumber.Text = cmd.Parameters["@cSerialNumber"].Value.ToString();
                            }
                        }

                        MessageBox.Show(@"保存成功", @"成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SetControlDisable();
                        pageChange.GetRecord();
                        var bPrint = MessageBox.Show(@"是否立即打印", @"是否", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                            DialogResult.Yes;
                        if (bPrint)
                        {
                            PrintDialog("print");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }

        private void biDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void utecInvName_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            using (var brm = new SelectKisInventory(_dtRawMaterial,txtcInvCode.Text))
            {
                if (brm.ShowDialog() == DialogResult.Yes)
                {
                    _FitemId = brm.FitemId;
                    txtcInvCode.Text = brm.InvCode;
                    utecInvName.Text = brm.InvName;
                    txtcInvStd.Text = brm.InvStd;
                    txtcFullName.Text = brm.FullName;
                    _FitemId = brm.FitemId;
                    _DefaultLoc = brm.DefaultLoc;
                    _DefaultSP = brm.DefalutSP;

                }
            }
        }

        private void txtcInvCode_RowSelected(object sender, Infragistics.Win.UltraWinGrid.RowSelectedEventArgs e)
        {
            var uRow = e.Row;

            SetDefaultValue(uRow);
        }

        private void SetDefaultValue(UltraGridRow uRow)
        {
            if (uRow == null || uRow.Index <= -1) return;
            _FitemId = uRow.Cells["FItemID"].Value.ToString();
            txtcInvCode.Text = uRow.Cells["FNumber"].Value.ToString();
            utecInvName.Text = uRow.Cells["FName"].Value.ToString();
            txtcInvStd.Text = uRow.Cells["FModel"].Value.ToString();
            txtcFullName.Text = uRow.Cells["FFullName"].Value.ToString();
            _FitemId = uRow.Cells["FItemID"].Value.ToString();
            _DefaultLoc = uRow.Cells["FDefaultLoc"].Value.ToString();
            _DefaultSP = uRow.Cells["FSPID"].Value.ToString();
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

        private void biEditTemplet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var st = new Base_Templet(true, "原料标签"))
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

        private void uGridRawMaterial_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            if (e.Cell.Row.Index < 0)
                return;
            if (biSave.Enabled)
            {
                MessageBox.Show(@"在编辑状态下，不允许选择！");
                return;
            }
            SetPanelVlaue(e.Cell.Row.Cells["AutoID"].Value.ToString());
        }
    }
}
