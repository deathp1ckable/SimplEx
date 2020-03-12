namespace SimplexTestingFormDesigner
{
    partial class HFlatScrollBar
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
            this.runnerButton = new System.Windows.Forms.Button();
            this.lineDownButton = new System.Windows.Forms.Button();
            this.lineUpButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // runnerButton
            // 
            this.runnerButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.runnerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runnerButton.Location = new System.Drawing.Point(25, 1);
            this.runnerButton.Name = "runnerButton";
            this.runnerButton.Size = new System.Drawing.Size(40, 14);
            this.runnerButton.TabIndex = 3;
            this.runnerButton.UseVisualStyleBackColor = true;
            this.runnerButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.runnerButton_MouseDown);
            this.runnerButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.runnerButton_MouseUp);
            // 
            // lineDownButton
            // 
            this.lineDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lineDownButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lineDownButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lineDownButton.Image = global::SimplexTestingFormDesigner.Properties.Resources.RightArrow;
            this.lineDownButton.Location = new System.Drawing.Point(79, 1);
            this.lineDownButton.Name = "lineDownButton";
            this.lineDownButton.Size = new System.Drawing.Size(18, 14);
            this.lineDownButton.TabIndex = 2;
            this.lineDownButton.UseVisualStyleBackColor = true;
            this.lineDownButton.Click += new System.EventHandler(this.lineDownButton_Click);
            // 
            // lineUpButton
            // 
            this.lineUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lineUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lineUpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lineUpButton.Image = global::SimplexTestingFormDesigner.Properties.Resources.LeftArrow;
            this.lineUpButton.Location = new System.Drawing.Point(1, 1);
            this.lineUpButton.Name = "lineUpButton";
            this.lineUpButton.Size = new System.Drawing.Size(18, 14);
            this.lineUpButton.TabIndex = 4;
            this.lineUpButton.UseVisualStyleBackColor = true;
            this.lineUpButton.Click += new System.EventHandler(this.lineUpButton_Click);
            // 
            // HFlatScrollBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lineDownButton);
            this.Controls.Add(this.lineUpButton);
            this.Controls.Add(this.runnerButton);
            this.Name = "HFlatScrollBar";
            this.Size = new System.Drawing.Size(100, 18);
            this.Click += new System.EventHandler(this.flatScrollBar_Click);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button lineDownButton;
        private System.Windows.Forms.Button runnerButton;
        private System.Windows.Forms.Button lineUpButton;
    }
}
