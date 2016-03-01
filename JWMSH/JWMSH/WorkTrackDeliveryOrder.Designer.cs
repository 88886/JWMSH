namespace JWMSH
{
    partial class WorkTrackDeliveryOrder
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
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton2 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ProDeliveryDetail", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AutoID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FItemID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn41 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("cCode");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("cLotNo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("cInvCode");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("cInvName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn42 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("iQuantity");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FSPNumber");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("dAddTime");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("dScanTime");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("cOperator");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("cMemo");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkTrackDeliveryOrder));
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblcState = new Infragistics.Win.Misc.UltraLabel();
            this.btnPre = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.ugbxMain = new Infragistics.Win.Misc.UltraGroupBox();
            this.utecDepName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxcOrderType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.utxtcCusName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpdDate = new System.Windows.Forms.DateTimePicker();
            this.lblAutoID = new System.Windows.Forms.Label();
            this.txtcMemo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtcCode = new System.Windows.Forms.TextBox();
            this.lblcRNo = new System.Windows.Forms.Label();
            this.uGridProDeliveryDetail = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.proDeliveryDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataBiDetail = new JWMSH.DLL.DataBiDetail();
            this.tsgfMain = new UpjdControlBox.ToolStripGridFunction();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.imageCollection3 = new DevExpress.Utils.ImageCollection(this.components);
            this.bsiPrint = new DevExpress.XtraBars.BarSubItem();
            this.biPrint = new DevExpress.XtraBars.BarButtonItem();
            this.biPreview = new DevExpress.XtraBars.BarButtonItem();
            this.biDesign = new DevExpress.XtraBars.BarButtonItem();
            this.biExport = new DevExpress.XtraBars.BarButtonItem();
            this.biSave = new DevExpress.XtraBars.BarButtonItem();
            this.biAddNew = new DevExpress.XtraBars.BarButtonItem();
            this.biExit = new DevExpress.XtraBars.BarButtonItem();
            this.biEdit = new DevExpress.XtraBars.BarButtonItem();
            this.biDelete = new DevExpress.XtraBars.BarButtonItem();
            this.biEditTemplet = new DevExpress.XtraBars.BarButtonItem();
            this.bsiTemplet = new DevExpress.XtraBars.BarStaticItem();
            this.biGiveup = new DevExpress.XtraBars.BarButtonItem();
            this.bsiPrinter = new DevExpress.XtraBars.BarStaticItem();
            this.biEditPrinter = new DevExpress.XtraBars.BarButtonItem();
            this.biAppprove = new DevExpress.XtraBars.BarButtonItem();
            this.imageCollection4 = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgSystem = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgExport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgNew = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgTemplet = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgPrinter = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.proDeliveryDetailTableAdapter = new JWMSH.DLL.DataBiDetailTableAdapters.ProDeliveryDetailTableAdapter();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtQuery = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugbxMain)).BeginInit();
            this.ugbxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.utecDepName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.utxtcCusName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGridProDeliveryDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proDeliveryDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBiDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuery)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackgroundImage = global::JWMSH.Properties.Resources.window_titlebar;
            this.panelTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelTop.Controls.Add(this.lblcState);
            this.panelTop.Controls.Add(this.btnPre);
            this.panelTop.Controls.Add(this.btnLast);
            this.panelTop.Controls.Add(this.btnNext);
            this.panelTop.Controls.Add(this.btnFirst);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 98);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(984, 35);
            this.panelTop.TabIndex = 16;
            // 
            // lblcState
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.BorderColor = System.Drawing.Color.Red;
            appearance1.ForeColor = System.Drawing.Color.Red;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.lblcState.Appearance = appearance1;
            this.lblcState.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lblcState.Location = new System.Drawing.Point(62, 6);
            this.lblcState.Name = "lblcState";
            this.lblcState.Size = new System.Drawing.Size(165, 23);
            this.lblcState.TabIndex = 107;
            // 
            // btnPre
            // 
            this.btnPre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPre.BackColor = System.Drawing.Color.Transparent;
            this.btnPre.BackgroundImage = global::JWMSH.Properties.Resources.pre;
            this.btnPre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPre.FlatAppearance.BorderSize = 0;
            this.btnPre.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPre.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPre.ForeColor = System.Drawing.Color.Transparent;
            this.btnPre.Location = new System.Drawing.Point(711, 5);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(25, 25);
            this.btnPre.TabIndex = 3;
            this.btnPre.UseVisualStyleBackColor = false;
            this.btnPre.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnLast
            // 
            this.btnLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLast.BackColor = System.Drawing.Color.Transparent;
            this.btnLast.BackgroundImage = global::JWMSH.Properties.Resources.last;
            this.btnLast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLast.FlatAppearance.BorderSize = 0;
            this.btnLast.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnLast.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLast.ForeColor = System.Drawing.Color.Transparent;
            this.btnLast.Location = new System.Drawing.Point(769, 5);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(25, 25);
            this.btnLast.TabIndex = 5;
            this.btnLast.UseVisualStyleBackColor = false;
            this.btnLast.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.BackgroundImage = global::JWMSH.Properties.Resources.next;
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.ForeColor = System.Drawing.Color.Transparent;
            this.btnNext.Location = new System.Drawing.Point(740, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(25, 25);
            this.btnNext.TabIndex = 4;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFirst.BackColor = System.Drawing.Color.Transparent;
            this.btnFirst.BackgroundImage = global::JWMSH.Properties.Resources.first;
            this.btnFirst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFirst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFirst.FlatAppearance.BorderSize = 0;
            this.btnFirst.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnFirst.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirst.ForeColor = System.Drawing.Color.Transparent;
            this.btnFirst.Location = new System.Drawing.Point(682, 5);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(25, 25);
            this.btnFirst.TabIndex = 2;
            this.btnFirst.UseVisualStyleBackColor = false;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(413, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(159, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "产品出库指令单";
            // 
            // ugbxMain
            // 
            this.ugbxMain.Controls.Add(this.utecDepName);
            this.ugbxMain.Controls.Add(this.label6);
            this.ugbxMain.Controls.Add(this.dtpDeliveryDate);
            this.ugbxMain.Controls.Add(this.label4);
            this.ugbxMain.Controls.Add(this.dtpOrderDate);
            this.ugbxMain.Controls.Add(this.label2);
            this.ugbxMain.Controls.Add(this.cbxcOrderType);
            this.ugbxMain.Controls.Add(this.label3);
            this.ugbxMain.Controls.Add(this.utxtcCusName);
            this.ugbxMain.Controls.Add(this.label5);
            this.ugbxMain.Controls.Add(this.dtpdDate);
            this.ugbxMain.Controls.Add(this.lblAutoID);
            this.ugbxMain.Controls.Add(this.txtcMemo);
            this.ugbxMain.Controls.Add(this.label8);
            this.ugbxMain.Controls.Add(this.label1);
            this.ugbxMain.Controls.Add(this.txtcCode);
            this.ugbxMain.Controls.Add(this.lblcRNo);
            this.ugbxMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.ugbxMain.Location = new System.Drawing.Point(0, 133);
            this.ugbxMain.Name = "ugbxMain";
            this.ugbxMain.Size = new System.Drawing.Size(984, 191);
            this.ugbxMain.TabIndex = 17;
            // 
            // utecDepName
            // 
            this.utecDepName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            appearance2.Image = global::JWMSH.Properties.Resources.search_tool;
            editorButton1.Appearance = appearance2;
            this.utecDepName.ButtonsRight.Add(editorButton1);
            this.utecDepName.Location = new System.Drawing.Point(157, 101);
            this.utecDepName.Name = "utecDepName";
            this.utecDepName.ReadOnly = true;
            this.utecDepName.Size = new System.Drawing.Size(142, 21);
            this.utecDepName.TabIndex = 147;
            this.utecDepName.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.utecDepName_EditorButtonClick);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(99, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 146;
            this.label6.Text = "送货单位";
            // 
            // dtpDeliveryDate
            // 
            this.dtpDeliveryDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpDeliveryDate.Checked = false;
            this.dtpDeliveryDate.Location = new System.Drawing.Point(742, 66);
            this.dtpDeliveryDate.Name = "dtpDeliveryDate";
            this.dtpDeliveryDate.ShowCheckBox = true;
            this.dtpDeliveryDate.Size = new System.Drawing.Size(142, 21);
            this.dtpDeliveryDate.TabIndex = 142;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(686, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 141;
            this.label4.Text = "送货日期";
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpOrderDate.Location = new System.Drawing.Point(435, 66);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(142, 21);
            this.dtpOrderDate.TabIndex = 140;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(379, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 139;
            this.label2.Text = "定货日期";
            // 
            // cbxcOrderType
            // 
            this.cbxcOrderType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbxcOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxcOrderType.FormattingEnabled = true;
            this.cbxcOrderType.Items.AddRange(new object[] {
            "领料",
            "销售"});
            this.cbxcOrderType.Location = new System.Drawing.Point(435, 30);
            this.cbxcOrderType.Name = "cbxcOrderType";
            this.cbxcOrderType.Size = new System.Drawing.Size(142, 20);
            this.cbxcOrderType.TabIndex = 138;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(379, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 137;
            this.label3.Text = "订单类型";
            // 
            // utxtcCusName
            // 
            this.utxtcCusName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            appearance3.Image = global::JWMSH.Properties.Resources.search_tool;
            editorButton2.Appearance = appearance3;
            this.utxtcCusName.ButtonsRight.Add(editorButton2);
            this.utxtcCusName.Location = new System.Drawing.Point(742, 30);
            this.utxtcCusName.Name = "utxtcCusName";
            this.utxtcCusName.ReadOnly = true;
            this.utxtcCusName.Size = new System.Drawing.Size(142, 21);
            this.utxtcCusName.TabIndex = 134;
            this.utxtcCusName.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.utxtcCusName_EditorButtonClick);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(686, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 133;
            this.label5.Text = "客    户";
            // 
            // dtpdDate
            // 
            this.dtpdDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpdDate.Location = new System.Drawing.Point(157, 66);
            this.dtpdDate.Name = "dtpdDate";
            this.dtpdDate.Size = new System.Drawing.Size(142, 21);
            this.dtpdDate.TabIndex = 130;
            // 
            // lblAutoID
            // 
            this.lblAutoID.AutoSize = true;
            this.lblAutoID.ForeColor = System.Drawing.Color.Red;
            this.lblAutoID.Location = new System.Drawing.Point(43, 38);
            this.lblAutoID.Name = "lblAutoID";
            this.lblAutoID.Size = new System.Drawing.Size(0, 12);
            this.lblAutoID.TabIndex = 128;
            this.lblAutoID.Visible = false;
            // 
            // txtcMemo
            // 
            this.txtcMemo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtcMemo.Enabled = false;
            this.txtcMemo.Location = new System.Drawing.Point(157, 126);
            this.txtcMemo.MaxLength = 255;
            this.txtcMemo.Multiline = true;
            this.txtcMemo.Name = "txtcMemo";
            this.txtcMemo.Size = new System.Drawing.Size(787, 39);
            this.txtcMemo.TabIndex = 127;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(99, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 126;
            this.label8.Text = "出库备注";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 122;
            this.label1.Text = "拣货日期";
            // 
            // txtcCode
            // 
            this.txtcCode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtcCode.Enabled = false;
            this.txtcCode.Location = new System.Drawing.Point(157, 30);
            this.txtcCode.Name = "txtcCode";
            this.txtcCode.ReadOnly = true;
            this.txtcCode.Size = new System.Drawing.Size(142, 21);
            this.txtcCode.TabIndex = 121;
            // 
            // lblcRNo
            // 
            this.lblcRNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblcRNo.AutoSize = true;
            this.lblcRNo.Location = new System.Drawing.Point(99, 34);
            this.lblcRNo.Name = "lblcRNo";
            this.lblcRNo.Size = new System.Drawing.Size(53, 12);
            this.lblcRNo.TabIndex = 120;
            this.lblcRNo.Text = "指令单号";
            // 
            // uGridProDeliveryDetail
            // 
            this.uGridProDeliveryDetail.DataSource = this.proDeliveryDetailBindingSource;
            appearance4.BackColor = System.Drawing.Color.White;
            this.uGridProDeliveryDetail.DisplayLayout.Appearance = appearance4;
            this.uGridProDeliveryDetail.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn3.Header.Caption = "标识";
            ultraGridColumn3.Header.VisiblePosition = 0;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn18.Header.VisiblePosition = 2;
            ultraGridColumn41.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn41.Header.Caption = "拣货单号";
            ultraGridColumn41.Header.VisiblePosition = 5;
            ultraGridColumn41.Hidden = true;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn4.Header.Caption = "批号";
            ultraGridColumn4.Header.VisiblePosition = 6;
            ultraGridColumn4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            ultraGridColumn4.Width = 93;
            ultraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn15.Header.Caption = "产品编码";
            ultraGridColumn15.Header.VisiblePosition = 3;
            ultraGridColumn15.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            ultraGridColumn15.Width = 88;
            ultraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn16.Header.Caption = "产品名称";
            ultraGridColumn16.Header.VisiblePosition = 4;
            ultraGridColumn16.Width = 85;
            ultraGridColumn42.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn42.Header.Caption = "实发数量";
            ultraGridColumn42.Header.VisiblePosition = 7;
            ultraGridColumn42.MaskInput = "nnnnnnnn";
            ultraGridColumn42.Width = 78;
            ultraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn19.Header.VisiblePosition = 8;
            ultraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn20.Header.VisiblePosition = 9;
            ultraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn21.Header.VisiblePosition = 10;
            ultraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn23.Header.VisiblePosition = 11;
            ultraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn22.Header.Caption = "备注";
            ultraGridColumn22.Header.VisiblePosition = 12;
            ultraGridColumn22.Width = 220;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn3,
            ultraGridColumn2,
            ultraGridColumn18,
            ultraGridColumn41,
            ultraGridColumn4,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn42,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn23,
            ultraGridColumn22});
            this.uGridProDeliveryDetail.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.uGridProDeliveryDetail.DisplayLayout.GroupByBox.Prompt = "如需按照某个列进行分类汇总请把列名拖动到此处";
            this.uGridProDeliveryDetail.DisplayLayout.MaxColScrollRegions = 1;
            this.uGridProDeliveryDetail.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.Color.Transparent;
            this.uGridProDeliveryDetail.DisplayLayout.Override.CardAreaAppearance = appearance5;
            this.uGridProDeliveryDetail.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.uGridProDeliveryDetail.DisplayLayout.Override.CellPadding = 3;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.TextHAlignAsString = "Center";
            appearance6.TextVAlignAsString = "Middle";
            appearance6.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGridProDeliveryDetail.DisplayLayout.Override.HeaderAppearance = appearance6;
            this.uGridProDeliveryDetail.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.uGridProDeliveryDetail.DisplayLayout.Override.RowAlternateAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Black;
            appearance8.TextHAlignAsString = "Right";
            appearance8.TextVAlignAsString = "Middle";
            this.uGridProDeliveryDetail.DisplayLayout.Override.RowAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            appearance9.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGridProDeliveryDetail.DisplayLayout.Override.RowSelectorAppearance = appearance9;
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            appearance10.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGridProDeliveryDetail.DisplayLayout.Override.RowSelectorHeaderAppearance = appearance10;
            this.uGridProDeliveryDetail.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton;
            this.uGridProDeliveryDetail.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            this.uGridProDeliveryDetail.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.uGridProDeliveryDetail.DisplayLayout.Override.RowSelectorWidth = 40;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            appearance11.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance11.BorderColor = System.Drawing.Color.Black;
            appearance11.ForeColor = System.Drawing.Color.Black;
            this.uGridProDeliveryDetail.DisplayLayout.Override.SelectedRowAppearance = appearance11;
            this.uGridProDeliveryDetail.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.uGridProDeliveryDetail.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.uGridProDeliveryDetail.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.uGridProDeliveryDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uGridProDeliveryDetail.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uGridProDeliveryDetail.Location = new System.Drawing.Point(0, 349);
            this.uGridProDeliveryDetail.Name = "uGridProDeliveryDetail";
            this.uGridProDeliveryDetail.Size = new System.Drawing.Size(984, 213);
            this.uGridProDeliveryDetail.TabIndex = 19;
            this.uGridProDeliveryDetail.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus;
            // 
            // proDeliveryDetailBindingSource
            // 
            this.proDeliveryDetailBindingSource.DataMember = "ProDeliveryDetail";
            this.proDeliveryDetailBindingSource.DataSource = this.dataBiDetail;
            // 
            // dataBiDetail
            // 
            this.dataBiDetail.DataSetName = "DataBiDetail";
            this.dataBiDetail.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tsgfMain
            // 
            this.tsgfMain.Constr = null;
            this.tsgfMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tsgfMain.FormId = null;
            this.tsgfMain.FormName = null;
            this.tsgfMain.Location = new System.Drawing.Point(0, 324);
            this.tsgfMain.Name = "tsgfMain";
            this.tsgfMain.Size = new System.Drawing.Size(984, 25);
            this.tsgfMain.TabIndex = 20;
            this.tsgfMain.UGrid = this.uGridProDeliveryDetail;
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.ExpandCollapseItem.Name = "";
            this.ribbon.Images = this.imageCollection3;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.bsiPrint,
            this.biExport,
            this.biSave,
            this.biPrint,
            this.biAddNew,
            this.biExit,
            this.biEdit,
            this.biDelete,
            this.biEditTemplet,
            this.bsiTemplet,
            this.biGiveup,
            this.bsiPrinter,
            this.biEditPrinter,
            this.biPreview,
            this.biDesign,
            this.biAppprove});
            this.ribbon.LargeImages = this.imageCollection4;
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 83;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowCategoryInCaption = false;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbon.Size = new System.Drawing.Size(984, 98);
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // imageCollection3
            // 
            this.imageCollection3.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection3.ImageStream")));
            this.imageCollection3.InsertImage(global::JWMSH.Properties.Resources.design, "design", typeof(global::JWMSH.Properties.Resources), 0);
            this.imageCollection3.Images.SetKeyName(0, "design");
            this.imageCollection3.InsertImage(global::JWMSH.Properties.Resources.preview, "preview", typeof(global::JWMSH.Properties.Resources), 1);
            this.imageCollection3.Images.SetKeyName(1, "preview");
            this.imageCollection3.InsertImage(global::JWMSH.Properties.Resources.print, "print", typeof(global::JWMSH.Properties.Resources), 2);
            this.imageCollection3.Images.SetKeyName(2, "print");
            // 
            // bsiPrint
            // 
            this.bsiPrint.Caption = "打印";
            this.bsiPrint.Id = 2;
            this.bsiPrint.LargeImageIndex = 7;
            this.bsiPrint.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.biPreview),
            new DevExpress.XtraBars.LinkPersistInfo(this.biDesign)});
            this.bsiPrint.Name = "bsiPrint";
            this.bsiPrint.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // biPrint
            // 
            this.biPrint.Caption = "打印";
            this.biPrint.Id = 55;
            this.biPrint.ImageIndex = 2;
            this.biPrint.Name = "biPrint";
            // 
            // biPreview
            // 
            this.biPreview.Caption = "预览";
            this.biPreview.Id = 79;
            this.biPreview.ImageIndex = 1;
            this.biPreview.Name = "biPreview";
            // 
            // biDesign
            // 
            this.biDesign.Caption = "设计";
            this.biDesign.Id = 80;
            this.biDesign.ImageIndex = 0;
            this.biDesign.Name = "biDesign";
            // 
            // biExport
            // 
            this.biExport.Caption = "输出";
            this.biExport.Id = 3;
            this.biExport.LargeImageIndex = 5;
            this.biExport.Name = "biExport";
            this.biExport.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // biSave
            // 
            this.biSave.Caption = "保存";
            this.biSave.Enabled = false;
            this.biSave.Id = 46;
            this.biSave.LargeImageIndex = 8;
            this.biSave.Name = "biSave";
            this.biSave.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.biSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biSave_ItemClick);
            // 
            // biAddNew
            // 
            this.biAddNew.Caption = "新增";
            this.biAddNew.Id = 58;
            this.biAddNew.LargeImageIndex = 1;
            this.biAddNew.Name = "biAddNew";
            this.biAddNew.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.biAddNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biAddNew_ItemClick);
            // 
            // biExit
            // 
            this.biExit.Caption = "退出";
            this.biExit.Id = 62;
            this.biExit.LargeImageIndex = 4;
            this.biExit.Name = "biExit";
            // 
            // biEdit
            // 
            this.biEdit.Caption = "修改";
            this.biEdit.Id = 67;
            this.biEdit.LargeImageIndex = 2;
            this.biEdit.Name = "biEdit";
            this.biEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biEdit_ItemClick);
            // 
            // biDelete
            // 
            this.biDelete.Caption = "删除";
            this.biDelete.Id = 68;
            this.biDelete.LargeImageIndex = 9;
            this.biDelete.Name = "biDelete";
            this.biDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biDelete_ItemClick);
            // 
            // biEditTemplet
            // 
            this.biEditTemplet.Caption = "原料标准模版";
            this.biEditTemplet.Id = 70;
            this.biEditTemplet.ItemAppearance.Disabled.ForeColor = System.Drawing.Color.Blue;
            this.biEditTemplet.ItemAppearance.Disabled.Options.UseForeColor = true;
            this.biEditTemplet.Name = "biEditTemplet";
            // 
            // bsiTemplet
            // 
            this.bsiTemplet.Caption = "当前模版如下";
            this.bsiTemplet.Id = 72;
            this.bsiTemplet.Name = "bsiTemplet";
            this.bsiTemplet.TextAlignment = System.Drawing.StringAlignment.Near;
            this.bsiTemplet.Width = 100;
            // 
            // biGiveup
            // 
            this.biGiveup.Caption = "放弃";
            this.biGiveup.Enabled = false;
            this.biGiveup.Id = 73;
            this.biGiveup.LargeImageIndex = 6;
            this.biGiveup.Name = "biGiveup";
            this.biGiveup.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.biGiveup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biGiveup_ItemClick);
            // 
            // bsiPrinter
            // 
            this.bsiPrinter.Caption = "当前打印机";
            this.bsiPrinter.Id = 74;
            this.bsiPrinter.Name = "bsiPrinter";
            this.bsiPrinter.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // biEditPrinter
            // 
            this.biEditPrinter.Caption = "ZM4001";
            this.biEditPrinter.Id = 75;
            this.biEditPrinter.Name = "biEditPrinter";
            // 
            // biAppprove
            // 
            this.biAppprove.Caption = "审核导入";
            this.biAppprove.Id = 82;
            this.biAppprove.LargeImageIndex = 3;
            this.biAppprove.Name = "biAppprove";
            // 
            // imageCollection4
            // 
            this.imageCollection4.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection4.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection4.ImageStream")));
            this.imageCollection4.InsertImage(global::JWMSH.Properties.Resources.abandon, "abandon", typeof(global::JWMSH.Properties.Resources), 0);
            this.imageCollection4.Images.SetKeyName(0, "abandon");
            this.imageCollection4.InsertImage(global::JWMSH.Properties.Resources.add, "add", typeof(global::JWMSH.Properties.Resources), 1);
            this.imageCollection4.Images.SetKeyName(1, "add");
            this.imageCollection4.InsertImage(global::JWMSH.Properties.Resources.edit, "edit", typeof(global::JWMSH.Properties.Resources), 2);
            this.imageCollection4.Images.SetKeyName(2, "edit");
            this.imageCollection4.InsertImage(global::JWMSH.Properties.Resources.examin, "examin", typeof(global::JWMSH.Properties.Resources), 3);
            this.imageCollection4.Images.SetKeyName(3, "examin");
            this.imageCollection4.InsertImage(global::JWMSH.Properties.Resources.exit, "exit", typeof(global::JWMSH.Properties.Resources), 4);
            this.imageCollection4.Images.SetKeyName(4, "exit");
            this.imageCollection4.InsertImage(global::JWMSH.Properties.Resources.ExportDialog, "ExportDialog", typeof(global::JWMSH.Properties.Resources), 5);
            this.imageCollection4.Images.SetKeyName(5, "ExportDialog");
            this.imageCollection4.InsertImage(global::JWMSH.Properties.Resources.giveup, "giveup", typeof(global::JWMSH.Properties.Resources), 6);
            this.imageCollection4.Images.SetKeyName(6, "giveup");
            this.imageCollection4.InsertImage(global::JWMSH.Properties.Resources.printDialog, "printDialog", typeof(global::JWMSH.Properties.Resources), 7);
            this.imageCollection4.Images.SetKeyName(7, "printDialog");
            this.imageCollection4.InsertImage(global::JWMSH.Properties.Resources.save, "save", typeof(global::JWMSH.Properties.Resources), 8);
            this.imageCollection4.Images.SetKeyName(8, "save");
            this.imageCollection4.InsertImage(global::JWMSH.Properties.Resources.delete1, "delete1", typeof(global::JWMSH.Properties.Resources), 9);
            this.imageCollection4.Images.SetKeyName(9, "delete1");
            // 
            // ribbonPage
            // 
            this.ribbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgSystem,
            this.rpgExport,
            this.rpgNew,
            this.rpgTemplet,
            this.rpgPrinter});
            this.ribbonPage.Name = "ribbonPage";
            this.ribbonPage.Text = "菜单选项";
            // 
            // rpgSystem
            // 
            this.rpgSystem.ItemLinks.Add(this.biExit);
            this.rpgSystem.Name = "rpgSystem";
            this.rpgSystem.ShowCaptionButton = false;
            this.rpgSystem.Text = "系统";
            // 
            // rpgExport
            // 
            this.rpgExport.ItemLinks.Add(this.bsiPrint);
            this.rpgExport.ItemLinks.Add(this.biExport);
            this.rpgExport.Name = "rpgExport";
            this.rpgExport.ShowCaptionButton = false;
            this.rpgExport.Text = "处理";
            // 
            // rpgNew
            // 
            this.rpgNew.ItemLinks.Add(this.biAddNew);
            this.rpgNew.ItemLinks.Add(this.biEdit);
            this.rpgNew.ItemLinks.Add(this.biGiveup);
            this.rpgNew.ItemLinks.Add(this.biSave);
            this.rpgNew.ItemLinks.Add(this.biDelete);
            this.rpgNew.ItemLinks.Add(this.biAppprove);
            this.rpgNew.Name = "rpgNew";
            this.rpgNew.ShowCaptionButton = false;
            this.rpgNew.Text = "操作";
            // 
            // rpgTemplet
            // 
            this.rpgTemplet.ItemLinks.Add(this.bsiTemplet);
            this.rpgTemplet.ItemLinks.Add(this.biEditTemplet);
            this.rpgTemplet.Name = "rpgTemplet";
            this.rpgTemplet.Text = "打印模版";
            // 
            // rpgPrinter
            // 
            this.rpgPrinter.ItemLinks.Add(this.bsiPrinter);
            this.rpgPrinter.ItemLinks.Add(this.biEditPrinter);
            this.rpgPrinter.Name = "rpgPrinter";
            this.rpgPrinter.Text = "打印机属性";
            // 
            // proDeliveryDetailTableAdapter
            // 
            this.proDeliveryDetailTableAdapter.ClearBeforeFill = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(862, 50);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 141;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(866, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 140;
            this.label7.Text = "指令单号：";
            // 
            // txtQuery
            // 
            this.txtQuery.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.txtQuery.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            this.txtQuery.Location = new System.Drawing.Point(820, 29);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(159, 21);
            this.txtQuery.TabIndex = 139;
            // 
            // WorkTrackDeliveryOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.uGridProDeliveryDetail);
            this.Controls.Add(this.tsgfMain);
            this.Controls.Add(this.ugbxMain);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.ribbon);
            this.Icon = global::JWMSH.Properties.Resources.scanicon;
            this.Name = "WorkTrackDeliveryOrder";
            this.Text = "产成品出库指令单";
            this.Load += new System.EventHandler(this.WorkTrackDeliveryOrder_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugbxMain)).EndInit();
            this.ugbxMain.ResumeLayout(false);
            this.ugbxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.utecDepName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.utxtcCusName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGridProDeliveryDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proDeliveryDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBiDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuery)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private Infragistics.Win.Misc.UltraLabel lblcState;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Label lblTitle;
        private Infragistics.Win.Misc.UltraGroupBox ugbxMain;
        private System.Windows.Forms.DateTimePicker dtpDeliveryDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxcOrderType;
        private System.Windows.Forms.Label label3;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor utxtcCusName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpdDate;
        private System.Windows.Forms.Label lblAutoID;
        private System.Windows.Forms.TextBox txtcMemo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtcCode;
        private System.Windows.Forms.Label lblcRNo;
        private Infragistics.Win.UltraWinGrid.UltraGrid uGridProDeliveryDetail;
        private UpjdControlBox.ToolStripGridFunction tsgfMain;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.Utils.ImageCollection imageCollection3;
        private DevExpress.XtraBars.BarSubItem bsiPrint;
        private DevExpress.XtraBars.BarButtonItem biPrint;
        private DevExpress.XtraBars.BarButtonItem biPreview;
        private DevExpress.XtraBars.BarButtonItem biDesign;
        private DevExpress.XtraBars.BarButtonItem biExport;
        private DevExpress.XtraBars.BarButtonItem biSave;
        private DevExpress.XtraBars.BarButtonItem biAddNew;
        private DevExpress.XtraBars.BarButtonItem biExit;
        private DevExpress.XtraBars.BarButtonItem biEdit;
        private DevExpress.XtraBars.BarButtonItem biDelete;
        private DevExpress.XtraBars.BarButtonItem biEditTemplet;
        private DevExpress.XtraBars.BarStaticItem bsiTemplet;
        private DevExpress.XtraBars.BarButtonItem biGiveup;
        private DevExpress.XtraBars.BarStaticItem bsiPrinter;
        private DevExpress.XtraBars.BarButtonItem biEditPrinter;
        private DevExpress.Utils.ImageCollection imageCollection4;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgSystem;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgExport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgNew;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgTemplet;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgPrinter;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor utecDepName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource proDeliveryDetailBindingSource;
        private DLL.DataBiDetail dataBiDetail;
        private DLL.DataBiDetailTableAdapters.ProDeliveryDetailTableAdapter proDeliveryDetailTableAdapter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label7;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor txtQuery;
        private DevExpress.XtraBars.BarButtonItem biAppprove;
    }
}