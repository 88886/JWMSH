using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;

namespace JWMSH
{
    public partial class SelectKisCurrectStock : Form
    {
        private WorkTrackShiftOrder _wShiftOrder;

        private DLL.DataInventory.BomDetailDataTable BomDetail;

        private DLL.DataInventory.ShiftDetailDataTable ShiftDetail;
        public SelectKisCurrectStock(WorkTrackShiftOrder wShiftOrder)
        {
            InitializeComponent();
            _wShiftOrder = wShiftOrder;
            BomDetail = _wShiftOrder.GetBomDetail();
            ShiftDetail = _wShiftOrder.GetShiftDetail();

        }

        private void SelectKisCurrectStock_Load(object sender, EventArgs e)
        {
            uGridBomDetail.DataSource = BomDetail;

            uGridShiftDetail.DataSource = ShiftDetail;

            uGridBomDetail.Text = _wShiftOrder.GetProductQuantity() + @" 个产品的Bom结构";
            foreach (DataRow vRow in BomDetail.Rows)
            {
                decimal iQuantity;
                if (decimal.TryParse(vRow["iQuantity"].ToString(), out iQuantity))
                {
                    vRow["iQuantity"] = iQuantity*_wShiftOrder.GetProductQuantity();}
            }
            //查询当前BOM中的物料库存情况
            var cFitemList = string.Empty;
            for (var i = 0; i < BomDetail.Rows.Count; i++)
            {
                cFitemList = cFitemList + BomDetail.Rows[i]["cFitemID"] + ",";
            }
            cFitemList = cFitemList.Remove(cFitemList.Length - 1);
            GetCurrentStock(cFitemList);

            //初始化表格功能控件
            tsgfMain.FormId = Name.GetHashCode().ToString(CultureInfo.CurrentCulture);
            tsgfMain.FormName = Text;
            tsgfMain.Constr = BaseStructure.WmsCon;
            tsgfMain.GetGridStyle(tsgfMain.FormId);
        }


        private void GetCurrentStock(string cFitemList)
        {
            var cmd = new SqlCommand(@" select a.FItemID,b.FNumber,b.FName,a.FQty Quantity,b.FModel,b.FFullName,a.FBatchNo,a.FStockID,
c.FNumber FStockNumber,c.FName FStockName,a.FStockPlaceID,d.FNumber FStockPlaceNumber,d.FName FStockPlaceName
from ICInventory a inner join t_ICItem b on a.FItemID=b.FItemID 
inner join t_Stock c on a.FStockID=c.FItemID inner join t_StockPlace d on a.FStockPlaceID=d.FSPID
where a.FQty>0 and a.FItemID in(" + cFitemList + ")   order by a.FItemID,a.FBatchNo,a.FStockID,a.FStockPlaceID ");
            var wf = new WmsFunction(BaseStructure.KisConstring);
            uGridCurrentStock.DataSource = wf.GetSqlTable(cmd);
        }

        private void uGridBomDetail_ClickCell(object sender, Infragistics.Win.UltraWinGrid.ClickCellEventArgs e)
        {
            if (e.Cell.Row.Index < 0)
                return;
            uGridCurrentStock.DisplayLayout.Bands[0].ColumnFilters["FNumber"].FilterConditions.Clear();
            uGridCurrentStock.DisplayLayout.Bands[0].ColumnFilters["FNumber"].FilterConditions.Add(
                FilterComparisionOperator.Contains, e.Cell.Row.Cells["cInvCode"].Value.ToString());
        }

        private void uGridCurrentStock_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            if (e.Cell.Row.Index < 0)
                return;int StockID,ItemID,StockPlaceID;
            var FItemID = e.Cell.Row.Cells["FItemID"].Value.ToString();
            var FBatchNo=e.Cell.Row.Cells["FBatchNo"].Value.ToString();
            
            var FStockID=e.Cell.Row.Cells["FStockID"].Value.ToString();
            var FStockPlaceID=e.Cell.Row.Cells["FStockPlaceID"].Value.ToString();


            if(!int.TryParse(FItemID,out ItemID)||!int.TryParse(FStockID,out StockID)||!int.TryParse(FStockPlaceID,out StockPlaceID))
            {
                return;
            }


            //foreach (DataRow dRow in ShiftDetail.Rows)
            //{
            //    if (dRow.RowState == DataRowState.Deleted)
            //        continue;
            //    if (
            //            dRow["cFItemID"].ToString().Equals(FItemID) &&
            //            dRow["FBatchNo"].ToString().Equals(FBatchNo) &&
            //            dRow["FStockID"].ToString().Equals(FStockID) &&
            //            dRow["FStockPlaceID"].ToString().Equals(FStockPlaceID)
            //        )
            //    {return;
            //    }
            //}

            if (ShiftDetail.Rows.Cast<DataRow>().Where(dRow => dRow.RowState != DataRowState.Deleted).Any(dRow => dRow["cFItemID"].ToString().Equals(FItemID) &&
                                                                                                                  dRow["FBatchNo"].ToString().Equals(FBatchNo) &&
                                                                                                                  dRow["FStockID"].ToString().Equals(FStockID) &&
                                                                                                                  dRow["FStockPlaceID"].ToString().Equals(FStockPlaceID)))
            {
                return;
            }

            


            var cInvCode = e.Cell.Row.Cells["FNumber"].Value.ToString();
            var cInvName = e.Cell.Row.Cells["FName"].Value.ToString();
            var cInvStd = e.Cell.Row.Cells["FModel"].Value.ToString();
            var cFullName = e.Cell.Row.Cells["FFullName"].Value.ToString();
            var FStockNumber = e.Cell.Row.Cells["FStockNumber"].Value.ToString();
            var FStockName = e.Cell.Row.Cells["FStockName"].Value.ToString();
            var FStockPlaceNumber = e.Cell.Row.Cells["FStockPlaceNumber"].Value.ToString();
            var FStockPlaceName = e.Cell.Row.Cells["FStockPlaceName"].Value.ToString();

            var nRow = ShiftDetail.NewShiftDetailRow();
            nRow.FBatchNo = FBatchNo;
            nRow.FStockID = StockID;
            nRow.FStockName = FStockName;
            nRow.FStockNumber = FStockNumber;
            nRow.FStockPlaceID = StockPlaceID;
            nRow.FStockPlaceName = FStockPlaceName;
            nRow.FStockPlaceNumber = FStockPlaceNumber;
            nRow.cFitemID = ItemID;
            nRow.cFullName = cFullName;
            nRow.cInvCode = cInvCode;
            nRow.cInvName = cInvName;
            nRow.cInvStd = cInvStd;
            ShiftDetail.Rows.Add(nRow);

        }

        private void tsbtnFinished_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }
    }
}
