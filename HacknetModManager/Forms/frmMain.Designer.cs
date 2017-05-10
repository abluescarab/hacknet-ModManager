namespace HacknetModManager {
    partial class frmMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tlpBottom = new System.Windows.Forms.TableLayoutPanel();
            this.tlpTop = new System.Windows.Forms.TableLayoutPanel();
            this.tlpSide = new System.Windows.Forms.TableLayoutPanel();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.lblAuthors = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblTitleVersion = new System.Windows.Forms.Label();
            this.tlpPlay = new System.Windows.Forms.TableLayoutPanel();
            this.status = new System.Windows.Forms.StatusStrip();
            this.statusStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusSep1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusRemaining = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusSep2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusReset = new System.Windows.Forms.ToolStripStatusLabel();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.helpUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.helpLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.listMods = new HacknetModManager.Controls.DarkListView();
            this.btnRemove = new HacknetModManager.Controls.DarkButton();
            this.btnInstall = new HacknetModManager.Controls.DarkButton();
            this.btnRefresh = new HacknetModManager.Controls.DarkButton();
            this.btnDisableAll = new HacknetModManager.Controls.DarkButton();
            this.btnEnableAll = new HacknetModManager.Controls.DarkButton();
            this.btnOpenModFolder = new HacknetModManager.Controls.DarkButton();
            this.btnHomepage = new HacknetModManager.Controls.DarkButton();
            this.btnEditModInfo = new HacknetModManager.Controls.DarkButton();
            this.btnUpdate = new HacknetModManager.Controls.DarkButton();
            this.btnChooseRelease = new HacknetModManager.Controls.DarkButton();
            this.btnUpdateModManager = new HacknetModManager.Controls.DarkButton();
            this.btnPlayUnmodded = new HacknetModManager.Controls.DarkButton();
            this.btnPlayPathfinder = new HacknetModManager.Controls.DarkButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tlpBottom.SuspendLayout();
            this.tlpTop.SuspendLayout();
            this.tlpSide.SuspendLayout();
            this.tlpPlay.SuspendLayout();
            this.status.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 46);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listMods);
            this.splitContainer1.Panel1.Controls.Add(this.tlpBottom);
            this.splitContainer1.Panel1.Controls.Add(this.tlpTop);
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tlpSide);
            this.splitContainer1.Panel2.Controls.Add(this.txtInfo);
            this.splitContainer1.Panel2.Controls.Add(this.lblAuthors);
            this.splitContainer1.Panel2.Controls.Add(this.lblDescription);
            this.splitContainer1.Panel2.Controls.Add(this.lblTitleVersion);
            this.splitContainer1.Panel2.Controls.Add(this.tlpPlay);
            this.splitContainer1.Panel2MinSize = 250;
            this.splitContainer1.Size = new System.Drawing.Size(617, 371);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 3;
            // 
            // tlpBottom
            // 
            this.tlpBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpBottom.ColumnCount = 3;
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpBottom.Controls.Add(this.btnRemove, 1, 0);
            this.tlpBottom.Controls.Add(this.btnInstall, 0, 0);
            this.tlpBottom.Controls.Add(this.btnRefresh, 2, 0);
            this.tlpBottom.Location = new System.Drawing.Point(12, 337);
            this.tlpBottom.Name = "tlpBottom";
            this.tlpBottom.RowCount = 1;
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBottom.Size = new System.Drawing.Size(185, 31);
            this.tlpBottom.TabIndex = 5;
            // 
            // tlpTop
            // 
            this.tlpTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpTop.ColumnCount = 3;
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tlpTop.Controls.Add(this.btnDisableAll, 1, 0);
            this.tlpTop.Controls.Add(this.btnEnableAll, 0, 0);
            this.tlpTop.Controls.Add(this.btnOpenModFolder, 2, 0);
            this.tlpTop.Location = new System.Drawing.Point(12, 12);
            this.tlpTop.Name = "tlpTop";
            this.tlpTop.RowCount = 1;
            this.tlpTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTop.Size = new System.Drawing.Size(185, 31);
            this.tlpTop.TabIndex = 0;
            // 
            // tlpSide
            // 
            this.tlpSide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpSide.ColumnCount = 1;
            this.tlpSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSide.Controls.Add(this.btnHomepage, 0, 0);
            this.tlpSide.Controls.Add(this.btnEditModInfo, 0, 4);
            this.tlpSide.Controls.Add(this.btnUpdate, 0, 2);
            this.tlpSide.Controls.Add(this.btnChooseRelease, 0, 3);
            this.tlpSide.Controls.Add(this.btnUpdateModManager, 0, 6);
            this.tlpSide.Location = new System.Drawing.Point(274, 12);
            this.tlpSide.Name = "tlpSide";
            this.tlpSide.RowCount = 8;
            this.tlpSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpSide.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSide.Size = new System.Drawing.Size(127, 319);
            this.tlpSide.TabIndex = 10;
            // 
            // txtInfo
            // 
            this.txtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.txtInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInfo.ForeColor = System.Drawing.Color.White;
            this.txtInfo.Location = new System.Drawing.Point(3, 88);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfo.Size = new System.Drawing.Size(265, 243);
            this.txtInfo.TabIndex = 9;
            this.txtInfo.Text = "No information.";
            this.txtInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInfo_KeyDown);
            // 
            // lblAuthors
            // 
            this.lblAuthors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAuthors.AutoEllipsis = true;
            this.lblAuthors.ForeColor = System.Drawing.Color.White;
            this.lblAuthors.Location = new System.Drawing.Point(3, 57);
            this.lblAuthors.Name = "lblAuthors";
            this.lblAuthors.Size = new System.Drawing.Size(265, 28);
            this.lblAuthors.TabIndex = 5;
            this.lblAuthors.Text = "N/A";
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.AutoEllipsis = true;
            this.lblDescription.ForeColor = System.Drawing.Color.White;
            this.lblDescription.Location = new System.Drawing.Point(3, 29);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(265, 28);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "N/A";
            // 
            // lblTitleVersion
            // 
            this.lblTitleVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitleVersion.AutoEllipsis = true;
            this.lblTitleVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleVersion.ForeColor = System.Drawing.Color.White;
            this.lblTitleVersion.Location = new System.Drawing.Point(3, 12);
            this.lblTitleVersion.Name = "lblTitleVersion";
            this.lblTitleVersion.Size = new System.Drawing.Size(265, 17);
            this.lblTitleVersion.TabIndex = 3;
            this.lblTitleVersion.Text = "N/A";
            // 
            // tlpPlay
            // 
            this.tlpPlay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPlay.ColumnCount = 2;
            this.tlpPlay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPlay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPlay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpPlay.Controls.Add(this.btnPlayUnmodded, 0, 0);
            this.tlpPlay.Controls.Add(this.btnPlayPathfinder, 1, 0);
            this.tlpPlay.Location = new System.Drawing.Point(3, 337);
            this.tlpPlay.Name = "tlpPlay";
            this.tlpPlay.RowCount = 1;
            this.tlpPlay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPlay.Size = new System.Drawing.Size(398, 31);
            this.tlpPlay.TabIndex = 16;
            // 
            // status
            // 
            this.status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStatus,
            this.statusSep1,
            this.statusRemaining,
            this.statusSep2,
            this.statusReset});
            this.status.Location = new System.Drawing.Point(0, 420);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(617, 22);
            this.status.SizingGrip = false;
            this.status.TabIndex = 4;
            // 
            // statusStatus
            // 
            this.statusStatus.ForeColor = System.Drawing.Color.White;
            this.statusStatus.Name = "statusStatus";
            this.statusStatus.Size = new System.Drawing.Size(39, 17);
            this.statusStatus.Text = "Ready";
            // 
            // statusSep1
            // 
            this.statusSep1.ForeColor = System.Drawing.Color.White;
            this.statusSep1.Name = "statusSep1";
            this.statusSep1.Size = new System.Drawing.Size(10, 17);
            this.statusSep1.Text = "|";
            // 
            // statusRemaining
            // 
            this.statusRemaining.ForeColor = System.Drawing.Color.White;
            this.statusRemaining.Name = "statusRemaining";
            this.statusRemaining.Size = new System.Drawing.Size(125, 17);
            this.statusRemaining.Text = "{0} requests remaining";
            // 
            // statusSep2
            // 
            this.statusSep2.ForeColor = System.Drawing.Color.White;
            this.statusSep2.Name = "statusSep2";
            this.statusSep2.Size = new System.Drawing.Size(10, 17);
            this.statusSep2.Text = "|";
            // 
            // statusReset
            // 
            this.statusReset.ForeColor = System.Drawing.Color.White;
            this.statusReset.Name = "statusReset";
            this.statusReset.Size = new System.Drawing.Size(112, 17);
            this.statusReset.Text = "Requests reset at {0}";
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHelp});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(617, 24);
            this.menu.TabIndex = 5;
            // 
            // menuHelp
            // 
            this.menuHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpLogin,
            this.helpUpdates});
            this.menuHelp.ForeColor = System.Drawing.Color.White;
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(44, 20);
            this.menuHelp.Text = "Help";
            // 
            // helpUpdates
            // 
            this.helpUpdates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.helpUpdates.ForeColor = System.Drawing.Color.White;
            this.helpUpdates.Name = "helpUpdates";
            this.helpUpdates.Size = new System.Drawing.Size(180, 22);
            this.helpUpdates.Text = "Check for Updates...";
            // 
            // helpLogin
            // 
            this.helpLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.helpLogin.ForeColor = System.Drawing.Color.White;
            this.helpLogin.Name = "helpLogin";
            this.helpLogin.Size = new System.Drawing.Size(180, 22);
            this.helpLogin.Text = "Login to GitHub";
            // 
            // listMods
            // 
            this.listMods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listMods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.listMods.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listMods.CheckBoxes = true;
            this.listMods.ForeColor = System.Drawing.Color.White;
            this.listMods.HideSelection = false;
            this.listMods.Location = new System.Drawing.Point(12, 50);
            this.listMods.Name = "listMods";
            this.listMods.OwnerDraw = true;
            this.listMods.ShowGroups = false;
            this.listMods.Size = new System.Drawing.Size(185, 281);
            this.listMods.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listMods.TabIndex = 4;
            this.listMods.UseCompatibleStateImageBehavior = false;
            this.listMods.View = System.Windows.Forms.View.List;
            this.listMods.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listMods_ItemChecked);
            this.listMods.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listMods_ItemSelectionChanged);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnRemove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.ForeColor = System.Drawing.Color.White;
            this.btnRemove.Location = new System.Drawing.Point(80, 3);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(71, 25);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnInstall
            // 
            this.btnInstall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnInstall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInstall.FlatAppearance.BorderSize = 0;
            this.btnInstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstall.ForeColor = System.Drawing.Color.White;
            this.btnInstall.Location = new System.Drawing.Point(3, 3);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(71, 25);
            this.btnInstall.TabIndex = 6;
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = false;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Image = global::HacknetModManager.Properties.Resources.arrow_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(157, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(25, 25);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDisableAll
            // 
            this.btnDisableAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnDisableAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDisableAll.FlatAppearance.BorderSize = 0;
            this.btnDisableAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisableAll.ForeColor = System.Drawing.Color.White;
            this.btnDisableAll.Location = new System.Drawing.Point(76, 3);
            this.btnDisableAll.Name = "btnDisableAll";
            this.btnDisableAll.Size = new System.Drawing.Size(68, 25);
            this.btnDisableAll.TabIndex = 2;
            this.btnDisableAll.Text = "Disable All";
            this.btnDisableAll.UseVisualStyleBackColor = false;
            this.btnDisableAll.Click += new System.EventHandler(this.btnDisableAll_Click);
            // 
            // btnEnableAll
            // 
            this.btnEnableAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnEnableAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEnableAll.FlatAppearance.BorderSize = 0;
            this.btnEnableAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnableAll.ForeColor = System.Drawing.Color.White;
            this.btnEnableAll.Location = new System.Drawing.Point(3, 3);
            this.btnEnableAll.Name = "btnEnableAll";
            this.btnEnableAll.Size = new System.Drawing.Size(67, 25);
            this.btnEnableAll.TabIndex = 1;
            this.btnEnableAll.Text = "Enable All";
            this.btnEnableAll.UseVisualStyleBackColor = false;
            this.btnEnableAll.Click += new System.EventHandler(this.btnEnableAll_Click);
            // 
            // btnOpenModFolder
            // 
            this.btnOpenModFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnOpenModFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenModFolder.FlatAppearance.BorderSize = 0;
            this.btnOpenModFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenModFolder.ForeColor = System.Drawing.Color.White;
            this.btnOpenModFolder.Image = global::HacknetModManager.Properties.Resources.folder_go;
            this.btnOpenModFolder.Location = new System.Drawing.Point(150, 3);
            this.btnOpenModFolder.Name = "btnOpenModFolder";
            this.btnOpenModFolder.Size = new System.Drawing.Size(32, 25);
            this.btnOpenModFolder.TabIndex = 3;
            this.btnOpenModFolder.UseVisualStyleBackColor = false;
            this.btnOpenModFolder.Click += new System.EventHandler(this.btnOpenModFolder_Click);
            // 
            // btnHomepage
            // 
            this.btnHomepage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnHomepage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHomepage.FlatAppearance.BorderSize = 0;
            this.btnHomepage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHomepage.ForeColor = System.Drawing.Color.White;
            this.btnHomepage.Location = new System.Drawing.Point(3, 3);
            this.btnHomepage.Name = "btnHomepage";
            this.btnHomepage.Size = new System.Drawing.Size(121, 25);
            this.btnHomepage.TabIndex = 11;
            this.btnHomepage.Text = "Visit Homepage";
            this.btnHomepage.UseVisualStyleBackColor = false;
            this.btnHomepage.Click += new System.EventHandler(this.btnHomepage_Click);
            // 
            // btnEditModInfo
            // 
            this.btnEditModInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnEditModInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEditModInfo.FlatAppearance.BorderSize = 0;
            this.btnEditModInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditModInfo.ForeColor = System.Drawing.Color.White;
            this.btnEditModInfo.Location = new System.Drawing.Point(3, 106);
            this.btnEditModInfo.Name = "btnEditModInfo";
            this.btnEditModInfo.Size = new System.Drawing.Size(121, 25);
            this.btnEditModInfo.TabIndex = 14;
            this.btnEditModInfo.Text = "Edit Mod Info";
            this.btnEditModInfo.UseVisualStyleBackColor = false;
            this.btnEditModInfo.Click += new System.EventHandler(this.btnEditModInfo_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(3, 44);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(121, 25);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "Update Mod";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnChooseRelease
            // 
            this.btnChooseRelease.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnChooseRelease.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChooseRelease.FlatAppearance.BorderSize = 0;
            this.btnChooseRelease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChooseRelease.ForeColor = System.Drawing.Color.White;
            this.btnChooseRelease.Location = new System.Drawing.Point(3, 75);
            this.btnChooseRelease.Name = "btnChooseRelease";
            this.btnChooseRelease.Size = new System.Drawing.Size(121, 25);
            this.btnChooseRelease.TabIndex = 13;
            this.btnChooseRelease.Text = "Choose Release";
            this.btnChooseRelease.UseVisualStyleBackColor = false;
            this.btnChooseRelease.Click += new System.EventHandler(this.btnChooseRelease_Click);
            // 
            // btnUpdateModManager
            // 
            this.btnUpdateModManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnUpdateModManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdateModManager.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnUpdateModManager.FlatAppearance.BorderSize = 0;
            this.btnUpdateModManager.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.btnUpdateModManager.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnUpdateModManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateModManager.ForeColor = System.Drawing.Color.White;
            this.btnUpdateModManager.Location = new System.Drawing.Point(3, 147);
            this.btnUpdateModManager.Name = "btnUpdateModManager";
            this.btnUpdateModManager.Size = new System.Drawing.Size(121, 25);
            this.btnUpdateModManager.TabIndex = 15;
            this.btnUpdateModManager.Text = "Check for Updates";
            this.btnUpdateModManager.UseVisualStyleBackColor = false;
            this.btnUpdateModManager.Click += new System.EventHandler(this.btnUpdateModManager_Click);
            // 
            // btnPlayUnmodded
            // 
            this.btnPlayUnmodded.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnPlayUnmodded.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPlayUnmodded.FlatAppearance.BorderSize = 0;
            this.btnPlayUnmodded.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayUnmodded.ForeColor = System.Drawing.Color.White;
            this.btnPlayUnmodded.Location = new System.Drawing.Point(3, 3);
            this.btnPlayUnmodded.Name = "btnPlayUnmodded";
            this.btnPlayUnmodded.Size = new System.Drawing.Size(193, 25);
            this.btnPlayUnmodded.TabIndex = 17;
            this.btnPlayUnmodded.Text = "Play (Unmodded)";
            this.btnPlayUnmodded.UseVisualStyleBackColor = false;
            this.btnPlayUnmodded.Click += new System.EventHandler(this.btnPlayUnmodded_Click);
            // 
            // btnPlayPathfinder
            // 
            this.btnPlayPathfinder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnPlayPathfinder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPlayPathfinder.FlatAppearance.BorderSize = 0;
            this.btnPlayPathfinder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayPathfinder.ForeColor = System.Drawing.Color.White;
            this.btnPlayPathfinder.Location = new System.Drawing.Point(202, 3);
            this.btnPlayPathfinder.Name = "btnPlayPathfinder";
            this.btnPlayPathfinder.Size = new System.Drawing.Size(193, 25);
            this.btnPlayPathfinder.TabIndex = 18;
            this.btnPlayPathfinder.Text = "Play (Pathfinder)";
            this.btnPlayPathfinder.UseVisualStyleBackColor = false;
            this.btnPlayPathfinder.Click += new System.EventHandler(this.btnPlayPathfinder_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(617, 442);
            this.Controls.Add(this.status);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.menu;
            this.MinimumSize = new System.Drawing.Size(475, 334);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hacknet Mod Manager";
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tlpBottom.ResumeLayout(false);
            this.tlpTop.ResumeLayout(false);
            this.tlpSide.ResumeLayout(false);
            this.tlpPlay.ResumeLayout(false);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controls.DarkButton btnDisableAll;
        private Controls.DarkButton btnEnableAll;
        private System.Windows.Forms.TableLayoutPanel tlpTop;
        private Controls.DarkButton btnOpenModFolder;
        private System.Windows.Forms.TableLayoutPanel tlpBottom;
        private Controls.DarkButton btnRemove;
        private Controls.DarkButton btnInstall;
        private Controls.DarkButton btnRefresh;
        private Controls.DarkButton btnPlayPathfinder;
        private Controls.DarkButton btnPlayUnmodded;
        private System.Windows.Forms.TableLayoutPanel tlpPlay;
        private System.Windows.Forms.Label lblTitleVersion;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblAuthors;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.TableLayoutPanel tlpSide;
        private Controls.DarkButton btnEditModInfo;
        private Controls.DarkButton btnHomepage;
        private Controls.DarkListView listMods;
        private Controls.DarkButton btnUpdate;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel statusStatus;
        private Controls.DarkButton btnChooseRelease;
        private Controls.DarkButton btnUpdateModManager;
        private System.Windows.Forms.ToolStripStatusLabel statusSep1;
        private System.Windows.Forms.ToolStripStatusLabel statusRemaining;
        private System.Windows.Forms.ToolStripStatusLabel statusSep2;
        private System.Windows.Forms.ToolStripStatusLabel statusReset;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem helpLogin;
        private System.Windows.Forms.ToolStripMenuItem helpUpdates;
    }
}

