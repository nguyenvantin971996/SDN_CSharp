namespace Routing_Application.Forms
{
    partial class Main
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.ctlMainMenu = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuAlgorithms = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOptionsAutoWeight = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOptionsToolBar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOptionsFullMesh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOptionsCriterias = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOptionsCriteriasCapacity = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOptionsCriteriasLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOptionsCriteriasDelay = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOptionsCriteriasMetric = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOptionsConnectivity = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.ctlStatusBarGrid = new System.Windows.Forms.StatusStrip();
            this.lblGreed = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ctlTabControl = new System.Windows.Forms.TabControl();
            this.ctlContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextClose = new System.Windows.Forms.ToolStripMenuItem();
            this.ctlStatusBarStatus = new System.Windows.Forms.StatusStrip();
            this.lblInstrument = new System.Windows.Forms.ToolStripStatusLabel();
            this.ctlStatusBarFile = new System.Windows.Forms.StatusStrip();
            this.lblFieldSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRouters = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblWires = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ctlToolBar = new System.Windows.Forms.ToolStrip();
            this.btnToolNew = new System.Windows.Forms.ToolStripButton();
            this.btnToolOpen = new System.Windows.Forms.ToolStripButton();
            this.btnToolSave = new System.Windows.Forms.ToolStripButton();
            this.btnToolSaveAs = new System.Windows.Forms.ToolStripButton();
            this.btnToolEdit = new System.Windows.Forms.ToolStripButton();
            this.btnToolWire = new System.Windows.Forms.ToolStripButton();
            this.btnToolRouter = new System.Windows.Forms.ToolStripButton();
            this.btnToolTextLabel = new System.Windows.Forms.ToolStripButton();
            this.btnToolDeleteAll = new System.Windows.Forms.ToolStripButton();
            this.btnToolReset = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.menuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolsEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolsPutRouter = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolsInsertWire = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolsCreateText = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolsHorAlignment = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolsVertAlignment = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolsReset = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolsDeleteAll = new System.Windows.Forms.ToolStripMenuItem();
            this.GA = new System.Windows.Forms.ToolStripMenuItem();
            this.PSO = new System.Windows.Forms.ToolStripMenuItem();
            this.FA = new System.Windows.Forms.ToolStripMenuItem();
            this.ABC = new System.Windows.Forms.ToolStripMenuItem();
            this.ACO = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctlMainMenu.SuspendLayout();
            this.ctlStatusBarGrid.SuspendLayout();
            this.ctlContextMenu.SuspendLayout();
            this.ctlStatusBarStatus.SuspendLayout();
            this.ctlStatusBarFile.SuspendLayout();
            this.ctlToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctlMainMenu
            // 
            this.ctlMainMenu.BackColor = System.Drawing.Color.LightBlue;
            this.ctlMainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctlMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuTools,
            this.menuAlgorithms,
            this.menuOptions,
            this.menuHelp});
            this.ctlMainMenu.Location = new System.Drawing.Point(0, 0);
            this.ctlMainMenu.Name = "ctlMainMenu";
            this.ctlMainMenu.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.ctlMainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ctlMainMenu.Size = new System.Drawing.Size(1311, 54);
            this.ctlMainMenu.TabIndex = 0;
            this.ctlMainMenu.Text = "stripMainMenu";
            this.ctlMainMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ctlMainMenu_ItemClicked);
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileNew,
            this.menuFileOpen,
            this.menuFileSeparator1,
            this.menuFileSaveAs,
            this.menuFileSave,
            this.menuFileExit});
            this.menuFile.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(46, 50);
            this.menuFile.Text = "File";
            this.menuFile.DropDownOpening += new System.EventHandler(this.menuFile_DropDownOpening);
            // 
            // menuFileSeparator1
            // 
            this.menuFileSeparator1.Name = "menuFileSeparator1";
            this.menuFileSeparator1.Size = new System.Drawing.Size(142, 6);
            // 
            // menuTools
            // 
            this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolsEdit,
            this.menuToolsPutRouter,
            this.menuToolsInsertWire,
            this.menuToolsCreateText,
            this.toolStripSeparator3,
            this.menuToolsHorAlignment,
            this.menuToolsVertAlignment,
            this.toolStripMenuItem1,
            this.menuToolsReset,
            this.menuToolsDeleteAll});
            this.menuTools.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menuTools.Name = "menuTools";
            this.menuTools.Size = new System.Drawing.Size(57, 50);
            this.menuTools.Text = "Tools";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(223, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(223, 6);
            // 
            // menuAlgorithms
            // 
            this.menuAlgorithms.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GA,
            this.PSO,
            this.FA,
            this.ABC,
            this.ACO});
            this.menuAlgorithms.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menuAlgorithms.Name = "menuAlgorithms";
            this.menuAlgorithms.Size = new System.Drawing.Size(99, 50);
            this.menuAlgorithms.Text = "Algorithms";
            // 
            // menuOptions
            // 
            this.menuOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOptionsAutoWeight,
            this.menuOptionsToolBar,
            this.menuOptionsFullMesh,
            this.menuOptionsCriterias,
            this.menuOptionsConnectivity,
            this.generateToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.createPathToolStripMenuItem});
            this.menuOptions.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menuOptions.Name = "menuOptions";
            this.menuOptions.Size = new System.Drawing.Size(77, 50);
            this.menuOptions.Text = "Options";
            // 
            // menuOptionsAutoWeight
            // 
            this.menuOptionsAutoWeight.Checked = true;
            this.menuOptionsAutoWeight.CheckOnClick = true;
            this.menuOptionsAutoWeight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuOptionsAutoWeight.Name = "menuOptionsAutoWeight";
            this.menuOptionsAutoWeight.Size = new System.Drawing.Size(180, 26);
            this.menuOptionsAutoWeight.Text = "AutoWeight";
            this.menuOptionsAutoWeight.Click += new System.EventHandler(this.menuOptionsAutoWeight_Click);
            // 
            // menuOptionsToolBar
            // 
            this.menuOptionsToolBar.Checked = true;
            this.menuOptionsToolBar.CheckOnClick = true;
            this.menuOptionsToolBar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuOptionsToolBar.Name = "menuOptionsToolBar";
            this.menuOptionsToolBar.Size = new System.Drawing.Size(180, 26);
            this.menuOptionsToolBar.Text = "ToolBar";
            this.menuOptionsToolBar.Click += new System.EventHandler(this.MenuOptionsToolBar_Click);
            // 
            // menuOptionsFullMesh
            // 
            this.menuOptionsFullMesh.CheckOnClick = true;
            this.menuOptionsFullMesh.Name = "menuOptionsFullMesh";
            this.menuOptionsFullMesh.Size = new System.Drawing.Size(180, 26);
            this.menuOptionsFullMesh.Text = "FullMesh";
            this.menuOptionsFullMesh.Click += new System.EventHandler(this.menuOptionsFullMesh_Click);
            // 
            // menuOptionsCriterias
            // 
            this.menuOptionsCriterias.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOptionsCriteriasCapacity,
            this.menuOptionsCriteriasLoad,
            this.menuOptionsCriteriasDelay,
            this.menuOptionsCriteriasMetric});
            this.menuOptionsCriterias.Name = "menuOptionsCriterias";
            this.menuOptionsCriterias.Size = new System.Drawing.Size(180, 26);
            this.menuOptionsCriterias.Text = "Criterias";
            // 
            // menuOptionsCriteriasCapacity
            // 
            this.menuOptionsCriteriasCapacity.Name = "menuOptionsCriteriasCapacity";
            this.menuOptionsCriteriasCapacity.Size = new System.Drawing.Size(139, 26);
            this.menuOptionsCriteriasCapacity.Text = "Capacity";
            this.menuOptionsCriteriasCapacity.Click += new System.EventHandler(this.menuOptionsCriteriasCapacity_Click);
            // 
            // menuOptionsCriteriasLoad
            // 
            this.menuOptionsCriteriasLoad.Name = "menuOptionsCriteriasLoad";
            this.menuOptionsCriteriasLoad.Size = new System.Drawing.Size(139, 26);
            this.menuOptionsCriteriasLoad.Text = "Load";
            this.menuOptionsCriteriasLoad.Click += new System.EventHandler(this.menuOptionsCriteriasLoad_Click);
            // 
            // menuOptionsCriteriasDelay
            // 
            this.menuOptionsCriteriasDelay.Name = "menuOptionsCriteriasDelay";
            this.menuOptionsCriteriasDelay.Size = new System.Drawing.Size(139, 26);
            this.menuOptionsCriteriasDelay.Text = "Delay";
            this.menuOptionsCriteriasDelay.Click += new System.EventHandler(this.menuOptionsCriteriasDelay_Click);
            // 
            // menuOptionsCriteriasMetric
            // 
            this.menuOptionsCriteriasMetric.Checked = true;
            this.menuOptionsCriteriasMetric.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuOptionsCriteriasMetric.Name = "menuOptionsCriteriasMetric";
            this.menuOptionsCriteriasMetric.Size = new System.Drawing.Size(139, 26);
            this.menuOptionsCriteriasMetric.Text = "Metric";
            this.menuOptionsCriteriasMetric.Click += new System.EventHandler(this.menuOptionsCriteriasMetric_Click);
            // 
            // menuOptionsConnectivity
            // 
            this.menuOptionsConnectivity.Name = "menuOptionsConnectivity";
            this.menuOptionsConnectivity.Size = new System.Drawing.Size(180, 26);
            this.menuOptionsConnectivity.Text = "Connectivity";
            this.menuOptionsConnectivity.Click += new System.EventHandler(this.menuOptionsConnectivity_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.AutoSize = false;
            this.menuHelp.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(80, 50);
            this.menuHelp.Text = "Help";
            // 
            // ctlStatusBarGrid
            // 
            this.ctlStatusBarGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlStatusBarGrid.AutoSize = false;
            this.ctlStatusBarGrid.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ctlStatusBarGrid.Dock = System.Windows.Forms.DockStyle.None;
            this.ctlStatusBarGrid.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctlStatusBarGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblGreed,
            this.toolStripStatusLabel1});
            this.ctlStatusBarGrid.Location = new System.Drawing.Point(784, 673);
            this.ctlStatusBarGrid.Name = "ctlStatusBarGrid";
            this.ctlStatusBarGrid.Size = new System.Drawing.Size(177, 27);
            this.ctlStatusBarGrid.TabIndex = 5;
            // 
            // lblGreed
            // 
            this.lblGreed.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblGreed.Name = "lblGreed";
            this.lblGreed.Size = new System.Drawing.Size(97, 22);
            this.lblGreed.Text = "Greed: 0, 0";
            this.lblGreed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 15);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // ctlTabControl
            // 
            this.ctlTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlTabControl.ContextMenuStrip = this.ctlContextMenu;
            this.ctlTabControl.Location = new System.Drawing.Point(0, 117);
            this.ctlTabControl.Multiline = true;
            this.ctlTabControl.Name = "ctlTabControl";
            this.ctlTabControl.Padding = new System.Drawing.Point(0, 0);
            this.ctlTabControl.SelectedIndex = 0;
            this.ctlTabControl.Size = new System.Drawing.Size(1300, 555);
            this.ctlTabControl.TabIndex = 2;
            this.ctlTabControl.SelectedIndexChanged += new System.EventHandler(this.ctlTabControl_SelectedIndexChanged);
            this.ctlTabControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ctlTabControl_KeyDown);
            this.ctlTabControl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ctlTabControl_KeyUp);
            // 
            // ctlContextMenu
            // 
            this.ctlContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctlContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextClose});
            this.ctlContextMenu.Name = "ctlContextMenu";
            this.ctlContextMenu.Size = new System.Drawing.Size(104, 26);
            this.ctlContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ctlContextMenu_Opening);
            // 
            // contextClose
            // 
            this.contextClose.Name = "contextClose";
            this.contextClose.Size = new System.Drawing.Size(103, 22);
            this.contextClose.Text = "Close";
            this.contextClose.Click += new System.EventHandler(this.ContextClose_Click);
            // 
            // ctlStatusBarStatus
            // 
            this.ctlStatusBarStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlStatusBarStatus.AutoSize = false;
            this.ctlStatusBarStatus.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ctlStatusBarStatus.Dock = System.Windows.Forms.DockStyle.None;
            this.ctlStatusBarStatus.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ctlStatusBarStatus.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctlStatusBarStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblInstrument});
            this.ctlStatusBarStatus.Location = new System.Drawing.Point(0, 673);
            this.ctlStatusBarStatus.Name = "ctlStatusBarStatus";
            this.ctlStatusBarStatus.Size = new System.Drawing.Size(156, 27);
            this.ctlStatusBarStatus.SizingGrip = false;
            this.ctlStatusBarStatus.TabIndex = 3;
            // 
            // lblInstrument
            // 
            this.lblInstrument.Name = "lblInstrument";
            this.lblInstrument.Size = new System.Drawing.Size(41, 22);
            this.lblInstrument.Text = "Edit";
            this.lblInstrument.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ctlStatusBarFile
            // 
            this.ctlStatusBarFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlStatusBarFile.AutoSize = false;
            this.ctlStatusBarFile.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ctlStatusBarFile.Dock = System.Windows.Forms.DockStyle.None;
            this.ctlStatusBarFile.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctlStatusBarFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblFieldSize,
            this.lblRouters,
            this.lblWires});
            this.ctlStatusBarFile.Location = new System.Drawing.Point(156, 673);
            this.ctlStatusBarFile.Name = "ctlStatusBarFile";
            this.ctlStatusBarFile.Size = new System.Drawing.Size(628, 27);
            this.ctlStatusBarFile.SizingGrip = false;
            this.ctlStatusBarFile.TabIndex = 4;
            // 
            // lblFieldSize
            // 
            this.lblFieldSize.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFieldSize.Name = "lblFieldSize";
            this.lblFieldSize.Size = new System.Drawing.Size(42, 22);
            this.lblFieldSize.Text = "N\\A";
            // 
            // lblRouters
            // 
            this.lblRouters.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRouters.Name = "lblRouters";
            this.lblRouters.Size = new System.Drawing.Size(106, 22);
            this.lblRouters.Text = "   Routers: 0";
            // 
            // lblWires
            // 
            this.lblWires.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWires.Name = "lblWires";
            this.lblWires.Size = new System.Drawing.Size(88, 22);
            this.lblWires.Text = "   Wires: 0";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Topology Files (*.rsv) | *.rsv";
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Topology Files (*.rsv) | *.rsv";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // ctlToolBar
            // 
            this.ctlToolBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlToolBar.AutoSize = false;
            this.ctlToolBar.BackColor = System.Drawing.Color.AliceBlue;
            this.ctlToolBar.Dock = System.Windows.Forms.DockStyle.None;
            this.ctlToolBar.GripMargin = new System.Windows.Forms.Padding(0);
            this.ctlToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ctlToolBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctlToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnToolNew,
            this.btnToolOpen,
            this.btnToolSave,
            this.btnToolSaveAs,
            this.btnToolEdit,
            this.btnToolWire,
            this.btnToolRouter,
            this.btnToolTextLabel,
            this.btnToolDeleteAll,
            this.btnToolReset,
            this.toolStripButton1});
            this.ctlToolBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ctlToolBar.Location = new System.Drawing.Point(0, 54);
            this.ctlToolBar.Name = "ctlToolBar";
            this.ctlToolBar.Padding = new System.Windows.Forms.Padding(0);
            this.ctlToolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ctlToolBar.Size = new System.Drawing.Size(1111, 60);
            this.ctlToolBar.TabIndex = 1;
            // 
            // btnToolNew
            // 
            this.btnToolNew.AutoSize = false;
            this.btnToolNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnToolNew.Image = global::Routing_Application.Properties.Resources.document_new;
            this.btnToolNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnToolNew.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnToolNew.Name = "btnToolNew";
            this.btnToolNew.Size = new System.Drawing.Size(80, 50);
            this.btnToolNew.Text = "New";
            this.btnToolNew.Click += new System.EventHandler(this.btnToolNew_Click);
            // 
            // btnToolOpen
            // 
            this.btnToolOpen.AutoSize = false;
            this.btnToolOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnToolOpen.Image = global::Routing_Application.Properties.Resources.document_open;
            this.btnToolOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnToolOpen.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnToolOpen.Name = "btnToolOpen";
            this.btnToolOpen.Size = new System.Drawing.Size(80, 50);
            this.btnToolOpen.Text = "Open";
            this.btnToolOpen.Click += new System.EventHandler(this.btnToolOpen_Click);
            // 
            // btnToolSave
            // 
            this.btnToolSave.AutoSize = false;
            this.btnToolSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnToolSave.Image = global::Routing_Application.Properties.Resources.save;
            this.btnToolSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnToolSave.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnToolSave.Name = "btnToolSave";
            this.btnToolSave.Size = new System.Drawing.Size(80, 50);
            this.btnToolSave.Text = "Save";
            this.btnToolSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnToolSave.Click += new System.EventHandler(this.btnToolSave_Click);
            // 
            // btnToolSaveAs
            // 
            this.btnToolSaveAs.AutoSize = false;
            this.btnToolSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnToolSaveAs.Image = global::Routing_Application.Properties.Resources.document_save_as;
            this.btnToolSaveAs.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnToolSaveAs.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnToolSaveAs.Name = "btnToolSaveAs";
            this.btnToolSaveAs.Size = new System.Drawing.Size(80, 50);
            this.btnToolSaveAs.Text = "Save As...";
            this.btnToolSaveAs.Click += new System.EventHandler(this.btnToolSaveAs_Click);
            // 
            // btnToolEdit
            // 
            this.btnToolEdit.AutoSize = false;
            this.btnToolEdit.BackColor = System.Drawing.Color.White;
            this.btnToolEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnToolEdit.Checked = true;
            this.btnToolEdit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnToolEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnToolEdit.Image = global::Routing_Application.Properties.Resources.cursor;
            this.btnToolEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnToolEdit.ImageTransparentColor = System.Drawing.Color.White;
            this.btnToolEdit.Name = "btnToolEdit";
            this.btnToolEdit.Size = new System.Drawing.Size(80, 50);
            this.btnToolEdit.Text = "Edit";
            this.btnToolEdit.ToolTipText = "Edit (E)";
            this.btnToolEdit.Click += new System.EventHandler(this.btnToolEdit_Click);
            // 
            // btnToolWire
            // 
            this.btnToolWire.AutoSize = false;
            this.btnToolWire.BackColor = System.Drawing.Color.AliceBlue;
            this.btnToolWire.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnToolWire.Image = global::Routing_Application.Properties.Resources.line;
            this.btnToolWire.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnToolWire.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnToolWire.Name = "btnToolWire";
            this.btnToolWire.Size = new System.Drawing.Size(80, 50);
            this.btnToolWire.Text = "Insert Wire";
            this.btnToolWire.ToolTipText = "Insert Wire (W)";
            this.btnToolWire.Click += new System.EventHandler(this.btnToolWire_Click);
            // 
            // btnToolRouter
            // 
            this.btnToolRouter.AutoSize = false;
            this.btnToolRouter.BackColor = System.Drawing.Color.AliceBlue;
            this.btnToolRouter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnToolRouter.Image = global::Routing_Application.Properties.Resources.router0;
            this.btnToolRouter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnToolRouter.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnToolRouter.Name = "btnToolRouter";
            this.btnToolRouter.Size = new System.Drawing.Size(80, 50);
            this.btnToolRouter.Text = "Insert Router";
            this.btnToolRouter.ToolTipText = "Insert Router (R)";
            this.btnToolRouter.Click += new System.EventHandler(this.btnToolRouter_Click);
            // 
            // btnToolTextLabel
            // 
            this.btnToolTextLabel.AutoSize = false;
            this.btnToolTextLabel.BackColor = System.Drawing.Color.AliceBlue;
            this.btnToolTextLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnToolTextLabel.Image = global::Routing_Application.Properties.Resources.Editing_Text_icon;
            this.btnToolTextLabel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnToolTextLabel.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnToolTextLabel.Name = "btnToolTextLabel";
            this.btnToolTextLabel.Size = new System.Drawing.Size(80, 50);
            this.btnToolTextLabel.Text = "Create Text";
            this.btnToolTextLabel.ToolTipText = "Create Text (T)";
            this.btnToolTextLabel.Click += new System.EventHandler(this.btnToolTextLabel_Click);
            // 
            // btnToolDeleteAll
            // 
            this.btnToolDeleteAll.AutoSize = false;
            this.btnToolDeleteAll.BackColor = System.Drawing.Color.AliceBlue;
            this.btnToolDeleteAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnToolDeleteAll.Image = global::Routing_Application.Properties.Resources.cancel;
            this.btnToolDeleteAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnToolDeleteAll.ImageTransparentColor = System.Drawing.Color.White;
            this.btnToolDeleteAll.Name = "btnToolDeleteAll";
            this.btnToolDeleteAll.Size = new System.Drawing.Size(80, 50);
            this.btnToolDeleteAll.Text = "Delete All";
            this.btnToolDeleteAll.ToolTipText = "Delete All (P)";
            this.btnToolDeleteAll.Click += new System.EventHandler(this.btnToolDeleteAll_Click);
            // 
            // btnToolReset
            // 
            this.btnToolReset.AutoSize = false;
            this.btnToolReset.BackColor = System.Drawing.Color.AliceBlue;
            this.btnToolReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnToolReset.Image = global::Routing_Application.Properties.Resources.power_reset_1847;
            this.btnToolReset.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnToolReset.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnToolReset.Name = "btnToolReset";
            this.btnToolReset.Size = new System.Drawing.Size(80, 50);
            this.btnToolReset.Text = "Сброс";
            this.btnToolReset.ToolTipText = "Reset";
            this.btnToolReset.Click += new System.EventHandler(this.btnToolReset_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripButton1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripButton1.Image = global::Routing_Application.Properties.Resources.chart;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(80, 50);
            this.toolStripButton1.Text = "toolStripButton_chartt";
            this.toolStripButton1.ToolTipText = "Chart";
            this.toolStripButton1.Click += new System.EventHandler(this.char_paper_eng_1);
            // 
            // menuFileNew
            // 
            this.menuFileNew.Image = global::Routing_Application.Properties.Resources.document_new;
            this.menuFileNew.Name = "menuFileNew";
            this.menuFileNew.Size = new System.Drawing.Size(145, 26);
            this.menuFileNew.Text = "New ...";
            this.menuFileNew.Click += new System.EventHandler(this.MenuFileNew_Click);
            // 
            // menuFileOpen
            // 
            this.menuFileOpen.Image = global::Routing_Application.Properties.Resources.document_open;
            this.menuFileOpen.Name = "menuFileOpen";
            this.menuFileOpen.Size = new System.Drawing.Size(145, 26);
            this.menuFileOpen.Text = "Open";
            this.menuFileOpen.Click += new System.EventHandler(this.MenuFileOpen_Click);
            // 
            // menuFileSaveAs
            // 
            this.menuFileSaveAs.Image = global::Routing_Application.Properties.Resources.save;
            this.menuFileSaveAs.Name = "menuFileSaveAs";
            this.menuFileSaveAs.Size = new System.Drawing.Size(145, 26);
            this.menuFileSaveAs.Text = "Save as ...";
            this.menuFileSaveAs.Click += new System.EventHandler(this.MenuFileSaveAs_Click);
            // 
            // menuFileSave
            // 
            this.menuFileSave.Image = global::Routing_Application.Properties.Resources.document_save_as;
            this.menuFileSave.Name = "menuFileSave";
            this.menuFileSave.Size = new System.Drawing.Size(145, 26);
            this.menuFileSave.Text = "Save";
            this.menuFileSave.Click += new System.EventHandler(this.MenuFileSave_Click);
            // 
            // menuFileExit
            // 
            this.menuFileExit.Image = global::Routing_Application.Properties.Resources.exit;
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.Size = new System.Drawing.Size(145, 26);
            this.menuFileExit.Text = "Exit";
            this.menuFileExit.Click += new System.EventHandler(this.MenuFileExit_Click);
            // 
            // menuToolsEdit
            // 
            this.menuToolsEdit.Image = global::Routing_Application.Properties.Resources.cursor;
            this.menuToolsEdit.Name = "menuToolsEdit";
            this.menuToolsEdit.Size = new System.Drawing.Size(226, 26);
            this.menuToolsEdit.Text = "Edit";
            this.menuToolsEdit.Click += new System.EventHandler(this.menuToolsEdit_Click);
            // 
            // menuToolsPutRouter
            // 
            this.menuToolsPutRouter.Image = global::Routing_Application.Properties.Resources.router16;
            this.menuToolsPutRouter.Name = "menuToolsPutRouter";
            this.menuToolsPutRouter.Size = new System.Drawing.Size(226, 26);
            this.menuToolsPutRouter.Text = "Insert router";
            this.menuToolsPutRouter.Click += new System.EventHandler(this.menuToolsInsertRouter_Click);
            // 
            // menuToolsInsertWire
            // 
            this.menuToolsInsertWire.Image = ((System.Drawing.Image)(resources.GetObject("menuToolsInsertWire.Image")));
            this.menuToolsInsertWire.Name = "menuToolsInsertWire";
            this.menuToolsInsertWire.Size = new System.Drawing.Size(226, 26);
            this.menuToolsInsertWire.Text = "Insert wire";
            this.menuToolsInsertWire.Click += new System.EventHandler(this.menuToolsInsertWire_Click);
            // 
            // menuToolsCreateText
            // 
            this.menuToolsCreateText.Image = global::Routing_Application.Properties.Resources.Editing_Text_icon;
            this.menuToolsCreateText.Name = "menuToolsCreateText";
            this.menuToolsCreateText.Size = new System.Drawing.Size(226, 26);
            this.menuToolsCreateText.Text = "Text";
            this.menuToolsCreateText.Click += new System.EventHandler(this.menuToolsCreateText_Click);
            // 
            // menuToolsHorAlignment
            // 
            this.menuToolsHorAlignment.Image = ((System.Drawing.Image)(resources.GetObject("menuToolsHorAlignment.Image")));
            this.menuToolsHorAlignment.Name = "menuToolsHorAlignment";
            this.menuToolsHorAlignment.Size = new System.Drawing.Size(226, 26);
            this.menuToolsHorAlignment.Text = "Horizontal alignment";
            this.menuToolsHorAlignment.Click += new System.EventHandler(this.menuToolsHorAlignment_Click);
            // 
            // menuToolsVertAlignment
            // 
            this.menuToolsVertAlignment.Image = ((System.Drawing.Image)(resources.GetObject("menuToolsVertAlignment.Image")));
            this.menuToolsVertAlignment.Name = "menuToolsVertAlignment";
            this.menuToolsVertAlignment.Size = new System.Drawing.Size(226, 26);
            this.menuToolsVertAlignment.Text = "Vertical alignment";
            this.menuToolsVertAlignment.Click += new System.EventHandler(this.menuToolsVertAlignment_Click);
            // 
            // menuToolsReset
            // 
            this.menuToolsReset.Image = global::Routing_Application.Properties.Resources.power_reset_1847;
            this.menuToolsReset.Name = "menuToolsReset";
            this.menuToolsReset.Size = new System.Drawing.Size(226, 26);
            this.menuToolsReset.Text = "Reset";
            this.menuToolsReset.Click += new System.EventHandler(this.menuToolsReset_Click);
            // 
            // menuToolsDeleteAll
            // 
            this.menuToolsDeleteAll.Image = global::Routing_Application.Properties.Resources.cancel;
            this.menuToolsDeleteAll.Name = "menuToolsDeleteAll";
            this.menuToolsDeleteAll.Size = new System.Drawing.Size(226, 26);
            this.menuToolsDeleteAll.Text = "Delete all";
            this.menuToolsDeleteAll.Click += new System.EventHandler(this.menuToolsDeleteAll_Click);
            // 
            // GA
            // 
            this.GA.Image = ((System.Drawing.Image)(resources.GetObject("GA.Image")));
            this.GA.Name = "GA";
            this.GA.Size = new System.Drawing.Size(184, 26);
            this.GA.Text = "GA";
            this.GA.Click += new System.EventHandler(this.toolStripButton_GA_Click);
            // 
            // PSO
            // 
            this.PSO.Image = ((System.Drawing.Image)(resources.GetObject("PSO.Image")));
            this.PSO.Name = "PSO";
            this.PSO.Size = new System.Drawing.Size(184, 26);
            this.PSO.Text = "PSO";
            this.PSO.Click += new System.EventHandler(this.toolStripButton_PSO_Click);
            // 
            // FA
            // 
            this.FA.Image = ((System.Drawing.Image)(resources.GetObject("FA.Image")));
            this.FA.Name = "FA";
            this.FA.Size = new System.Drawing.Size(184, 26);
            this.FA.Text = "FA";
            this.FA.Click += new System.EventHandler(this.toolStripButton_FA_Click);
            // 
            // ABC
            // 
            this.ABC.Image = ((System.Drawing.Image)(resources.GetObject("ABC.Image")));
            this.ABC.Name = "ABC";
            this.ABC.Size = new System.Drawing.Size(184, 26);
            this.ABC.Text = "ABC";
            this.ABC.Click += new System.EventHandler(this.toolStripButton_ABC_Click);
            // 
            // ACO
            // 
            this.ACO.Image = ((System.Drawing.Image)(resources.GetObject("ACO.Image")));
            this.ACO.Name = "ACO";
            this.ACO.Size = new System.Drawing.Size(184, 26);
            this.ACO.Text = "ACO";
            this.ACO.Click += new System.EventHandler(this.toolStripButton_ACO_Click);
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.generateToolStripMenuItem.Text = "generate";
            this.generateToolStripMenuItem.Click += new System.EventHandler(this.generate_population_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.removeToolStripMenuItem.Text = "remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.remove_population_Click);
            // 
            // createPathToolStripMenuItem
            // 
            this.createPathToolStripMenuItem.Name = "createPathToolStripMenuItem";
            this.createPathToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.createPathToolStripMenuItem.Text = "create path";
            this.createPathToolStripMenuItem.Click += new System.EventHandler(this.create_paths_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1311, 700);
            this.Controls.Add(this.ctlStatusBarFile);
            this.Controls.Add(this.ctlStatusBarStatus);
            this.Controls.Add(this.ctlToolBar);
            this.Controls.Add(this.ctlTabControl);
            this.Controls.Add(this.ctlStatusBarGrid);
            this.Controls.Add(this.ctlMainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.ctlMainMenu;
            this.MinimumSize = new System.Drawing.Size(630, 297);
            this.Name = "Main";
            this.Text = "EvoLoadBalancer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDoubleClick);
            this.ctlMainMenu.ResumeLayout(false);
            this.ctlMainMenu.PerformLayout();
            this.ctlStatusBarGrid.ResumeLayout(false);
            this.ctlStatusBarGrid.PerformLayout();
            this.ctlContextMenu.ResumeLayout(false);
            this.ctlStatusBarStatus.ResumeLayout(false);
            this.ctlStatusBarStatus.PerformLayout();
            this.ctlStatusBarFile.ResumeLayout(false);
            this.ctlStatusBarFile.PerformLayout();
            this.ctlToolBar.ResumeLayout(false);
            this.ctlToolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip ctlMainMenu;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuFileNew;
        private System.Windows.Forms.StatusStrip ctlStatusBarGrid;
        private System.Windows.Forms.ToolStripMenuItem menuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem menuFileExit;
        private System.Windows.Forms.ToolStripStatusLabel lblGreed;
        private System.Windows.Forms.ToolStripSeparator menuFileSeparator1;
        public System.Windows.Forms.TabControl ctlTabControl;
        private System.Windows.Forms.ToolStripMenuItem menuFileSave;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.StatusStrip ctlStatusBarStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblInstrument;
        private System.Windows.Forms.StatusStrip ctlStatusBarFile;
        private System.Windows.Forms.ToolStripStatusLabel lblFieldSize;
        private System.Windows.Forms.ToolStripMenuItem menuTools;
        private System.Windows.Forms.ToolStripMenuItem menuOptions;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuFileSaveAs;
        private System.Windows.Forms.ToolStripMenuItem menuOptionsToolBar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripMenuItem menuToolsInsertWire;
        public System.Windows.Forms.ToolStripMenuItem menuToolsPutRouter;
        public System.Windows.Forms.ToolStripMenuItem menuToolsDeleteAll;
        private System.Windows.Forms.ToolStripMenuItem menuAlgorithms;
        private System.Windows.Forms.ToolStripMenuItem contextClose;
        public System.Windows.Forms.ContextMenuStrip ctlContextMenu;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripStatusLabel lblRouters;
        private System.Windows.Forms.ToolStripStatusLabel lblWires;
        private System.Windows.Forms.ToolStripMenuItem menuOptionsCriterias;
        public System.Windows.Forms.ToolStripMenuItem menuOptionsCriteriasDelay;
        public System.Windows.Forms.ToolStripMenuItem menuOptionsCriteriasLoad;
        public System.Windows.Forms.ToolStripMenuItem menuOptionsCriteriasCapacity;
        public System.Windows.Forms.ToolStripMenuItem menuOptionsAutoWeight;
        public System.Windows.Forms.ToolStripMenuItem menuToolsEdit;
        public System.Windows.Forms.ToolStripMenuItem menuOptionsConnectivity;
        public System.Windows.Forms.ToolStripMenuItem menuToolsReset;
        public System.Windows.Forms.ToolStripMenuItem menuOptionsCriteriasMetric;
        public System.Windows.Forms.ToolStripMenuItem menuOptionsFullMesh;
        private System.Windows.Forms.ToolStripMenuItem menuToolsCreateText;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuToolsHorAlignment;
        private System.Windows.Forms.ToolStripMenuItem menuToolsVertAlignment;
        public System.Windows.Forms.ToolStripMenuItem PSO;
        public System.Windows.Forms.ToolStripMenuItem GA;
        public System.Windows.Forms.ToolStripMenuItem FA;
        public System.Windows.Forms.ToolStripMenuItem ABC;
        private System.Windows.Forms.ToolStripButton btnToolNew;
        private System.Windows.Forms.ToolStripButton btnToolOpen;
        private System.Windows.Forms.ToolStripButton btnToolSave;
        private System.Windows.Forms.ToolStripButton btnToolSaveAs;
        public System.Windows.Forms.ToolStripButton btnToolEdit;
        public System.Windows.Forms.ToolStripButton btnToolWire;
        public System.Windows.Forms.ToolStripButton btnToolRouter;
        private System.Windows.Forms.ToolStripButton btnToolTextLabel;
        public System.Windows.Forms.ToolStripButton btnToolDeleteAll;
        public System.Windows.Forms.ToolStripButton btnToolReset;
        private System.Windows.Forms.ToolStrip ctlToolBar;
        public System.Windows.Forms.ToolStripMenuItem ACO;
        public System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createPathToolStripMenuItem;
    }
}

