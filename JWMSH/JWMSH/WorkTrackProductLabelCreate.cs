using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JWMSH
{
    public partial class WorkTrackProductLabelCreate : Form
    {
        public string Memo;
        public int Quantity;
        public int SerialQty;

        public WorkTrackProductLabelCreate(string cInvCode,string cInvName,string cOrderNumber,string dDate)
        {
            InitializeComponent();
            lblcInvCode.Text = cInvCode;
            lblcInvName.Text = cInvName;
            lblcOrder.Text = cOrderNumber;
            lbldDate.Text = dDate;
        }

        private void WorkTrackProductLabelCreate_Load(object sender, EventArgs e)
        {
            

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(uteiQuantity.Value==null||string.IsNullOrEmpty(uteiQuantity.Value.ToString()))
            {
                return;
            }
            if (uneSerial.Value == null || string.IsNullOrEmpty(uneSerial.Value.ToString()))
            {
                return;
            }

            Memo = txtcMemo.Text;
            Quantity = int.Parse(uteiQuantity.Value.ToString());
            SerialQty = int.Parse(uneSerial.Value.ToString());
            DialogResult = DialogResult.Yes;
        }
    }
}
