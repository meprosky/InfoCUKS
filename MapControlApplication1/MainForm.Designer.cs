namespace InfoCUKS
{
    partial class MainForm
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
            //Ensures that any ESRI libraries that have been used are unloaded in the correct order. 
            //Failure to do this may result in random crashes on exit due to the operating system unloading 
            //the libraries in the incorrect order. 
            ESRI.ArcGIS.ADF.COMSupport.AOUninitialize.Shutdown();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuExitApp = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyViewToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.îáíîâèòüToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.áàçûÄàííûõToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.íàñòğîéêèToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ïóòèToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusBarXY = new System.Windows.Forms.ToolStripStatusLabel();
            this.ContMnu1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MnuItemGoToXY = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axLicenseControl2 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnKV = new System.Windows.Forms.Button();
            this.btnRK = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.tsbDrawing = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_LP = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.ïîãîäàÑâîäêàÎòÖÃÌÑToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.âçğûâûToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.òâåğäûåÂçğûâ÷àòûåÂåùåñòâàToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.òîïëèâîâîçäóøíàÿÑìåñüToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ãàçîToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ïûëåâîçäóøíàÿÑìåñüToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.òåõíîãåííûåÏîæàğûToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ãîğåíèåËÂÆToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.àÕÎÂToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.êàğòî÷êèÀÕÎÂToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.àâàğèèÑÀÕÎÂToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ñåòåâîéÃğàôèêÏğîèçâîäñòâàĞàáîòToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.æÊÕToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ğàñ÷åòÏàäåíèÿÒåìïåğàòóğûToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ğàñ÷åòÑíàáæåíèÿÂîäîéToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSiS = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.ContMnu1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.editToolStripMenuItem,
            this.áàçûÄàííûõToolStripMenuItem,
            this.íàñòğîéêèToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(860, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNewDoc,
            this.menuOpenDoc,
            this.menuSaveDoc,
            this.menuSaveAs,
            this.menuSeparator,
            this.menuExitApp});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(45, 20);
            this.menuFile.Text = "Ôàéë";
            // 
            // menuNewDoc
            // 
            this.menuNewDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuNewDoc.Image")));
            this.menuNewDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuNewDoc.Name = "menuNewDoc";
            this.menuNewDoc.Size = new System.Drawing.Size(162, 22);
            this.menuNewDoc.Text = "Íîâàÿ êàğòà";
            this.menuNewDoc.Click += new System.EventHandler(this.menuNewDoc_Click);
            // 
            // menuOpenDoc
            // 
            this.menuOpenDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuOpenDoc.Image")));
            this.menuOpenDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuOpenDoc.Name = "menuOpenDoc";
            this.menuOpenDoc.Size = new System.Drawing.Size(162, 22);
            this.menuOpenDoc.Text = "Îòêğûòü êàğòó";
            this.menuOpenDoc.Click += new System.EventHandler(this.menuOpenDoc_Click);
            // 
            // menuSaveDoc
            // 
            this.menuSaveDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuSaveDoc.Image")));
            this.menuSaveDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuSaveDoc.Name = "menuSaveDoc";
            this.menuSaveDoc.Size = new System.Drawing.Size(162, 22);
            this.menuSaveDoc.Text = "Ñîõğàíèò êàğòó";
            this.menuSaveDoc.Click += new System.EventHandler(this.menuSaveDoc_Click);
            // 
            // menuSaveAs
            // 
            this.menuSaveAs.Name = "menuSaveAs";
            this.menuSaveAs.Size = new System.Drawing.Size(162, 22);
            this.menuSaveAs.Text = "Ñîõğàíèòü êàğòó";
            this.menuSaveAs.Click += new System.EventHandler(this.menuSaveAs_Click);
            // 
            // menuSeparator
            // 
            this.menuSeparator.Name = "menuSeparator";
            this.menuSeparator.Size = new System.Drawing.Size(159, 6);
            // 
            // menuExitApp
            // 
            this.menuExitApp.Name = "menuExitApp";
            this.menuExitApp.Size = new System.Drawing.Size(162, 22);
            this.menuExitApp.Text = "Âûõîä";
            this.menuExitApp.Click += new System.EventHandler(this.menuExitApp_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyViewToClipboardToolStripMenuItem,
            this.îáíîâèòüToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.editToolStripMenuItem.Text = "Êàğòà";
            // 
            // copyViewToClipboardToolStripMenuItem
            // 
            this.copyViewToClipboardToolStripMenuItem.Name = "copyViewToClipboardToolStripMenuItem";
            this.copyViewToClipboardToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.copyViewToClipboardToolStripMenuItem.Text = "Ñîõğàíèòü êàğòó";
            this.copyViewToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyViewToClipboardToolStripMenuItem_Click);
            // 
            // îáíîâèòüToolStripMenuItem
            // 
            this.îáíîâèòüToolStripMenuItem.Name = "îáíîâèòüToolStripMenuItem";
            this.îáíîâèòüToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.îáíîâèòüToolStripMenuItem.Text = "Îáíîâèòü";
            this.îáíîâèòüToolStripMenuItem.Click += new System.EventHandler(this.îáíîâèòüToolStripMenuItem_Click);
            // 
            // áàçûÄàííûõToolStripMenuItem
            // 
            this.áàçûÄàííûõToolStripMenuItem.Name = "áàçûÄàííûõToolStripMenuItem";
            this.áàçûÄàííûõToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.áàçûÄàííûõToolStripMenuItem.Text = "Áàçû äàííûõ";
            this.áàçûÄàííûõToolStripMenuItem.DropDownOpening += new System.EventHandler(this.áàçûÄàííûõToolStripMenuItem_Click);
            // 
            // íàñòğîéêèToolStripMenuItem
            // 
            this.íàñòğîéêèToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ïóòèToolStripMenuItem});
            this.íàñòğîéêèToolStripMenuItem.Name = "íàñòğîéêèToolStripMenuItem";
            this.íàñòğîéêèToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.íàñòğîéêèToolStripMenuItem.Text = "Íàñòğîéêè";
            // 
            // ïóòèToolStripMenuItem
            // 
            this.ïóòèToolStripMenuItem.Name = "ïóòèToolStripMenuItem";
            this.ïóòèToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.ïóòèToolStripMenuItem.Text = "Ïóòè ê ÁÄ";
            this.ïóòèToolStripMenuItem.Click += new System.EventHandler(this.ïóòèToolStripMenuItem_Click);
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 24);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(860, 28);
            this.axToolbarControl1.TabIndex = 3;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(73, 532);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 5;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarXY});
            this.statusStrip1.Location = new System.Drawing.Point(0, 682);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(860, 22);
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusBar1";
            // 
            // statusBarXY
            // 
            this.statusBarXY.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusBarXY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusBarXY.Name = "statusBarXY";
            this.statusBarXY.Size = new System.Drawing.Size(49, 17);
            this.statusBarXY.Text = "Test 123";
            // 
            // ContMnu1
            // 
            this.ContMnu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuItemGoToXY});
            this.ContMnu1.Name = "ContMnu1";
            this.ContMnu1.ShowImageMargin = false;
            this.ContMnu1.Size = new System.Drawing.Size(146, 26);
            // 
            // MnuItemGoToXY
            // 
            this.MnuItemGoToXY.Name = "MnuItemGoToXY";
            this.MnuItemGoToXY.Size = new System.Drawing.Size(145, 22);
            this.MnuItemGoToXY.Text = "Ïîêàçàòü íà êàğòå";
            this.MnuItemGoToXY.Click += new System.EventHandler(this.MnuItemGoToXY_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 93);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.axTOCControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.axLicenseControl2);
            this.splitContainer1.Panel2.Controls.Add(this.axMapControl1);
            this.splitContainer1.Size = new System.Drawing.Size(697, 589);
            this.splitContainer1.SplitterDistance = 77;
            this.splitContainer1.TabIndex = 9;
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axTOCControl1.Location = new System.Drawing.Point(0, 0);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(77, 589);
            this.axTOCControl1.TabIndex = 4;
            // 
            // axLicenseControl2
            // 
            this.axLicenseControl2.Enabled = true;
            this.axLicenseControl2.Location = new System.Drawing.Point(411, 367);
            this.axLicenseControl2.Name = "axLicenseControl2";
            this.axLicenseControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl2.OcxState")));
            this.axLicenseControl2.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl2.TabIndex = 3;
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(0, 0);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(616, 589);
            this.axMapControl1.TabIndex = 2;
            this.axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl1_OnMouseDown);
            this.axMapControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl1_OnMouseMove);
            this.axMapControl1.OnMapReplaced += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMapReplacedEventHandler(this.axMapControl1_OnMapReplaced);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.btnKV);
            this.panel1.Controls.Add(this.btnRK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(697, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(163, 589);
            this.panel1.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(25, 195);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 40);
            this.button2.TabIndex = 11;
            this.button2.Text = "Ñèëû è ñğåäñòâà\r\nÏ×,ÄÏÎ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 38);
            this.button1.TabIndex = 10;
            this.button1.Text = "Ôåäåğàëüíûå\r\nàâòîäîğîãè";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.kola_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(25, 241);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(116, 40);
            this.button4.TabIndex = 9;
            this.button4.Text = "Àğåíäàòîğû ëåñîâ";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.arendator_Click);
            // 
            // btnKV
            // 
            this.btnKV.Location = new System.Drawing.Point(25, 105);
            this.btnKV.Name = "btnKV";
            this.btnKV.Size = new System.Drawing.Size(116, 40);
            this.btnKV.TabIndex = 9;
            this.btnKV.Text = "Ëåñîóñòğîéñòâî";
            this.btnKV.UseVisualStyleBackColor = true;
            this.btnKV.Click += new System.EventHandler(this.btnKV_Click);
            // 
            // btnRK
            // 
            this.btnRK.Location = new System.Drawing.Point(25, 16);
            this.btnRK.Name = "btnRK";
            this.btnRK.Size = new System.Drawing.Size(116, 83);
            this.btnRK.TabIndex = 9;
            this.btnRK.Text = "Ğåñïóáëèêà \r\nÊàğåëèÿ\r\nÀäìèíèñòğàòèâíîå\r\näåëåíèå";
            this.btnRK.UseVisualStyleBackColor = true;
            this.btnRK.Click += new System.EventHandler(this.btnRK_Click);
            // 
            // fontDialog1
            // 
            this.fontDialog1.Color = System.Drawing.SystemColors.ControlText;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.toolStrip2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(860, 41);
            this.panel2.TabIndex = 11;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.tsbDrawing,
            this.toolStripLabel1,
            this.toolStripButton_LP,
            this.toolStripSeparator1,
            this.toolStripButton2,
            this.toolStripLabel2,
            this.toolStripSeparator2,
            this.toolStripButton1,
            this.toolStripSeparator3,
            this.tsbSiS,
            this.toolStripSeparator4});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(860, 41);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(36, 38);
            this.toolStripButton3.Text = "toolStripButton1";
            this.toolStripButton3.ToolTipText = "Ğåñïóáëèêà Êàğåëèÿ\r\níà êàğòå";
            this.toolStripButton3.Click += new System.EventHandler(this.view_all_RK_Click);
            // 
            // tsbDrawing
            // 
            this.tsbDrawing.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDrawing.Image = ((System.Drawing.Image)(resources.GetObject("tsbDrawing.Image")));
            this.tsbDrawing.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDrawing.Name = "tsbDrawing";
            this.tsbDrawing.Size = new System.Drawing.Size(36, 38);
            this.tsbDrawing.Text = "Ğèñîâàíèå";
            this.tsbDrawing.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 38);
            // 
            // toolStripButton_LP
            // 
            this.toolStripButton_LP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_LP.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_LP.Image")));
            this.toolStripButton_LP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_LP.Name = "toolStripButton_LP";
            this.toolStripButton_LP.Size = new System.Drawing.Size(36, 38);
            this.toolStripButton_LP.Text = "toolStripButton2";
            this.toolStripButton_LP.ToolTipText = "Ïğîãíîç ğàçâèòèÿ ËÏ";
            this.toolStripButton_LP.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ïîãîäàÑâîäêàÎòÖÃÌÑToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.àÕÎÂToolStripMenuItem,
            this.âçğûâûToolStripMenuItem,
            this.òåõíîãåííûåÏîæàğûToolStripMenuItem,
            this.æÊÕToolStripMenuItem,
            this.ñåòåâîéÃğàôèêÏğîèçâîäñòâàĞàáîòToolStripMenuItem});
            this.toolStripButton2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripButton2.ForeColor = System.Drawing.Color.Red;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(118, 38);
            this.toolStripButton2.Text = "ÏĞÎÃÍÎÇÛ";
            // 
            // ïîãîäàÑâîäêàÎòÖÃÌÑToolStripMenuItem
            // 
            this.ïîãîäàÑâîäêàÎòÖÃÌÑToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ïîãîäàÑâîäêàÎòÖÃÌÑToolStripMenuItem.Name = "ïîãîäàÑâîäêàÎòÖÃÌÑToolStripMenuItem";
            this.ïîãîäàÑâîäêàÎòÖÃÌÑToolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            this.ïîãîäàÑâîäêàÎòÖÃÌÑToolStripMenuItem.Text = "Ïîãîäà ñâîäêà îò ÖÃÌÑ";
            this.ïîãîäàÑâîäêàÎòÖÃÌÑToolStripMenuItem.Click += new System.EventHandler(this.ïîãîäàÑâîäêàÎòÖÃÌÑToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(293, 22);
            this.toolStripMenuItem1.Text = "Ïîãîäà ìåæäóíàğîäíûé ïğîãíîç";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.ïîãîäàToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(293, 22);
            this.toolStripMenuItem2.Text = "Ëåñíûå ïîæàğû";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.ëåñíûåÏîæàğûToolStripMenuItem_Click);
            // 
            // âçğûâûToolStripMenuItem
            // 
            this.âçğûâûToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.òâåğäûåÂçğûâ÷àòûåÂåùåñòâàToolStripMenuItem,
            this.òîïëèâîâîçäóøíàÿÑìåñüToolStripMenuItem,
            this.ãàçîToolStripMenuItem,
            this.ïûëåâîçäóøíàÿÑìåñüToolStripMenuItem});
            this.âçğûâûToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.âçğûâûToolStripMenuItem.Name = "âçğûâûToolStripMenuItem";
            this.âçğûâûToolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            this.âçğûâûToolStripMenuItem.Text = "Âçğûâû";
            // 
            // òâåğäûåÂçğûâ÷àòûåÂåùåñòâàToolStripMenuItem
            // 
            this.òâåğäûåÂçğûâ÷àòûåÂåùåñòâàToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.òâåğäûåÂçğûâ÷àòûåÂåùåñòâàToolStripMenuItem.Name = "òâåğäûåÂçğûâ÷àòûåÂåùåñòâàToolStripMenuItem";
            this.òâåğäûåÂçğûâ÷àòûåÂåùåñòâàToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.òâåğäûåÂçğûâ÷àòûåÂåùåñòâàToolStripMenuItem.Text = "Òâåğäûå âçğûâ÷àòûå âåùåñòâà";
            this.òâåğäûåÂçğûâ÷àòûåÂåùåñòâàToolStripMenuItem.Click += new System.EventHandler(this.òâåğäûåÂçğûâ÷àòûåÂåùåñòâàToolStripMenuItem_Click);
            // 
            // òîïëèâîâîçäóøíàÿÑìåñüToolStripMenuItem
            // 
            this.òîïëèâîâîçäóøíàÿÑìåñüToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.òîïëèâîâîçäóøíàÿÑìåñüToolStripMenuItem.Name = "òîïëèâîâîçäóøíàÿÑìåñüToolStripMenuItem";
            this.òîïëèâîâîçäóøíàÿÑìåñüToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.òîïëèâîâîçäóøíàÿÑìåñüToolStripMenuItem.Text = "Òîïëèâîâîçäóøíàÿ ñìåñü";
            this.òîïëèâîâîçäóøíàÿÑìåñüToolStripMenuItem.Click += new System.EventHandler(this.òîïëèâîâîçäóøíàÿÑìåñüToolStripMenuItem_Click);
            // 
            // ãàçîToolStripMenuItem
            // 
            this.ãàçîToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ãàçîToolStripMenuItem.Name = "ãàçîToolStripMenuItem";
            this.ãàçîToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.ãàçîToolStripMenuItem.Text = "Ãàçî- ïàğîâîçäóøíàÿ ñìåñü";
            this.ãàçîToolStripMenuItem.Click += new System.EventHandler(this.ãàçîToolStripMenuItem_Click);
            // 
            // ïûëåâîçäóøíàÿÑìåñüToolStripMenuItem
            // 
            this.ïûëåâîçäóøíàÿÑìåñüToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ïûëåâîçäóøíàÿÑìåñüToolStripMenuItem.Name = "ïûëåâîçäóøíàÿÑìåñüToolStripMenuItem";
            this.ïûëåâîçäóøíàÿÑìåñüToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.ïûëåâîçäóøíàÿÑìåñüToolStripMenuItem.Text = "Ïûëåâîçäóøíàÿ ñìåñü";
            this.ïûëåâîçäóøíàÿÑìåñüToolStripMenuItem.Click += new System.EventHandler(this.ïûëåâîçäóøíàÿÑìåñüToolStripMenuItem_Click);
            // 
            // òåõíîãåííûåÏîæàğûToolStripMenuItem
            // 
            this.òåõíîãåííûåÏîæàğûToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ãîğåíèåËÂÆToolStripMenuItem});
            this.òåõíîãåííûåÏîæàğûToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.òåõíîãåííûåÏîæàğûToolStripMenuItem.Name = "òåõíîãåííûåÏîæàğûToolStripMenuItem";
            this.òåõíîãåííûåÏîæàğûToolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            this.òåõíîãåííûåÏîæàğûToolStripMenuItem.Text = "Òåõíîãåííûå ïîæàğû";
            // 
            // ãîğåíèåËÂÆToolStripMenuItem
            // 
            this.ãîğåíèåËÂÆToolStripMenuItem.Name = "ãîğåíèåËÂÆToolStripMenuItem";
            this.ãîğåíèåËÂÆToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.ãîğåíèåËÂÆToolStripMenuItem.Text = "Ãîğåíèå ËÂÆ";
            this.ãîğåíèåËÂÆToolStripMenuItem.Click += new System.EventHandler(this.ãîğåíèåËÂÆToolStripMenuItem_Click);
            // 
            // àÕÎÂToolStripMenuItem
            // 
            this.àÕÎÂToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.êàğòî÷êèÀÕÎÂToolStripMenuItem,
            this.àâàğèèÑÀÕÎÂToolStripMenuItem});
            this.àÕÎÂToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.àÕÎÂToolStripMenuItem.Name = "àÕÎÂToolStripMenuItem";
            this.àÕÎÂToolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            this.àÕÎÂToolStripMenuItem.Text = "ÀÕÎÂ";
            // 
            // êàğòî÷êèÀÕÎÂToolStripMenuItem
            // 
            this.êàğòî÷êèÀÕÎÂToolStripMenuItem.Name = "êàğòî÷êèÀÕÎÂToolStripMenuItem";
            this.êàğòî÷êèÀÕÎÂToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.êàğòî÷êèÀÕÎÂToolStripMenuItem.Text = "Êàğòî÷êè ÀÕÎÂ";
            this.êàğòî÷êèÀÕÎÂToolStripMenuItem.Click += new System.EventHandler(this.êàğòî÷êèÀÕÎÂToolStripMenuItem_Click);
            // 
            // àâàğèèÑÀÕÎÂToolStripMenuItem
            // 
            this.àâàğèèÑÀÕÎÂToolStripMenuItem.Name = "àâàğèèÑÀÕÎÂToolStripMenuItem";
            this.àâàğèèÑÀÕÎÂToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.àâàğèèÑÀÕÎÂToolStripMenuItem.Text = "Àâàğèè ñ ÀÕÎÂ";
            this.àâàğèèÑÀÕÎÂToolStripMenuItem.Click += new System.EventHandler(this.àâàğèèÑÀÕÎÂToolStripMenuItem_Click);
            // 
            // ñåòåâîéÃğàôèêÏğîèçâîäñòâàĞàáîòToolStripMenuItem
            // 
            this.ñåòåâîéÃğàôèêÏğîèçâîäñòâàĞàáîòToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ñåòåâîéÃğàôèêÏğîèçâîäñòâàĞàáîòToolStripMenuItem.Name = "ñåòåâîéÃğàôèêÏğîèçâîäñòâàĞàáîòToolStripMenuItem";
            this.ñåòåâîéÃğàôèêÏğîèçâîäñòâàĞàáîòToolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            this.ñåòåâîéÃğàôèêÏğîèçâîäñòâàĞàáîòToolStripMenuItem.Text = "Ñåòåâîé ãğàôèê ïğîèçâîäñòâà ğàáîò";
            this.ñåòåâîéÃğàôèêÏğîèçâîäñòâàĞàáîòToolStripMenuItem.Click += new System.EventHandler(this.ñåòåâîéÃğàôèêÏğîèçâîäñòâàĞàáîòToolStripMenuItem_Click);
            // 
            // æÊÕToolStripMenuItem
            // 
            this.æÊÕToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ğàñ÷åòÏàäåíèÿÒåìïåğàòóğûToolStripMenuItem,
            this.ğàñ÷åòÑíàáæåíèÿÂîäîéToolStripMenuItem});
            this.æÊÕToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.æÊÕToolStripMenuItem.Name = "æÊÕToolStripMenuItem";
            this.æÊÕToolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            this.æÊÕToolStripMenuItem.Text = "ÆÊÕ";
            // 
            // ğàñ÷åòÏàäåíèÿÒåìïåğàòóğûToolStripMenuItem
            // 
            this.ğàñ÷åòÏàäåíèÿÒåìïåğàòóğûToolStripMenuItem.Name = "ğàñ÷åòÏàäåíèÿÒåìïåğàòóğûToolStripMenuItem";
            this.ğàñ÷åòÏàäåíèÿÒåìïåğàòóğûToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.ğàñ÷åòÏàäåíèÿÒåìïåğàòóğûToolStripMenuItem.Text = "Ğàñ÷åò ïàäåíèÿ òåìïåğàòóğû";
            this.ğàñ÷åòÏàäåíèÿÒåìïåğàòóğûToolStripMenuItem.Click += new System.EventHandler(this.ğàñ÷åòÏàäåíèÿÒåìïåğàòóğûToolStripMenuItem_Click);
            // 
            // ğàñ÷åòÑíàáæåíèÿÂîäîéToolStripMenuItem
            // 
            this.ğàñ÷åòÑíàáæåíèÿÂîäîéToolStripMenuItem.Name = "ğàñ÷åòÑíàáæåíèÿÂîäîéToolStripMenuItem";
            this.ğàñ÷åòÑíàáæåíèÿÂîäîéToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.ğàñ÷åòÑíàáæåíèÿÂîäîéToolStripMenuItem.Text = "Ğàñ÷åò ñíàáæåíèÿ âîäîé";
            this.ğàñ÷åòÑíàáæåíèÿÂîäîéToolStripMenuItem.Click += new System.EventHandler(this.ğàñ÷åòÑíàáæåíèÿÂîäîéToolStripMenuItem_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(124, 38);
            this.toolStripLabel2.Text = "                                       ";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(93, 38);
            this.toolStripButton1.Text = "Àëãîğèòìû ÎÄÑ";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 41);
            // 
            // tsbSiS
            // 
            this.tsbSiS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSiS.Image = ((System.Drawing.Image)(resources.GetObject("tsbSiS.Image")));
            this.tsbSiS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSiS.Name = "tsbSiS";
            this.tsbSiS.Size = new System.Drawing.Size(73, 38);
            this.tsbSiS.Text = "ÑèÑ â òî÷êå";
            this.tsbSiS.Click += new System.EventHandler(this.tsbSiS_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 41);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 704);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "InfoCUKS";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ContMnu1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuNewDoc;
        private System.Windows.Forms.ToolStripMenuItem menuOpenDoc;
        private System.Windows.Forms.ToolStripMenuItem menuSaveDoc;
        private System.Windows.Forms.ToolStripMenuItem menuSaveAs;
        private System.Windows.Forms.ToolStripMenuItem menuExitApp;
        private System.Windows.Forms.ToolStripSeparator menuSeparator;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusBarXY;
        private System.Windows.Forms.ContextMenuStrip ContMnu1;
        private System.Windows.Forms.ToolStripMenuItem MnuItemGoToXY;            //private áûë
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRK;
        private System.Windows.Forms.Button btnKV;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyViewToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem áàçûÄàííûõToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ToolStripMenuItem îáíîâèòüToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton tsbDrawing;
        public ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl2;
        public ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem íàñòğîéêèToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ïóòèToolStripMenuItem;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbSiS;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton_LP;
        private System.Windows.Forms.ToolStripSplitButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem âçğûâûToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem òâåğäûåÂçğûâ÷àòûåÂåùåñòâàToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem òîïëèâîâîçäóøíàÿÑìåñüToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ãàçîToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ïûëåâîçäóøíàÿÑìåñüToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem òåõíîãåííûåÏîæàğûToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ãîğåíèåËÂÆToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem àÕÎÂToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem êàğòî÷êèÀÕÎÂToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem àâàğèèÑÀÕÎÂToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem æÊÕToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ğàñ÷åòÏàäåíèÿÒåìïåğàòóğûToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ğàñ÷åòÑíàáæåíèÿÂîäîéToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ïîãîäàÑâîäêàÎòÖÃÌÑToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ñåòåâîéÃğàôèêÏğîèçâîäñòâàĞàáîòToolStripMenuItem;
    }
}

