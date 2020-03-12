namespace SimplExTesting
{
    partial class FlatPanel
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
            this.cornerPanel = new System.Windows.Forms.Panel();
            this.vFlatScrollBar = new SimplExTesting.VFlatScrollBar();
            this.hFlatScrollBar = new SimplExTesting.HFlatScrollBar();
            this.leftBorder = new System.Windows.Forms.Panel();
            this.rightBorder = new System.Windows.Forms.Panel();
            this.topBorder = new System.Windows.Forms.Panel();
            this.bottomBorder = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // cornerPanel
            // 
            this.cornerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cornerPanel.Location = new System.Drawing.Point(200, 200);
            this.cornerPanel.Name = "cornerPanel";
            this.cornerPanel.Size = new System.Drawing.Size(18, 18);
            this.cornerPanel.TabIndex = 2;
            // 
            // vFlatScrollBar
            // 
            this.vFlatScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vFlatScrollBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vFlatScrollBar.LargeChange = 10;
            this.vFlatScrollBar.Location = new System.Drawing.Point(200, 0);
            this.vFlatScrollBar.Maximum = 100;
            this.vFlatScrollBar.Minimum = 0;
            this.vFlatScrollBar.MoversColor = System.Drawing.Color.White;
            this.vFlatScrollBar.Name = "vFlatScrollBar";
            this.vFlatScrollBar.Size = new System.Drawing.Size(18, 200);
            this.vFlatScrollBar.SmallChange = 1;
            this.vFlatScrollBar.TabIndex = 1;
            this.vFlatScrollBar.Value = 0;
            // 
            // hFlatScrollBar
            // 
            this.hFlatScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hFlatScrollBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hFlatScrollBar.LargeChange = 10;
            this.hFlatScrollBar.Location = new System.Drawing.Point(0, 200);
            this.hFlatScrollBar.Maximum = 100;
            this.hFlatScrollBar.Minimum = 0;
            this.hFlatScrollBar.MoversColor = System.Drawing.Color.White;
            this.hFlatScrollBar.Name = "hFlatScrollBar";
            this.hFlatScrollBar.Size = new System.Drawing.Size(200, 18);
            this.hFlatScrollBar.SmallChange = 1;
            this.hFlatScrollBar.TabIndex = 0;
            this.hFlatScrollBar.Value = 0;
            // 
            // leftBorder
            // 
            this.leftBorder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.leftBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.leftBorder.Location = new System.Drawing.Point(0, 0);
            this.leftBorder.Name = "leftBorder";
            this.leftBorder.Size = new System.Drawing.Size(1, 218);
            this.leftBorder.TabIndex = 3;
            // 
            // rightBorder
            // 
            this.rightBorder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rightBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rightBorder.Location = new System.Drawing.Point(217, 0);
            this.rightBorder.Name = "rightBorder";
            this.rightBorder.Size = new System.Drawing.Size(1, 218);
            this.rightBorder.TabIndex = 4;
            // 
            // topBorder
            // 
            this.topBorder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.topBorder.Location = new System.Drawing.Point(0, 0);
            this.topBorder.Name = "topBorder";
            this.topBorder.Size = new System.Drawing.Size(218, 1);
            this.topBorder.TabIndex = 5;
            // 
            // bottomBorder
            // 
            this.bottomBorder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bottomBorder.Location = new System.Drawing.Point(0, 217);
            this.bottomBorder.Name = "bottomBorder";
            this.bottomBorder.Size = new System.Drawing.Size(218, 1);
            this.bottomBorder.TabIndex = 6;
            // 
            // FlatPanel
            // 
            this.Controls.Add(this.bottomBorder);
            this.Controls.Add(this.topBorder);
            this.Controls.Add(this.rightBorder);
            this.Controls.Add(this.leftBorder);
            this.Controls.Add(this.vFlatScrollBar);
            this.Controls.Add(this.hFlatScrollBar);
            this.Controls.Add(this.cornerPanel);
            this.Name = "FlatPanel";
            this.Size = new System.Drawing.Size(218, 218);
            this.ResumeLayout(false);

        }

        #endregion

        private HFlatScrollBar hFlatScrollBar;
        private VFlatScrollBar vFlatScrollBar;
        private System.Windows.Forms.Panel cornerPanel;
        private System.Windows.Forms.Panel leftBorder;
        private System.Windows.Forms.Panel rightBorder;
        private System.Windows.Forms.Panel topBorder;
        private System.Windows.Forms.Panel bottomBorder;
    }
}
