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
    public partial class RptRmLabelPrint : Form
    {
        public RptRmLabelPrint()
        {
            InitializeComponent();
        }

        private void RptRmLabelPrint_Load(object sender, EventArgs e)
        {
            pageChange.Constr = BaseStructure.WmsCon;
            pageChange.GetRecord();
            //初始化表格功能控件
            tsgfMain.FormId = Name.GetHashCode().ToString(CultureInfo.CurrentCulture);
            tsgfMain.FormName = Text;
            tsgfMain.Constr = BaseStructure.WmsCon;
            tsgfMain.GetGridStyle(tsgfMain.FormId);
        }

        private void uGridRawMaterial_DoubleClickCell(object sender, Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs e)
        {
            if (e.Cell.Row.Cells["AutoID"].Value == null)
                return;
            var lid = e.Cell.Row.Cells["AutoID"].Value.ToString();
            if (string.IsNullOrEmpty(lid))
                return;
            var lblPrintForm = (WorkRmLabelPrint)FormIsExist("WorkRmLabelPrint");
            if (lblPrintForm == null)
            {
                var feturesOpen = new WorkRmLabelPrint(lid) { MdiParent = ParentForm };
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

        private void biSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var bfun = new WmsFunction(BaseStructure.WmsCon);
            var strTemp = bfun.GetWhereSqlStr("RmLabel");
            if (string.IsNullOrEmpty(strTemp))
                return;
            pageChange.WhereStr = strTemp;
            pageChange.GetRecord();
            MessageBox.Show(@"查询成功", @"成功");
        }
    }
}
