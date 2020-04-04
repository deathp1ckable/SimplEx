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
            this.timeLimitationCheck = new System.Windows.Forms.CheckBox();
            this.trackViolationsCheck = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.waitReconnectionCheck = new System.Windows.Forms.CheckBox();
            this.violationsLimitBox = new System.Windows.Forms.NumericUpDown();
            this.limitLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.startSessionButton = new System.Windows.Forms.Button();
            this.reconnectTimeBox = new System.Windows.Forms.NumericUpDown();
            this.reconnectionLabel = new System.Windows.Forms.Label();
            this.chatCheck = new System.Windows.Forms.CheckBox();
            this.mixAnswersCheck = new System.Windows.Forms.CheckBox();
            this.saveResultsCheck = new System.Windows.Forms.CheckBox();
            this.trackStatusCheck = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.violationsLimitBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reconnectTimeBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(-1, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(424, 36);
            this.label3.TabIndex = 24;
            this.label3.Text = "Настройки сессии тестирования:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(5, 40);
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
            this.groupNameBox.Location = new System.Drawing.Point(81, 40);
            this.groupNameBox.Name = "groupNameBox";
            this.groupNameBox.Size = new System.Drawing.Size(501, 26);
            this.groupNameBox.TabIndex = 99;
            this.groupNameBox.TextChanged += new System.EventHandler(this.GroupNameBoxTextChanged);
            // 
            // timeLimitationCheck
            // 
            this.timeLimitationCheck.AutoSize = true;
            this.timeLimitationCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.timeLimitationCheck.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timeLimitationCheck.Location = new System.Drawing.Point(9, 109);
            this.timeLimitationCheck.Name = "timeLimitationCheck";
            this.timeLimitationCheck.Size = new System.Drawing.Size(309, 27);
            this.timeLimitationCheck.TabIndex = 101;
            this.timeLimitationCheck.Text = "Включить ограничение по времени";
            this.timeLimitationCheck.UseVisualStyleBackColor = true;
            // 
            // trackViolationsCheck
            // 
            this.trackViolationsCheck.AutoSize = true;
            this.trackViolationsCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.trackViolationsCheck.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.trackViolationsCheck.Location = new System.Drawing.Point(9, 297);
            this.trackViolationsCheck.Name = "trackViolationsCheck";
            this.trackViolationsCheck.Size = new System.Drawing.Size(224, 27);
            this.trackViolationsCheck.TabIndex = 102;
            this.trackViolationsCheck.Text = "Отслеживать нарушения";
            this.trackViolationsCheck.UseVisualStyleBackColor = true;
            this.trackViolationsCheck.CheckedChanged += new System.EventHandler(this.TrackViolationsCheckCheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.trackStatusCheck);
            this.panel1.Controls.Add(this.waitReconnectionCheck);
            this.panel1.Controls.Add(this.violationsLimitBox);
            this.panel1.Controls.Add(this.limitLabel);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.startSessionButton);
            this.panel1.Controls.Add(this.reconnectTimeBox);
            this.panel1.Controls.Add(this.reconnectionLabel);
            this.panel1.Controls.Add(this.chatCheck);
            this.panel1.Controls.Add(this.mixAnswersCheck);
            this.panel1.Controls.Add(this.saveResultsCheck);
            this.panel1.Controls.Add(this.trackViolationsCheck);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.timeLimitationCheck);
            this.panel1.Controls.Add(this.groupNameBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(585, 429);
            this.panel1.TabIndex = 103;
            // 
            // waitReconnectionCheck
            // 
            this.waitReconnectionCheck.AutoSize = true;
            this.waitReconnectionCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.waitReconnectionCheck.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.waitReconnectionCheck.Location = new System.Drawing.Point(9, 241);
            this.waitReconnectionCheck.Name = "waitReconnectionCheck";
            this.waitReconnectionCheck.Size = new System.Drawing.Size(251, 27);
            this.waitReconnectionCheck.TabIndex = 115;
            this.waitReconnectionCheck.Text = "Ожидать переподключений";
            this.waitReconnectionCheck.UseVisualStyleBackColor = true;
            this.waitReconnectionCheck.CheckedChanged += new System.EventHandler(this.WaitReconnectionCheckCheckedChanged);
            // 
            // violationsLimitBox
            // 
            this.violationsLimitBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.violationsLimitBox.Enabled = false;
            this.violationsLimitBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.violationsLimitBox.Location = new System.Drawing.Point(173, 327);
            this.violationsLimitBox.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.violationsLimitBox.Name = "violationsLimitBox";
            this.violationsLimitBox.Size = new System.Drawing.Size(407, 26);
            this.violationsLimitBox.TabIndex = 114;
            // 
            // limitLabel
            // 
            this.limitLabel.AutoSize = true;
            this.limitLabel.Enabled = false;
            this.limitLabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.limitLabel.Location = new System.Drawing.Point(7, 327);
            this.limitLabel.Name = "limitLabel";
            this.limitLabel.Size = new System.Drawing.Size(162, 23);
            this.limitLabel.TabIndex = 113;
            this.limitLabel.Text = "Лимит нарушений:";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cancelButton.Location = new System.Drawing.Point(3, 399);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(579, 26);
            this.cancelButton.TabIndex = 112;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // startSessionButton
            // 
            this.startSessionButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startSessionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(31)))), ((int)(((byte)(47)))));
            this.startSessionButton.Enabled = false;
            this.startSessionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startSessionButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startSessionButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.startSessionButton.Location = new System.Drawing.Point(3, 363);
            this.startSessionButton.Name = "startSessionButton";
            this.startSessionButton.Size = new System.Drawing.Size(580, 30);
            this.startSessionButton.TabIndex = 104;
            this.startSessionButton.Text = "Начать сессию";
            this.startSessionButton.UseVisualStyleBackColor = false;
            this.startSessionButton.Click += new System.EventHandler(this.StartSessionButtonClick);
            // 
            // reconnectTimeBox
            // 
            this.reconnectTimeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reconnectTimeBox.Enabled = false;
            this.reconnectTimeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reconnectTimeBox.Location = new System.Drawing.Point(322, 271);
            this.reconnectTimeBox.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.reconnectTimeBox.Name = "reconnectTimeBox";
            this.reconnectTimeBox.Size = new System.Drawing.Size(258, 26);
            this.reconnectTimeBox.TabIndex = 108;
            // 
            // reconnectionLabel
            // 
            this.reconnectionLabel.AutoSize = true;
            this.reconnectionLabel.Enabled = false;
            this.reconnectionLabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reconnectionLabel.Location = new System.Drawing.Point(7, 271);
            this.reconnectionLabel.Name = "reconnectionLabel";
            this.reconnectionLabel.Size = new System.Drawing.Size(312, 23);
            this.reconnectionLabel.TabIndex = 107;
            this.reconnectionLabel.Text = "Ожидать переподключений (секунд):";
            // 
            // chatCheck
            // 
            this.chatCheck.AutoSize = true;
            this.chatCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chatCheck.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chatCheck.Location = new System.Drawing.Point(9, 208);
            this.chatCheck.Name = "chatCheck";
            this.chatCheck.Size = new System.Drawing.Size(283, 27);
            this.chatCheck.TabIndex = 105;
            this.chatCheck.Text = "Включить чат с преподавателем";
            this.chatCheck.UseVisualStyleBackColor = true;
            // 
            // mixAnswersCheck
            // 
            this.mixAnswersCheck.AutoSize = true;
            this.mixAnswersCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mixAnswersCheck.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mixAnswersCheck.Location = new System.Drawing.Point(9, 175);
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
            this.saveResultsCheck.Location = new System.Drawing.Point(9, 142);
            this.saveResultsCheck.Name = "saveResultsCheck";
            this.saveResultsCheck.Size = new System.Drawing.Size(310, 27);
            this.saveResultsCheck.TabIndex = 103;
            this.saveResultsCheck.Text = "Сохранить результаты выполнения ";
            this.saveResultsCheck.UseVisualStyleBackColor = true;
            // 
            // trackStatusCheck
            // 
            this.trackStatusCheck.AutoSize = true;
            this.trackStatusCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.trackStatusCheck.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.trackStatusCheck.Location = new System.Drawing.Point(9, 72);
            this.trackStatusCheck.Name = "trackStatusCheck";
            this.trackStatusCheck.Size = new System.Drawing.Size(286, 27);
            this.trackStatusCheck.TabIndex = 116;
            this.trackStatusCheck.Text = "Отслеживать статус выполнения";
            this.trackStatusCheck.UseVisualStyleBackColor = true;
            // 
            // StartSessionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(31)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(609, 453);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartSessionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки тестирования";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.violationsLimitBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reconnectTimeBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox groupNameBox;
        private System.Windows.Forms.CheckBox timeLimitationCheck;
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
    }
}