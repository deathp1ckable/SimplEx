namespace SimplExServer.Controls
{
    partial class EditQuestionControl
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
            this.numberLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.propertiesPanel = new System.Windows.Forms.Panel();
            this.themesList = new System.Windows.Forms.ComboBox();
            this.questionTypeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // numberLabel
            // 
            this.numberLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numberLabel.AutoSize = true;
            this.numberLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numberLabel.Location = new System.Drawing.Point(2, 402);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(129, 19);
            this.numberLabel.TabIndex = 86;
            this.numberLabel.Text = "Номер вопроса: 0";
            this.numberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Location = new System.Drawing.Point(3, 376);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(711, 23);
            this.deleteButton.TabIndex = 84;
            this.deleteButton.Text = "Удалить вопрос";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButtonClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(2, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 19);
            this.label4.TabIndex = 82;
            this.label4.Text = "Тема вопроса:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(2, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 19);
            this.label3.TabIndex = 80;
            this.label3.Text = "Управление вопросом:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(2, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 88;
            this.label1.Text = "Параметры";
            // 
            // propertiesPanel
            // 
            this.propertiesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertiesPanel.Location = new System.Drawing.Point(3, 75);
            this.propertiesPanel.Name = "propertiesPanel";
            this.propertiesPanel.Size = new System.Drawing.Size(711, 293);
            this.propertiesPanel.TabIndex = 87;
            // 
            // themesList
            // 
            this.themesList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.themesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.themesList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.themesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.themesList.FormattingEnabled = true;
            this.themesList.Location = new System.Drawing.Point(114, 27);
            this.themesList.Name = "themesList";
            this.themesList.Size = new System.Drawing.Size(600, 23);
            this.themesList.TabIndex = 37;
            this.themesList.SelectedIndexChanged += new System.EventHandler(this.ThemesListSelectedIndexChanged);
            // 
            // questionTypeLabel
            // 
            this.questionTypeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.questionTypeLabel.AutoSize = true;
            this.questionTypeLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.questionTypeLabel.Location = new System.Drawing.Point(2, 421);
            this.questionTypeLabel.Name = "questionTypeLabel";
            this.questionTypeLabel.Size = new System.Drawing.Size(284, 19);
            this.questionTypeLabel.TabIndex = 89;
            this.questionTypeLabel.Text = "Тип вопроса: Тестовый с одним ответом";
            this.questionTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EditQuestionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.questionTypeLabel);
            this.Controls.Add(this.themesList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.propertiesPanel);
            this.Controls.Add(this.numberLabel);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "EditQuestionControl";
            this.Size = new System.Drawing.Size(719, 445);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel propertiesPanel;
        private System.Windows.Forms.ComboBox themesList;
        private System.Windows.Forms.Label questionTypeLabel;
    }
}
