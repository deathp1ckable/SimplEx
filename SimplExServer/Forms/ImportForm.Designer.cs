namespace SimplExServer.Forms
{
    partial class ImportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportForm));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.loaderListPanel = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.dbInfoLabel = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.openFileButton = new System.Windows.Forms.Button();
            this.examsList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hider = new System.Windows.Forms.Panel();
            this.loaderExamPanel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.infoText = new System.Windows.Forms.Label();
            this.nameText = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.skipButtonButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.questionsList = new System.Windows.Forms.ListBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.ComboBox();
            this.questionContentToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.loaderListPanel.SuspendLayout();
            this.hider.SuspendLayout();
            this.loaderExamPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.leftPanel);
            this.splitContainer.Panel1MinSize = 257;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.hider);
            this.splitContainer.Panel2.Controls.Add(this.nameText);
            this.splitContainer.Panel2.Controls.Add(this.label3);
            this.splitContainer.Panel2.Controls.Add(this.panel1);
            this.splitContainer.Panel2MinSize = 500;
            this.splitContainer.Size = new System.Drawing.Size(894, 543);
            this.splitContainer.SplitterDistance = 317;
            this.splitContainer.SplitterWidth = 3;
            this.splitContainer.TabIndex = 0;
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.leftPanel.Controls.Add(this.loaderListPanel);
            this.leftPanel.Controls.Add(this.dbInfoLabel);
            this.leftPanel.Controls.Add(this.connectButton);
            this.leftPanel.Controls.Add(this.openFileButton);
            this.leftPanel.Controls.Add(this.examsList);
            this.leftPanel.Controls.Add(this.label2);
            this.leftPanel.Controls.Add(this.label1);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(315, 541);
            this.leftPanel.TabIndex = 0;
            // 
            // loaderListPanel
            // 
            this.loaderListPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loaderListPanel.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaderListPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loaderListPanel.Controls.Add(this.panel5);
            this.loaderListPanel.Controls.Add(this.label6);
            this.loaderListPanel.Location = new System.Drawing.Point(3, 93);
            this.loaderListPanel.Name = "loaderListPanel";
            this.loaderListPanel.Size = new System.Drawing.Size(309, 368);
            this.loaderListPanel.TabIndex = 40;
            this.loaderListPanel.Visible = false;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(301, 343);
            this.panel5.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(3, 343);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 23;
            this.label6.Text = "Загрузка....";
            // 
            // dbInfoLabel
            // 
            this.dbInfoLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbInfoLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.dbInfoLabel.Location = new System.Drawing.Point(0, 526);
            this.dbInfoLabel.Name = "dbInfoLabel";
            this.dbInfoLabel.Size = new System.Drawing.Size(312, 16);
            this.dbInfoLabel.TabIndex = 87;
            this.dbInfoLabel.Text = "Информация про подключение";
            // 
            // connectButton
            // 
            this.connectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.connectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.connectButton.ForeColor = System.Drawing.SystemColors.Control;
            this.connectButton.Location = new System.Drawing.Point(3, 498);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(309, 25);
            this.connectButton.TabIndex = 41;
            this.connectButton.Text = "Подключится к базе данных";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.ConnectButtonClick);
            // 
            // openFileButton
            // 
            this.openFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openFileButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.openFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openFileButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.openFileButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.openFileButton.Location = new System.Drawing.Point(3, 467);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(309, 25);
            this.openFileButton.TabIndex = 86;
            this.openFileButton.Text = "Открыть файл";
            this.openFileButton.UseVisualStyleBackColor = false;
            this.openFileButton.Click += new System.EventHandler(this.OpenFileButtonClick);
            // 
            // examsList
            // 
            this.examsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.examsList.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.examsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.examsList.Font = new System.Drawing.Font("Calibri Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.examsList.FormattingEnabled = true;
            this.examsList.ItemHeight = 23;
            this.examsList.Location = new System.Drawing.Point(5, 93);
            this.examsList.Name = "examsList";
            this.examsList.Size = new System.Drawing.Size(305, 368);
            this.examsList.TabIndex = 23;
            this.examsList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ExamsListMouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(3, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 36);
            this.label2.TabIndex = 12;
            this.label2.Text = "Экзамены:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 36);
            this.label1.TabIndex = 37;
            this.label1.Text = "Импорт вопросов";
            // 
            // hider
            // 
            this.hider.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.hider.Controls.Add(this.loaderExamPanel);
            this.hider.Controls.Add(this.panel6);
            this.hider.Controls.Add(this.infoText);
            this.hider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hider.Location = new System.Drawing.Point(0, 0);
            this.hider.Name = "hider";
            this.hider.Size = new System.Drawing.Size(572, 541);
            this.hider.TabIndex = 38;
            // 
            // loaderExamPanel
            // 
            this.loaderExamPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.loaderExamPanel.Controls.Add(this.panel4);
            this.loaderExamPanel.Controls.Add(this.label5);
            this.loaderExamPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loaderExamPanel.Location = new System.Drawing.Point(0, 0);
            this.loaderExamPanel.Name = "loaderExamPanel";
            this.loaderExamPanel.Size = new System.Drawing.Size(572, 541);
            this.loaderExamPanel.TabIndex = 38;
            this.loaderExamPanel.Visible = false;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(566, 509);
            this.panel4.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(3, 515);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 23;
            this.label5.Text = "Загрузка....";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(566, 509);
            this.panel6.TabIndex = 42;
            // 
            // infoText
            // 
            this.infoText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.infoText.AutoSize = true;
            this.infoText.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoText.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.infoText.Location = new System.Drawing.Point(7, 515);
            this.infoText.Name = "infoText";
            this.infoText.Size = new System.Drawing.Size(254, 23);
            this.infoText.TabIndex = 23;
            this.infoText.Text = "Выберете экзамен для работы";
            // 
            // nameText
            // 
            this.nameText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nameText.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameText.ForeColor = System.Drawing.SystemColors.ControlText;
            this.nameText.Location = new System.Drawing.Point(250, 16);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(326, 26);
            this.nameText.TabIndex = 37;
            this.nameText.Text = "Новый экзамен";
            this.nameText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(1, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 36);
            this.label3.TabIndex = 31;
            this.label3.Text = "Вопросы:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.skipButtonButton);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.questionsList);
            this.panel1.Controls.Add(this.searchButton);
            this.panel1.Controls.Add(this.importButton);
            this.panel1.Controls.Add(this.searchBox);
            this.panel1.Location = new System.Drawing.Point(3, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(566, 490);
            this.panel1.TabIndex = 36;
            // 
            // skipButtonButton
            // 
            this.skipButtonButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.skipButtonButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.skipButtonButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.skipButtonButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.skipButtonButton.Location = new System.Drawing.Point(3, 460);
            this.skipButtonButton.Name = "skipButtonButton";
            this.skipButtonButton.Size = new System.Drawing.Size(558, 25);
            this.skipButtonButton.TabIndex = 85;
            this.skipButtonButton.Text = "Отмена";
            this.skipButtonButton.UseVisualStyleBackColor = false;
            this.skipButtonButton.Click += new System.EventHandler(this.SkipButtonButtonClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cancelButton.Enabled = false;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelButton.Location = new System.Drawing.Point(467, 370);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(20, 28);
            this.cancelButton.TabIndex = 35;
            this.cancelButton.Text = "X";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // questionsList
            // 
            this.questionsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.questionsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.questionsList.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.questionsList.FormattingEnabled = true;
            this.questionsList.ItemHeight = 19;
            this.questionsList.Location = new System.Drawing.Point(3, 3);
            this.questionsList.Name = "questionsList";
            this.questionsList.Size = new System.Drawing.Size(558, 361);
            this.questionsList.TabIndex = 32;
            this.questionsList.SelectedIndexChanged += new System.EventHandler(this.QuestionsListSelectedIndexChanged);
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchButton.Location = new System.Drawing.Point(491, 370);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(70, 28);
            this.searchButton.TabIndex = 34;
            this.searchButton.Text = "Поиск";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.SearchButtonClick);
            // 
            // importButton
            // 
            this.importButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.importButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.importButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.importButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.importButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.importButton.Location = new System.Drawing.Point(3, 404);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(558, 50);
            this.importButton.TabIndex = 30;
            this.importButton.Text = "Имортировать вопрос";
            this.importButton.UseVisualStyleBackColor = false;
            this.importButton.Click += new System.EventHandler(this.ImportButtonClick);
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchBox.FormattingEnabled = true;
            this.searchBox.Location = new System.Drawing.Point(3, 370);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(458, 28);
            this.searchBox.TabIndex = 33;
            this.searchBox.TextChanged += new System.EventHandler(this.SearchBoxTextChanged);
            // 
            // questionContentToolTip
            // 
            this.questionContentToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.questionContentToolTip.ToolTipTitle = "Текст вопроса";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "*.smpx";
            this.openFileDialog.FileName = "Новый экзамен";
            this.openFileDialog.Filter = "*.smpx Файлы Экзаменов|*.smpx";
            this.openFileDialog.Title = "Открыть экзамен";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialogFileOk);
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(894, 543);
            this.Controls.Add(this.splitContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(820, 490);
            this.Name = "ImportForm";
            this.Text = "Импорт вопроса";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ImportQuestionFormFormClosed);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            this.loaderListPanel.ResumeLayout(false);
            this.loaderListPanel.PerformLayout();
            this.hider.ResumeLayout(false);
            this.hider.PerformLayout();
            this.loaderExamPanel.ResumeLayout(false);
            this.loaderExamPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ListBox questionsList;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.ComboBox searchBox;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip questionContentToolTip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox examsList;
        private System.Windows.Forms.Button skipButtonButton;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label nameText;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label dbInfoLabel;
        private System.Windows.Forms.Panel loaderListPanel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel hider;
        private System.Windows.Forms.Panel loaderExamPanel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label infoText;
    }
}