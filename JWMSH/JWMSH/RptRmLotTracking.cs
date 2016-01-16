using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace JWMSH
{
    public partial class RptRmLotTracking : Form
    {
        public RptRmLotTracking()
        {
            InitializeComponent();
        }

        private void biSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Query_RmTrackingUseInProduct();
            
        }

        /// <summary>
        /// 获取原料批号所有被使用的产成品序列号
        /// </summary>
        private void Query_RmTrackingUseInProduct()
        {
            if (string.IsNullOrEmpty(biRmcInvCode.EditValue.ToString()) ||
                string.IsNullOrEmpty(biRmLotNo.EditValue.ToString()))
                return;

            uGridRawMaterial.Text = string.Format("原料编码 {0}   原料批号：{1}", biRmcInvCode.EditValue, biRmLotNo.EditValue);
            var cmd = new SqlCommand("Query_RmTrackingUseInProduct") {CommandType = CommandType.StoredProcedure};
            cmd.Parameters.AddWithValue("@cInvCode", biRmcInvCode.EditValue);
            cmd.Parameters.AddWithValue("@FBatchNo", biRmLotNo.EditValue);
            var wf = new WmsFunction(BaseStructure.WmsCon);

            uGridRawMaterial.DataSource = wf.GetSqlTable(cmd);
            MessageBox.Show(@"成功查询", @"成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RptRmLotTracking_Load(object sender, EventArgs e)
        {
            //初始化表格功能控件
            tsgfMain.FormId = Name.GetHashCode().ToString(CultureInfo.CurrentCulture);
            tsgfMain.FormName = Text;
            tsgfMain.Constr = BaseStructure.WmsCon;
            tsgfMain.GetGridStyle(tsgfMain.FormId);
        }
    }
}
