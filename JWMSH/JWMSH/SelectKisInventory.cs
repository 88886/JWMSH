using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;

namespace JWMSH
{
    /// <summary>
    /// 金蝶物料选择界面
    /// </summary>
    public partial class SelectKisInventory : Form
    {
        /// <summary>
        /// 物料ID
        /// </summary>
        public string FitemId;

        /// <summary>
        /// 物料编码
        /// </summary>
        public string InvCode;
        /// <summary>
        /// 物料名称
        /// </summary>
        public string InvName;

        /// <summary>
        /// 全名
        /// </summary>
        public string FullName;
        /// <summary>
        /// 规格型号
        /// </summary>
        public string InvStd;

        /// <summary>
        /// 默认仓库
        /// </summary>
        public string DefaultLoc;

        /// <summary>
        /// 默认仓位
        /// </summary>
        public string DefalutSP;


        public string FUnitID;

        public string FUnitName;

        private bool _bFirst;

        public SelectKisInventory(DataTable dSoure,string cInvCode,bool bFirst)
        {
            InitializeComponent();
            uGirdKisInventory.DataSource = dSoure;
            uGirdKisInventory.DisplayLayout.Bands[0].ColumnFilters["FNumber"].FilterConditions.Add(
                FilterComparisionOperator.Contains, cInvCode);
            _bFirst = bFirst;
        }

        private void SelectKisInventory_Load(object sender, EventArgs e)
        {
            tsgfMain.FormId = Name.GetHashCode().ToString(CultureInfo.CurrentCulture);
            tsgfMain.FormName = Text;
            tsgfMain.Constr = BaseStructure.WmsCon;
            tsgfMain.GetGridStyle(tsgfMain.FormId);

            if (_bFirst)
            {
                var rFilter = uGirdKisInventory.Rows.GetFilteredInNonGroupByRows();
                if (rFilter.First() == null) return;
                FitemId = rFilter.First().Cells["FItemID"].Value.ToString();
                InvCode = rFilter.First().Cells["FNumber"].Value.ToString();
                InvName = rFilter.First().Cells["FName"].Value.ToString();
                FullName = rFilter.First().Cells["FFullName"].Value.ToString();
                DefaultLoc = rFilter.First().Cells["FDefaultLoc"].Value.ToString();
                DefalutSP = rFilter.First().Cells["FSPID"].Value.ToString();
                FUnitID = rFilter.First().Cells["FUnitID"].Value.ToString();
                FUnitName = rFilter.First().Cells["FUnitName"].Value.ToString();
                DialogResult = DialogResult.Yes;
            }
        }

        private void uGirdKisInventory_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            if (e.Cell.Row == null || e.Cell.Row.Index <= -1) return;
            FitemId = e.Cell.Row.Cells["FItemID"].Value.ToString();
            InvCode = e.Cell.Row.Cells["FNumber"].Value.ToString();
            InvName = e.Cell.Row.Cells["FName"].Value.ToString();
            FullName = e.Cell.Row.Cells["FFullName"].Value.ToString();
            DefaultLoc = e.Cell.Row.Cells["FDefaultLoc"].Value.ToString();
            DefalutSP = e.Cell.Row.Cells["FSPID"].Value.ToString();
            FUnitID = e.Cell.Row.Cells["FUnitID"].Value.ToString();
            FUnitName= e.Cell.Row.Cells["FUnitName"].Value.ToString();
            DialogResult = DialogResult.Yes;
        }
    }
}
