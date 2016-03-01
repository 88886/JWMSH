﻿namespace JWMSH
{
    partial class SelectWarehouse
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("t_Stock", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FItemID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FNumber");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FAddress");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            this.uGridCustomer = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.tsgfMain = new UpjdControlBox.ToolStripGridFunction();
            this.dataKis = new JWMSH.DLL.DataKis();
            this.tStockBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.t_StockTableAdapter = new JWMSH.DLL.DataKisTableAdapters.t_StockTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.uGridCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataKis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tStockBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // uGridCustomer
            // 
            this.uGridCustomer.DataSource = this.tStockBindingSource;
            appearance1.BackColor = System.Drawing.Color.White;
            this.uGridCustomer.DisplayLayout.Appearance = appearance1;
            ultraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn5.Header.VisiblePosition = 0;
            ultraGridColumn5.Width = 93;
            ultraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn7.Header.VisiblePosition = 1;
            ultraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn8.Header.VisiblePosition = 2;
            ultraGridColumn8.Width = 168;
            ultraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn9.Header.VisiblePosition = 3;
            ultraGridColumn9.Width = 248;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn5,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9});
            this.uGridCustomer.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.uGridCustomer.DisplayLayout.GroupByBox.Prompt = "如需按照某个列进行分类汇总请把列名拖动到此处";
            this.uGridCustomer.DisplayLayout.MaxColScrollRegions = 1;
            this.uGridCustomer.DisplayLayout.MaxRowScrollRegions = 1;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.uGridCustomer.DisplayLayout.Override.CardAreaAppearance = appearance2;
            this.uGridCustomer.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.uGridCustomer.DisplayLayout.Override.CellPadding = 3;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.TextHAlignAsString = "Center";
            appearance3.TextVAlignAsString = "Middle";
            appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGridCustomer.DisplayLayout.Override.HeaderAppearance = appearance3;
            this.uGridCustomer.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
            appearance4.BorderColor = System.Drawing.Color.Black;
            appearance4.TextHAlignAsString = "Right";
            appearance4.TextVAlignAsString = "Middle";
            this.uGridCustomer.DisplayLayout.Override.RowAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGridCustomer.DisplayLayout.Override.RowSelectorAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGridCustomer.DisplayLayout.Override.RowSelectorHeaderAppearance = appearance6;
            this.uGridCustomer.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton;
            this.uGridCustomer.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            this.uGridCustomer.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.uGridCustomer.DisplayLayout.Override.RowSelectorWidth = 40;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance7.BorderColor = System.Drawing.Color.Black;
            appearance7.ForeColor = System.Drawing.Color.Black;
            this.uGridCustomer.DisplayLayout.Override.SelectedRowAppearance = appearance7;
            this.uGridCustomer.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.uGridCustomer.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.uGridCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uGridCustomer.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uGridCustomer.Location = new System.Drawing.Point(0, 25);
            this.uGridCustomer.Name = "uGridCustomer";
            this.uGridCustomer.Size = new System.Drawing.Size(784, 537);
            this.uGridCustomer.TabIndex = 26;
            this.uGridCustomer.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus;
            this.uGridCustomer.DoubleClickCell += new Infragistics.Win.UltraWinGrid.DoubleClickCellEventHandler(this.uGridCustomer_DoubleClickCell);
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
            this.tsgfMain.TabIndex = 25;
            this.tsgfMain.UGrid = this.uGridCustomer;
            // 
            // dataKis
            // 
            this.dataKis.DataSetName = "DataKis";
            this.dataKis.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tStockBindingSource
            // 
            this.tStockBindingSource.DataMember = "t_Stock";
            this.tStockBindingSource.DataSource = this.dataKis;
            // 
            // t_StockTableAdapter
            // 
            this.t_StockTableAdapter.ClearBeforeFill = true;
            // 
            // SelectWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.uGridCustomer);
            this.Controls.Add(this.tsgfMain);
            this.Icon = global::JWMSH.Properties.Resources.scanicon;
            this.Name = "SelectWarehouse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择仓库";
            this.Load += new System.EventHandler(this.SelectWarehouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uGridCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataKis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tStockBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid uGridCustomer;
        private UpjdControlBox.ToolStripGridFunction tsgfMain;
        private DLL.DataKis dataKis;
        private System.Windows.Forms.BindingSource tStockBindingSource;
        private DLL.DataKisTableAdapters.t_StockTableAdapter t_StockTableAdapter;
    }
}