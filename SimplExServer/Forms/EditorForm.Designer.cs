namespace SimplExServer
{
    partial class EditorForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorForm));
            this.subHeaderPanel = new System.Windows.Forms.Panel();
            this.headerPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.propertiesButton = new System.Windows.Forms.Button();
            this.markSystemButton = new System.Windows.Forms.Button();
            this.contentButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.structureLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.creationDateLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lastChangeDateLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.questionCountLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.treePanel = new System.Windows.Forms.Panel();
            this.propertiesPanel = new System.Windows.Forms.Panel();
            this.unsavedPropertiesTip = new System.Windows.Forms.ToolTip(this.components);
            this.unsavedMarkSystemToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.subHeaderPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // subHeaderPanel
            // 
            this.subHeaderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subHeaderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.subHeaderPanel.Controls.Add(this.headerPanel);
            this.subHeaderPanel.Location = new System.Drawing.Point(-1, -1);
            this.subHeaderPanel.Name = "subHeaderPanel";
            this.subHeaderPanel.Size = new System.Drawing.Size(1193, 50);
            this.subHeaderPanel.TabIndex = 1;
            this.subHeaderPanel.Tag = "0";
            // 
            // headerPanel
            // 
            this.headerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headerPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.headerPanel.Controls.Add(this.propertiesButton);
            this.headerPanel.Controls.Add(this.markSystemButton);
            this.headerPanel.Controls.Add(this.contentButton);
            this.headerPanel.Controls.Add(this.saveButton);
            this.headerPanel.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.headerPanel.Location = new System.Drawing.Point(4, 4);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1166, 40);
            this.headerPanel.TabIndex = 0;
            // 
            // propertiesButton
            // 
            this.propertiesButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.propertiesButton.Enabled = false;
            this.propertiesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.propertiesButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.propertiesButton.ForeColor = System.Drawing.SystemColors.Control;
            this.propertiesButton.Location = new System.Drawing.Point(3, 3);
            this.propertiesButton.Name = "propertiesButton";
            this.propertiesButton.Size = new System.Drawing.Size(200, 34);
            this.propertiesButton.TabIndex = 1;
            this.propertiesButton.Tag = "0";
            this.propertiesButton.Text = "Параметры";
            this.propertiesButton.UseVisualStyleBackColor = false;
            this.propertiesButton.Click += new System.EventHandler(this.TabStopClick);
            // 
            // markSystemButton
            // 
            this.markSystemButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.markSystemButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.markSystemButton.ForeColor = System.Drawing.SystemColors.Control;
            this.markSystemButton.Location = new System.Drawing.Point(209, 3);
            this.markSystemButton.Name = "markSystemButton";
            this.markSystemButton.Size = new System.Drawing.Size(200, 34);
            this.markSystemButton.TabIndex = 3;
            this.markSystemButton.Tag = "1";
            this.markSystemButton.Text = "Система оценивания";
            this.markSystemButton.UseVisualStyleBackColor = true;
            this.markSystemButton.Click += new System.EventHandler(this.TabStopClick);
            // 
            // contentButton
            // 
            this.contentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.contentButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.contentButton.ForeColor = System.Drawing.SystemColors.Control;
            this.contentButton.Location = new System.Drawing.Point(415, 3);
            this.contentButton.Name = "contentButton";
            this.contentButton.Size = new System.Drawing.Size(200, 34);
            this.contentButton.TabIndex = 1;
            this.contentButton.Tag = "2";
            this.contentButton.Text = "Содержание";
            this.contentButton.UseVisualStyleBackColor = true;
            this.contentButton.Click += new System.EventHandler(this.TabStopClick);
            // 
            // saveButton
            // 
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveButton.ForeColor = System.Drawing.SystemColors.Control;
            this.saveButton.Location = new System.Drawing.Point(621, 3);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(200, 34);
            this.saveButton.TabIndex = 4;
            this.saveButton.Tag = "3";
            this.saveButton.Text = "Сохранение";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.TabStopClick);
            // 
            // structureLabel
            // 
            this.structureLabel.AutoSize = true;
            this.structureLabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.structureLabel.Location = new System.Drawing.Point(4, 4);
            this.structureLabel.Name = "structureLabel";
            this.structureLabel.Size = new System.Drawing.Size(135, 23);
            this.structureLabel.TabIndex = 2;
            this.structureLabel.Text = "Структура теста";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Свойства";
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.creationDateLabel,
            this.lastChangeDateLabel,
            this.questionCountLabel});
            this.statusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip.Location = new System.Drawing.Point(0, 635);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1175, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip1";
            // 
            // creationDateLabel
            // 
            this.creationDateLabel.BackColor = System.Drawing.SystemColors.Control;
            this.creationDateLabel.Name = "creationDateLabel";
            this.creationDateLabel.Size = new System.Drawing.Size(88, 17);
            this.creationDateLabel.Text = "Дата создания:";
            // 
            // lastChangeDateLabel
            // 
            this.lastChangeDateLabel.Name = "lastChangeDateLabel";
            this.lastChangeDateLabel.Size = new System.Drawing.Size(98, 17);
            this.lastChangeDateLabel.Text = "Дата изменения:";
            // 
            // questionCountLabel
            // 
            this.questionCountLabel.Name = "questionCountLabel";
            this.questionCountLabel.Size = new System.Drawing.Size(131, 17);
            this.questionCountLabel.Text = "Количество вопросов:";
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Location = new System.Drawing.Point(6, 56);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treePanel);
            this.splitContainer.Panel1.Controls.Add(this.structureLabel);
            this.splitContainer.Panel1MinSize = 320;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.propertiesPanel);
            this.splitContainer.Panel2.Controls.Add(this.label2);
            this.splitContainer.Panel2MinSize = 600;
            this.splitContainer.Size = new System.Drawing.Size(1164, 576);
            this.splitContainer.SplitterDistance = 427;
            this.splitContainer.TabIndex = 6;
            this.splitContainer.TabStop = false;
            // 
            // treePanel
            // 
            this.treePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treePanel.Location = new System.Drawing.Point(3, 30);
            this.treePanel.Name = "treePanel";
            this.treePanel.Size = new System.Drawing.Size(419, 541);
            this.treePanel.TabIndex = 6;
            // 
            // propertiesPanel
            // 
            this.propertiesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertiesPanel.AutoScroll = true;
            this.propertiesPanel.AutoScrollMargin = new System.Drawing.Size(0, 5);
            this.propertiesPanel.Location = new System.Drawing.Point(3, 30);
            this.propertiesPanel.Name = "propertiesPanel";
            this.propertiesPanel.Size = new System.Drawing.Size(725, 541);
            this.propertiesPanel.TabIndex = 5;
            // 
            // unsavedPropertiesTip
            // 
            this.unsavedPropertiesTip.Active = false;
            this.unsavedPropertiesTip.IsBalloon = true;
            this.unsavedPropertiesTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.unsavedPropertiesTip.ToolTipTitle = "Данные не сохранены";
            // 
            // unsavedMarkSystemToolTip
            // 
            this.unsavedMarkSystemToolTip.Active = false;
            this.unsavedMarkSystemToolTip.IsBalloon = true;
            this.unsavedMarkSystemToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.unsavedMarkSystemToolTip.ToolTipTitle = "Данные не сохранены";
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1175, 657);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.subHeaderPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(849, 597);
            this.Name = "EditorForm";
            this.Text = "SimplEx Редактор";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditorFormFormClosing);
            this.subHeaderPanel.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel subHeaderPanel;
        private System.Windows.Forms.Label structureLabel;
        private System.Windows.Forms.FlowLayoutPanel headerPanel;
        private System.Windows.Forms.Button contentButton;
        private System.Windows.Forms.Button propertiesButton;
        private System.Windows.Forms.Button markSystemButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ToolStripStatusLabel creationDateLabel;
        private System.Windows.Forms.ToolStripStatusLabel lastChangeDateLabel;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ToolStripStatusLabel questionCountLabel;
        private System.Windows.Forms.Panel propertiesPanel;
        private System.Windows.Forms.ToolTip unsavedPropertiesTip;
        private System.Windows.Forms.ToolTip unsavedMarkSystemToolTip;
        private System.Windows.Forms.Panel treePanel;
    }
}