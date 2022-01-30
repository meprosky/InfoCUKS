namespace InfoCUKS
{
    partial class Path2DB
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboMap = new System.Windows.Forms.ComboBox();
            this.comboPath = new System.Windows.Forms.ComboBox();
            this.buttOK = new System.Windows.Forms.Button();
            this.buttCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Путь к БД";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Путь к документу карты";
            // 
            // comboMap
            // 
            this.comboMap.FormattingEnabled = true;
            this.comboMap.Items.AddRange(new object[] {
            "..\\..\\..\\rkv2_4test.mxd",
            "V:\\ПО\\DB\\rkv2_4info.mxd",
            "D:\\C#\\Data\\РК.mxd"});
            this.comboMap.Location = new System.Drawing.Point(15, 87);
            this.comboMap.Name = "comboMap";
            this.comboMap.Size = new System.Drawing.Size(430, 21);
            this.comboMap.TabIndex = 1;
            // 
            // comboPath
            // 
            this.comboPath.FormattingEnabled = true;
            this.comboPath.Items.AddRange(new object[] {
            "..\\..\\..\\db3_beta.mdb",
            "d:\\c#\\data\\db3.mdb",
            "V:\\ПО\\DB\\db3.mdb"});
            this.comboPath.Location = new System.Drawing.Point(15, 38);
            this.comboPath.Name = "comboPath";
            this.comboPath.Size = new System.Drawing.Size(430, 21);
            this.comboPath.TabIndex = 1;
            this.comboPath.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // buttOK
            // 
            this.buttOK.Location = new System.Drawing.Point(309, 142);
            this.buttOK.Name = "buttOK";
            this.buttOK.Size = new System.Drawing.Size(62, 27);
            this.buttOK.TabIndex = 2;
            this.buttOK.Text = "Ok";
            this.buttOK.UseVisualStyleBackColor = true;
            this.buttOK.Click += new System.EventHandler(this.Ok_Click);
            // 
            // buttCancel
            // 
            this.buttCancel.Location = new System.Drawing.Point(377, 142);
            this.buttCancel.Name = "buttCancel";
            this.buttCancel.Size = new System.Drawing.Size(65, 27);
            this.buttCancel.TabIndex = 2;
            this.buttCancel.Text = "Отмена";
            this.buttCancel.UseVisualStyleBackColor = true;
            this.buttCancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Path2DB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 175);
            this.Controls.Add(this.buttCancel);
            this.Controls.Add(this.buttOK);
            this.Controls.Add(this.comboPath);
            this.Controls.Add(this.comboMap);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Path2DB";
            this.Text = "Пути к БД";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboMap;
        private System.Windows.Forms.ComboBox comboPath;
        private System.Windows.Forms.Button buttOK;
        private System.Windows.Forms.Button buttCancel;
    }
}