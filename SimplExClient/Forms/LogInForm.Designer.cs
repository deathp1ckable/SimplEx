namespace SimplExClient.Forms
{
    partial class LogInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInForm));
            this.label5 = new System.Windows.Forms.Label();
            this.patronymicBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.surnameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.header = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(5, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 23);
            this.label5.TabIndex = 116;
            this.label5.Text = "Отчество:";
            // 
            // patronymicBox
            // 
            this.patronymicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.patronymicBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.patronymicBox.Location = new System.Drawing.Point(98, 67);
            this.patronymicBox.Name = "patronymicBox";
            this.patronymicBox.Size = new System.Drawing.Size(472, 26);
            this.patronymicBox.TabIndex = 115;
            this.patronymicBox.TextChanged += new System.EventHandler(this.PatronymicBoxTextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 23);
            this.label4.TabIndex = 114;
            this.label4.Text = "Фамилия:";
            // 
            // surnameBox
            // 
            this.surnameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.surnameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.surnameBox.Location = new System.Drawing.Point(98, 35);
            this.surnameBox.Name = "surnameBox";
            this.surnameBox.Size = new System.Drawing.Size(472, 26);
            this.surnameBox.TabIndex = 113;
            this.surnameBox.TextChanged += new System.EventHandler(this.SurnameBoxTextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(-1, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(376, 23);
            this.label2.TabIndex = 111;
            this.label2.Text = "Введите данные для подключения к сессии:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(43, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 23);
            this.label1.TabIndex = 110;
            this.label1.Text = "Имя:";
            // 
            // nameBox
            // 
            this.nameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameBox.Location = new System.Drawing.Point(98, 5);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(472, 26);
            this.nameBox.TabIndex = 109;
            this.nameBox.TextChanged += new System.EventHandler(this.NameBoxTextChanged);
            // 
            // connectButton
            // 
            this.connectButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(31)))), ((int)(((byte)(47)))));
            this.connectButton.Enabled = false;
            this.connectButton.FlatAppearance.BorderSize = 0;
            this.connectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.connectButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.connectButton.Location = new System.Drawing.Point(3, 283);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(575, 30);
            this.connectButton.TabIndex = 107;
            this.connectButton.Text = "Подключится";
            this.connectButton.UseVisualStyleBackColor = false;
            this.connectButton.Click += new System.EventHandler(this.ConnectButtonClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(31)))), ((int)(((byte)(47)))));
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.header);
            this.panel1.Controls.Add(this.pictureBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(581, 148);
            this.panel1.TabIndex = 117;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(145, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(341, 36);
            this.label6.TabIndex = 118;
            this.label6.Text = "Начало экзаминирования";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(147, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 23);
            this.label3.TabIndex = 42;
            this.label3.Text = "Simple Examination Program";
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
            this.pictureBox.Image = global::SimplExClient.Properties.Resources.logoPicture;
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
            this.panel2.Controls.Add(this.surnameBox);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.nameBox);
            this.panel2.Controls.Add(this.patronymicBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(3, 177);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(575, 100);
            this.panel2.TabIndex = 118;
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 317);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LogInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Подключение к сессии ";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox patronymicBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox surnameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label header;
        private System.Windows.Forms.Panel panel2;
    }
}