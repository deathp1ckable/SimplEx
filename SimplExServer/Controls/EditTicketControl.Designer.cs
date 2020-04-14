namespace SimplExServer.Controls
{
    partial class EditTicketControl
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
            this.components = new System.ComponentModel.Container();
            this.groupCountLabel = new System.Windows.Forms.Label();
            this.questionsCountLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.ticketBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.addGroupButton = new System.Windows.Forms.Button();
            this.questionsList = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.downButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.watchButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.questionContentToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // groupCountLabel
            // 
            this.groupCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupCountLabel.AutoSize = true;
            this.groupCountLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupCountLabel.Location = new System.Drawing.Point(2, 426);
            this.groupCountLabel.Name = "groupCountLabel";
            this.groupCountLabel.Size = new System.Drawing.Size(212, 19);
            this.groupCountLabel.TabIndex = 78;
            this.groupCountLabel.Text = "Количество групп вопросов: 0";
            this.groupCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // questionsCountLabel
            // 
            this.questionsCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.questionsCountLabel.AutoSize = true;
            this.questionsCountLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.questionsCountLabel.Location = new System.Drawing.Point(2, 407);
            this.questionsCountLabel.Name = "questionsCountLabel";
            this.questionsCountLabel.Size = new System.Drawing.Size(171, 19);
            this.questionsCountLabel.TabIndex = 77;
            this.questionsCountLabel.Text = "Количество вопросов: 0";
            this.questionsCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Location = new System.Drawing.Point(3, 87);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(713, 23);
            this.deleteButton.TabIndex = 76;
            this.deleteButton.Text = "Удалить билет";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButtonClick);
            // 
            // ticketBox
            // 
            this.ticketBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ticketBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ticketBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ticketBox.Location = new System.Drawing.Point(140, 31);
            this.ticketBox.Name = "ticketBox";
            this.ticketBox.Size = new System.Drawing.Size(576, 21);
            this.ticketBox.TabIndex = 75;
            this.ticketBox.TextChanged += new System.EventHandler(this.TicketBoxTextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(2, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 19);
            this.label4.TabIndex = 74;
            this.label4.Text = "Название билета:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(2, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 19);
            this.label3.TabIndex = 72;
            this.label3.Text = "Управление билетом:";
            // 
            // addGroupButton
            // 
            this.addGroupButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addGroupButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addGroupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addGroupButton.Location = new System.Drawing.Point(3, 58);
            this.addGroupButton.Name = "addGroupButton";
            this.addGroupButton.Size = new System.Drawing.Size(713, 23);
            this.addGroupButton.TabIndex = 79;
            this.addGroupButton.Text = "Добавить группу вопросов";
            this.addGroupButton.UseVisualStyleBackColor = false;
            this.addGroupButton.Click += new System.EventHandler(this.AddGroupButtonClick);
            // 
            // questionsList
            // 
            this.questionsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.questionsList.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.questionsList.FormattingEnabled = true;
            this.questionsList.IntegralHeight = false;
            this.questionsList.ItemHeight = 19;
            this.questionsList.Location = new System.Drawing.Point(4, 135);
            this.questionsList.Name = "questionsList";
            this.questionsList.Size = new System.Drawing.Size(712, 215);
            this.questionsList.TabIndex = 80;
            this.questionsList.SelectedIndexChanged += new System.EventHandler(this.QuestionsListSelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(3, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(245, 19);
            this.label5.TabIndex = 81;
            this.label5.Text = "Управление порядком вопросов:";
            // 
            // downButton
            // 
            this.downButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.downButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.downButton.Enabled = false;
            this.downButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.downButton.Location = new System.Drawing.Point(79, 356);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(70, 23);
            this.downButton.TabIndex = 83;
            this.downButton.Text = "▼";
            this.downButton.UseVisualStyleBackColor = false;
            this.downButton.Click += new System.EventHandler(this.DownButtonClick);
            // 
            // upButton
            // 
            this.upButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.upButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.upButton.Enabled = false;
            this.upButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.upButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.upButton.Location = new System.Drawing.Point(3, 356);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(70, 23);
            this.upButton.TabIndex = 82;
            this.upButton.Text = "▲";
            this.upButton.UseVisualStyleBackColor = false;
            this.upButton.Click += new System.EventHandler(this.UpButtonClick);
            // 
            // watchButton
            // 
            this.watchButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.watchButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.watchButton.Enabled = false;
            this.watchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.watchButton.Location = new System.Drawing.Point(155, 356);
            this.watchButton.Name = "watchButton";
            this.watchButton.Size = new System.Drawing.Size(561, 23);
            this.watchButton.TabIndex = 84;
            this.watchButton.Text = "Просмотреть вопрос";
            this.watchButton.UseVisualStyleBackColor = false;
            this.watchButton.Click += new System.EventHandler(this.WatchButtonClick);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(3, 385);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(713, 23);
            this.saveButton.TabIndex = 85;
            this.saveButton.Text = "Сохранить билет";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // questionContentToolTip
            // 
            this.questionContentToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.questionContentToolTip.ToolTipTitle = "Текст вопроса";
            // 
            // EditTicketControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.watchButton);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.upButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.questionsList);
            this.Controls.Add(this.addGroupButton);
            this.Controls.Add(this.groupCountLabel);
            this.Controls.Add(this.questionsCountLabel);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.ticketBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "EditTicketControl";
            this.Size = new System.Drawing.Size(721, 449);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label groupCountLabel;
        private System.Windows.Forms.Label questionsCountLabel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TextBox ticketBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addGroupButton;
        private System.Windows.Forms.ListBox questionsList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button watchButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ToolTip questionContentToolTip;
    }
}
