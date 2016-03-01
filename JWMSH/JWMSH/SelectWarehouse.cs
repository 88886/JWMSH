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
    public partial class SelectWarehouse : Form
    {

        public string CWhCode;
        public string CWhName;
        public SelectWarehouse()
        {
            InitializeComponent();
        }

        private void SelectWarehouse_Load(object sender, EventArgs e)
        {
            t_StockTableAdapter.Connection.ConnectionString = BaseStructure.KisConstring;
            this.t_StockTableAdapter.Fill(this.dataKis.t_Stock);
           

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
            CWhCode = e.Cell.Row.Cells["FNumber"].Value.ToString();
            CWhName = e.Cell.Row.Cells["FName"].Value.ToString();

            DialogResult = DialogResult.Yes;
        }
    }
}
