namespace SimplExServer
{
    partial class SessionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SessionForm));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.clientsList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.startStopSessionButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.header = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.propertiesPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.additionButton = new System.Windows.Forms.Button();
            this.sesionInfoButton = new System.Windows.Forms.Button();
            this.connectionControlButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.groupLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.sessionStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.connectionsListToolTip = new System.Windows.Forms.ToolTip(this.components);
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
            this.splitContainer.Panel1.Controls.Add(this.clientsList);
            this.splitContainer.Panel1.Controls.Add(this.label2);
            this.splitContainer.Panel1.Controls.Add(this.startStopSessionButton);
            this.splitContainer.Panel1.Controls.Add(this.panel1);
            this.splitContainer.Panel1MinSize = 390;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.propertiesPanel);
            this.splitContainer.Panel2.Controls.Add(this.panel3);
            this.splitContainer.Panel2.Controls.Add(this.label1);
            this.splitContainer.Panel2MinSize = 600;
            this.splitContainer.Size = new System.Drawing.Size(1008, 642);
            this.splitContainer.SplitterDistance = 390;
            this.splitContainer.SplitterWidth = 3;
            this.splitContainer.TabIndex = 0;
            // 
            // clientsList
            // 
            this.clientsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientsList.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.clientsList.Font = new System.Drawing.Font("Calibri Light", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clientsList.FormattingEnabled = true;
            this.clientsList.IntegralHeight = false;
            this.clientsList.ItemHeight = 26;
            this.clientsList.Location = new System.Drawing.Point(3, 191);
            this.clientsList.Name = "clientsList";
            this.clientsList.Size = new System.Drawing.Size(382, 394);
            this.clientsList.TabIndex = 23;
            this.clientsList.SelectedIndexChanged += new System.EventHandler(this.ClientsListSelectedIndexChanged);
            this.clientsList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ClientsListMouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(-3, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 36);
            this.label2.TabIndex = 12;
            this.label2.Text = "Подключения:";
            // 
            // startStopSessionButton
            // 
            this.startStopSessionButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startStopSessionButton.BackColor = System.Drawing.SystemColors.Control;
            this.startStopSessionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startStopSessionButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startStopSessionButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.startStopSessionButton.Location = new System.Drawing.Point(3, 591);
            this.startStopSessionButton.Name = "startStopSessionButton";
            this.startStopSessionButton.Size = new System.Drawing.Size(382, 46);
            this.startStopSessionButton.TabIndex = 24;
            this.startStopSessionButton.Text = "Начать сессию";
            this.startStopSessionButton.UseVisualStyleBackColor = false;
            this.startStopSessionButton.Click += new System.EventHandler(this.StartStopSessionButtonClick);
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
            this.panel1.TabIndex = 0;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox.Image = global::SimplExServer.Properties.Resources.logoPicture;
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
            // propertiesPanel
            // 
            this.propertiesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertiesPanel.Location = new System.Drawing.Point(3, 74);
            this.propertiesPanel.Name = "propertiesPanel";
            this.propertiesPanel.Size = new System.Drawing.Size(607, 563);
            this.propertiesPanel.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.additionButton);
            this.panel3.Controls.Add(this.sesionInfoButton);
            this.panel3.Controls.Add(this.connectionControlButton);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.MinimumSize = new System.Drawing.Size(607, 42);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(607, 42);
            this.panel3.TabIndex = 0;
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
            // connectionControlButton
            // 
            this.connectionControlButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectionControlButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(31)))), ((int)(((byte)(47)))));
            this.connectionControlButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectionControlButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.connectionControlButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.connectionControlButton.Location = new System.Drawing.Point(244, 3);
            this.connectionControlButton.Name = "connectionControlButton";
            this.connectionControlButton.Size = new System.Drawing.Size(117, 34);
            this.connectionControlButton.TabIndex = 6;
            this.connectionControlButton.Tag = "1";
            this.connectionControlButton.Text = "Подключение";
            this.connectionControlButton.UseVisualStyleBackColor = false;
            this.connectionControlButton.Click += new System.EventHandler(this.TabStopClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Свойства";
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.groupLabel,
            this.sessionStatusLabel,
            this.timeLabel});
            this.statusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip.Location = new System.Drawing.Point(0, 645);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 9;
            this.statusStrip.Text = "statusStrip1";
            // 
            // groupLabel
            // 
            this.groupLabel.BackColor = System.Drawing.SystemColors.Control;
            this.groupLabel.Name = "groupLabel";
            this.groupLabel.Size = new System.Drawing.Size(49, 17);
            this.groupLabel.Text = "Группа:";
            // 
            // sessionStatusLabel
            // 
            this.sessionStatusLabel.BackColor = System.Drawing.SystemColors.Control;
            this.sessionStatusLabel.Name = "sessionStatusLabel";
            this.sessionStatusLabel.Size = new System.Drawing.Size(46, 17);
            this.sessionStatusLabel.Text = "Статус:";
            // 
            // timeLabel
            // 
            this.timeLabel.BackColor = System.Drawing.SystemColors.Control;
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(152, 17);
            this.timeLabel.Text = "Отсалось времени: --:--:--";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.TimerTick);
            // 
            // SessionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 667);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.splitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1024, 705);
            this.Name = "SessionForm";
            this.Text = "Проведение сессии экзаменов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SessionFormFormClosing);
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label header;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel sessionStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel groupLabel;
        private System.Windows.Forms.Button sesionInfoButton;
        private System.Windows.Forms.Button connectionControlButton;
        private System.Windows.Forms.Button startStopSessionButton;
        private System.Windows.Forms.Panel propertiesPanel;
        private System.Windows.Forms.Button additionButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripStatusLabel timeLabel;
        private System.Windows.Forms.ListBox clientsList;
        private System.Windows.Forms.ToolTip connectionsListToolTip;
        private System.Windows.Forms.Timer timer;
    }
}