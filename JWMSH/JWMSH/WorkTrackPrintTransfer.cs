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

namespace JWMSH
{
    public partial class WorkTrackPrintTransfer : Form
    {

        /// <summary>
        /// 当前单号
        /// </summary>
        private string _cOrderNumber;

        /// <summary>
        /// 当前行号
        /// </summary>
        private int _iRowNo;

        /// <summary>
        /// 当前行FinterID
        /// </summary>
        private int _FinterID;
        public WorkTrackPrintTransfer()
        {
            InitializeComponent();
        }

        private void WorkRmPurchaseOrder_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            var cmd =
                new SqlCommand(
                    @"select top 100 FInterID,ICStockBIll.FBillNo,FDCStockID,FSCStockID,FDate,ICStockBIll.FStatus,FBillerID,FCheckerID,FCheckDate,
t_User.FName CreateName,temp.FName CheckName,t_Stock.FName StoreWareHouse,tStock.FName DeliveryWareHouse
from ICStockBIll left join t_Stock on ICStockBIll.FDCStockID=t_Stock.FItemID
left join t_Stock tStock on ICStockBIll.FSCStockID=tStock.FItemID
left join t_User on ICStockBIll.FBillerID=t_User.FUserID 
left join t_User temp on ICStockBIll.FCheckerID=temp.FUserID
where ICStockBIll.FTranType=41
order by FInterID desc");
            var wmf = new WmsFunction(BaseStructure.KisConstring);
            uGridCheck.DataSource = wmf.GetSqlTable(cmd);
        }

        private void RefreshData(string cOrderNumber)
        {
            var cmd =
                new SqlCommand(
                    @"select top 100 FInterID,ICStockBIll.FBillNo,FDCStockID,FSCStockID,FDate,ICStockBIll.FStatus,FBillerID,FCheckerID,FCheckDate,
t_User.FName CreateName,temp.FName CheckName,t_Stock.FName StoreWareHouse,tStock.FName DeliveryWareHouse
from ICStockBIll left join t_Stock on ICStockBIll.FDCStockID=t_Stock.FItemID
left join t_Stock tStock on ICStockBIll.FSCStockID=tStock.FItemID
left join t_User on ICStockBIll.FBillerID=t_User.FUserID 
left join t_User temp on ICStockBIll.FCheckerID=temp.FUserID where ICStockBIll.FBillNo like '%" + cOrderNumber + "%'  and ICStockBIll.FTranType=41 order by FInterID desc");
            var wmf = new WmsFunction(BaseStructure.KisConstring);
            uGridCheck.DataSource = wmf.GetSqlTable(cmd);
        }

        private void uGridCheck_DoubleClickCell(object sender, Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs e)
        {
            if (e.Cell.Row == null || e.Cell.Row.Index < 0)
                return;
            _cOrderNumber = e.Cell.Row.Cells["FBillNo"].Value.ToString();
            _iRowNo = e.Cell.Row.Index;
            if (!int.TryParse(e.Cell.Row.Cells["FinterID"].Value.ToString(), out _FinterID))
                return;
            var cmd =
                new SqlCommand(
                    @"select ICStockBIllEntry.FItemID,ICStockBIllEntry.FEntryID,FShortNumber,FNumber,FModel,FName,FQty 
from ICStockBIllEntry inner join t_ICItem on ICStockBIllEntry.FItemID=t_ICItem.FItemID
where FInterID=@FinterID");
            cmd.Parameters.AddWithValue("@FinterID", _FinterID);
            var wmf = new WmsFunction(BaseStructure.KisConstring);
            uGridChecks.DataSource = wmf.GetSqlTable(cmd);
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
            var temPath = Application.StartupPath + @"\Stencil\DeliveryOrder.repx";

            if (!File.Exists(temPath))
            {
                MessageBox.Show(@"当前路径下的打印模版文件不存在!", @"异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                xtreport.Name = "DeliveryOrder";
                xtreport.ShowDesigner();
                return;
            }
            xtreport.LoadLayout(temPath);

            xtreport.RequestParameters = false;
            xtreport.ShowPrintStatusDialog = false;
            xtreport.ShowPrintMarginsWarning = false;
            xtreport.DataSource = uGridChecks.DataSource;
            //模板赋值
            string cKey, cValue;
            for (var i = 0; i < uGridCheck.DisplayLayout.Bands[0].Columns.Count; i++)
            {
                cKey = uGridCheck.DisplayLayout.Bands[0].Columns[i].Key;
                cValue = uGridCheck.Rows[_iRowNo].Cells[i].Value.ToString();
                DLL.DllWorkPrintLabel.SetParametersValue(xtreport, cKey, cValue);
            }


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
        private void biPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintDialog("preview");
        }

        private void biDesign_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintDialog("design");
        }

        private void biPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintDialog("print");
        }

        private void biExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RefreshData();
        }

        private void biSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (beiOrder.EditValue == null || string.IsNullOrEmpty(beiOrder.EditValue.ToString()))
                return;RefreshData(beiOrder.EditValue.ToString());
        }
    }
}
