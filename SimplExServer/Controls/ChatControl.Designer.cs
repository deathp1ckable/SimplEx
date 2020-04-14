namespace SimplExServer.Controls
{
    partial class ChatControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.chatLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chatBox = new System.Windows.Forms.TextBox();
            this.messageLabel = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.modeLabel = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.modeBox = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chatLabel
            // 
            this.chatLabel.AutoSize = true;
            this.chatLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chatLabel.Location = new System.Drawing.Point(3, 1);
            this.chatLabel.Name = "chatLabel";
            this.chatLabel.Size = new System.Drawing.Size(36, 19);
            this.chatLabel.TabIndex = 63;
            this.chatLabel.Text = "Чат:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chatBox);
            this.panel1.Location = new System.Drawing.Point(3, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(713, 364);
            this.panel1.TabIndex = 64;
            // 
            // chatBox
            // 
            this.chatBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chatBox.Font = new System.Drawing.Font("Calibri", 12F);
            this.chatBox.Location = new System.Drawing.Point(3, 3);
            this.chatBox.Multiline = true;
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatBox.Size = new System.Drawing.Size(705, 356);
            this.chatBox.TabIndex = 0;
            // 
            // messageLabel
            // 
            this.messageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.messageLabel.AutoSize = true;
            this.messageLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.messageLabel.Location = new System.Drawing.Point(-1, 390);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(93, 19);
            this.messageLabel.TabIndex = 68;
            this.messageLabel.Text = "Сообщение:";
            this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox.Location = new System.Drawing.Point(3, 412);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(713, 55);
            this.textBox.TabIndex = 69;
            this.textBox.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            // 
            // modeLabel
            // 
            this.modeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.modeLabel.AutoSize = true;
            this.modeLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.modeLabel.Location = new System.Drawing.Point(-1, 473);
            this.modeLabel.Name = "modeLabel";
            this.modeLabel.Size = new System.Drawing.Size(126, 19);
            this.modeLabel.TabIndex = 70;
            this.modeLabel.Text = "Режим отправки:";
            this.modeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.sendButton.Enabled = false;
            this.sendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sendButton.Location = new System.Drawing.Point(568, 472);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(148, 23);
            this.sendButton.TabIndex = 71;
            this.sendButton.Text = "Отправить";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.SendButtonClick);
            // 
            // modeBox
            // 
            this.modeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modeBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.modeBox.FormattingEnabled = true;
            this.modeBox.Items.AddRange(new object[] {
            "Только текущему подключению",
            "Всем"});
            this.modeBox.Location = new System.Drawing.Point(131, 472);
            this.modeBox.Name = "modeBox";
            this.modeBox.Size = new System.Drawing.Size(431, 23);
            this.modeBox.TabIndex = 72;
            // 
            // ChatControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.modeBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.modeLabel);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chatLabel);
            this.Name = "ChatControl";
            this.Size = new System.Drawing.Size(721, 501);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label chatLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox chatBox;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label modeLabel;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.ComboBox modeBox;
    }
}
