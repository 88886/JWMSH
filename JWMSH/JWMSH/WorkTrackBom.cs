using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;

namespace JWMSH
{
    public partial class WorkTrackBom : Form
    {
        private string _lid;

        private DataTable _dtRawMaterial;

        private string _FitemId;
        public WorkTrackBom()
        {
            InitializeComponent();
            //增加一个按键动作映射，当敲击回车时，提交修改
            uGridRawMaterial.KeyActionMappings.Add(new GridKeyActionMapping(
            Keys.Enter,                       // 按下回车键时
            UltraGridAction.CommitRow,         // 提交修改
            UltraGridState.IsCheckbox,        // 单元格不能为checkbox
            UltraGridState.InEdit,              // 选中单元格时
            0,                                // 不禁止特殊键
            0                                 // 不需要特殊键
        ));
        }

        public WorkTrackBom(string lid)
        {
            InitializeComponent();
            //增加一个按键动作映射，当敲击回车时，提交修改
                uGridRawMaterial.KeyActionMappings.Add(new GridKeyActionMapping(
                Keys.Enter,                       // 按下回车键时
                UltraGridAction.CommitRow,         // 提交修改
                UltraGridState.IsCheckbox,        // 单元格不能为checkbox
                UltraGridState.InEdit,              // 选中单元格时
                0,                                // 不禁止特殊键
                0                                 // 不需要特殊键
            ));
            _lid = lid;
        }
        

        private void WorkTrackBom_Load(object sender, EventArgs e)
        {
            GetRawMaterial();

           

            if (string.IsNullOrEmpty(_lid))
            {
                SetPanelVlaue("", "btnLast");
            }
            else
            {
                SetPanelVlaue(_lid);
            }

            lblTitleMain.btnFirst.Click += btnFirst_Click;
            lblTitleMain.btnNext.Click += btnFirst_Click;
            lblTitleMain.btnPre.Click += btnFirst_Click;
            lblTitleMain.btnLast.Click += btnFirst_Click;

          
        }



        private void GetRawMaterial()
        {
            var cmd = new SqlCommand("select   a.FItemID,a.FNumber,a.FName,FModel,FFullName,FDefaultLoc,FSPID,a.FUnitID,b.FName FUnitName from t_icitem a inner join t_MeasureUnit b on a.FUnitID=b.FMeasureUnitID where isnull(a.FDeleted,0)<>1 order by a.FitemID");
            var wf = new WmsFunction(BaseStructure.KisConstring);
            _dtRawMaterial = wf.GetSqlTable(cmd);
            txtcInvCode.DataSource = _dtRawMaterial;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (biSave.Enabled)
            {
                MessageBox.Show(@"请取消编辑后再翻页!", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var btn = (Button)sender;
            SetPanelVlaue(lblTitleMain.lblAutoID.Text, btn.Name);
        }


        private void biAddNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ResetNull();
            SetControlEnable();
            
        }

        /// <summary>
        /// 重置内容
        /// </summary>
        private void ResetNull()
        {
            foreach (Control ctrl in ugbxMain.Controls)
            {
                if (ctrl is TextBox || ctrl is UltraComboEditor || ctrl is UltraTextEditor)
                {
                    ctrl.Text = "";
                }
                else if (ctrl is UltraNumericEditor)
                {
                    var uctr = ctrl as UltraNumericEditor;
                    uctr.Value = null;

                }

            }
            txtcInvCode.Text = "";
            lblTitleMain.lblAutoID.Text = "";
            //清空制单人等信息
            dataInventory.BomDetail.Rows.Clear();
        }

        private void biEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(lblTitleMain.lblAutoID.Text))
            {
                MessageBox.Show(@"未指定单据，请检查后再试!", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SetControlEnable();//启用所有输入框和保存按钮
        }

        private void biDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(lblTitleMain.lblAutoID.Text))
            {
                MessageBox.Show(@"未指定单据，请检查后再试!", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show(@"确实要删除吗!", @"提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                DialogResult.Yes)
                return;
            using (var con = new SqlConnection(BaseStructure.WmsCon))
            {
                con.Open();
                using (var cmd = new SqlCommand("DeleteProDelivery") { CommandType = CommandType.StoredProcedure, Connection = con })
                {
                    cmd.Parameters.AddWithValue("@AutoID", lblTitleMain.lblAutoID.Text);
                    try
                    {
                        if (cmd.ExecuteNonQuery() > 1)
                        {
                            MessageBox.Show(@"删除成功!");
                            SetPanelVlaue("", "btnLast");
                        }
                        else
                        {
                            MessageBox.Show(@"删除失败，请查找原因!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(@"删除失败!" + ex.Message);
                    }
                }
            }
        }

        private void biGiveup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetControlDisable();//取消就是撤消此次修改。
            if (string.IsNullOrEmpty(lblTitleMain.lblAutoID.Text))
            {
                SetPanelVlaue("", "btnLast");
            }
            else
            {
                SetPanelVlaue(lblTitleMain.lblAutoID.Text);
            }
        }


        /// <summary>
        /// 启用所有新增和更新控件时使用的输入和保存按钮
        /// </summary>
        private void SetControlEnable()
        {
            foreach (Control ctrl in ugbxMain.Controls)
            {
                if (ctrl is Label || ctrl is UltraLabel)
                {
                    continue;
                }
                ctrl.Enabled = true;
            }
            biSave.Enabled = true; //在可编辑下保存按钮可用
            biGiveup.Enabled = true; //在可编辑下取消按钮可用
            biAddNew.Enabled = false; //在可编辑下新增按钮不可用
            biEdit.Enabled = false; //在可编辑下修改按钮不可用
            biDelete.Enabled = false;
            uGridRawMaterial.DisplayLayout.Override.AllowAddNew =
                AllowAddNew.TemplateOnBottom;
        }

        /// <summary>
        /// 禁用所有输入框和保存按钮
        /// </summary>
        private void SetControlDisable()
        {
            foreach (Control ctrl in ugbxMain.Controls)
            {
                if (ctrl is Label || ctrl is UltraLabel)
                {
                    continue;
                }
                ctrl.Enabled = false;
            }

            biSave.Enabled = false;//在不可编辑下保存按钮不可用
            biGiveup.Enabled = false;//在不可编辑下取消按钮不可用
            biAddNew.Enabled = true;//在不可编辑下新增按钮可用
            biEdit.Enabled = true;//在不可编辑下修改按钮可用
            biDelete.Enabled = true;
            uGridRawMaterial.DisplayLayout.Override.AllowAddNew= AllowAddNew.No;
            }

        

        /// <summary>
        /// 进行数据库数据定位显示
        /// </summary>
        /// <param name="lId"></param>
        /// <param name="llocation"></param>
        public void SetPanelVlaue(string lId, string llocation = "")
        {
            var sqlcmd = new SqlCommand();
            switch (llocation)
            {
                case "btnLast":
                    sqlcmd.CommandText = "select top 1 * from Bom order by AutoID desc";
                    break;
                case "btnFirst":
                    sqlcmd.CommandText = "select top 1 * from Bom order by AutoID";
                    break;
                case "btnPre":
                    if (string.IsNullOrEmpty(lId))
                    {
                        MessageBox.Show(@"已到首页");
                        return;
                    }
                    sqlcmd.CommandText = "select top 1 * from Bom where AutoID<@AutoID order by AutoID desc";
                    sqlcmd.Parameters.AddWithValue("@AutoID", lId);
                    break;
                case "btnNext":
                    if (string.IsNullOrEmpty(lId))
                    {
                        MessageBox.Show(@"已到末页");
                        return;
                    }
                    sqlcmd.CommandText = "select top 1 * from Bom where AutoID>@AutoID order by AutoID";
                    sqlcmd.Parameters.AddWithValue("@AutoID", lId);
                    break;
                case "":
                    sqlcmd.CommandText = "select top 1 * from Bom where AutoID=@AutoID";
                    sqlcmd.Parameters.AddWithValue("@AutoID", lId);
                    break;
            }

            using (var con = new SqlConnection(BaseStructure.WmsCon))
            {
                sqlcmd.Connection = con;
                con.Open();
                #region 读取数据库中数据
                using (var dr = sqlcmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        //获取所有取得的数据并显示
                        lblTitleMain.lblAutoID.Text = dr["AutoID"].ToString();
                        txtcInvCode.Text = dr["cInvCode"].ToString();
                        utecInvName.Text = dr["cInvName"].ToString();
                        txtcInvStd.Text = dr["cInvStd"].ToString();
                        txtcFullName.Text = dr["cFullName"].ToString();
                        txtcMemo.Text = dr["cMemo"].ToString();
                        
                        //获取子表
                        bomDetailTableAdapter.Fill(dataInventory.BomDetail, int.Parse(lblTitleMain.lblAutoID.Text));
                    }
                    else
                    {
                        switch (llocation)
                        {
                            case "btnPre":
                                MessageBox.Show(@"已经是首页");
                                break;
                            case "btnNext":
                                MessageBox.Show(@"已经是末页");
                                break;
                            default:
                                MessageBox.Show(@"无记录");
                                //ResetNull();
                                //SetControlDisable();
                                break;
                        }

                    }
                #endregion
                }
            }

        }


        /// <summary>
        /// 判断什么未填写,返回对应的标签
        /// </summary>
        /// <returns></returns>
        private string CheckNull()
        {
            if (string.IsNullOrEmpty(txtcInvCode.Text))
                return "产成品编码";
            if (string.IsNullOrEmpty(utecInvName.Text))
                return "产成品名称";
            return dataInventory.BomDetail.Rows.Count < 1 ? "子件" : string.Empty;
        }

        private void txtcInvCode_RowSelected(object sender, RowSelectedEventArgs e)
        {
            var uRow = e.Row;

            SetDefaultValue(uRow);
        }

        private void SetDefaultValue(UltraGridRow uRow)
        {
            if (uRow == null || uRow.Index <= -1) return;
            _FitemId = uRow.Cells["FItemID"].Value.ToString();
            txtcInvCode.Text = uRow.Cells["FNumber"].Value.ToString();
            utecInvName.Text = uRow.Cells["FName"].Value.ToString();
            txtcInvStd.Text = uRow.Cells["FModel"].Value.ToString();
            txtcFullName.Text = uRow.Cells["FFullName"].Value.ToString();
            _FitemId = uRow.Cells["FItemID"].Value.ToString();
        }

        private void biSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //判断什么为填写
            var nullstr = CheckNull();
            if (!string.IsNullOrEmpty(nullstr))
            {
                MessageBox.Show(nullstr + @"必填,请填写完成!", @"必填", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var con = new SqlConnection(BaseStructure.WmsCon))
            {
                using (var cmd = new SqlCommand { CommandType = CommandType.StoredProcedure, Connection = con })
                {
                    if (string.IsNullOrEmpty(lblTitleMain.lblAutoID.Text))
                    {
                        cmd.CommandText = "proc_BomInsert";
                        var idParameter = new SqlParameter("@AutoID", SqlDbType.BigInt)
                        {
                            Direction = ParameterDirection.Output
                        };
                        
                        //获取id的返回值和采购订单号的返回值
                        cmd.Parameters.Add(idParameter);
                    }
                    else
                    {
                        cmd.CommandText = "proc_BomUpdate";
                        cmd.Parameters.AddWithValue("@AutoID", lblTitleMain.lblAutoID.Text);
                    }

                    //赋参数
                    cmd.Parameters.AddWithValue("@cFitemID", _FitemId);
                    cmd.Parameters.AddWithValue("@cInvCode", txtcInvCode.Text);
                    cmd.Parameters.AddWithValue("@cInvName", utecInvName.Text);
                    cmd.Parameters.AddWithValue("@cInvStd", txtcInvStd.Text);
                    cmd.Parameters.AddWithValue("@cFullName", txtcFullName.Text);
                    cmd.Parameters.AddWithValue("@cMemo", txtcMemo.Text);
                    con.Open();
                    using (var tran = con.BeginTransaction())
                    {
                        int ieffect;
                        cmd.Transaction = tran;
                        try
                        {
                            ieffect = cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }
                        //判断是否是真的完成了主表的写入
                        if (ieffect > 0)
                        {
                            if (string.IsNullOrEmpty(lblTitleMain.lblAutoID.Text))
                            {
                                lblTitleMain.lblAutoID.Text = cmd.Parameters["@AutoID"].Value.ToString();
                            }
                        }
                        else
                        {
                            MessageBox.Show(@"保存失败，请检查该产品是否已经存储Bom结构", @"失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        uGridRawMaterial.UpdateData();
                        //重新赋值一下行号/单据号给子表
                        for (var i = 0; i < dataInventory.BomDetail.Rows.Count; i++)
                        {
                            var dr = dataInventory.BomDetail.Rows[i];
                            if (dr.RowState == DataRowState.Deleted)
                                continue;
                            dr["BomID"] = lblTitleMain.lblAutoID.Text;

                        }
                        //将改变提交到内存表
                        uGridRawMaterial.UpdateData();
                        try
                        {
                            //提交子表
                            bomDetailTableAdapter.Update(dataInventory.BomDetail);
                            //提交主表
                            tran.Commit();
                            MessageBox.Show(@"保存成功", @"成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            SetControlDisable();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        private void utecInvName_EditorButtonClick(object sender, EditorButtonEventArgs e)
        {
            using (var brm = new SelectKisInventory(_dtRawMaterial, txtcInvCode.Text))
            {
                if (brm.ShowDialog() == DialogResult.Yes)
                {
                    _FitemId = brm.FitemId;
                    txtcInvCode.Text = brm.InvCode;
                    utecInvName.Text = brm.InvName;
                    txtcInvStd.Text = brm.InvStd;
                    txtcFullName.Text = brm.FullName;
                    _FitemId = brm.FitemId;

                }
            }
        }

        private void uGridRawMaterial_ClickCellButton(object sender, CellEventArgs e)
        {
            if (e.Cell.Row.Index < 0)
                return;
            if (string.IsNullOrEmpty(txtcInvCode.Text) || string.IsNullOrEmpty(utecInvName.Text))
            {
                MessageBox.Show(@"请先选择成品", @"失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var brm = new SelectKisInventory(_dtRawMaterial, e.Cell.Row.Cells["cInvCode"].Value.ToString()))
            {
                if (brm.ShowDialog() == DialogResult.Yes)
                {
                    if (dataInventory.BomDetail.Rows.Cast<DataRow>().Any(iRow => iRow.RowState!=DataRowState.Deleted&&iRow["cInvCode"].ToString().Equals(brm.InvCode)))
                    {
                        MessageBox.Show(@"错误，子件已经存在", @"失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (brm.InvCode.Equals(txtcInvCode.Text))
                    {
                        MessageBox.Show(@"错误，子件不能是自己本身", @"失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    e.Cell.Row.Cells["BomID"].Value = -1;
                    e.Cell.Row.Cells["cFitemID"].Value = brm.FitemId;
                    e.Cell.Row.Cells["cInvCode"].Value = brm.InvCode;
                    e.Cell.Row.Cells["cInvName"].Value = brm.InvName;
                    e.Cell.Row.Cells["cInvStd"].Value = brm.InvStd;
                    e.Cell.Row.Cells["cFullName"].Value = brm.FullName;
                    e.Cell.Row.Cells["cUnitID"].Value = brm.FUnitID;
                    e.Cell.Row.Cells["cUnitName"].Value = brm.FUnitName;
                    e.Cell.Row.Cells["dAddTime"].Value = DateTime.Now;

                }
            }
        }

        private void biExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void biExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }
    }
}
