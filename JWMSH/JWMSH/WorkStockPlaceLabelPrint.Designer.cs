namespace JWMSH
{
    partial class WorkStockPlaceLabelPrint
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("t_StockPlace", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FSPID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FNumber");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FFullName");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkStockPlaceLabelPrint));
            this.uGridCheck = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.tStockPlaceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataKis = new JWMSH.DLL.DataKis();
            this.tsgfMain = new UpjdControlBox.ToolStripGridFunction();
            this.ImgCollection16 = new DevExpress.Utils.ImageCollection(this.components);
            this.ImgCollection32 = new DevExpress.Utils.ImageCollection(this.components);
            this.t_StockPlaceTableAdapter = new JWMSH.DLL.DataKisTableAdapters.t_StockPlaceTableAdapter();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.bsiPrint = new DevExpress.XtraBars.BarSubItem();
            this.biPrint = new DevExpress.XtraBars.BarButtonItem();
            this.biPreview = new DevExpress.XtraBars.BarButtonItem();
            this.biDesign = new DevExpress.XtraBars.BarButtonItem();
            this.biExport = new DevExpress.XtraBars.BarButtonItem();
            this.biAddNew = new DevExpress.XtraBars.BarButtonItem();
            this.biExit = new DevExpress.XtraBars.BarButtonItem();
            this.biDelete = new DevExpress.XtraBars.BarButtonItem();
            this.biEditTemplet = new DevExpress.XtraBars.BarButtonItem();
            this.bsiTemplet = new DevExpress.XtraBars.BarStaticItem();
            this.bsiPrinter = new DevExpress.XtraBars.BarStaticItem();
            this.biEditPrinter = new DevExpress.XtraBars.BarButtonItem();
            this.beiCopies = new DevExpress.XtraBars.BarEditItem();
            this.imageCollection2 = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgSystem = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgExport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgTemplet = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgPrinter = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.uGridCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tStockPlaceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataKis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgCollection16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgCollection32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).BeginInit();
            this.SuspendLayout();
            // 
            // uGridCheck
            // 
            this.uGridCheck.DataSource = this.tStockPlaceBindingSource;
            appearance1.BackColor = System.Drawing.Color.White;
            this.uGridCheck.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.Header.Caption = "金蝶ID";
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.Caption = "仓位编码";
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 176;
            ultraGridColumn3.Header.Caption = "仓位名称";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Width = 212;
            ultraGridColumn4.Header.Caption = "仓位全称";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Width = 358;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4});
            this.uGridCheck.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.uGridCheck.DisplayLayout.GroupByBox.Prompt = "如需按照某个列进行分类汇总请把列名拖动到此处";
            this.uGridCheck.DisplayLayout.MaxColScrollRegions = 1;
            this.uGridCheck.DisplayLayout.MaxRowScrollRegions = 1;
            this.uGridCheck.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.uGridCheck.DisplayLayout.Override.CardAreaAppearance = appearance2;
            this.uGridCheck.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.uGridCheck.DisplayLayout.Override.CellPadding = 3;
            this.uGridCheck.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.TextHAlignAsString = "Center";
            appearance3.TextVAlignAsString = "Middle";
            appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGridCheck.DisplayLayout.Override.HeaderAppearance = appearance3;
            this.uGridCheck.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.uGridCheck.DisplayLayout.Override.RowAlternateAppearance = appearance4;
            appearance5.BorderColor = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Right";
            appearance5.TextVAlignAsString = "Middle";
            this.uGridCheck.DisplayLayout.Override.RowAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGridCheck.DisplayLayout.Override.RowSelectorAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGridCheck.DisplayLayout.Override.RowSelectorHeaderAppearance = appearance7;
            this.uGridCheck.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton;
            this.uGridCheck.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            this.uGridCheck.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.uGridCheck.DisplayLayout.Override.RowSelectorWidth = 40;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            appearance8.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance8.BorderColor = System.Drawing.Color.Black;
            appearance8.ForeColor = System.Drawing.Color.Black;
            this.uGridCheck.DisplayLayout.Override.SelectedRowAppearance = appearance8;
            this.uGridCheck.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.uGridCheck.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.uGridCheck.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.uGridCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uGridCheck.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uGridCheck.Location = new System.Drawing.Point(0, 123);
            this.uGridCheck.Name = "uGridCheck";
            this.uGridCheck.Size = new System.Drawing.Size(984, 439);
            this.uGridCheck.TabIndex = 59;
            this.uGridCheck.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus;
            // 
            // tStockPlaceBindingSource
            // 
            this.tStockPlaceBindingSource.DataMember = "t_StockPlace";
            this.tStockPlaceBindingSource.DataSource = this.dataKis;
            // 
            // dataKis
            // 
            this.dataKis.DataSetName = "DataKis";
            this.dataKis.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tsgfMain
            // 
            this.tsgfMain.Constr = null;
            this.tsgfMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tsgfMain.FormId = null;
            this.tsgfMain.FormName = null;
            this.tsgfMain.Location = new System.Drawing.Point(0, 98);
            this.tsgfMain.Name = "tsgfMain";
            this.tsgfMain.Size = new System.Drawing.Size(984, 25);
            this.tsgfMain.TabIndex = 58;
            this.tsgfMain.UGrid = this.uGridCheck;
            // 
            // ImgCollection16
            // 
            this.ImgCollection16.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ImgCollection16.ImageStream")));
            this.ImgCollection16.InsertImage(global::JWMSH.Properties.Resources.design, "design", typeof(global::JWMSH.Properties.Resources), 0);
            this.ImgCollection16.Images.SetKeyName(0, "design");
            this.ImgCollection16.InsertImage(global::JWMSH.Properties.Resources.preview, "preview", typeof(global::JWMSH.Properties.Resources), 1);
            this.ImgCollection16.Images.SetKeyName(1, "preview");
            this.ImgCollection16.InsertImage(global::JWMSH.Properties.Resources.print, "print", typeof(global::JWMSH.Properties.Resources), 2);
            this.ImgCollection16.Images.SetKeyName(2, "print");
            this.ImgCollection16.InsertImage(global::JWMSH.Properties.Resources.search, "search", typeof(global::JWMSH.Properties.Resources), 3);
            this.ImgCollection16.Images.SetKeyName(3, "search");
            // 
            // ImgCollection32
            // 
            this.ImgCollection32.ImageSize = new System.Drawing.Size(32, 32);
            this.ImgCollection32.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ImgCollection32.ImageStream")));
            this.ImgCollection32.InsertImage(global::JWMSH.Properties.Resources.abandon, "abandon", typeof(global::JWMSH.Properties.Resources), 0);
            this.ImgCollection32.Images.SetKeyName(0, "abandon");
            this.ImgCollection32.InsertImage(global::JWMSH.Properties.Resources.add, "add", typeof(global::JWMSH.Properties.Resources), 1);
            this.ImgCollection32.Images.SetKeyName(1, "add");
            this.ImgCollection32.InsertImage(global::JWMSH.Properties.Resources.edit, "edit", typeof(global::JWMSH.Properties.Resources), 2);
            this.ImgCollection32.Images.SetKeyName(2, "edit");
            this.ImgCollection32.InsertImage(global::JWMSH.Properties.Resources.examin, "examin", typeof(global::JWMSH.Properties.Resources), 3);
            this.ImgCollection32.Images.SetKeyName(3, "examin");
            this.ImgCollection32.InsertImage(global::JWMSH.Properties.Resources.exit, "exit", typeof(global::JWMSH.Properties.Resources), 4);
            this.ImgCollection32.Images.SetKeyName(4, "exit");
            this.ImgCollection32.InsertImage(global::JWMSH.Properties.Resources.ExportDialog, "ExportDialog", typeof(global::JWMSH.Properties.Resources), 5);
            this.ImgCollection32.Images.SetKeyName(5, "ExportDialog");
            this.ImgCollection32.InsertImage(global::JWMSH.Properties.Resources.giveup, "giveup", typeof(global::JWMSH.Properties.Resources), 6);
            this.ImgCollection32.Images.SetKeyName(6, "giveup");
            this.ImgCollection32.InsertImage(global::JWMSH.Properties.Resources.printDialog, "printDialog", typeof(global::JWMSH.Properties.Resources), 7);
            this.ImgCollection32.Images.SetKeyName(7, "printDialog");
            this.ImgCollection32.InsertImage(global::JWMSH.Properties.Resources.save, "save", typeof(global::JWMSH.Properties.Resources), 8);
            this.ImgCollection32.Images.SetKeyName(8, "save");
            this.ImgCollection32.Images.SetKeyName(9, "Query.png");
            this.ImgCollection32.InsertImage(global::JWMSH.Properties.Resources.cRefresh, "cRefresh", typeof(global::JWMSH.Properties.Resources), 10);
            this.ImgCollection32.Images.SetKeyName(10, "cRefresh");
            // 
            // t_StockPlaceTableAdapter
            // 
            this.t_StockPlaceTableAdapter.ClearBeforeFill = true;
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.ExpandCollapseItem.Name = "";
            this.ribbon.Images = this.imageCollection1;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.bsiPrint,
            this.biExport,
            this.biPrint,
            this.biAddNew,
            this.biExit,
            this.biDelete,
            this.biEditTemplet,
            this.bsiTemplet,
            this.bsiPrinter,
            this.biEditPrinter,
            this.beiCopies,
            this.biPreview,
            this.biDesign});
            this.ribbon.LargeImages = this.imageCollection2;
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 81;
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
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertImage(global::JWMSH.Properties.Resources.design, "design", typeof(global::JWMSH.Properties.Resources), 0);
            this.imageCollection1.Images.SetKeyName(0, "design");
            this.imageCollection1.InsertImage(global::JWMSH.Properties.Resources.preview, "preview", typeof(global::JWMSH.Properties.Resources), 1);
            this.imageCollection1.Images.SetKeyName(1, "preview");
            this.imageCollection1.InsertImage(global::JWMSH.Properties.Resources.print, "print", typeof(global::JWMSH.Properties.Resources), 2);
            this.imageCollection1.Images.SetKeyName(2, "print");
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
            this.biPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biPrint_ItemClick);
            // 
            // biPreview
            // 
            this.biPreview.Caption = "预览";
            this.biPreview.Id = 79;
            this.biPreview.ImageIndex = 1;
            this.biPreview.Name = "biPreview";
            this.biPreview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biPreview_ItemClick);
            // 
            // biDesign
            // 
            this.biDesign.Caption = "设计";
            this.biDesign.Id = 80;
            this.biDesign.ImageIndex = 0;
            this.biDesign.Name = "biDesign";
            this.biDesign.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biDesign_ItemClick);
            // 
            // biExport
            // 
            this.biExport.Caption = "输出";
            this.biExport.Id = 3;
            this.biExport.LargeImageIndex = 5;
            this.biExport.Name = "biExport";
            this.biExport.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.biExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biExport_ItemClick);
            // 
            // biAddNew
            // 
            this.biAddNew.Caption = "新增";
            this.biAddNew.Id = 58;
            this.biAddNew.LargeImageIndex = 1;
            this.biAddNew.Name = "biAddNew";
            this.biAddNew.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // biExit
            // 
            this.biExit.Caption = "退出";
            this.biExit.Id = 62;
            this.biExit.LargeImageIndex = 4;
            this.biExit.Name = "biExit";
            this.biExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biExit_ItemClick);
            // 
            // biDelete
            // 
            this.biDelete.Caption = "删除";
            this.biDelete.Id = 68;
            this.biDelete.LargeImageIndex = 9;
            this.biDelete.Name = "biDelete";
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
            // beiCopies
            // 
            this.beiCopies.Caption = "份数";
            this.beiCopies.Edit = null;
            this.beiCopies.Id = 76;
            this.beiCopies.Name = "beiCopies";
            this.beiCopies.Width = 100;
            // 
            // imageCollection2
            // 
            this.imageCollection2.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection2.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection2.ImageStream")));
            this.imageCollection2.InsertImage(global::JWMSH.Properties.Resources.abandon, "abandon", typeof(global::JWMSH.Properties.Resources), 0);
            this.imageCollection2.Images.SetKeyName(0, "abandon");
            this.imageCollection2.InsertImage(global::JWMSH.Properties.Resources.add, "add", typeof(global::JWMSH.Properties.Resources), 1);
            this.imageCollection2.Images.SetKeyName(1, "add");
            this.imageCollection2.InsertImage(global::JWMSH.Properties.Resources.edit, "edit", typeof(global::JWMSH.Properties.Resources), 2);
            this.imageCollection2.Images.SetKeyName(2, "edit");
            this.imageCollection2.InsertImage(global::JWMSH.Properties.Resources.examin, "examin", typeof(global::JWMSH.Properties.Resources), 3);
            this.imageCollection2.Images.SetKeyName(3, "examin");
            this.imageCollection2.InsertImage(global::JWMSH.Properties.Resources.exit, "exit", typeof(global::JWMSH.Properties.Resources), 4);
            this.imageCollection2.Images.SetKeyName(4, "exit");
            this.imageCollection2.InsertImage(global::JWMSH.Properties.Resources.ExportDialog, "ExportDialog", typeof(global::JWMSH.Properties.Resources), 5);
            this.imageCollection2.Images.SetKeyName(5, "ExportDialog");
            this.imageCollection2.InsertImage(global::JWMSH.Properties.Resources.giveup, "giveup", typeof(global::JWMSH.Properties.Resources), 6);
            this.imageCollection2.Images.SetKeyName(6, "giveup");
            this.imageCollection2.InsertImage(global::JWMSH.Properties.Resources.printDialog, "printDialog", typeof(global::JWMSH.Properties.Resources), 7);
            this.imageCollection2.Images.SetKeyName(7, "printDialog");
            this.imageCollection2.InsertImage(global::JWMSH.Properties.Resources.save, "save", typeof(global::JWMSH.Properties.Resources), 8);
            this.imageCollection2.Images.SetKeyName(8, "save");
            this.imageCollection2.InsertImage(global::JWMSH.Properties.Resources.delete1, "delete1", typeof(global::JWMSH.Properties.Resources), 9);
            this.imageCollection2.Images.SetKeyName(9, "delete1");
            // 
            // ribbonPage
            // 
            this.ribbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgSystem,
            this.rpgExport,
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
            this.rpgPrinter.ItemLinks.Add(this.beiCopies);
            this.rpgPrinter.Name = "rpgPrinter";
            this.rpgPrinter.Text = "打印机属性";
            // 
            // WorkStockPlaceLabelPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.uGridCheck);
            this.Controls.Add(this.tsgfMain);
            this.Controls.Add(this.ribbon);
            this.Icon = global::JWMSH.Properties.Resources.scanicon;
            this.Name = "WorkStockPlaceLabelPrint";
            this.Text = "仓位标签打印";
            this.Load += new System.EventHandler(this.WorkStockPlaceLabelPrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uGridCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tStockPlaceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataKis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgCollection16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgCollection32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid uGridCheck;
        private UpjdControlBox.ToolStripGridFunction tsgfMain;
        private DevExpress.Utils.ImageCollection ImgCollection16;
        private DevExpress.Utils.ImageCollection ImgCollection32;
        private DLL.DataKis dataKis;
        private System.Windows.Forms.BindingSource tStockPlaceBindingSource;
        private DLL.DataKisTableAdapters.t_StockPlaceTableAdapter t_StockPlaceTableAdapter;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.BarSubItem bsiPrint;
        private DevExpress.XtraBars.BarButtonItem biPrint;
        private DevExpress.XtraBars.BarButtonItem biPreview;
        private DevExpress.XtraBars.BarButtonItem biDesign;
        private DevExpress.XtraBars.BarButtonItem biExport;
        private DevExpress.XtraBars.BarButtonItem biAddNew;
        private DevExpress.XtraBars.BarButtonItem biExit;
        private DevExpress.XtraBars.BarButtonItem biDelete;
        private DevExpress.XtraBars.BarButtonItem biEditTemplet;
        private DevExpress.XtraBars.BarStaticItem bsiTemplet;
        private DevExpress.XtraBars.BarStaticItem bsiPrinter;
        private DevExpress.XtraBars.BarButtonItem biEditPrinter;
        private DevExpress.XtraBars.BarEditItem beiCopies;
        private DevExpress.Utils.ImageCollection imageCollection2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgSystem;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgExport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgTemplet;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgPrinter;
    }
}