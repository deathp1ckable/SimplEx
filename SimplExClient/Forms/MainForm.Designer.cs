namespace SimplExClient.Forms
{
    partial class MainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Темы вопросов");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Билет");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.tree = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.header = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.structureLabel = new System.Windows.Forms.Label();
            this.propertiesPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.additionButton = new System.Windows.Forms.Button();
            this.sesionInfoButton = new System.Windows.Forms.Button();
            this.executionButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.groupLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.executedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.creationDateLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.chatToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel3.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.disconnectButton);
            this.splitContainer.Panel1.Controls.Add(this.tree);
            this.splitContainer.Panel1.Controls.Add(this.panel1);
            this.splitContainer.Panel1.Controls.Add(this.structureLabel);
            this.splitContainer.Panel1MinSize = 390;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.propertiesPanel);
            this.splitContainer.Panel2.Controls.Add(this.panel3);
            this.splitContainer.Panel2.Controls.Add(this.label2);
            this.splitContainer.Panel2MinSize = 100;
            this.splitContainer.Size = new System.Drawing.Size(1008, 642);
            this.splitContainer.SplitterDistance = 390;
            this.splitContainer.SplitterWidth = 3;
            this.splitContainer.TabIndex = 0;
            // 
            // disconnectButton
            // 
            this.disconnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.disconnectButton.BackColor = System.Drawing.SystemColors.Control;
            this.disconnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disconnectButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.disconnectButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.disconnectButton.Location = new System.Drawing.Point(3, 591);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(382, 46);
            this.disconnectButton.TabIndex = 25;
            this.disconnectButton.Text = "Отключится";
            this.disconnectButton.UseVisualStyleBackColor = false;
            this.disconnectButton.Click += new System.EventHandler(this.DisconnectButtonClick);
            // 
            // tree
            // 
            this.tree.AllowDrop = true;
            this.tree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tree.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tree.HideSelection = false;
            this.tree.Location = new System.Drawing.Point(3, 191);
            this.tree.Name = "tree";
            treeNode1.Name = "Themes";
            treeNode1.Text = "Темы вопросов";
            treeNode2.Name = "Ticket";
            treeNode2.Text = "Билет";
            this.tree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.tree.Size = new System.Drawing.Size(382, 394);
            this.tree.TabIndex = 8;
            this.tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeAfterSelect);
            this.tree.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TreeMouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(31)))), ((int)(((byte)(47)))));
            this.panel1.Controls.Add(this.pictureBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.header);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(382, 152);
            this.panel1.TabIndex = 7;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox.Image = global::SimplExClient.Properties.Resources.logoPicture;
            this.pictureBox.Location = new System.Drawing.Point(8, 8);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Padding = new System.Windows.Forms.Padding(2);
            this.pictureBox.Size = new System.Drawing.Size(100, 100);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 44;
            this.pictureBox.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(117, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(231, 23);
            this.label4.TabIndex = 43;
            this.label4.Text = "Simple Examination Program";
            // 
            // header
            // 
            this.header.AutoSize = true;
            this.header.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.header.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.header.Location = new System.Drawing.Point(0, 108);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(316, 45);
            this.header.TabIndex = 10;
            this.header.Text = "Экзаминирование";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(111, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 59);
            this.label3.TabIndex = 42;
            this.label3.Text = "SimplEx";
            // 
            // structureLabel
            // 
            this.structureLabel.AutoSize = true;
            this.structureLabel.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.structureLabel.Location = new System.Drawing.Point(-3, 156);
            this.structureLabel.Name = "structureLabel";
            this.structureLabel.Size = new System.Drawing.Size(212, 36);
            this.structureLabel.TabIndex = 2;
            this.structureLabel.Text = "Структура теста:";
            // 
            // propertiesPanel
            // 
            this.propertiesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertiesPanel.AutoScroll = true;
            this.propertiesPanel.AutoScrollMargin = new System.Drawing.Size(0, 5);
            this.propertiesPanel.Location = new System.Drawing.Point(3, 74);
            this.propertiesPanel.Name = "propertiesPanel";
            this.propertiesPanel.Size = new System.Drawing.Size(607, 563);
            this.propertiesPanel.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.additionButton);
            this.panel3.Controls.Add(this.sesionInfoButton);
            this.panel3.Controls.Add(this.executionButton);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(607, 42);
            this.panel3.TabIndex = 6;
            // 
            // additionButton
            // 
            this.additionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.additionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(31)))), ((int)(((byte)(47)))));
            this.additionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.additionButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.additionButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.additionButton.Location = new System.Drawing.Point(367, 3);
            this.additionButton.Name = "additionButton";
            this.additionButton.Size = new System.Drawing.Size(235, 34);
            this.additionButton.TabIndex = 7;
            this.additionButton.Tag = "2";
            this.additionButton.Text = "Дополнительно";
            this.additionButton.UseVisualStyleBackColor = false;
            this.additionButton.Click += new System.EventHandler(this.TabStopClick);
            // 
            // sesionInfoButton
            // 
            this.sesionInfoButton.BackColor = System.Drawing.SystemColors.Control;
            this.sesionInfoButton.Enabled = false;
            this.sesionInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sesionInfoButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sesionInfoButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.sesionInfoButton.Location = new System.Drawing.Point(3, 3);
            this.sesionInfoButton.Name = "sesionInfoButton";
            this.sesionInfoButton.Size = new System.Drawing.Size(235, 34);
            this.sesionInfoButton.TabIndex = 5;
            this.sesionInfoButton.Tag = "0";
            this.sesionInfoButton.Text = "Информация про сессию";
            this.sesionInfoButton.UseVisualStyleBackColor = false;
            this.sesionInfoButton.Click += new System.EventHandler(this.TabStopClick);
            // 
            // executionButton
            // 
            this.executionButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.executionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(31)))), ((int)(((byte)(47)))));
            this.executionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.executionButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.executionButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.executionButton.Location = new System.Drawing.Point(244, 3);
            this.executionButton.Name = "executionButton";
            this.executionButton.Size = new System.Drawing.Size(117, 34);
            this.executionButton.TabIndex = 6;
            this.executionButton.Tag = "1";
            this.executionButton.Text = "Выполнение";
            this.executionButton.UseVisualStyleBackColor = false;
            this.executionButton.Click += new System.EventHandler(this.TabStopClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Свойства";
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.groupLabel,
            this.statusLabel,
            this.timeLabel,
            this.executedLabel});
            this.statusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip.Location = new System.Drawing.Point(0, 645);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 8;
            this.statusStrip.Text = "statusStrip1";
            // 
            // groupLabel
            // 
            this.groupLabel.Name = "groupLabel";
            this.groupLabel.Size = new System.Drawing.Size(49, 17);
            this.groupLabel.Text = "Группа:";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(46, 17);
            this.statusLabel.Text = "Статус:";
            // 
            // timeLabel
            // 
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(152, 17);
            this.timeLabel.Text = "Осталось времени: --:--:--";
            // 
            // executedLabel
            // 
            this.executedLabel.Name = "executedLabel";
            this.executedLabel.Size = new System.Drawing.Size(130, 17);
            this.executedLabel.Text = "Выполнено вопросов:";
            // 
            // creationDateLabel
            // 
            this.creationDateLabel.BackColor = System.Drawing.SystemColors.Control;
            this.creationDateLabel.Name = "creationDateLabel";
            this.creationDateLabel.Size = new System.Drawing.Size(159, 17);
            this.creationDateLabel.Text = "Максимальный бал за тест:";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(46, 17);
            this.toolStripStatusLabel1.Text = "Статус:";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel3.Text = "Количество вопросов:";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(204, 17);
            this.toolStripStatusLabel2.Text = "Количество выполненых вопросов:";
            // 
            // chatToolTip
            // 
            this.chatToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.chatToolTip.ToolTipTitle = "Новое сообщение в чате";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.TimerTick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 667);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.splitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1024, 705);
            this.Name = "MainForm";
            this.Text = "Выполнение экзамена";
            this.Deactivate += new System.EventHandler(this.MainFormDeactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel3.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label structureLabel;
        private System.Windows.Forms.Panel propertiesPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel creationDateLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label header;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.ToolStripStatusLabel groupLabel;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel timeLabel;
        private System.Windows.Forms.ToolStripStatusLabel executedLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button additionButton;
        private System.Windows.Forms.Button sesionInfoButton;
        private System.Windows.Forms.Button executionButton;
        private System.Windows.Forms.ToolTip chatToolTip;
        private System.Windows.Forms.Timer timer;
    }
}

