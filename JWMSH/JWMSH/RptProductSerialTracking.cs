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
    public partial class RptProductSerialTracking : Form
    {
        public RptProductSerialTracking()
        {
            InitializeComponent();
        }

        private void RptProductSerialTracking_Load(object sender, EventArgs e)
        {

            //初始化表格功能控件
            tsgfMain.FormId = Name.GetHashCode().ToString(CultureInfo.CurrentCulture);
            tsgfMain.FormName = Text;
            tsgfMain.Constr = BaseStructure.WmsCon;
            tsgfMain.GetGridStyle(tsgfMain.FormId);
            RefreshData();
        }

        private void RefreshData()
        {
            view_ProductLabelTableAdapter.Fill(dataReport.View_ProductLabel);
            shiftDetailTableAdapter.Fill(dataReport.ShiftDetail);
        }
    }
}
