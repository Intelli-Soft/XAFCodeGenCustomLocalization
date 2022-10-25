namespace XAFCodeGenCustomLocalization
{
    partial class frmMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainForm));
            this.directXFormContainerControl1 = new DevExpress.XtraEditors.DirectXFormContainerControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.prgPreparation = new DevExpress.XtraEditors.ProgressBarControl();
            this.grpCode = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.txtNamespace = new DevExpress.XtraEditors.TextEdit();
            this.cmdCreateFile = new DevExpress.XtraEditors.SimpleButton();
            this.cmdShowCode = new DevExpress.XtraEditors.SimpleButton();
            this.rdgCodeGeneration = new DevExpress.XtraEditors.RadioGroup();
            this.rdgTextOptions = new DevExpress.XtraEditors.RadioGroup();
            this.txtPostfix = new DevExpress.XtraEditors.TextEdit();
            this.txtPraefix = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.grdMain = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtPath = new DevExpress.XtraEditors.ButtonEdit();
            this.cmdOpenXAFMLFile = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.OpenFileDialog = new DevExpress.XtraEditors.XtraOpenFileDialog(this.components);
            this.SaveFileDialog = new DevExpress.XtraEditors.XtraSaveFileDialog(this.components);
            this.directXFormContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prgPreparation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCode)).BeginInit();
            this.grpCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNamespace.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgCodeGeneration.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgTextOptions.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostfix.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPraefix.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            this.SuspendLayout();
            // 
            // directXFormContainerControl1
            // 
            this.directXFormContainerControl1.Controls.Add(this.layoutControl1);
            this.directXFormContainerControl1.Location = new System.Drawing.Point(1, 31);
            this.directXFormContainerControl1.Name = "directXFormContainerControl1";
            this.directXFormContainerControl1.Size = new System.Drawing.Size(953, 693);
            this.directXFormContainerControl1.TabIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.prgPreparation);
            this.layoutControl1.Controls.Add(this.grpCode);
            this.layoutControl1.Controls.Add(this.grdMain);
            this.layoutControl1.Controls.Add(this.txtPath);
            this.layoutControl1.Controls.Add(this.cmdOpenXAFMLFile);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(970, -1147, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(953, 693);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // prgPreparation
            // 
            this.prgPreparation.Location = new System.Drawing.Point(12, 386);
            this.prgPreparation.Name = "prgPreparation";
            this.prgPreparation.Size = new System.Drawing.Size(929, 15);
            this.prgPreparation.StyleController = this.layoutControl1;
            this.prgPreparation.TabIndex = 8;
            // 
            // grpCode
            // 
            this.grpCode.CaptionImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("grpCode.CaptionImageOptions.SvgImage")));
            this.grpCode.Controls.Add(this.layoutControl2);
            this.grpCode.Enabled = false;
            this.grpCode.Location = new System.Drawing.Point(12, 405);
            this.grpCode.Name = "grpCode";
            this.grpCode.Size = new System.Drawing.Size(929, 276);
            this.grpCode.TabIndex = 7;
            this.grpCode.Text = "Code Generation";
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.txtNamespace);
            this.layoutControl2.Controls.Add(this.cmdCreateFile);
            this.layoutControl2.Controls.Add(this.cmdShowCode);
            this.layoutControl2.Controls.Add(this.rdgCodeGeneration);
            this.layoutControl2.Controls.Add(this.rdgTextOptions);
            this.layoutControl2.Controls.Add(this.txtPostfix);
            this.layoutControl2.Controls.Add(this.txtPraefix);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 33);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(956, -1161, 650, 400);
            this.layoutControl2.Root = this.layoutControlGroup1;
            this.layoutControl2.Size = new System.Drawing.Size(925, 241);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // txtNamespace
            // 
            this.txtNamespace.Location = new System.Drawing.Point(112, 12);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(801, 20);
            this.txtNamespace.StyleController = this.layoutControl2;
            this.txtNamespace.TabIndex = 10;
            // 
            // cmdCreateFile
            // 
            this.cmdCreateFile.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("cmdCreateFile.ImageOptions.SvgImage")));
            this.cmdCreateFile.Location = new System.Drawing.Point(607, 193);
            this.cmdCreateFile.Name = "cmdCreateFile";
            this.cmdCreateFile.Size = new System.Drawing.Size(306, 36);
            this.cmdCreateFile.StyleController = this.layoutControl2;
            this.cmdCreateFile.TabIndex = 9;
            this.cmdCreateFile.Text = "Create file";
            this.cmdCreateFile.Click += new System.EventHandler(this.cmdCreateFile_Click);
            // 
            // cmdShowCode
            // 
            this.cmdShowCode.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("cmdShowCode.ImageOptions.SvgImage")));
            this.cmdShowCode.Location = new System.Drawing.Point(12, 193);
            this.cmdShowCode.Name = "cmdShowCode";
            this.cmdShowCode.Size = new System.Drawing.Size(325, 36);
            this.cmdShowCode.StyleController = this.layoutControl2;
            this.cmdShowCode.TabIndex = 8;
            this.cmdShowCode.Text = "Show code file";
            this.cmdShowCode.Click += new System.EventHandler(this.cmdShowCode_Click);
            // 
            // rdgCodeGeneration
            // 
            this.rdgCodeGeneration.Location = new System.Drawing.Point(112, 133);
            this.rdgCodeGeneration.Name = "rdgCodeGeneration";
            this.rdgCodeGeneration.Properties.Columns = 2;
            this.rdgCodeGeneration.Properties.ItemHorzAlignment = DevExpress.XtraEditors.RadioItemHorzAlignment.Center;
            this.rdgCodeGeneration.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "C#"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Visual Basic")});
            this.rdgCodeGeneration.Size = new System.Drawing.Size(801, 56);
            this.rdgCodeGeneration.StyleController = this.layoutControl2;
            this.rdgCodeGeneration.TabIndex = 7;
            // 
            // rdgTextOptions
            // 
            this.rdgTextOptions.Location = new System.Drawing.Point(112, 84);
            this.rdgTextOptions.Name = "rdgTextOptions";
            this.rdgTextOptions.Properties.Columns = 4;
            this.rdgTextOptions.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "None"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "First letter to upper"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Text to lower"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "Text to upper")});
            this.rdgTextOptions.Size = new System.Drawing.Size(801, 45);
            this.rdgTextOptions.StyleController = this.layoutControl2;
            this.rdgTextOptions.TabIndex = 6;
            // 
            // txtPostfix
            // 
            this.txtPostfix.Location = new System.Drawing.Point(112, 60);
            this.txtPostfix.Name = "txtPostfix";
            this.txtPostfix.Size = new System.Drawing.Size(801, 20);
            this.txtPostfix.StyleController = this.layoutControl2;
            this.txtPostfix.TabIndex = 5;
            // 
            // txtPraefix
            // 
            this.txtPraefix.Location = new System.Drawing.Point(112, 36);
            this.txtPraefix.Name = "txtPraefix";
            this.txtPraefix.Size = new System.Drawing.Size(801, 20);
            this.txtPraefix.StyleController = this.layoutControl2;
            this.txtPraefix.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5,
            this.emptySpaceItem1,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.layoutControlItem11});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(925, 241);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtPraefix;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(905, 24);
            this.layoutControlItem5.Text = "Praefix";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(88, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(329, 181);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(266, 40);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtPostfix;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(905, 24);
            this.layoutControlItem6.Text = "Postfix";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(88, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.rdgTextOptions;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(905, 49);
            this.layoutControlItem7.Text = "Text options";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(88, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.rdgCodeGeneration;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 121);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(905, 60);
            this.layoutControlItem8.Text = "Code Generation";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(88, 13);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.cmdShowCode;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 181);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(329, 40);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.cmdCreateFile;
            this.layoutControlItem10.Location = new System.Drawing.Point(595, 181);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(310, 40);
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.txtNamespace;
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(905, 24);
            this.layoutControlItem11.Text = "Namespace";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(88, 13);
            // 
            // grdMain
            // 
            this.grdMain.Location = new System.Drawing.Point(12, 62);
            this.grdMain.MainView = this.gridView1;
            this.grdMain.Name = "grdMain";
            this.grdMain.Size = new System.Drawing.Size(929, 320);
            this.grdMain.TabIndex = 6;
            this.grdMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdMain;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(84, 12);
            this.txtPath.Name = "txtPath";
            this.txtPath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtPath.Properties.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(857, 20);
            this.txtPath.StyleController = this.layoutControl1;
            this.txtPath.TabIndex = 5;
            this.txtPath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtPath_ButtonClick);
            // 
            // cmdOpenXAFMLFile
            // 
            this.cmdOpenXAFMLFile.Location = new System.Drawing.Point(12, 36);
            this.cmdOpenXAFMLFile.Name = "cmdOpenXAFMLFile";
            this.cmdOpenXAFMLFile.Size = new System.Drawing.Size(929, 22);
            this.cmdOpenXAFMLFile.StyleController = this.layoutControl1;
            this.cmdOpenXAFMLFile.TabIndex = 4;
            this.cmdOpenXAFMLFile.Text = "Open XAFML File";
            this.cmdOpenXAFMLFile.Click += new System.EventHandler(this.cmdOpenXAFMLFile_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem13});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(953, 693);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.cmdOpenXAFMLFile;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(933, 26);
            this.layoutControlItem1.Text = "Open File Button";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtPath;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(933, 24);
            this.layoutControlItem2.Text = "XAFML Path";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(60, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.grdMain;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(104, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(933, 324);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "Grid Control";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.grpCode;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 393);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(0, 280);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(258, 248);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(933, 280);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "Code Generation Item";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.prgPreparation;
            this.layoutControlItem13.Location = new System.Drawing.Point(0, 374);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(933, 19);
            this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem13.TextVisible = false;
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "Model.DesignedDiffs.xafml";
            this.OpenFileDialog.SupportMultiDottedExtensions = true;
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.FileName = "SaveFileDialog";
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 725);
            this.Controls.Add(this.directXFormContainerControl1);
            this.DoubleBuffered = true;
            this.Name = "frmMainForm";
            this.Text = "XAF Code Generator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.directXFormContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.prgPreparation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCode)).EndInit();
            this.grpCode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNamespace.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgCodeGeneration.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgTextOptions.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostfix.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPraefix.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DirectXFormContainerControl directXFormContainerControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.XtraOpenFileDialog OpenFileDialog;
        private DevExpress.XtraEditors.XtraSaveFileDialog SaveFileDialog;
        private DevExpress.XtraEditors.ButtonEdit txtPath;
        private DevExpress.XtraEditors.SimpleButton cmdOpenXAFMLFile;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl grdMain;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.GroupControl grpCode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraEditors.RadioGroup rdgTextOptions;
        private DevExpress.XtraEditors.TextEdit txtPostfix;
        private DevExpress.XtraEditors.TextEdit txtPraefix;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.RadioGroup rdgCodeGeneration;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.SimpleButton cmdShowCode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraEditors.TextEdit txtNamespace;
        private DevExpress.XtraEditors.SimpleButton cmdCreateFile;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.ProgressBarControl prgPreparation;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
    }
}

