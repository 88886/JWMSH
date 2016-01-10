namespace JWMSH
{
    partial class SelectKisInventory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CORDERNUMBER");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CORDERTYPE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DADDTIME");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDATE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CVENDOR");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CCOMPANY");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CBUYER");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CBUYERTAX");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn44 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CBUYERPHONE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn45 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CBUYERCELL");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn46 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BTAX");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn47 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CCURRENCY");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn48 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CPAYMENTTYPE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn49 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CDEPARTMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn50 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("COPERATOR");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn51 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ROWNUMBER");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            this.tsgfMain = new UpjdControlBox.ToolStripGridFunction();
            this.uGirdKisInventory = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.uGirdKisInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // tsgfMain
            // 
            this.tsgfMain.Constr = null;
            this.tsgfMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tsgfMain.FormId = null;
            this.tsgfMain.FormName = null;
            this.tsgfMain.Location = new System.Drawing.Point(0, 0);
            this.tsgfMain.Name = "tsgfMain";
            this.tsgfMain.Size = new System.Drawing.Size(784, 25);
            this.tsgfMain.TabIndex = 56;
            this.tsgfMain.UGrid = this.uGirdKisInventory;
            // 
            // uGirdKisInventory
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            this.uGirdKisInventory.DisplayLayout.Appearance = appearance1;
            ultraGridColumn6.Header.Caption = "单据编号";
            ultraGridColumn6.Header.VisiblePosition = 0;
            ultraGridColumn17.Header.Caption = "业务类型";
            ultraGridColumn17.Header.VisiblePosition = 1;
            ultraGridColumn23.Header.Caption = "订单日期";
            ultraGridColumn23.Header.VisiblePosition = 2;
            ultraGridColumn25.Header.Caption = "业务日期";
            ultraGridColumn25.Header.VisiblePosition = 3;
            ultraGridColumn26.Header.Caption = "供方名称";
            ultraGridColumn26.Header.VisiblePosition = 4;
            ultraGridColumn27.Header.Caption = "需方名称";
            ultraGridColumn27.Header.VisiblePosition = 5;
            ultraGridColumn28.Header.Caption = "联系人";
            ultraGridColumn28.Header.VisiblePosition = 6;
            ultraGridColumn29.Header.Caption = "传真号码";
            ultraGridColumn29.Header.VisiblePosition = 7;
            ultraGridColumn44.Header.Caption = "联系电话";
            ultraGridColumn44.Header.VisiblePosition = 8;
            ultraGridColumn45.Header.Caption = "手机号码";
            ultraGridColumn45.Header.VisiblePosition = 9;
            ultraGridColumn46.Header.Caption = "含税否";
            ultraGridColumn46.Header.VisiblePosition = 10;
            ultraGridColumn47.Header.Caption = "币种";
            ultraGridColumn47.Header.VisiblePosition = 11;
            ultraGridColumn48.Header.Caption = "付款方式";
            ultraGridColumn48.Header.VisiblePosition = 12;
            ultraGridColumn49.Header.Caption = "部门";
            ultraGridColumn49.Header.VisiblePosition = 13;
            ultraGridColumn50.Header.Caption = "制单人";
            ultraGridColumn50.Header.VisiblePosition = 14;
            ultraGridColumn51.Header.Caption = "行号";
            ultraGridColumn51.Header.VisiblePosition = 15;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn6,
            ultraGridColumn17,
            ultraGridColumn23,
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28,
            ultraGridColumn29,
            ultraGridColumn44,
            ultraGridColumn45,
            ultraGridColumn46,
            ultraGridColumn47,
            ultraGridColumn48,
            ultraGridColumn49,
            ultraGridColumn50,
            ultraGridColumn51});
            this.uGirdKisInventory.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.uGirdKisInventory.DisplayLayout.GroupByBox.Prompt = "如需按照某个列进行分类汇总请把列名拖动到此处";
            this.uGirdKisInventory.DisplayLayout.MaxColScrollRegions = 1;
            this.uGirdKisInventory.DisplayLayout.MaxRowScrollRegions = 1;
            this.uGirdKisInventory.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.uGirdKisInventory.DisplayLayout.Override.CardAreaAppearance = appearance2;
            this.uGirdKisInventory.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.uGirdKisInventory.DisplayLayout.Override.CellPadding = 3;
            this.uGirdKisInventory.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.TextHAlignAsString = "Center";
            appearance3.TextVAlignAsString = "Middle";
            appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGirdKisInventory.DisplayLayout.Override.HeaderAppearance = appearance3;
            this.uGirdKisInventory.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.uGirdKisInventory.DisplayLayout.Override.RowAlternateAppearance = appearance4;
            appearance5.BorderColor = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Right";
            appearance5.TextVAlignAsString = "Middle";
            this.uGirdKisInventory.DisplayLayout.Override.RowAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGirdKisInventory.DisplayLayout.Override.RowSelectorAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGirdKisInventory.DisplayLayout.Override.RowSelectorHeaderAppearance = appearance7;
            this.uGirdKisInventory.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton;
            this.uGirdKisInventory.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            this.uGirdKisInventory.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.uGirdKisInventory.DisplayLayout.Override.RowSelectorWidth = 40;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            appearance8.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance8.BorderColor = System.Drawing.Color.Black;
            appearance8.ForeColor = System.Drawing.Color.Black;
            this.uGirdKisInventory.DisplayLayout.Override.SelectedRowAppearance = appearance8;
            this.uGirdKisInventory.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.uGirdKisInventory.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.uGirdKisInventory.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.uGirdKisInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uGirdKisInventory.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uGirdKisInventory.Location = new System.Drawing.Point(0, 25);
            this.uGirdKisInventory.Name = "uGirdKisInventory";
            this.uGirdKisInventory.Size = new System.Drawing.Size(784, 537);
            this.uGirdKisInventory.TabIndex = 57;
            this.uGirdKisInventory.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus;
            this.uGirdKisInventory.DoubleClickCell += new Infragistics.Win.UltraWinGrid.DoubleClickCellEventHandler(this.uGirdKisInventory_DoubleClickCell);
            // 
            // SelectKisInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.uGirdKisInventory);
            this.Controls.Add(this.tsgfMain);
            this.Icon = global::JWMSH.Properties.Resources.scanicon;
            this.Name = "SelectKisInventory";
            this.Text = "金蝶物料档案";
            this.Load += new System.EventHandler(this.SelectKisInventory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uGirdKisInventory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UpjdControlBox.ToolStripGridFunction tsgfMain;
        private Infragistics.Win.UltraWinGrid.UltraGrid uGirdKisInventory;
    }
}