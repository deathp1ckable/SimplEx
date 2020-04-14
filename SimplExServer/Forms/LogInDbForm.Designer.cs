namespace SimplExServer.Forms
{
    partial class LogInDbForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInDbForm));
            this.connectButton = new System.Windows.Forms.Button();
            this.skipButton = new System.Windows.Forms.Button();
            this.hostBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.portBox = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.header = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.portBox)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.connectButton.FlatAppearance.BorderSize = 0;
            this.connectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.connectButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.connectButton.Location = new System.Drawing.Point(3, 313);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(430, 30);
            this.connectButton.TabIndex = 13;
            this.connectButton.Text = "Подключится";
            this.connectButton.UseVisualStyleBackColor = false;
            this.connectButton.Click += new System.EventHandler(this.ConnectButtonClick);
            // 
            // skipButton
            // 
            this.skipButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.skipButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.skipButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.skipButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.skipButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.skipButton.Location = new System.Drawing.Point(435, 313);
            this.skipButton.Name = "skipButton";
            this.skipButton.Size = new System.Drawing.Size(138, 30);
            this.skipButton.TabIndex = 14;
            this.skipButton.Text = "Пропустить";
            this.skipButton.UseVisualStyleBackColor = false;
            this.skipButton.Click += new System.EventHandler(this.SkipButtonClick);
            // 
            // hostBox
            // 
            this.hostBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hostBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hostBox.Location = new System.Drawing.Point(176, 3);
            this.hostBox.Name = "hostBox";
            this.hostBox.Size = new System.Drawing.Size(389, 26);
            this.hostBox.TabIndex = 97;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(116, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 23);
            this.label1.TabIndex = 98;
            this.label1.Text = "Хост:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(-1, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(357, 23);
            this.label2.TabIndex = 99;
            this.label2.Text = "Введите данные для подключения к базе:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(116, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 23);
            this.label3.TabIndex = 101;
            this.label3.Text = "Порт:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(7, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 23);
            this.label4.TabIndex = 103;
            this.label4.Text = "Имя пользователя:";
            // 
            // usernameBox
            // 
            this.usernameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usernameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.usernameBox.Location = new System.Drawing.Point(176, 67);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(389, 26);
            this.usernameBox.TabIndex = 102;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(91, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 23);
            this.label5.TabIndex = 105;
            this.label5.Text = "Пароль:";
            // 
            // passwordBox
            // 
            this.passwordBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordBox.Location = new System.Drawing.Point(176, 99);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '•';
            this.passwordBox.Size = new System.Drawing.Size(389, 26);
            this.passwordBox.TabIndex = 104;
            // 
            // portBox
            // 
            this.portBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.portBox.Location = new System.Drawing.Point(176, 35);
            this.portBox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(389, 26);
            this.portBox.TabIndex = 106;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(31)))), ((int)(((byte)(47)))));
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.header);
            this.panel1.Controls.Add(this.pictureBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(576, 148);
            this.panel1.TabIndex = 118;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(145, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(380, 36);
            this.label6.TabIndex = 118;
            this.label6.Text = "Подключение к базе данных";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(147, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(231, 23);
            this.label7.TabIndex = 42;
            this.label7.Text = "Simple Examination Program";
            // 
            // header
            // 
            this.header.AutoSize = true;
            this.header.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.header.ForeColor = System.Drawing.SystemColors.Control;
            this.header.Location = new System.Drawing.Point(141, 9);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(182, 59);
            this.header.TabIndex = 41;
            this.header.Text = "SimplEx";
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox.Image = global::SimplExServer.Properties.Resources.logoPicture;
            this.pictureBox.Location = new System.Drawing.Point(9, 9);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Padding = new System.Windows.Forms.Padding(2);
            this.pictureBox.Size = new System.Drawing.Size(129, 129);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 40;
            this.pictureBox.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.hostBox);
            this.panel2.Controls.Add(this.portBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.passwordBox);
            this.panel2.Controls.Add(this.usernameBox);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(3, 177);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(570, 130);
            this.panel2.TabIndex = 119;
            // 
            // LogInDbForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 349);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.skipButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LogInDbForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметры подключения к базе";
            ((System.ComponentModel.ISupportInitialize)(this.portBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button skipButton;
        private System.Windows.Forms.TextBox hostBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.NumericUpDown portBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label header;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel panel2;
    }
}