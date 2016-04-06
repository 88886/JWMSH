namespace AutoSync
{
    partial class SyncOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SyncOrder));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("cMStorage", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Id");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RKbarcode");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RKinvCode");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RKoperator");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RKdate");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RKpdasn");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RKisToBill");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RKbillTime");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RKBillNum");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AddTime");
            Infragistics.Win.UltraWinGrid.SummarySettings summarySettings1 = new Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Count, null, "Id", 0, true, "cMStorage", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "Id", 0, true);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Wms_M_Order", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AutoID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("cGuid");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("cType");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("cOrderNumber");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("bUpdate");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("cTable");
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            this.tsOpeStore = new System.Windows.Forms.ToolStrip();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tstxtServer = new System.Windows.Forms.ToolStripTextBox();
            this.tsbtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.timerExec = new System.Windows.Forms.Timer();
            this.timerSpan = new System.Windows.Forms.Timer();
            this.nfiMain = new System.Windows.Forms.NotifyIcon();
            this.uGroupBox = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.uGroupBoxPanelTop = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.lblCostTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblLastTime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTimeSpan = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudTimeSpan = new System.Windows.Forms.NumericUpDown();
            this.btnSaveTime = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pbMain = new System.Windows.Forms.ProgressBar();
            this.uGridStore = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.uGridStoreToBill = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.wmsMOrderBindingSource = new System.Windows.Forms.BindingSource();
            this.dsOrder = new AutoSync.dsOrder();
            this.wms_M_OrderTableAdapter = new AutoSync.dsOrderTableAdapters.Wms_M_OrderTableAdapter();
            this.tsOpeStore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uGroupBox)).BeginInit();
            this.uGroupBox.SuspendLayout();
            this.uGroupBoxPanelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeSpan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGridStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGridStoreToBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmsMOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // tsOpeStore
            // 
            this.tsOpeStore.BackgroundImage = global::AutoSync.Properties.Resources.toolbarBk;
            this.tsOpeStore.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbExit,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.tstxtServer,
            this.tsbtnSave,
            this.toolStripSeparator1});
            this.tsOpeStore.Location = new System.Drawing.Point(0, 0);
            this.tsOpeStore.Name = "tsOpeStore";
            this.tsOpeStore.Size = new System.Drawing.Size(984, 25);
            this.tsOpeStore.TabIndex = 16;
            // 
            // tsbExit
            // 
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(36, 22);
            this.tsbExit.Text = "退出";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(91, 22);
            this.toolStripLabel1.Text = "服务器IP端口：";
            // 
            // tstxtServer
            // 
            this.tstxtServer.Name = "tstxtServer";
            this.tstxtServer.Size = new System.Drawing.Size(210, 25);
            // 
            // tsbtnSave
            // 
            this.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSave.Name = "tsbtnSave";
            this.tsbtnSave.Size = new System.Drawing.Size(60, 22);
            this.tsbtnSave.Text = "保存配置";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // timerExec
            // 
            this.timerExec.Enabled = true;
            this.timerExec.Interval = 6000;
            this.timerExec.Tick += new System.EventHandler(this.timerExec_Tick);
            // 
            // timerSpan
            // 
            this.timerSpan.Enabled = true;
            this.timerSpan.Interval = 1000;
            this.timerSpan.Tick += new System.EventHandler(this.timerSpan_Tick);
            // 
            // nfiMain
            // 
            this.nfiMain.Icon = ((System.Drawing.Icon)(resources.GetObject("nfiMain.Icon")));
            this.nfiMain.Text = "nfiMain";
            this.nfiMain.Visible = true;
            this.nfiMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nfiMain_MouseDoubleClick);
            // 
            // uGroupBox
            // 
            this.uGroupBox.Controls.Add(this.uGroupBoxPanelTop);
            this.uGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.uGroupBox.ExpandedSize = new System.Drawing.Size(984, 114);
            this.uGroupBox.Location = new System.Drawing.Point(0, 25);
            this.uGroupBox.Name = "uGroupBox";
            this.uGroupBox.Size = new System.Drawing.Size(984, 114);
            this.uGroupBox.TabIndex = 17;
            this.uGroupBox.Text = "配置运行时属性";
            this.uGroupBox.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // uGroupBoxPanelTop
            // 
            this.uGroupBoxPanelTop.Controls.Add(this.lblCostTime);
            this.uGroupBoxPanelTop.Controls.Add(this.label5);
            this.uGroupBoxPanelTop.Controls.Add(this.lblLastTime);
            this.uGroupBoxPanelTop.Controls.Add(this.label4);
            this.uGroupBoxPanelTop.Controls.Add(this.lblTimeSpan);
            this.uGroupBoxPanelTop.Controls.Add(this.dtpStartTime);
            this.uGroupBoxPanelTop.Controls.Add(this.label3);
            this.uGroupBoxPanelTop.Controls.Add(this.label2);
            this.uGroupBoxPanelTop.Controls.Add(this.nudTimeSpan);
            this.uGroupBoxPanelTop.Controls.Add(this.btnSaveTime);
            this.uGroupBoxPanelTop.Controls.Add(this.label1);
            this.uGroupBoxPanelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uGroupBoxPanelTop.Location = new System.Drawing.Point(3, 20);
            this.uGroupBoxPanelTop.Name = "uGroupBoxPanelTop";
            this.uGroupBoxPanelTop.Size = new System.Drawing.Size(978, 91);
            this.uGroupBoxPanelTop.TabIndex = 0;
            // 
            // lblCostTime
            // 
            this.lblCostTime.AutoSize = true;
            this.lblCostTime.BackColor = System.Drawing.Color.Transparent;
            this.lblCostTime.Location = new System.Drawing.Point(837, 54);
            this.lblCostTime.Name = "lblCostTime";
            this.lblCostTime.Size = new System.Drawing.Size(0, 12);
            this.lblCostTime.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(796, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "用时:";
            // 
            // lblLastTime
            // 
            this.lblLastTime.AutoSize = true;
            this.lblLastTime.BackColor = System.Drawing.Color.Transparent;
            this.lblLastTime.Location = new System.Drawing.Point(659, 54);
            this.lblLastTime.Name = "lblLastTime";
            this.lblLastTime.Size = new System.Drawing.Size(0, 12);
            this.lblLastTime.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(523, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "上一次执行导入时间是:";
            // 
            // lblTimeSpan
            // 
            this.lblTimeSpan.AutoSize = true;
            this.lblTimeSpan.BackColor = System.Drawing.Color.Transparent;
            this.lblTimeSpan.Location = new System.Drawing.Point(339, 54);
            this.lblTimeSpan.Name = "lblTimeSpan";
            this.lblTimeSpan.Size = new System.Drawing.Size(0, 12);
            this.lblTimeSpan.TabIndex = 7;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpStartTime.Enabled = false;
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(109, 50);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(157, 21);
            this.dtpStartTime.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(286, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "已运行:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(32, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "开始时间为:";
            // 
            // nudTimeSpan
            // 
            this.nudTimeSpan.Location = new System.Drawing.Point(181, 4);
            this.nudTimeSpan.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudTimeSpan.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTimeSpan.Name = "nudTimeSpan";
            this.nudTimeSpan.Size = new System.Drawing.Size(52, 21);
            this.nudTimeSpan.TabIndex = 3;
            this.nudTimeSpan.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // btnSaveTime
            // 
            this.btnSaveTime.Location = new System.Drawing.Point(235, 3);
            this.btnSaveTime.Name = "btnSaveTime";
            this.btnSaveTime.Size = new System.Drawing.Size(52, 23);
            this.btnSaveTime.TabIndex = 2;
            this.btnSaveTime.Text = "保存";
            this.btnSaveTime.UseVisualStyleBackColor = true;
            this.btnSaveTime.Click += new System.EventHandler(this.btnSaveTime_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(32, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "1:定时执行间隔(单位:分)";
            // 
            // pbMain
            // 
            this.pbMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbMain.Location = new System.Drawing.Point(0, 139);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(984, 23);
            this.pbMain.TabIndex = 19;
            // 
            // uGridStore
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            this.uGridStore.DisplayLayout.Appearance = appearance1;
            this.uGridStore.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn15.Header.Caption = "SQLID";
            ultraGridColumn15.Header.VisiblePosition = 0;
            ultraGridColumn15.Width = 54;
            ultraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn16.Header.Caption = "条码";
            ultraGridColumn16.Header.VisiblePosition = 1;
            ultraGridColumn16.Width = 106;
            ultraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn17.Header.Caption = "存货编码";
            ultraGridColumn17.Header.VisiblePosition = 2;
            ultraGridColumn17.Width = 106;
            ultraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn18.Header.Caption = "扫描员";
            ultraGridColumn18.Header.VisiblePosition = 3;
            ultraGridColumn18.Width = 106;
            ultraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn19.Header.Caption = "扫描日期";
            ultraGridColumn19.Header.VisiblePosition = 4;
            ultraGridColumn19.Width = 84;
            ultraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn20.Header.Caption = "扫描枪SN";
            ultraGridColumn20.Header.VisiblePosition = 5;
            ultraGridColumn20.Width = 106;
            ultraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn21.Header.Caption = "是否入库";
            ultraGridColumn21.Header.VisiblePosition = 6;
            ultraGridColumn21.Width = 106;
            ultraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn22.Header.Caption = "入库时间";
            ultraGridColumn22.Header.VisiblePosition = 7;
            ultraGridColumn22.Width = 84;
            ultraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn23.Header.Caption = "入库编号";
            ultraGridColumn23.Header.VisiblePosition = 8;
            ultraGridColumn23.Width = 106;
            ultraGridColumn24.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn24.Header.Caption = "上传时间";
            ultraGridColumn24.Header.VisiblePosition = 9;
            ultraGridColumn24.Width = 84;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24});
            summarySettings1.DisplayFormat = "总计 = {0}行";
            summarySettings1.GroupBySummaryValueAppearance = appearance2;
            ultraGridBand1.Summaries.AddRange(new Infragistics.Win.UltraWinGrid.SummarySettings[] {
            summarySettings1});
            ultraGridBand1.SummaryFooterCaption = "当前合计如下";
            this.uGridStore.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.uGridStore.DisplayLayout.ColumnChooserEnabled = Infragistics.Win.DefaultableBoolean.False;
            this.uGridStore.DisplayLayout.GroupByBox.Prompt = "如需按照某个列进行分类汇总请把列名拖动到此处";
            this.uGridStore.DisplayLayout.MaxColScrollRegions = 1;
            this.uGridStore.DisplayLayout.MaxRowScrollRegions = 1;
            this.uGridStore.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.uGridStore.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.uGridStore.DisplayLayout.Override.CardAreaAppearance = appearance3;
            this.uGridStore.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.uGridStore.DisplayLayout.Override.CellPadding = 3;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            appearance4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance4.TextHAlignAsString = "Center";
            appearance4.TextVAlignAsString = "Middle";
            appearance4.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGridStore.DisplayLayout.Override.HeaderAppearance = appearance4;
            this.uGridStore.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance5.BorderColor = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Right";
            appearance5.TextVAlignAsString = "Middle";
            this.uGridStore.DisplayLayout.Override.RowAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGridStore.DisplayLayout.Override.RowSelectorAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGridStore.DisplayLayout.Override.RowSelectorHeaderAppearance = appearance7;
            this.uGridStore.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement;
            this.uGridStore.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            this.uGridStore.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.uGridStore.DisplayLayout.Override.RowSelectorWidth = 40;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            appearance8.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance8.BorderColor = System.Drawing.Color.Black;
            appearance8.ForeColor = System.Drawing.Color.Black;
            this.uGridStore.DisplayLayout.Override.SelectedRowAppearance = appearance8;
            this.uGridStore.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            this.uGridStore.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.uGridStore.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.uGridStore.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.uGridStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uGridStore.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uGridStore.Location = new System.Drawing.Point(0, 332);
            this.uGridStore.Name = "uGridStore";
            this.uGridStore.Size = new System.Drawing.Size(984, 230);
            this.uGridStore.TabIndex = 20;
            this.uGridStore.Text = "未生成入库单条码一览表";
            this.uGridStore.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus;
            // 
            // uGridStoreToBill
            // 
            this.uGridStoreToBill.DataSource = this.wmsMOrderBindingSource;
            appearance9.BackColor = System.Drawing.Color.White;
            this.uGridStoreToBill.DisplayLayout.Appearance = appearance9;
            this.uGridStoreToBill.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Width = 153;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn2.Header.Caption = "GUID";
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 195;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn3.Header.Caption = "类型";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Width = 195;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn4.Header.Caption = "订单号";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Width = 195;
            ultraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn5.Header.Caption = "更新";
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Width = 99;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.Width = 105;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6});
            ultraGridBand2.SummaryFooterCaption = "当前合计如下";
            this.uGridStoreToBill.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.uGridStoreToBill.DisplayLayout.ColumnChooserEnabled = Infragistics.Win.DefaultableBoolean.False;
            this.uGridStoreToBill.DisplayLayout.GroupByBox.Prompt = "如需按照某个列进行分类汇总请把列名拖动到此处";
            this.uGridStoreToBill.DisplayLayout.MaxColScrollRegions = 1;
            this.uGridStoreToBill.DisplayLayout.MaxRowScrollRegions = 1;
            this.uGridStoreToBill.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.uGridStoreToBill.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            appearance10.BackColor = System.Drawing.Color.Transparent;
            this.uGridStoreToBill.DisplayLayout.Override.CardAreaAppearance = appearance10;
            this.uGridStoreToBill.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.uGridStoreToBill.DisplayLayout.Override.CellPadding = 3;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            appearance11.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance11.TextHAlignAsString = "Center";
            appearance11.TextVAlignAsString = "Middle";
            appearance11.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGridStoreToBill.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.uGridStoreToBill.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance12.BorderColor = System.Drawing.Color.Black;
            appearance12.TextHAlignAsString = "Right";
            appearance12.TextVAlignAsString = "Middle";
            this.uGridStoreToBill.DisplayLayout.Override.RowAppearance = appearance12;
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            appearance13.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGridStoreToBill.DisplayLayout.Override.RowSelectorAppearance = appearance13;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            appearance14.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGridStoreToBill.DisplayLayout.Override.RowSelectorHeaderAppearance = appearance14;
            this.uGridStoreToBill.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement;
            this.uGridStoreToBill.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            this.uGridStoreToBill.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.uGridStoreToBill.DisplayLayout.Override.RowSelectorWidth = 40;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            appearance15.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance15.BorderColor = System.Drawing.Color.Black;
            appearance15.ForeColor = System.Drawing.Color.Black;
            this.uGridStoreToBill.DisplayLayout.Override.SelectedRowAppearance = appearance15;
            this.uGridStoreToBill.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            this.uGridStoreToBill.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.uGridStoreToBill.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.uGridStoreToBill.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.uGridStoreToBill.Dock = System.Windows.Forms.DockStyle.Top;
            this.uGridStoreToBill.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uGridStoreToBill.Location = new System.Drawing.Point(0, 162);
            this.uGridStoreToBill.Name = "uGridStoreToBill";
            this.uGridStoreToBill.Size = new System.Drawing.Size(984, 170);
            this.uGridStoreToBill.TabIndex = 21;
            this.uGridStoreToBill.Text = "计划生成入库单汇总";
            this.uGridStoreToBill.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus;
            // 
            // wmsMOrderBindingSource
            // 
            this.wmsMOrderBindingSource.DataMember = "Wms_M_Order";
            this.wmsMOrderBindingSource.DataSource = this.dsOrder;
            // 
            // dsOrder
            // 
            this.dsOrder.DataSetName = "dsOrder";
            this.dsOrder.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // wms_M_OrderTableAdapter
            // 
            this.wms_M_OrderTableAdapter.ClearBeforeFill = true;
            // 
            // SyncOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.uGridStore);
            this.Controls.Add(this.uGridStoreToBill);
            this.Controls.Add(this.pbMain);
            this.Controls.Add(this.uGroupBox);
            this.Controls.Add(this.tsOpeStore);
            this.Icon = global::AutoSync.Properties.Resources.Mine;
            this.Name = "SyncOrder";
            this.Text = "SyncOrder";
            this.Load += new System.EventHandler(this.SyncOrder_Load);
            this.SizeChanged += new System.EventHandler(this.SyncOrder_SizeChanged);
            this.tsOpeStore.ResumeLayout(false);
            this.tsOpeStore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uGroupBox)).EndInit();
            this.uGroupBox.ResumeLayout(false);
            this.uGroupBoxPanelTop.ResumeLayout(false);
            this.uGroupBoxPanelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeSpan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGridStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGridStoreToBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmsMOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsOpeStore;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tstxtServer;
        private System.Windows.Forms.ToolStripButton tsbtnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Timer timerExec;
        private System.Windows.Forms.Timer timerSpan;
        private System.Windows.Forms.NotifyIcon nfiMain;
        private Infragistics.Win.Misc.UltraExpandableGroupBox uGroupBox;
        private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel uGroupBoxPanelTop;
        private System.Windows.Forms.Label lblCostTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblLastTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTimeSpan;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudTimeSpan;
        private System.Windows.Forms.Button btnSaveTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar pbMain;
        private Infragistics.Win.UltraWinGrid.UltraGrid uGridStore;
        private Infragistics.Win.UltraWinGrid.UltraGrid uGridStoreToBill;
        private System.Windows.Forms.BindingSource wmsMOrderBindingSource;
        private dsOrder dsOrder;
        private dsOrderTableAdapters.Wms_M_OrderTableAdapter wms_M_OrderTableAdapter;
    }
}