﻿namespace SimplExServer.Forms
{
    partial class EditPropertiesForm
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
            this.propertiesPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // propertiesPanel
            // 
            this.propertiesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertiesPanel.AutoScroll = true;
            this.propertiesPanel.AutoScrollMargin = new System.Drawing.Size(0, 5);
            this.propertiesPanel.Location = new System.Drawing.Point(12, 12);
            this.propertiesPanel.Name = "propertiesPanel";
            this.propertiesPanel.Size = new System.Drawing.Size(800, 462);
            this.propertiesPanel.TabIndex = 6;
            // 
            // EditPropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 486);
            this.Controls.Add(this.propertiesPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditPropertiesForm";
            this.Text = "Свойства";
            this.Activated += new System.EventHandler(this.EditPropertiesFormActivated);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel propertiesPanel;
    }
}