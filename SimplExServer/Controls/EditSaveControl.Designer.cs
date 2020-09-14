namespace SimplExServer.Controls
{
    partial class EditSaveControl
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
            this.label3 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.saveAsButton = new System.Windows.Forms.Button();
            this.saveToDb = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.watchKeyButton = new System.Windows.Forms.Button();
            this.watchTaskButton = new System.Windows.Forms.Button();
            this.watchBlankButton = new System.Windows.Forms.Button();
            this.setRightAnswerCheck = new System.Windows.Forms.CheckBox();
            this.ticketsList = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.warningsList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 19);
            this.label3.TabIndex = 32;
            this.label3.Text = "Сохраниние:";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(7, 31);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(711, 23);
            this.saveButton.TabIndex = 85;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // saveAsButton
            // 
            this.saveAsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveAsButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveAsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveAsButton.Location = new System.Drawing.Point(7, 60);
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(711, 23);
            this.saveAsButton.TabIndex = 86;
            this.saveAsButton.Text = "Сохранить как...";
            this.saveAsButton.UseVisualStyleBackColor = false;
            this.saveAsButton.Click += new System.EventHandler(this.SaveAsButtonClick);
            // 
            // saveToDb
            // 
            this.saveToDb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveToDb.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveToDb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveToDb.Location = new System.Drawing.Point(7, 89);
            this.saveToDb.Name = "saveToDb";
            this.saveToDb.Size = new System.Drawing.Size(711, 23);
            this.saveToDb.TabIndex = 87;
            this.saveToDb.Text = "Сохранить в базу";
            this.saveToDb.UseVisualStyleBackColor = false;
            this.saveToDb.Click += new System.EventHandler(this.SaveToDbClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 19);
            this.label1.TabIndex = 88;
            this.label1.Text = "Предпросмотр:";
            // 
            // watchKeyButton
            // 
            this.watchKeyButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.watchKeyButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.watchKeyButton.Enabled = false;
            this.watchKeyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.watchKeyButton.Location = new System.Drawing.Point(7, 166);
            this.watchKeyButton.Name = "watchKeyButton";
            this.watchKeyButton.Size = new System.Drawing.Size(711, 23);
            this.watchKeyButton.TabIndex = 89;
            this.watchKeyButton.Text = "Просмотреть ключ экзамена";
            this.watchKeyButton.UseVisualStyleBackColor = false;
            this.watchKeyButton.Click += new System.EventHandler(this.WatchKeyButtonClick);
            // 
            // watchTaskButton
            // 
            this.watchTaskButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.watchTaskButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.watchTaskButton.Enabled = false;
            this.watchTaskButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.watchTaskButton.Location = new System.Drawing.Point(7, 195);
            this.watchTaskButton.Name = "watchTaskButton";
            this.watchTaskButton.Size = new System.Drawing.Size(711, 23);
            this.watchTaskButton.TabIndex = 90;
            this.watchTaskButton.Text = "Просмотреть задание";
            this.watchTaskButton.UseVisualStyleBackColor = false;
            this.watchTaskButton.Click += new System.EventHandler(this.WatchTaskButtonClick);
            // 
            // watchBlankButton
            // 
            this.watchBlankButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.watchBlankButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.watchBlankButton.Enabled = false;
            this.watchBlankButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.watchBlankButton.Location = new System.Drawing.Point(7, 253);
            this.watchBlankButton.Name = "watchBlankButton";
            this.watchBlankButton.Size = new System.Drawing.Size(711, 23);
            this.watchBlankButton.TabIndex = 91;
            this.watchBlankButton.Text = "Просмотреть бланк выполнения";
            this.watchBlankButton.UseVisualStyleBackColor = false;
            this.watchBlankButton.Click += new System.EventHandler(this.WatchBlankButtonClick);
            // 
            // setRightAnswerCheck
            // 
            this.setRightAnswerCheck.AutoSize = true;
            this.setRightAnswerCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setRightAnswerCheck.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.setRightAnswerCheck.Location = new System.Drawing.Point(7, 224);
            this.setRightAnswerCheck.Name = "setRightAnswerCheck";
            this.setRightAnswerCheck.Size = new System.Drawing.Size(243, 23);
            this.setRightAnswerCheck.TabIndex = 92;
            this.setRightAnswerCheck.Text = "Проставить правильные ответы";
            this.setRightAnswerCheck.UseVisualStyleBackColor = true;
            // 
            // ticketsList
            // 
            this.ticketsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ticketsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ticketsList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ticketsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ticketsList.FormattingEnabled = true;
            this.ticketsList.Location = new System.Drawing.Point(65, 137);
            this.ticketsList.Name = "ticketsList";
            this.ticketsList.Size = new System.Drawing.Size(653, 23);
            this.ticketsList.TabIndex = 94;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(6, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 19);
            this.label4.TabIndex = 95;
            this.label4.Text = "Билет:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "*.smpx";
            this.saveFileDialog.FileName = "Новый экзамен";
            this.saveFileDialog.Filter = "*.smpx Файлы Экзаменов|*.smpx";
            this.saveFileDialog.Title = "Сохранить экзамен";
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveFileDialogFileOk);
            // 
            // warningsList
            // 
            this.warningsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.warningsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.warningsList.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.warningsList.FormattingEnabled = true;
            this.warningsList.HorizontalScrollbar = true;
            this.warningsList.IntegralHeight = false;
            this.warningsList.ItemHeight = 23;
            this.warningsList.Location = new System.Drawing.Point(7, 334);
            this.warningsList.Name = "warningsList";
            this.warningsList.Size = new System.Drawing.Size(711, 110);
            this.warningsList.TabIndex = 97;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 308);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 19);
            this.label2.TabIndex = 98;
            this.label2.Text = "Предупреждения:";
            // 
            // EditSaveControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.warningsList);
            this.Controls.Add(this.ticketsList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.setRightAnswerCheck);
            this.Controls.Add(this.watchBlankButton);
            this.Controls.Add(this.watchTaskButton);
            this.Controls.Add(this.watchKeyButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveToDb);
            this.Controls.Add(this.saveAsButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label3);
            this.Name = "EditSaveControl";
            this.Size = new System.Drawing.Size(723, 447);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button saveAsButton;
        private System.Windows.Forms.Button saveToDb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button watchKeyButton;
        private System.Windows.Forms.Button watchTaskButton;
        private System.Windows.Forms.Button watchBlankButton;
        private System.Windows.Forms.CheckBox setRightAnswerCheck;
        private System.Windows.Forms.ComboBox ticketsList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ListBox warningsList;
        private System.Windows.Forms.Label label2;
    }
}
