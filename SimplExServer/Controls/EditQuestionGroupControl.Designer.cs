namespace SimplExServer.Controls
{
    partial class EditQuestionGroupControl
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
            this.addGroupButton = new System.Windows.Forms.Button();
            this.groupCountLabel = new System.Windows.Forms.Label();
            this.questionsCountLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.importButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.questionTypesList = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addGroupButton
            // 
            this.addGroupButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addGroupButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addGroupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addGroupButton.Location = new System.Drawing.Point(3, 58);
            this.addGroupButton.Name = "addGroupButton";
            this.addGroupButton.Size = new System.Drawing.Size(715, 23);
            this.addGroupButton.TabIndex = 87;
            this.addGroupButton.Text = "Добавить группу вопросов";
            this.addGroupButton.UseVisualStyleBackColor = false;
            this.addGroupButton.Click += new System.EventHandler(this.AddGroupButtonClick);
            // 
            // groupCountLabel
            // 
            this.groupCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupCountLabel.AutoSize = true;
            this.groupCountLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupCountLabel.Location = new System.Drawing.Point(4, 425);
            this.groupCountLabel.Name = "groupCountLabel";
            this.groupCountLabel.Size = new System.Drawing.Size(212, 19);
            this.groupCountLabel.TabIndex = 86;
            this.groupCountLabel.Text = "Количество групп вопросов: 0";
            this.groupCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // questionsCountLabel
            // 
            this.questionsCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.questionsCountLabel.AutoSize = true;
            this.questionsCountLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.questionsCountLabel.Location = new System.Drawing.Point(4, 406);
            this.questionsCountLabel.Name = "questionsCountLabel";
            this.questionsCountLabel.Size = new System.Drawing.Size(171, 19);
            this.questionsCountLabel.TabIndex = 85;
            this.questionsCountLabel.Text = "Количество вопросов: 0";
            this.questionsCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Location = new System.Drawing.Point(3, 380);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(715, 23);
            this.deleteButton.TabIndex = 84;
            this.deleteButton.Text = "Удалить группу";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButtonClick);
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox.Location = new System.Drawing.Point(139, 31);
            this.groupBox.MaxLength = 100;
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(579, 21);
            this.groupBox.TabIndex = 83;
            this.groupBox.TextChanged += new System.EventHandler(this.GroupBoxTextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(4, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 19);
            this.label4.TabIndex = 82;
            this.label4.Text = "Название группы:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // importButton
            // 
            this.importButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.importButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.importButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.importButton.Location = new System.Drawing.Point(3, 193);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(715, 23);
            this.importButton.TabIndex = 81;
            this.importButton.Text = "Импорт вопроса";
            this.importButton.UseVisualStyleBackColor = false;
            this.importButton.Click += new System.EventHandler(this.ImportButtonClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(4, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 19);
            this.label3.TabIndex = 80;
            this.label3.Text = "Управление группой:";
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Location = new System.Drawing.Point(3, 164);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(715, 23);
            this.addButton.TabIndex = 88;
            this.addButton.Text = "Добавить вопрос";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.AddButtonClick);
            // 
            // questionTypesList
            // 
            this.questionTypesList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.questionTypesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.questionTypesList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.questionTypesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.questionTypesList.FormattingEnabled = true;
            this.questionTypesList.Location = new System.Drawing.Point(106, 135);
            this.questionTypesList.Name = "questionTypesList";
            this.questionTypesList.Size = new System.Drawing.Size(612, 23);
            this.questionTypesList.TabIndex = 90;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(4, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 19);
            this.label5.TabIndex = 89;
            this.label5.Text = "Тип вопроса:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(4, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 19);
            this.label6.TabIndex = 91;
            this.label6.Text = "Управление вопросами:";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(3, 87);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(715, 23);
            this.saveButton.TabIndex = 93;
            this.saveButton.Text = "Сохранить группу вопросов";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // EditQuestionGroupControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.questionTypesList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.addGroupButton);
            this.Controls.Add(this.groupCountLabel);
            this.Controls.Add(this.questionsCountLabel);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.label3);
            this.Name = "EditQuestionGroupControl";
            this.Size = new System.Drawing.Size(723, 447);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addGroupButton;
        private System.Windows.Forms.Label groupCountLabel;
        private System.Windows.Forms.Label questionsCountLabel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TextBox groupBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ComboBox questionTypesList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button saveButton;
    }
}
