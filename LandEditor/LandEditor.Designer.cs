namespace LandEditor
{
    partial class LandEditor
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LandEditor));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.파일FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSizing = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMap = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewMap = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditMap = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveMap = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLoadMap = new System.Windows.Forms.ToolStripMenuItem();
            this.menuShortcut = new System.Windows.Forms.ToolStripMenuItem();
            this.정보IToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProgramInformation = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolOpenFile = new System.Windows.Forms.ToolStripButton();
            this.toolSaveFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbWidth = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tbHeight = new System.Windows.Forms.ToolStripTextBox();
            this.btnDo = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.lbInformation = new System.Windows.Forms.ToolStripLabel();
            this.progress = new System.Windows.Forms.ToolStripProgressBar();
            this.groupLand = new System.Windows.Forms.GroupBox();
            this.listLand = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbMapSize = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbCoordination = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbLand = new System.Windows.Forms.Label();
            this.hScroll = new System.Windows.Forms.HScrollBar();
            this.vScroll = new System.Windows.Forms.VScrollBar();
            this.pbViewLand = new System.Windows.Forms.PictureBox();
            this.pbLand = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbMap = new System.Windows.Forms.PictureBox();
            this.단축키ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbViewLand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLand)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "hexzmap.e5";
            this.openFileDialog.Filter = "hexzmap.e5 (지형 속성 파일) | hexzmap.e5";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일FToolStripMenuItem,
            this.menuEdit,
            this.menuMap,
            this.menuSetting,
            this.정보IToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(898, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // 파일FToolStripMenuItem
            // 
            this.파일FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpenFile,
            this.menuSaveFile,
            this.toolStripMenuItem1,
            this.menuExit});
            this.파일FToolStripMenuItem.Name = "파일FToolStripMenuItem";
            this.파일FToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.파일FToolStripMenuItem.Text = "파일(&F)";
            // 
            // menuOpenFile
            // 
            this.menuOpenFile.Image = global::LandEditor.Properties.Resources.document_open;
            this.menuOpenFile.Name = "menuOpenFile";
            this.menuOpenFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuOpenFile.Size = new System.Drawing.Size(158, 22);
            this.menuOpenFile.Text = "열기(&O)";
            this.menuOpenFile.Click += new System.EventHandler(this.menuOpenFile_Click);
            // 
            // menuSaveFile
            // 
            this.menuSaveFile.Image = global::LandEditor.Properties.Resources.document_save;
            this.menuSaveFile.Name = "menuSaveFile";
            this.menuSaveFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuSaveFile.Size = new System.Drawing.Size(158, 22);
            this.menuSaveFile.Text = "저장(&S)";
            this.menuSaveFile.Click += new System.EventHandler(this.menuSaveFile_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(155, 6);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(158, 22);
            this.menuExit.Text = "종료(&X)";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuEdit
            // 
            this.menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAdd,
            this.menuDelete,
            this.menuSizing,
            this.menuRestore});
            this.menuEdit.Enabled = false;
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(57, 20);
            this.menuEdit.Text = "편집(&E)";
            // 
            // menuAdd
            // 
            this.menuAdd.Name = "menuAdd";
            this.menuAdd.Size = new System.Drawing.Size(154, 22);
            this.menuAdd.Text = "추가(&A)";
            this.menuAdd.Click += new System.EventHandler(this.menuAdd_Click);
            // 
            // menuDelete
            // 
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Size = new System.Drawing.Size(154, 22);
            this.menuDelete.Text = "삭제(&D)";
            this.menuDelete.Click += new System.EventHandler(this.menuDelete_Click);
            // 
            // menuSizing
            // 
            this.menuSizing.Name = "menuSizing";
            this.menuSizing.Size = new System.Drawing.Size(154, 22);
            this.menuSizing.Text = "크기 조정(&S)";
            this.menuSizing.Click += new System.EventHandler(this.menuSizing_Click);
            // 
            // menuRestore
            // 
            this.menuRestore.Name = "menuRestore";
            this.menuRestore.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.menuRestore.Size = new System.Drawing.Size(154, 22);
            this.menuRestore.Text = "복원(&R)";
            this.menuRestore.Click += new System.EventHandler(this.menuRestore_Click);
            // 
            // menuMap
            // 
            this.menuMap.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewMap,
            this.menuEditMap,
            this.menuSaveMap});
            this.menuMap.Enabled = false;
            this.menuMap.Name = "menuMap";
            this.menuMap.Size = new System.Drawing.Size(62, 20);
            this.menuMap.Text = "지도(&M)";
            // 
            // menuViewMap
            // 
            this.menuViewMap.Name = "menuViewMap";
            this.menuViewMap.Size = new System.Drawing.Size(152, 22);
            this.menuViewMap.Text = "보기(&V)";
            // 
            // menuEditMap
            // 
            this.menuEditMap.Name = "menuEditMap";
            this.menuEditMap.Size = new System.Drawing.Size(152, 22);
            this.menuEditMap.Text = "입력(&I)";
            // 
            // menuSaveMap
            // 
            this.menuSaveMap.Name = "menuSaveMap";
            this.menuSaveMap.Size = new System.Drawing.Size(152, 22);
            this.menuSaveMap.Text = "출력(&O)";
            // 
            // menuSetting
            // 
            this.menuSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLoadMap,
            this.menuShortcut});
            this.menuSetting.Name = "menuSetting";
            this.menuSetting.Size = new System.Drawing.Size(58, 20);
            this.menuSetting.Text = "설정(&S)";
            // 
            // menuLoadMap
            // 
            this.menuLoadMap.Name = "menuLoadMap";
            this.menuLoadMap.Size = new System.Drawing.Size(169, 22);
            this.menuLoadMap.Text = "지도 불러오기(&M)";
            this.menuLoadMap.Click += new System.EventHandler(this.menuLoadMap_Click);
            // 
            // menuShortcut
            // 
            this.menuShortcut.Name = "menuShortcut";
            this.menuShortcut.Size = new System.Drawing.Size(169, 22);
            this.menuShortcut.Text = "단축키 지정(&S)";
            // 
            // 정보IToolStripMenuItem
            // 
            this.정보IToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuProgramInformation});
            this.정보IToolStripMenuItem.Name = "정보IToolStripMenuItem";
            this.정보IToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.정보IToolStripMenuItem.Text = "정보(&I)";
            // 
            // menuProgramInformation
            // 
            this.menuProgramInformation.Name = "menuProgramInformation";
            this.menuProgramInformation.Size = new System.Drawing.Size(165, 22);
            this.menuProgramInformation.Text = "프로그램 정보(&P)";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOpenFile,
            this.toolSaveFile,
            this.toolStripSeparator1,
            this.tbWidth,
            this.toolStripLabel1,
            this.tbHeight,
            this.btnDo,
            this.btnCancel,
            this.lbInformation,
            this.progress});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(898, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolOpenFile
            // 
            this.toolOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolOpenFile.Image = global::LandEditor.Properties.Resources.document_open;
            this.toolOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolOpenFile.Name = "toolOpenFile";
            this.toolOpenFile.Size = new System.Drawing.Size(23, 22);
            this.toolOpenFile.Text = "파일 열기 (Ctrl + O)";
            this.toolOpenFile.Click += new System.EventHandler(this.toolOpenFile_Click);
            // 
            // toolSaveFile
            // 
            this.toolSaveFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSaveFile.Image = global::LandEditor.Properties.Resources.document_save;
            this.toolSaveFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSaveFile.Name = "toolSaveFile";
            this.toolSaveFile.Size = new System.Drawing.Size(23, 22);
            this.toolSaveFile.Text = "파일 저장 (Ctrl + S)";
            this.toolSaveFile.Click += new System.EventHandler(this.toolSaveFile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbWidth
            // 
            this.tbWidth.Enabled = false;
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Size = new System.Drawing.Size(100, 25);
            this.tbWidth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbWidth_KeyDown);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(13, 22);
            this.toolStripLabel1.Text = "x";
            // 
            // tbHeight
            // 
            this.tbHeight.Enabled = false;
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Size = new System.Drawing.Size(100, 25);
            this.tbHeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbWidth_KeyDown);
            // 
            // btnDo
            // 
            this.btnDo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDo.Enabled = false;
            this.btnDo.Image = global::LandEditor.Properties.Resources.go_next;
            this.btnDo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDo.Name = "btnDo";
            this.btnDo.Size = new System.Drawing.Size(23, 22);
            this.btnDo.Text = "적용";
            this.btnDo.Click += new System.EventHandler(this.btnDo_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCancel.Enabled = false;
            this.btnCancel.Image = global::LandEditor.Properties.Resources.edit_undo;
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(23, 22);
            this.btnCancel.Text = "취소";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbInformation
            // 
            this.lbInformation.Name = "lbInformation";
            this.lbInformation.Size = new System.Drawing.Size(0, 22);
            // 
            // progress
            // 
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(100, 22);
            // 
            // groupLand
            // 
            this.groupLand.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupLand.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupLand.Location = new System.Drawing.Point(710, 49);
            this.groupLand.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupLand.Name = "groupLand";
            this.groupLand.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupLand.Size = new System.Drawing.Size(188, 526);
            this.groupLand.TabIndex = 64;
            this.groupLand.TabStop = false;
            this.groupLand.Text = "지형 속성";
            // 
            // listLand
            // 
            this.listLand.FormattingEnabled = true;
            this.listLand.ItemHeight = 15;
            this.listLand.Location = new System.Drawing.Point(0, 49);
            this.listLand.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listLand.Name = "listLand";
            this.listLand.Size = new System.Drawing.Size(43, 514);
            this.listLand.TabIndex = 65;
            this.listLand.SelectedIndexChanged += new System.EventHandler(this.listLand_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(562, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 67;
            this.label1.Text = "지도 크기";
            // 
            // lbMapSize
            // 
            this.lbMapSize.AutoSize = true;
            this.lbMapSize.Location = new System.Drawing.Point(561, 75);
            this.lbMapSize.Name = "lbMapSize";
            this.lbMapSize.Size = new System.Drawing.Size(0, 15);
            this.lbMapSize.TabIndex = 68;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(648, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 67;
            this.label2.Text = "좌표";
            // 
            // lbCoordination
            // 
            this.lbCoordination.AutoSize = true;
            this.lbCoordination.Location = new System.Drawing.Point(648, 75);
            this.lbCoordination.Name = "lbCoordination";
            this.lbCoordination.Size = new System.Drawing.Size(0, 15);
            this.lbCoordination.TabIndex = 67;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(562, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 67;
            this.label3.Text = "지형 속성";
            // 
            // lbLand
            // 
            this.lbLand.AutoSize = true;
            this.lbLand.Location = new System.Drawing.Point(575, 132);
            this.lbLand.Name = "lbLand";
            this.lbLand.Size = new System.Drawing.Size(0, 15);
            this.lbLand.TabIndex = 68;
            // 
            // hScroll
            // 
            this.hScroll.LargeChange = 1;
            this.hScroll.Location = new System.Drawing.Point(49, 533);
            this.hScroll.Maximum = 0;
            this.hScroll.Name = "hScroll";
            this.hScroll.Size = new System.Drawing.Size(478, 18);
            this.hScroll.TabIndex = 71;
            this.hScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScroll_Scroll);
            // 
            // vScroll
            // 
            this.vScroll.LargeChange = 1;
            this.vScroll.Location = new System.Drawing.Point(532, 49);
            this.vScroll.Maximum = 0;
            this.vScroll.Name = "vScroll";
            this.vScroll.Size = new System.Drawing.Size(18, 478);
            this.vScroll.TabIndex = 72;
            this.vScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScroll_Scroll);
            // 
            // pbViewLand
            // 
            this.pbViewLand.Location = new System.Drawing.Point(641, 107);
            this.pbViewLand.Name = "pbViewLand";
            this.pbViewLand.Size = new System.Drawing.Size(48, 48);
            this.pbViewLand.TabIndex = 70;
            this.pbViewLand.TabStop = false;
            // 
            // pbLand
            // 
            this.pbLand.Location = new System.Drawing.Point(49, 49);
            this.pbLand.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbLand.Name = "pbLand";
            this.pbLand.Size = new System.Drawing.Size(480, 480);
            this.pbLand.TabIndex = 66;
            this.pbLand.TabStop = false;
            this.pbLand.Visible = false;
            this.pbLand.Paint += new System.Windows.Forms.PaintEventHandler(this.pbLands_Paint);
            this.pbLand.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbLand_MouseDown);
            this.pbLand.MouseLeave += new System.EventHandler(this.pbLands_MouseLeave);
            this.pbLand.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbLands_MouseMove);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.단축키ToolStripMenuItem,
            this.toolStripTextBox1});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(161, 51);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbMap);
            this.panel1.Location = new System.Drawing.Point(557, 174);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 144);
            this.panel1.TabIndex = 75;
            // 
            // pbMap
            // 
            this.pbMap.Location = new System.Drawing.Point(0, 0);
            this.pbMap.Name = "pbMap";
            this.pbMap.Size = new System.Drawing.Size(144, 144);
            this.pbMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbMap.TabIndex = 75;
            this.pbMap.TabStop = false;
            this.pbMap.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMap_Paint);
            // 
            // 단축키ToolStripMenuItem
            // 
            this.단축키ToolStripMenuItem.Name = "단축키ToolStripMenuItem";
            this.단축키ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.단축키ToolStripMenuItem.Text = "단축키";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            // 
            // LandEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 575);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.vScroll);
            this.Controls.Add(this.pbViewLand);
            this.Controls.Add(this.lbLand);
            this.Controls.Add(this.lbMapSize);
            this.Controls.Add(this.lbCoordination);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbLand);
            this.Controls.Add(this.listLand);
            this.Controls.Add(this.groupLand);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.hScroll);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "LandEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "지형 속성 편집기 by 고음불가";
            this.Load += new System.EventHandler(this.LandEditor_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbViewLand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLand)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.contextMenuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem 파일FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuOpenFile;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolOpenFile;
        private System.Windows.Forms.GroupBox groupLand;
        private System.Windows.Forms.ToolStripMenuItem menuSaveFile;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripButton toolSaveFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ListBox listLand;
        private System.Windows.Forms.PictureBox pbLand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbMapSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbCoordination;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbLand;
        private System.Windows.Forms.PictureBox pbViewLand;
        private System.Windows.Forms.HScrollBar hScroll;
        private System.Windows.Forms.VScrollBar vScroll;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuAdd;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        private System.Windows.Forms.ToolStripMenuItem menuRestore;
        private System.Windows.Forms.ToolStripMenuItem menuMap;
        private System.Windows.Forms.ToolStripMenuItem menuViewMap;
        private System.Windows.Forms.ToolStripMenuItem menuEditMap;
        private System.Windows.Forms.ToolStripMenuItem menuSaveMap;
        private System.Windows.Forms.ToolStripMenuItem 정보IToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuProgramInformation;
        private System.Windows.Forms.ToolStripMenuItem menuSizing;
        private System.Windows.Forms.ToolStripTextBox tbWidth;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tbHeight;
        private System.Windows.Forms.ToolStripButton btnDo;
        private System.Windows.Forms.ToolStripLabel lbInformation;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripProgressBar progress;
        private System.Windows.Forms.ToolStripMenuItem menuSetting;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuLoadMap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbMap;
        private System.Windows.Forms.ToolStripMenuItem menuShortcut;
        private System.Windows.Forms.ToolStripMenuItem 단축키ToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
    }
}

