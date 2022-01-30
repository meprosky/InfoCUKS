namespace InfoCUKS
{
    partial class Drawing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Drawing));
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axSymbologyControl1 = new ESRI.ArcGIS.Controls.AxSymbologyControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.bText = new System.Windows.Forms.Button();
            this.bCallout = new System.Windows.Forms.Button();
            this.bColor = new System.Windows.Forms.Button();
            this.bFont = new System.Windows.Forms.Button();
            this.gbText = new System.Windows.Forms.GroupBox();
            this.gbDrawing = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.gbText.SuspendLayout();
            this.gbDrawing.SuspendLayout();
            this.SuspendLayout();
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Location = new System.Drawing.Point(6, 11);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(28, 246);
            this.axToolbarControl1.TabIndex = 0;
            // 
            // axSymbologyControl1
            // 
            this.axSymbologyControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.axSymbologyControl1.Location = new System.Drawing.Point(49, 40);
            this.axSymbologyControl1.Name = "axSymbologyControl1";
            this.axSymbologyControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSymbologyControl1.OcxState")));
            this.axSymbologyControl1.Size = new System.Drawing.Size(210, 391);
            this.axSymbologyControl1.TabIndex = 1;
            this.axSymbologyControl1.OnItemSelected += new ESRI.ArcGIS.Controls.ISymbologyControlEvents_Ax_OnItemSelectedEventHandler(this.axSymbologyControl1_OnItemSelected);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(214, 373);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 16;
            this.comboBox1.Location = new System.Drawing.Point(49, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(210, 24);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // bText
            // 
            this.bText.BackColor = System.Drawing.SystemColors.Control;
            this.bText.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bText.Image = ((System.Drawing.Image)(resources.GetObject("bText.Image")));
            this.bText.Location = new System.Drawing.Point(8, 14);
            this.bText.Name = "bText";
            this.bText.Size = new System.Drawing.Size(25, 25);
            this.bText.TabIndex = 13;
            this.bText.UseVisualStyleBackColor = false;
            this.bText.Click += new System.EventHandler(this.drawtext_Click);
            // 
            // bCallout
            // 
            this.bCallout.Image = ((System.Drawing.Image)(resources.GetObject("bCallout.Image")));
            this.bCallout.Location = new System.Drawing.Point(8, 45);
            this.bCallout.Name = "bCallout";
            this.bCallout.Size = new System.Drawing.Size(25, 25);
            this.bCallout.TabIndex = 13;
            this.bCallout.UseVisualStyleBackColor = true;
            this.bCallout.Click += new System.EventHandler(this.drawcallouttext_Click);
            // 
            // bColor
            // 
            this.bColor.BackColor = System.Drawing.Color.Red;
            this.bColor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bColor.BackgroundImage")));
            this.bColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bColor.Location = new System.Drawing.Point(8, 76);
            this.bColor.Name = "bColor";
            this.bColor.Size = new System.Drawing.Size(25, 25);
            this.bColor.TabIndex = 13;
            this.bColor.UseVisualStyleBackColor = false;
            this.bColor.Click += new System.EventHandler(this.change_color_Click);
            // 
            // bFont
            // 
            this.bFont.Image = ((System.Drawing.Image)(resources.GetObject("bFont.Image")));
            this.bFont.Location = new System.Drawing.Point(8, 107);
            this.bFont.Margin = new System.Windows.Forms.Padding(0);
            this.bFont.Name = "bFont";
            this.bFont.Size = new System.Drawing.Size(25, 25);
            this.bFont.TabIndex = 13;
            this.bFont.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bFont.UseVisualStyleBackColor = false;
            this.bFont.Click += new System.EventHandler(this.change_font_Click);
            // 
            // gbText
            // 
            this.gbText.Controls.Add(this.bFont);
            this.gbText.Controls.Add(this.bColor);
            this.gbText.Controls.Add(this.bCallout);
            this.gbText.Controls.Add(this.bText);
            this.gbText.Location = new System.Drawing.Point(3, 285);
            this.gbText.Name = "gbText";
            this.gbText.Size = new System.Drawing.Size(40, 141);
            this.gbText.TabIndex = 14;
            this.gbText.TabStop = false;
            // 
            // gbDrawing
            // 
            this.gbDrawing.Controls.Add(this.axToolbarControl1);
            this.gbDrawing.Location = new System.Drawing.Point(3, 6);
            this.gbDrawing.Name = "gbDrawing";
            this.gbDrawing.Size = new System.Drawing.Size(40, 263);
            this.gbDrawing.TabIndex = 15;
            this.gbDrawing.TabStop = false;
            // 
            // Drawing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(267, 438);
            this.Controls.Add(this.gbDrawing);
            this.Controls.Add(this.gbText);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.axSymbologyControl1);
            this.Name = "Drawing";
            this.Text = "Условные обозначения";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Drawing_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Drawing_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.gbText.ResumeLayout(false);
            this.gbDrawing.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private ESRI.ArcGIS.Controls.AxSymbologyControl axSymbologyControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button bText;
        private System.Windows.Forms.Button bCallout;
        private System.Windows.Forms.Button bColor;
        private System.Windows.Forms.Button bFont;
        private System.Windows.Forms.GroupBox gbText;
        private System.Windows.Forms.GroupBox gbDrawing;
    }
}