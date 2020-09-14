namespace SimplExClient.Controls
{
    partial class QuestionControl
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
            this.questionTitleLabel = new System.Windows.Forms.Label();
            this.propertiesPanel = new System.Windows.Forms.Panel();
            this.prevButton = new System.Windows.Forms.Button();
            this.nextButtonEnabled = new System.Windows.Forms.Button();
            this.pointsLabel = new System.Windows.Forms.Label();
            this.themeBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // questionTitleLabel
            // 
            this.questionTitleLabel.AutoSize = true;
            this.questionTitleLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.questionTitleLabel.Location = new System.Drawing.Point(2, 0);
            this.questionTitleLabel.Name = "questionTitleLabel";
            this.questionTitleLabel.Size = new System.Drawing.Size(94, 19);
            this.questionTitleLabel.TabIndex = 88;
            this.questionTitleLabel.Text = "Вопрос №1:";
            // 
            // propertiesPanel
            // 
            this.propertiesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertiesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.propertiesPanel.Location = new System.Drawing.Point(3, 49);
            this.propertiesPanel.Name = "propertiesPanel";
            this.propertiesPanel.Size = new System.Drawing.Size(712, 364);
            this.propertiesPanel.TabIndex = 87;
            // 
            // prevButton
            // 
            this.prevButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.prevButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.prevButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prevButton.Location = new System.Drawing.Point(509, 417);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(100, 23);
            this.prevButton.TabIndex = 89;
            this.prevButton.Text = "Назад";
            this.prevButton.UseVisualStyleBackColor = false;
            this.prevButton.Click += new System.EventHandler(this.PrevButtonClick);
            // 
            // nextButtonEnabled
            // 
            this.nextButtonEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextButtonEnabled.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.nextButtonEnabled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextButtonEnabled.Location = new System.Drawing.Point(615, 417);
            this.nextButtonEnabled.Name = "nextButtonEnabled";
            this.nextButtonEnabled.Size = new System.Drawing.Size(100, 23);
            this.nextButtonEnabled.TabIndex = 90;
            this.nextButtonEnabled.Text = "Далее";
            this.nextButtonEnabled.UseVisualStyleBackColor = false;
            this.nextButtonEnabled.Click += new System.EventHandler(this.NextButtonEnabledClick);
            // 
            // pointsLabel
            // 
            this.pointsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pointsLabel.AutoSize = true;
            this.pointsLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pointsLabel.Location = new System.Drawing.Point(-1, 418);
            this.pointsLabel.Name = "pointsLabel";
            this.pointsLabel.Size = new System.Drawing.Size(116, 19);
            this.pointsLabel.TabIndex = 91;
            this.pointsLabel.Text = "Балл за вопрос:";
            // 
            // themeBox
            // 
            this.themeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.themeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.themeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.themeBox.Location = new System.Drawing.Point(114, 22);
            this.themeBox.Name = "themeBox";
            this.themeBox.ReadOnly = true;
            this.themeBox.Size = new System.Drawing.Size(601, 21);
            this.themeBox.TabIndex = 66;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 19);
            this.label4.TabIndex = 65;
            this.label4.Text = "Тема вопроса:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // QuestionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.themeBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pointsLabel);
            this.Controls.Add(this.nextButtonEnabled);
            this.Controls.Add(this.prevButton);
            this.Controls.Add(this.questionTitleLabel);
            this.Controls.Add(this.propertiesPanel);
            this.Name = "QuestionControl";
            this.Size = new System.Drawing.Size(719, 445);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label questionTitleLabel;
        private System.Windows.Forms.Panel propertiesPanel;
        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.Button nextButtonEnabled;
        private System.Windows.Forms.Label pointsLabel;
        private System.Windows.Forms.TextBox themeBox;
        private System.Windows.Forms.Label label4;
    }
}
