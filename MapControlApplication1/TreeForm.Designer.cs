namespace InfoCUKS
{
    partial class TreeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ïîêàçàòüÍàÊàğòåToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.èôîğìàöèÿÎáÎáúåêòåToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ïîñòğîèòüÑâÿçèToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cBox_schema = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboxSearch = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.äîêóìåíòûToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(426, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.fileToolStripMenuItem.Text = "Ôàéë";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 573);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(426, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 63);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(426, 510);
            this.treeView1.TabIndex = 3;
            this.treeView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseUp);
            this.treeView1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterExpand);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ïîêàçàòüÍàÊàğòåToolStripMenuItem,
            this.èôîğìàöèÿÎáÎáúåêòåToolStripMenuItem,
            this.äîêóìåíòûToolStripMenuItem,
            this.ïîñòğîèòüÑâÿçèToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(204, 114);
            // 
            // ïîêàçàòüÍàÊàğòåToolStripMenuItem
            // 
            this.ïîêàçàòüÍàÊàğòåToolStripMenuItem.Name = "ïîêàçàòüÍàÊàğòåToolStripMenuItem";
            this.ïîêàçàòüÍàÊàğòåToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.ïîêàçàòüÍàÊàğòåToolStripMenuItem.Text = "Ïîêàçàòü íà êàğòå";
            this.ïîêàçàòüÍàÊàğòåToolStripMenuItem.Click += new System.EventHandler(this.ïîêàçàòüÍàÊàğòåToolStripMenuItem_Click);
            // 
            // èôîğìàöèÿÎáÎáúåêòåToolStripMenuItem
            // 
            this.èôîğìàöèÿÎáÎáúåêòåToolStripMenuItem.Name = "èôîğìàöèÿÎáÎáúåêòåToolStripMenuItem";
            this.èôîğìàöèÿÎáÎáúåêòåToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.èôîğìàöèÿÎáÎáúåêòåToolStripMenuItem.Text = "Èôîğìàöèÿ îá îáúåêòå";
            this.èôîğìàöèÿÎáÎáúåêòåToolStripMenuItem.Click += new System.EventHandler(this.èôîğìàöèÿÎáÎáúåêòåToolStripMenuItem_Click);
            // 
            // ïîñòğîèòüÑâÿçèToolStripMenuItem
            // 
            this.ïîñòğîèòüÑâÿçèToolStripMenuItem.Name = "ïîñòğîèòüÑâÿçèToolStripMenuItem";
            this.ïîñòğîèòüÑâÿçèToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.ïîñòğîèòüÑâÿçèToolStripMenuItem.Text = "Câÿçàííûå îáúåêòû";
            this.ïîñòğîèòüÑâÿçèToolStripMenuItem.MouseHover += new System.EventHandler(this.ïîñòğîèòüÑâÿçèToolStripMenuItem_MouseHover);
            // 
            // cBox_schema
            // 
            this.cBox_schema.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cBox_schema.FormattingEnabled = true;
            this.cBox_schema.Location = new System.Drawing.Point(4, 9);
            this.cBox_schema.Name = "cBox_schema";
            this.cBox_schema.Size = new System.Drawing.Size(208, 21);
            this.cBox_schema.TabIndex = 4;
            this.cBox_schema.DropDownClosed += new System.EventHandler(this.cBox_schema_DropDownClosed);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(262, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 24);
            this.label1.TabIndex = 6;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboxSearch
            // 
            this.cboxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboxSearch.FormattingEnabled = true;
            this.cboxSearch.Location = new System.Drawing.Point(294, 9);
            this.cboxSearch.Name = "cboxSearch";
            this.cboxSearch.Size = new System.Drawing.Size(128, 21);
            this.cboxSearch.TabIndex = 4;
            this.cboxSearch.DropDownClosed += new System.EventHandler(this.cBox_schema_DropDownClosed);
            this.cboxSearch.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboxSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cBox_schema);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(426, 39);
            this.panel1.TabIndex = 7;
            // 
            // äîêóìåíòûToolStripMenuItem
            // 
            this.äîêóìåíòûToolStripMenuItem.Name = "äîêóìåíòûToolStripMenuItem";
            this.äîêóìåíòûToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.äîêóìåíòûToolStripMenuItem.Text = "Äîêóìåíòû";
            this.äîêóìåíòûToolStripMenuItem.Click += new System.EventHandler(this.äîêóìåíòûToolStripMenuItem_Click);
            // 
            // TreeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 595);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TreeForm";
            this.Text = "Îáúåêòû";
            this.Load += new System.EventHandler(this.TreeForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.testForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ïîêàçàòüÍàÊàğòåToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem èôîğìàöèÿÎáÎáúåêòåToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ïîñòğîèòüÑâÿçèToolStripMenuItem;
        private System.Windows.Forms.ComboBox cBox_schema;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboxSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem äîêóìåíòûToolStripMenuItem;

    }
}