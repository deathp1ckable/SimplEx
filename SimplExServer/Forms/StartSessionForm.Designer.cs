namespace SimplExServer
{
    partial class StartSessionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartSessionForm));
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupNameBox = new System.Windows.Forms.TextBox();
            this.trackViolationsCheck = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.patronymicBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.surnameBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.startSessionButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.limitLabel = new System.Windows.Forms.Label();
            this.violationsLimitBox = new System.Windows.Forms.NumericUpDown();
            this.reconnectTimeBox = new System.Windows.Forms.NumericUpDown();
            this.reconnectionLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.trackStatusCheck = new System.Windows.Forms.CheckBox();
            this.mixAnswersCheck = new System.Windows.Forms.CheckBox();
            this.saveResultsCheck = new System.Windows.Forms.CheckBox();
            this.waitReconnectionCheck = new System.Windows.Forms.CheckBox();
            this.chatCheck = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.header = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.violationsLimitBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reconnectTimeBox)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(143, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(472, 36);
            this.label3.TabIndex = 24;
            this.label3.Text = "Настройки сессии экзаменирования";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(29, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 23);
            this.label1.TabIndex = 100;
            this.label1.Text = "Группа:";
            // 
            // groupNameBox
            // 
            this.groupNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupNameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.groupNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupNameBox.Location = new System.Drawing.Point(105, 145);
            this.groupNameBox.MaxLength = 100;
            this.groupNameBox.Name = "groupNameBox";
            this.groupNameBox.Size = new System.Drawing.Size(612, 26);
            this.groupNameBox.TabIndex = 99;
            this.groupNameBox.TextChanged += new System.EventHandler(this.NameTextChanged);
            // 
            // trackViolationsCheck
            // 
            this.trackViolationsCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackViolationsCheck.AutoSize = true;
            this.trackViolationsCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.trackViolationsCheck.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.trackViolationsCheck.Location = new System.Drawing.Point(414, 3);
            this.trackViolationsCheck.Name = "trackViolationsCheck";
            this.trackViolationsCheck.Size = new System.Drawing.Size(224, 27);
            this.trackViolationsCheck.TabIndex = 102;
            this.trackViolationsCheck.Text = "Отслеживать нарушения";
            this.trackViolationsCheck.UseVisualStyleBackColor = true;
            this.trackViolationsCheck.CheckedChanged += new System.EventHandler(this.TrackViolationsCheckCheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.patronymicBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.surnameBox);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.nameBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.startSessionButton);
            this.panel1.Controls.Add(this.groupNameBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 148);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(720, 423);
            this.panel1.TabIndex = 103;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(3, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(170, 23);
            this.label8.TabIndex = 125;
            this.label8.Text = "Параметры сессии:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 23);
            this.label5.TabIndex = 124;
            this.label5.Text = "Отчество:";
            // 
            // patronymicBox
            // 
            this.patronymicBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.patronymicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.patronymicBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.patronymicBox.Location = new System.Drawing.Point(105, 90);
            this.patronymicBox.Name = "patronymicBox";
            this.patronymicBox.Size = new System.Drawing.Size(612, 26);
            this.patronymicBox.TabIndex = 123;
            this.patronymicBox.TextChanged += new System.EventHandler(this.NameTextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(10, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 23);
            this.label6.TabIndex = 122;
            this.label6.Text = "Фамилия:";
            // 
            // surnameBox
            // 
            this.surnameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.surnameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.surnameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.surnameBox.Location = new System.Drawing.Point(105, 58);
            this.surnameBox.Name = "surnameBox";
            this.surnameBox.Size = new System.Drawing.Size(612, 26);
            this.surnameBox.TabIndex = 121;
            this.surnameBox.TextChanged += new System.EventHandler(this.NameTextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(50, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 23);
            this.label7.TabIndex = 120;
            this.label7.Text = "Имя:";
            // 
            // nameBox
            // 
            this.nameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameBox.Location = new System.Drawing.Point(105, 26);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(612, 26);
            this.nameBox.TabIndex = 119;
            this.nameBox.TextChanged += new System.EventHandler(this.NameTextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 23);
            this.label4.TabIndex = 117;
            this.label4.Text = "Преподаватель:";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cancelButton.Location = new System.Drawing.Point(3, 392);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(714, 26);
            this.cancelButton.TabIndex = 112;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // startSessionButton
            // 
            this.startSessionButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startSessionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(31)))), ((int)(((byte)(47)))));
            this.startSessionButton.Enabled = false;
            this.startSessionButton.FlatAppearance.BorderSize = 0;
            this.startSessionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startSessionButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startSessionButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.startSessionButton.Location = new System.Drawing.Point(3, 356);
            this.startSessionButton.Name = "startSessionButton";
            this.startSessionButton.Size = new System.Drawing.Size(714, 30);
            this.startSessionButton.TabIndex = 104;
            this.startSessionButton.Text = "Начать сессию";
            this.startSessionButton.UseVisualStyleBackColor = false;
            this.startSessionButton.Click += new System.EventHandler(this.StartSessionButtonClick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.limitLabel);
            this.panel2.Controls.Add(this.violationsLimitBox);
            this.panel2.Controls.Add(this.reconnectTimeBox);
            this.panel2.Controls.Add(this.reconnectionLabel);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(3, 177);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(714, 173);
            this.panel2.TabIndex = 118;
            // 
            // limitLabel
            // 
            this.limitLabel.AutoSize = true;
            this.limitLabel.Enabled = false;
            this.limitLabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.limitLabel.Location = new System.Drawing.Point(153, 35);
            this.limitLabel.Name = "limitLabel";
            this.limitLabel.Size = new System.Drawing.Size(162, 23);
            this.limitLabel.TabIndex = 113;
            this.limitLabel.Text = "Лимит нарушений:";
            // 
            // violationsLimitBox
            // 
            this.violationsLimitBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.violationsLimitBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.violationsLimitBox.Enabled = false;
            this.violationsLimitBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.violationsLimitBox.Location = new System.Drawing.Point(321, 35);
            this.violationsLimitBox.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.violationsLimitBox.Name = "violationsLimitBox";
            this.violationsLimitBox.Size = new System.Drawing.Size(388, 26);
            this.violationsLimitBox.TabIndex = 114;
            // 
            // reconnectTimeBox
            // 
            this.reconnectTimeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reconnectTimeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reconnectTimeBox.Enabled = false;
            this.reconnectTimeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reconnectTimeBox.Location = new System.Drawing.Point(321, 3);
            this.reconnectTimeBox.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.reconnectTimeBox.Name = "reconnectTimeBox";
            this.reconnectTimeBox.Size = new System.Drawing.Size(388, 26);
            this.reconnectTimeBox.TabIndex = 108;
            // 
            // reconnectionLabel
            // 
            this.reconnectionLabel.AutoSize = true;
            this.reconnectionLabel.Enabled = false;
            this.reconnectionLabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reconnectionLabel.Location = new System.Drawing.Point(4, 3);
            this.reconnectionLabel.Name = "reconnectionLabel";
            this.reconnectionLabel.Size = new System.Drawing.Size(312, 23);
            this.reconnectionLabel.TabIndex = 107;
            this.reconnectionLabel.Text = "Ожидать переподключений (секунд):";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.trackStatusCheck);
            this.panel3.Controls.Add(this.mixAnswersCheck);
            this.panel3.Controls.Add(this.saveResultsCheck);
            this.panel3.Controls.Add(this.waitReconnectionCheck);
            this.panel3.Controls.Add(this.trackViolationsCheck);
            this.panel3.Controls.Add(this.chatCheck);
            this.panel3.Location = new System.Drawing.Point(3, 64);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(706, 104);
            this.panel3.TabIndex = 117;
            // 
            // trackStatusCheck
            // 
            this.trackStatusCheck.AutoSize = true;
            this.trackStatusCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.trackStatusCheck.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.trackStatusCheck.Location = new System.Drawing.Point(4, 3);
            this.trackStatusCheck.Name = "trackStatusCheck";
            this.trackStatusCheck.Size = new System.Drawing.Size(286, 27);
            this.trackStatusCheck.TabIndex = 116;
            this.trackStatusCheck.Text = "Отслеживать статус выполнения";
            this.trackStatusCheck.UseVisualStyleBackColor = true;
            // 
            // mixAnswersCheck
            // 
            this.mixAnswersCheck.AutoSize = true;
            this.mixAnswersCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mixAnswersCheck.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mixAnswersCheck.Location = new System.Drawing.Point(4, 69);
            this.mixAnswersCheck.Name = "mixAnswersCheck";
            this.mixAnswersCheck.Size = new System.Drawing.Size(282, 27);
            this.mixAnswersCheck.TabIndex = 104;
            this.mixAnswersCheck.Text = "Перемешивать варианты ответа";
            this.mixAnswersCheck.UseVisualStyleBackColor = true;
            // 
            // saveResultsCheck
            // 
            this.saveResultsCheck.AutoSize = true;
            this.saveResultsCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveResultsCheck.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveResultsCheck.Location = new System.Drawing.Point(4, 36);
            this.saveResultsCheck.Name = "saveResultsCheck";
            this.saveResultsCheck.Size = new System.Drawing.Size(306, 27);
            this.saveResultsCheck.TabIndex = 103;
            this.saveResultsCheck.Text = "Сохранить результаты выполнения";
            this.saveResultsCheck.UseVisualStyleBackColor = true;
            // 
            // waitReconnectionCheck
            // 
            this.waitReconnectionCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.waitReconnectionCheck.AutoSize = true;
            this.waitReconnectionCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.waitReconnectionCheck.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.waitReconnectionCheck.Location = new System.Drawing.Point(414, 36);
            this.waitReconnectionCheck.Name = "waitReconnectionCheck";
            this.waitReconnectionCheck.Size = new System.Drawing.Size(251, 27);
            this.waitReconnectionCheck.TabIndex = 115;
            this.waitReconnectionCheck.Text = "Ожидать переподключений";
            this.waitReconnectionCheck.UseVisualStyleBackColor = true;
            this.waitReconnectionCheck.CheckedChanged += new System.EventHandler(this.WaitReconnectionCheckCheckedChanged);
            // 
            // chatCheck
            // 
            this.chatCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chatCheck.AutoSize = true;
            this.chatCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chatCheck.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chatCheck.Location = new System.Drawing.Point(414, 69);
            this.chatCheck.Name = "chatCheck";
            this.chatCheck.Size = new System.Drawing.Size(283, 27);
            this.chatCheck.TabIndex = 105;
            this.chatCheck.Text = "Включить чат с преподавателем";
            this.chatCheck.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(149, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 23);
            this.label2.TabIndex = 119;
            this.label2.Text = "Simple Examination Program";
            // 
            // header
            // 
            this.header.AutoSize = true;
            this.header.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.header.ForeColor = System.Drawing.SystemColors.Control;
            this.header.Location = new System.Drawing.Point(143, 9);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(182, 59);
            this.header.TabIndex = 118;
            this.header.Text = "SimplEx";
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox.Image = global::SimplExServer.Properties.Resources.logoPicture;
            this.pictureBox.Location = new System.Drawing.Point(11, 9);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Padding = new System.Windows.Forms.Padding(2);
            this.pictureBox.Size = new System.Drawing.Size(129, 129);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 117;
            this.pictureBox.TabStop = false;
            // 
            // StartSessionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(31)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(720, 571);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.header);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StartSessionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки тестирования";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.violationsLimitBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reconnectTimeBox)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox groupNameBox;
        private System.Windows.Forms.CheckBox trackViolationsCheck;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox mixAnswersCheck;
        private System.Windows.Forms.CheckBox saveResultsCheck;
        private System.Windows.Forms.Label reconnectionLabel;
        private System.Windows.Forms.CheckBox chatCheck;
        private System.Windows.Forms.NumericUpDown reconnectTimeBox;
        private System.Windows.Forms.Button startSessionButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox waitReconnectionCheck;
        private System.Windows.Forms.NumericUpDown violationsLimitBox;
        private System.Windows.Forms.Label limitLabel;
        private System.Windows.Forms.CheckBox trackStatusCheck;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label header;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox patronymicBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox surnameBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label8;
    }
}