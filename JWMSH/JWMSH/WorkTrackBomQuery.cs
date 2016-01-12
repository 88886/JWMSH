using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JWMSH
{
    public partial class WorkTrackBomQuery : Form
    {
        public WorkTrackBomQuery()
        {
            InitializeComponent();
        }

        private void uGridBom_ClickCell(object sender, Infragistics.Win.UltraWinGrid.ClickCellEventArgs e)
        {
            if (e.Cell.Row.Index < 0)
                return;
            var cAutoID = e.Cell.Row.Cells["AutoID"].Value.ToString();
            int iAutoID;
            if (int.TryParse(cAutoID, out iAutoID))
            {
                dataInventory.BomDetail.Rows.Clear();
                bomDetailTableAdapter.Fill(dataInventory.BomDetail, iAutoID);
            }

        }

        private void biExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void biExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsgfMain.SaveExcel2003();
        }

        private void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pageChange.GetRecord();
        }

        private void WorkTrackBomQuery_Load(object sender, EventArgs e)
        {
            pageChange.Constr = BaseStructure.WmsCon;
            pageChange.GetRecord();
            //初始化表格功能控件
            tsgfMain.FormId = Name.GetHashCode().ToString(CultureInfo.CurrentCulture);
            tsgfMain.FormName = Text;
            tsgfMain.Constr = BaseStructure.WmsCon;
            tsgfMain.GetGridStyle(tsgfMain.FormId);
        }

        private void uGridBom_DoubleClickCell(object sender, Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs e)
        {
            if (e.Cell.Row.Cells["AutoID"].Value == null)
                return;
            var lid = e.Cell.Row.Cells["AutoID"].Value.ToString();
            if (string.IsNullOrEmpty(lid))
                return;
            var lblPrintForm = (WorkTrackBom)FormIsExist("WorkTrackBom");
            if (lblPrintForm == null)
            {
                var feturesOpen = new WorkTrackBom(lid) { MdiParent = ParentForm };
                feturesOpen.Show();
                return;
            }
            lblPrintForm.Activate();
            lblPrintForm.SetPanelVlaue(lid);
        }


        public Form FormIsExist(string fname)
        {
            return ParentForm == null ? null : ParentForm.MdiChildren.FirstOrDefault(cform => cform.Name.Equals(fname));
        }
    }
}
