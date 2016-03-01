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
    public partial class SelectCustomer : Form
    {
        public string CCusCode;
        public string CCusName;
        public SelectCustomer()
        {
            InitializeComponent();
        }

        private void SelectCustomer_Load(object sender, EventArgs e)
        {
            
            //初始化表格功能控件
            tsgfMain.FormId = Name.GetHashCode().ToString(CultureInfo.CurrentCulture);
            tsgfMain.FormName = Text;
            tsgfMain.Constr = BaseStructure.WmsCon;
            tsgfMain.GetGridStyle(tsgfMain.FormId);
        }

        private void uGridCustomer_DoubleClickCell(object sender, Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs e)
        {
            if (e.Cell.Row.Index < 0)
                return;
            CCusCode = e.Cell.Row.Cells["cCusCode"].Value.ToString();
            CCusName = e.Cell.Row.Cells["cCusName"].Value.ToString();
           
            DialogResult = DialogResult.Yes;
        }
    }
}
