using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;

namespace JWMSH
{
    public partial class BaseUser : Form
    {
        /// <summary>
        /// 判断是否允许关闭
        /// </summary>
        bool _bclose;

        public BaseUser()
        {
            InitializeComponent();
            //增加一个按键动作映射，当敲击回车时，提交修改
                uGridUser.KeyActionMappings.Add(new GridKeyActionMapping(
                Keys.Enter,                       // 按下回车键时
                UltraGridAction.CommitRow,         // 提交修改
                UltraGridState.IsCheckbox,        // 单元格不能为checkbox
                UltraGridState.Cell,              // 选中单元格时
                0,                                // 不禁止特殊键
                0                                 // 不需要特殊键
            ));
                //增加一个按键动作映射，当敲击回车时，提交修改
                uGridRole.KeyActionMappings.Add(new GridKeyActionMapping(
                Keys.Enter,                       // 按下回车键时
                UltraGridAction.CommitRow,         // 提交修改
                UltraGridState.IsCheckbox,        // 单元格不能为checkbox
                UltraGridState.Cell,              // 选中单元格时
                0,                                // 不禁止特殊键
                0                                 // 不需要特殊键
            ));
        }

        /// <summary>
        /// 设置GridView中的下拉列表
        /// </summary>
        private void SetRoleDropDownList()
        {
            uGridUser.DisplayLayout.ValueLists["roleList"].ValueListItems.Clear();
            //对用户管理界面的角色名的下拉列表添加选项
            foreach (DataRow dtr in baseDs.BRole.Rows)
            {
                uGridUser.DisplayLayout.ValueLists["roleList"].ValueListItems.Add(dtr["cCode"].ToString(), dtr["cName"].ToString());
            }
            uGridUser.DisplayLayout.Bands[0].Columns["Urole"].ValueList = uGridUser.DisplayLayout.ValueLists["roleList"];

            
            
            uGridUser.DisplayLayout.ValueLists["DepartList"].ValueListItems.Clear();
            //对用户管理界面的角色名的下拉列表添加选项
            uGridUser.DisplayLayout.ValueLists["DepartList"].ValueListItems.Add("D001", "Huaxiang");

            uGridUser.DisplayLayout.Bands[0].Columns["uDepartment"].ValueList = uGridUser.DisplayLayout.ValueLists["DepartList"];
        }

        private void BaseUser_Load(object sender, EventArgs e)
        {
            uGridUser.DisplayLayout.ValueLists.Add("roleList");
            uGridUser.DisplayLayout.ValueLists.Add("DepartList");
            //加载数据库账套连接
            bUserTableAdapter.Connection.ConnectionString =BaseStructure.WmsCon;
            bRoleTableAdapter.Connection.ConnectionString = BaseStructure.WmsCon;
            //加载数据
            bRoleTableAdapter.Fill(baseDs.BRole);
            bUserTableAdapter.Fill(baseDs.BUser);
            SetRoleDropDownList();
        }

        private void tsbRoleManager_Click(object sender, EventArgs e)
        {
            uSplitterRight.Collapsed = !uSplitterRight.Collapsed;
        }

        private void tsbRsave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveRoleData();
                SetRoleDropDownList();
                MessageBox.Show(@"操作成功", @"成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"发生异常：" + ex.Message, @"错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveUserData();
        }

        private void BaseUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_bclose)
            {
                return;
            }
            if (!baseDs.HasChanges()) return;
            if (MessageBox.Show(@"数据有修改是否保存此次修改？", @"确定删除？", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SaveUserData();
            }
        }

        /// <summary>
        /// 执行保存用户数据
        /// </summary>
        private void SaveUserData()
        {
            var btemp = baseDs.BUser.Rows.Cast<DataRow>().Where(dtr => dtr.RowState != DataRowState.Deleted).Any(dtr => string.IsNullOrEmpty(dtr["uCode"].ToString()) || string.IsNullOrEmpty(dtr["uName"].ToString()));
            if (btemp)
            {
                MessageBox.Show(@"用户名和密码必输!", @"未填写完全，请检查？", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    uGridUser.UpdateData();
                    bUserTableAdapter.Update(baseDs.BUser);
                    MessageBox.Show(@"操作成功", @"成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(@"发生异常：" + ex.Message, @"错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        /// <summary>
        /// 执行保存角色数据
        /// </summary>
        private void SaveRoleData()
        {
            var btemp = baseDs.BRole.Rows.Cast<DataRow>().Where(dtr => dtr.RowState != DataRowState.Deleted).Any(dtr => string.IsNullOrEmpty(dtr["cCode"].ToString()) || string.IsNullOrEmpty(dtr["cName"].ToString()));
            if (btemp)
            {
                MessageBox.Show(@"角色名,角色号必输", @"未填写完全，请检查？", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                uGridRole.UpdateData();
                bRoleTableAdapter.Update(baseDs.BRole);
            }
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            _bclose = true;
            if (baseDs.HasChanges())
            {
                if (MessageBox.Show(@"数据有修改是否保存此次修改？", @"确定删除？", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    SaveUserData();
                }
            }
            Close();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (uGridUser.ActiveRow == null)
                return;
            if (MessageBox.Show(@"确定删除吗？", @"确定删除？", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                uGridUser.ActiveRow.Delete(false);
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            bRoleTableAdapter.Fill(baseDs.BRole);
            bUserTableAdapter.Fill(baseDs.BUser);
            SetRoleDropDownList();
        }

        private void tsbRdelete_Click(object sender, EventArgs e)
        {
            if (uGridRole.ActiveRow == null)
                return;
            if (MessageBox.Show(@"确定删除吗？", @"确定删除？", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                uGridRole.ActiveRow.Delete(false);
            }
        }
    }
}
