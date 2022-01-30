namespace InfoCUKS
{
    partial class FormLP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLP));
            this.button_Close = new System.Windows.Forms.Button();
            this.tboxS0 = new System.Windows.Forms.TextBox();
            this.tBoxTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelT = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboxVwind = new System.Windows.Forms.ComboBox();
            this.labelS = new System.Windows.Forms.Label();
            this.cboxFirType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxWoodType = new System.Windows.Forms.ComboBox();
            this.cboxEmerClass = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cBoxWindDirection = new System.Windows.Forms.ComboBox();
            this.chkbOchag = new System.Windows.Forms.CheckBox();
            this.chkBoxInfo = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tBoxPrognoz = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tboxKM = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tboxKM_T = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tboxSiS = new System.Windows.Forms.TextBox();
            this.chkBoxSiS = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button_activate = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Close
            // 
            this.button_Close.Location = new System.Drawing.Point(277, 674);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(83, 29);
            this.button_Close.TabIndex = 3;
            this.button_Close.Text = "Закрыть";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // tboxS0
            // 
            this.tboxS0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tboxS0.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tboxS0.Location = new System.Drawing.Point(180, 20);
            this.tboxS0.Name = "tboxS0";
            this.tboxS0.Size = new System.Drawing.Size(157, 20);
            this.tboxS0.TabIndex = 2;
            this.tboxS0.Text = "1";
            this.tboxS0.TextChanged += new System.EventHandler(this.tboxS0_TextChanged);
            this.tboxS0.Leave += new System.EventHandler(this.tboxS0_Leave);
            // 
            // tBoxTime
            // 
            this.tBoxTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tBoxTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tBoxTime.Location = new System.Drawing.Point(180, 186);
            this.tBoxTime.Name = "tBoxTime";
            this.tBoxTime.Size = new System.Drawing.Size(157, 20);
            this.tBoxTime.TabIndex = 2;
            this.tBoxTime.Text = "1";
            this.tBoxTime.TextChanged += new System.EventHandler(this.tBoxTime_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(7, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 26);
            this.label5.TabIndex = 0;
            this.label5.Text = "Погодный класс\r\nпожарной опасности";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(5, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Класс горимости насаждений";
            // 
            // labelT
            // 
            this.labelT.AutoSize = true;
            this.labelT.BackColor = System.Drawing.SystemColors.Control;
            this.labelT.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelT.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labelT.Location = new System.Drawing.Point(68, 656);
            this.labelT.Name = "labelT";
            this.labelT.Size = new System.Drawing.Size(156, 28);
            this.labelT.TabIndex = 0;
            this.labelT.Text = "ФКУ \"ЦУКС ГУ МЧС России\r\nпо Республике Карелия\"";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(5, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Вид пожара";
            // 
            // cboxVwind
            // 
            this.cboxVwind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxVwind.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboxVwind.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboxVwind.FormattingEnabled = true;
            this.cboxVwind.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cboxVwind.Location = new System.Drawing.Point(181, 46);
            this.cboxVwind.Name = "cboxVwind";
            this.cboxVwind.Size = new System.Drawing.Size(156, 21);
            this.cboxVwind.TabIndex = 6;
            this.cboxVwind.SelectionChangeCommitted += new System.EventHandler(this.cboxVwind_SelectionChangeCommitted);
            // 
            // labelS
            // 
            this.labelS.AutoSize = true;
            this.labelS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelS.Location = new System.Drawing.Point(7, 23);
            this.labelS.Name = "labelS";
            this.labelS.Size = new System.Drawing.Size(169, 13);
            this.labelS.TabIndex = 0;
            this.labelS.Text = "Начальная площадь пожара, Га";
            // 
            // cboxFirType
            // 
            this.cboxFirType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxFirType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboxFirType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboxFirType.FormattingEnabled = true;
            this.cboxFirType.Location = new System.Drawing.Point(181, 101);
            this.cboxFirType.Name = "cboxFirType";
            this.cboxFirType.Size = new System.Drawing.Size(156, 21);
            this.cboxFirType.TabIndex = 7;
            this.cboxFirType.SelectionChangeCommitted += new System.EventHandler(this.cboxVwind_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(5, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Скорость ветра, м/с";
            // 
            // cboxWoodType
            // 
            this.cboxWoodType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxWoodType.DropDownWidth = 410;
            this.cboxWoodType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboxWoodType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboxWoodType.FormattingEnabled = true;
            this.cboxWoodType.ItemHeight = 13;
            this.cboxWoodType.Location = new System.Drawing.Point(180, 126);
            this.cboxWoodType.Name = "cboxWoodType";
            this.cboxWoodType.Size = new System.Drawing.Size(157, 21);
            this.cboxWoodType.TabIndex = 7;
            this.cboxWoodType.SelectionChangeCommitted += new System.EventHandler(this.cboxVwind_SelectionChangeCommitted);
            // 
            // cboxEmerClass
            // 
            this.cboxEmerClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxEmerClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboxEmerClass.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboxEmerClass.FormattingEnabled = true;
            this.cboxEmerClass.Location = new System.Drawing.Point(180, 154);
            this.cboxEmerClass.Name = "cboxEmerClass";
            this.cboxEmerClass.Size = new System.Drawing.Size(157, 21);
            this.cboxEmerClass.TabIndex = 7;
            this.cboxEmerClass.SelectionChangeCommitted += new System.EventHandler(this.cboxVwind_SelectionChangeCommitted);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(5, 77);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(107, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Направление ветра";
            // 
            // cBoxWindDirection
            // 
            this.cBoxWindDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxWindDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cBoxWindDirection.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cBoxWindDirection.FormattingEnabled = true;
            this.cBoxWindDirection.Location = new System.Drawing.Point(181, 74);
            this.cBoxWindDirection.Name = "cBoxWindDirection";
            this.cBoxWindDirection.Size = new System.Drawing.Size(156, 21);
            this.cBoxWindDirection.TabIndex = 6;
            this.cBoxWindDirection.SelectionChangeCommitted += new System.EventHandler(this.cboxVwind_SelectionChangeCommitted);
            // 
            // chkbOchag
            // 
            this.chkbOchag.AutoSize = true;
            this.chkbOchag.Checked = true;
            this.chkbOchag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbOchag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkbOchag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkbOchag.Location = new System.Drawing.Point(19, 211);
            this.chkbOchag.Name = "chkbOchag";
            this.chkbOchag.Size = new System.Drawing.Size(141, 17);
            this.chkbOchag.TabIndex = 8;
            this.chkbOchag.Text = "Наносить очаг пожара";
            this.chkbOchag.UseVisualStyleBackColor = true;
            // 
            // chkBoxInfo
            // 
            this.chkBoxInfo.AutoSize = true;
            this.chkBoxInfo.Checked = true;
            this.chkBoxInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkBoxInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkBoxInfo.Location = new System.Drawing.Point(19, 19);
            this.chkBoxInfo.Name = "chkBoxInfo";
            this.chkBoxInfo.Size = new System.Drawing.Size(205, 17);
            this.chkBoxInfo.TabIndex = 8;
            this.chkBoxInfo.Text = "Показывать информацию на карте";
            this.chkBoxInfo.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(7, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Время распространения ЛП, ч";
            // 
            // tBoxPrognoz
            // 
            this.tBoxPrognoz.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tBoxPrognoz.Location = new System.Drawing.Point(13, 42);
            this.tBoxPrognoz.Multiline = true;
            this.tBoxPrognoz.Name = "tBoxPrognoz";
            this.tBoxPrognoz.Size = new System.Drawing.Size(329, 165);
            this.tBoxPrognoz.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.ForeColor = System.Drawing.SystemColors.Control;
            this.panel1.Location = new System.Drawing.Point(8, 655);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(54, 56);
            this.panel1.TabIndex = 10;
            // 
            // tboxKM
            // 
            this.tboxKM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tboxKM.Location = new System.Drawing.Point(103, 32);
            this.tboxKM.Name = "tboxKM";
            this.tboxKM.Size = new System.Drawing.Size(61, 20);
            this.tboxKM.TabIndex = 2;
            this.tboxKM.Text = "1";
            this.tboxKM.TextChanged += new System.EventHandler(this.tboxKM_TextChanged);
            this.tboxKM.Leave += new System.EventHandler(this.tboxS0_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(10, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 26);
            this.label8.TabIndex = 0;
            this.label8.Text = "Расстояние, км\r\n(введите число)\r\n";
            // 
            // tboxKM_T
            // 
            this.tboxKM_T.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tboxKM_T.Location = new System.Drawing.Point(263, 32);
            this.tboxKM_T.Name = "tboxKM_T";
            this.tboxKM_T.Size = new System.Drawing.Size(73, 20);
            this.tboxKM_T.TabIndex = 2;
            this.tboxKM_T.TextChanged += new System.EventHandler(this.tboxS0_TextChanged);
            this.tboxKM_T.Leave += new System.EventHandler(this.tboxS0_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(195, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 26);
            this.label9.TabIndex = 0;
            this.label9.Text = "расчетное\r\nвремя, час";
            // 
            // tboxSiS
            // 
            this.tboxSiS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tboxSiS.Location = new System.Drawing.Point(7, 42);
            this.tboxSiS.Multiline = true;
            this.tboxSiS.Name = "tboxSiS";
            this.tboxSiS.Size = new System.Drawing.Size(329, 46);
            this.tboxSiS.TabIndex = 9;
            // 
            // chkBoxSiS
            // 
            this.chkBoxSiS.AutoSize = true;
            this.chkBoxSiS.Checked = true;
            this.chkBoxSiS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxSiS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkBoxSiS.Location = new System.Drawing.Point(13, 19);
            this.chkBoxSiS.Name = "chkBoxSiS";
            this.chkBoxSiS.Size = new System.Drawing.Size(237, 17);
            this.chkBoxSiS.TabIndex = 8;
            this.chkBoxSiS.Text = "Показывать информацию о СиС на карте";
            this.chkBoxSiS.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tboxKM);
            this.groupBox1.Controls.Add(this.tboxKM_T);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(14, 576);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 65);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Расчет времени прохождения фронта ЛП";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tboxSiS);
            this.groupBox2.Controls.Add(this.chkBoxSiS);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(6, 222);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(346, 96);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Расчет сил и средств для ликвидации ЛП";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tBoxPrognoz);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.chkBoxInfo);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.ForeColor = System.Drawing.Color.Firebrick;
            this.groupBox3.Location = new System.Drawing.Point(8, 246);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(359, 403);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Прогноз";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkbOchag);
            this.groupBox4.Controls.Add(this.cboxEmerClass);
            this.groupBox4.Controls.Add(this.cboxWoodType);
            this.groupBox4.Controls.Add(this.cboxFirType);
            this.groupBox4.Controls.Add(this.cBoxWindDirection);
            this.groupBox4.Controls.Add(this.cboxVwind);
            this.groupBox4.Controls.Add(this.tBoxTime);
            this.groupBox4.Controls.Add(this.tboxS0);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.labelS);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.ForeColor = System.Drawing.Color.Firebrick;
            this.groupBox4.Location = new System.Drawing.Point(8, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(358, 234);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Исходные данные";
            // 
            // button_activate
            // 
            this.button_activate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_activate.BackgroundImage")));
            this.button_activate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_activate.ForeColor = System.Drawing.SystemColors.Control;
            this.button_activate.Location = new System.Drawing.Point(230, 674);
            this.button_activate.Name = "button_activate";
            this.button_activate.Size = new System.Drawing.Size(29, 29);
            this.button_activate.TabIndex = 9;
            this.button_activate.UseVisualStyleBackColor = true;
            this.button_activate.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormLP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 714);
            this.Controls.Add(this.button_activate);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.labelT);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLP";
            this.Text = "Прогноз распространения ЛП";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormLP_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.TextBox tboxS0;
        private System.Windows.Forms.TextBox tBoxTime;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label labelT;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox cboxVwind;
        public System.Windows.Forms.Label labelS;
        public System.Windows.Forms.ComboBox cboxFirType;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cboxWoodType;
        public System.Windows.Forms.ComboBox cboxEmerClass;
        public System.Windows.Forms.Label label15;
        public System.Windows.Forms.ComboBox cBoxWindDirection;
        public System.Windows.Forms.CheckBox chkbOchag;
        public System.Windows.Forms.CheckBox chkBoxInfo;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox tBoxPrognoz;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox tboxKM;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox tboxKM_T;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox tboxSiS;
        public System.Windows.Forms.CheckBox chkBoxSiS;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button_activate;
    }
}