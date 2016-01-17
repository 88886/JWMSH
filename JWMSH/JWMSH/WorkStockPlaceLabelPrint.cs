using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using JWMSH.DLL;

namespace JWMSH
{
    public partial class WorkStockPlaceLabelPrint : Form
    {




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

        public WorkStockPlaceLabelPrint()
        {
            InitializeComponent();
        }

        private void WorkStockPlaceLabelPrint_Load(object sender, EventArgs e)
        {
            // TODO:  这行代码将数据加载到表“dataKis.t_StockPlace”中。您可以根据需要移动或删除它。
            t_StockPlaceTableAdapter.Connection.ConnectionString = Properties.Settings.Default.KisCon;
            t_StockPlaceTableAdapter.Fill(this.dataKis.t_StockPlace);

            DllWorkPrintLabel.GetTemplet("仓位标签", ref _cCaption, ref _cPrinter, ref _cTempletFileName);

            biEditPrinter.Caption = _cPrinter;
            biEditTemplet.Caption = _cCaption;
        }





        public void PrintDialog(string operation)
        {
            if (string.IsNullOrEmpty(biEditTemplet.Caption))
            {
                MessageBox.Show(@"请先在 维护中心-模板管理，添加仓位标签项，再打开此界面!", @"异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            var dt = new DataKis.StockPlacePrintDataTable();

            foreach (var uRow in uGridCheck.Rows.GetFilteredInNonGroupByRows())
            {
                var nRow = dt.NewStockPlacePrintRow();
                nRow.FSPID = int.Parse(uRow.Cells["FSPID"].Value.ToString());
                nRow.FNumber = uRow.Cells["FNumber"].Value.ToString();
                nRow.FName = uRow.Cells["FName"].Value.ToString();
                nRow.FFullName = uRow.Cells["FFullName"].Value.ToString();
                dt.Rows.Add(nRow);
            }
            if (dt.Rows.Count < 1)
            {
                MessageBox.Show(@"请先筛选要打印的数据!", @"异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
     
                return;
            }
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

            xtreport.DataSource = dt;
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

        private void biExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsgfMain.SaveExcel2003();
        }

        private void biExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}
