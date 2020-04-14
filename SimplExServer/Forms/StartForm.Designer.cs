namespace SimplExServer
{
    partial class StartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.leftPanel = new System.Windows.Forms.Panel();
            this.dbInfoLabel = new System.Windows.Forms.Label();
            this.loaderListPanel = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.examsList = new System.Windows.Forms.ListBox();
            this.createButton = new System.Windows.Forms.Button();
            this.openFileButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.header = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.startSessionButton = new System.Windows.Forms.Button();
            this.resultsList = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.printResultButton = new System.Windows.Forms.Button();
            this.creatorText = new System.Windows.Forms.Label();
            this.disciplineText = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.descriptionText = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.executionTimeText = new System.Windows.Forms.Label();
            this.firstNumberText = new System.Windows.Forms.Label();
            this.lastChangeText = new System.Windows.Forms.Label();
            this.creationText = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.deleteResultButton = new System.Windows.Forms.Button();
            this.ticketsBox = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.printTaskButton = new System.Windows.Forms.Button();
            this.printBlankButton = new System.Windows.Forms.Button();
            this.nameText = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.hider = new System.Windows.Forms.Panel();
            this.loaderExamPanel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.infoText = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.leftPanel.SuspendLayout();
            this.loaderListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.hider.SuspendLayout();
            this.loaderExamPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.leftPanel.Controls.Add(this.dbInfoLabel);
            this.leftPanel.Controls.Add(this.loaderListPanel);
            this.leftPanel.Controls.Add(this.connectButton);
            this.leftPanel.Controls.Add(this.pictureBox);
            this.leftPanel.Controls.Add(this.examsList);
            this.leftPanel.Controls.Add(this.createButton);
            this.leftPanel.Controls.Add(this.openFileButton);
            this.leftPanel.Controls.Add(this.label2);
            this.leftPanel.Controls.Add(this.label1);
            this.leftPanel.Controls.Add(this.header);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(377, 679);
            this.leftPanel.TabIndex = 0;
            // 
            // dbInfoLabel
            // 
            this.dbInfoLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbInfoLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.dbInfoLabel.Location = new System.Drawing.Point(2, 660);
            this.dbInfoLabel.Name = "dbInfoLabel";
            this.dbInfoLabel.Size = new System.Drawing.Size(354, 16);
            this.dbInfoLabel.TabIndex = 41;
            this.dbInfoLabel.Text = "Информация про подключение";
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
            this.loaderListPanel.Location = new System.Drawing.Point(5, 140);
            this.loaderListPanel.Name = "loaderListPanel";
            this.loaderListPanel.Size = new System.Drawing.Size(366, 435);
            this.loaderListPanel.TabIndex = 39;
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
            this.panel5.Size = new System.Drawing.Size(358, 410);
            this.panel5.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(3, 410);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 23;
            this.label6.Text = "Загрузка....";
            // 
            // connectButton
            // 
            this.connectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.connectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.connectButton.ForeColor = System.Drawing.SystemColors.Control;
            this.connectButton.Location = new System.Drawing.Point(205, 112);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(166, 25);
            this.connectButton.TabIndex = 40;
            this.connectButton.Text = "Подключится к базе данных";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.ConnectButtonClick);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox.Image = global::SimplExServer.Properties.Resources.logoPicture;
            this.pictureBox.Location = new System.Drawing.Point(4, 4);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Padding = new System.Windows.Forms.Padding(2);
            this.pictureBox.Size = new System.Drawing.Size(100, 100);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 39;
            this.pictureBox.TabStop = false;
            // 
            // examsList
            // 
            this.examsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.examsList.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.examsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.examsList.Font = new System.Drawing.Font("Calibri Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.examsList.FormattingEnabled = true;
            this.examsList.IntegralHeight = false;
            this.examsList.ItemHeight = 29;
            this.examsList.Location = new System.Drawing.Point(5, 140);
            this.examsList.Name = "examsList";
            this.examsList.Size = new System.Drawing.Size(366, 435);
            this.examsList.TabIndex = 22;
            this.examsList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ExamsListMouseDoubleClick);
            // 
            // createButton
            // 
            this.createButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.createButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.createButton.ForeColor = System.Drawing.SystemColors.Control;
            this.createButton.Location = new System.Drawing.Point(5, 627);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(366, 28);
            this.createButton.TabIndex = 13;
            this.createButton.Text = "Создать новый экзамен";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.CreateButtonClick);
            // 
            // openFileButton
            // 
            this.openFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openFileButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.openFileButton.ForeColor = System.Drawing.SystemColors.Control;
            this.openFileButton.Location = new System.Drawing.Point(5, 582);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(366, 39);
            this.openFileButton.TabIndex = 12;
            this.openFileButton.Text = "Открыть файл экзамена";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.OpenFileButtonClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(3, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 36);
            this.label2.TabIndex = 11;
            this.label2.Text = "Экзамены:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(110, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "Simple Examination Program";
            // 
            // header
            // 
            this.header.AutoSize = true;
            this.header.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.header.ForeColor = System.Drawing.SystemColors.Control;
            this.header.Location = new System.Drawing.Point(106, 19);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(140, 45);
            this.header.TabIndex = 9;
            this.header.Text = "SimplEx";
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.deleteButton.Location = new System.Drawing.Point(3, 593);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(496, 30);
            this.deleteButton.TabIndex = 23;
            this.deleteButton.Text = "Удалить экзамен";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButtonClick);
            // 
            // changeButton
            // 
            this.changeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.changeButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.changeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changeButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.changeButton.Location = new System.Drawing.Point(3, 557);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(496, 30);
            this.changeButton.TabIndex = 24;
            this.changeButton.Text = "Изменить экзамен";
            this.changeButton.UseVisualStyleBackColor = false;
            this.changeButton.Click += new System.EventHandler(this.ChangeButtonClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 36);
            this.label3.TabIndex = 23;
            this.label3.Text = "Действия:";
            // 
            // startSessionButton
            // 
            this.startSessionButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startSessionButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.startSessionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startSessionButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startSessionButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.startSessionButton.Location = new System.Drawing.Point(3, 511);
            this.startSessionButton.Name = "startSessionButton";
            this.startSessionButton.Size = new System.Drawing.Size(496, 40);
            this.startSessionButton.TabIndex = 25;
            this.startSessionButton.Text = "Начать тестирование";
            this.startSessionButton.UseVisualStyleBackColor = false;
            this.startSessionButton.Click += new System.EventHandler(this.StartSessionButtonClick);
            // 
            // resultsList
            // 
            this.resultsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsList.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.resultsList.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultsList.FormattingEnabled = true;
            this.resultsList.ItemHeight = 15;
            this.resultsList.Location = new System.Drawing.Point(3, 26);
            this.resultsList.Name = "resultsList";
            this.resultsList.Size = new System.Drawing.Size(496, 94);
            this.resultsList.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(1, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(208, 23);
            this.label4.TabIndex = 23;
            this.label4.Text = "Результаты выполнения:";
            // 
            // printResultButton
            // 
            this.printResultButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.printResultButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.printResultButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.printResultButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.printResultButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.printResultButton.Location = new System.Drawing.Point(3, 126);
            this.printResultButton.Name = "printResultButton";
            this.printResultButton.Size = new System.Drawing.Size(496, 25);
            this.printResultButton.TabIndex = 27;
            this.printResultButton.Text = "Распечатаь результат выполнения";
            this.printResultButton.UseVisualStyleBackColor = false;
            this.printResultButton.Click += new System.EventHandler(this.PrintResultClick);
            // 
            // creatorText
            // 
            this.creatorText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.creatorText.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.creatorText.ForeColor = System.Drawing.SystemColors.ControlText;
            this.creatorText.Location = new System.Drawing.Point(3, 0);
            this.creatorText.Name = "creatorText";
            this.creatorText.Size = new System.Drawing.Size(487, 15);
            this.creatorText.TabIndex = 23;
            this.creatorText.Text = "Автор:";
            // 
            // disciplineText
            // 
            this.disciplineText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.disciplineText.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.disciplineText.ForeColor = System.Drawing.SystemColors.ControlText;
            this.disciplineText.Location = new System.Drawing.Point(3, 15);
            this.disciplineText.Name = "disciplineText";
            this.disciplineText.Size = new System.Drawing.Size(487, 16);
            this.disciplineText.TabIndex = 28;
            this.disciplineText.Text = "Дисциплина:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.descriptionLabel);
            this.panel1.Controls.Add(this.executionTimeText);
            this.panel1.Controls.Add(this.firstNumberText);
            this.panel1.Controls.Add(this.lastChangeText);
            this.panel1.Controls.Add(this.creationText);
            this.panel1.Controls.Add(this.disciplineText);
            this.panel1.Controls.Add(this.creatorText);
            this.panel1.Location = new System.Drawing.Point(3, 313);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 192);
            this.panel1.TabIndex = 29;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.descriptionText);
            this.panel2.Location = new System.Drawing.Point(3, 110);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(488, 77);
            this.panel2.TabIndex = 34;
            // 
            // descriptionText
            // 
            this.descriptionText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionText.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.descriptionText.ForeColor = System.Drawing.SystemColors.ControlText;
            this.descriptionText.Location = new System.Drawing.Point(-2, 3);
            this.descriptionText.Name = "descriptionText";
            this.descriptionText.Size = new System.Drawing.Size(485, 68);
            this.descriptionText.TabIndex = 33;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.descriptionLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.descriptionLabel.Location = new System.Drawing.Point(3, 95);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(94, 15);
            this.descriptionLabel.TabIndex = 33;
            this.descriptionLabel.Text = "Описание:";
            // 
            // executionTimeText
            // 
            this.executionTimeText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.executionTimeText.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.executionTimeText.ForeColor = System.Drawing.SystemColors.ControlText;
            this.executionTimeText.Location = new System.Drawing.Point(3, 79);
            this.executionTimeText.Name = "executionTimeText";
            this.executionTimeText.Size = new System.Drawing.Size(487, 16);
            this.executionTimeText.TabIndex = 32;
            this.executionTimeText.Text = "Время выполнения:";
            // 
            // firstNumberText
            // 
            this.firstNumberText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.firstNumberText.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.firstNumberText.ForeColor = System.Drawing.SystemColors.ControlText;
            this.firstNumberText.Location = new System.Drawing.Point(3, 63);
            this.firstNumberText.Name = "firstNumberText";
            this.firstNumberText.Size = new System.Drawing.Size(487, 16);
            this.firstNumberText.TabIndex = 31;
            this.firstNumberText.Text = "Номер первого вопроса:";
            // 
            // lastChangeText
            // 
            this.lastChangeText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lastChangeText.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lastChangeText.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lastChangeText.Location = new System.Drawing.Point(3, 47);
            this.lastChangeText.Name = "lastChangeText";
            this.lastChangeText.Size = new System.Drawing.Size(487, 16);
            this.lastChangeText.TabIndex = 30;
            this.lastChangeText.Text = "Дата изменения:";
            // 
            // creationText
            // 
            this.creationText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.creationText.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.creationText.ForeColor = System.Drawing.SystemColors.ControlText;
            this.creationText.Location = new System.Drawing.Point(3, 31);
            this.creationText.Name = "creationText";
            this.creationText.Size = new System.Drawing.Size(487, 16);
            this.creationText.TabIndex = 29;
            this.creationText.Text = "Дата создания:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(3, 287);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(120, 23);
            this.label13.TabIndex = 30;
            this.label13.Text = "Информация:";
            // 
            // deleteResultButton
            // 
            this.deleteResultButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteResultButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.deleteResultButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteResultButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteResultButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.deleteResultButton.Location = new System.Drawing.Point(3, 157);
            this.deleteResultButton.Name = "deleteResultButton";
            this.deleteResultButton.Size = new System.Drawing.Size(496, 25);
            this.deleteResultButton.TabIndex = 31;
            this.deleteResultButton.Text = "Удалить результат выполнения";
            this.deleteResultButton.UseVisualStyleBackColor = false;
            this.deleteResultButton.Click += new System.EventHandler(this.DeleteResultButtonClick);
            // 
            // ticketsBox
            // 
            this.ticketsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ticketsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ticketsBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ticketsBox.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ticketsBox.FormattingEnabled = true;
            this.ticketsBox.Location = new System.Drawing.Point(70, 191);
            this.ticketsBox.Name = "ticketsBox";
            this.ticketsBox.Size = new System.Drawing.Size(429, 31);
            this.ticketsBox.TabIndex = 23;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(3, 194);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 23);
            this.label14.TabIndex = 32;
            this.label14.Text = "Билет:";
            // 
            // printTaskButton
            // 
            this.printTaskButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.printTaskButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.printTaskButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.printTaskButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.printTaskButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.printTaskButton.Location = new System.Drawing.Point(3, 228);
            this.printTaskButton.Name = "printTaskButton";
            this.printTaskButton.Size = new System.Drawing.Size(496, 25);
            this.printTaskButton.TabIndex = 33;
            this.printTaskButton.Text = "Распечатать задания";
            this.printTaskButton.UseVisualStyleBackColor = false;
            this.printTaskButton.Click += new System.EventHandler(this.PrintTaskButtonClick);
            // 
            // printBlankButton
            // 
            this.printBlankButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.printBlankButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.printBlankButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.printBlankButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.printBlankButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.printBlankButton.Location = new System.Drawing.Point(3, 259);
            this.printBlankButton.Name = "printBlankButton";
            this.printBlankButton.Size = new System.Drawing.Size(496, 25);
            this.printBlankButton.TabIndex = 34;
            this.printBlankButton.Text = "Распечатать бланк";
            this.printBlankButton.UseVisualStyleBackColor = false;
            this.printBlankButton.Click += new System.EventHandler(this.PrintBlankButtonClick);
            // 
            // nameText
            // 
            this.nameText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nameText.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameText.ForeColor = System.Drawing.SystemColors.ControlText;
            this.nameText.Location = new System.Drawing.Point(185, 16);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(326, 26);
            this.nameText.TabIndex = 35;
            this.nameText.Text = "Новый экзамен";
            this.nameText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.resultsList);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.startSessionButton);
            this.panel3.Controls.Add(this.deleteButton);
            this.panel3.Controls.Add(this.changeButton);
            this.panel3.Controls.Add(this.printBlankButton);
            this.panel3.Controls.Add(this.printResultButton);
            this.panel3.Controls.Add(this.printTaskButton);
            this.panel3.Controls.Add(this.deleteResultButton);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.ticketsBox);
            this.panel3.Location = new System.Drawing.Point(3, 48);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(504, 628);
            this.panel3.TabIndex = 36;
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
            this.hider.Size = new System.Drawing.Size(510, 679);
            this.hider.TabIndex = 37;
            // 
            // loaderExamPanel
            // 
            this.loaderExamPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.loaderExamPanel.Controls.Add(this.panel4);
            this.loaderExamPanel.Controls.Add(this.label5);
            this.loaderExamPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loaderExamPanel.Location = new System.Drawing.Point(0, 0);
            this.loaderExamPanel.Name = "loaderExamPanel";
            this.loaderExamPanel.Size = new System.Drawing.Size(510, 679);
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
            this.panel4.Size = new System.Drawing.Size(504, 650);
            this.panel4.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(5, 654);
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
            this.panel6.Size = new System.Drawing.Size(504, 652);
            this.panel6.TabIndex = 42;
            // 
            // infoText
            // 
            this.infoText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.infoText.AutoSize = true;
            this.infoText.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoText.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.infoText.Location = new System.Drawing.Point(3, 654);
            this.infoText.Name = "infoText";
            this.infoText.Size = new System.Drawing.Size(254, 23);
            this.infoText.TabIndex = 23;
            this.infoText.Text = "Выберете экзамен для работы";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "*.smpx";
            this.openFileDialog.FileName = "Новый экзамен";
            this.openFileDialog.Filter = "*.smpx Файлы Экзаменов|*.smpx";
            this.openFileDialog.Title = "Открыть экзамен";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialogFileOk);
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
            this.splitContainer.Panel1MinSize = 370;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.hider);
            this.splitContainer.Panel2.Controls.Add(this.nameText);
            this.splitContainer.Panel2.Controls.Add(this.label3);
            this.splitContainer.Panel2.Controls.Add(this.panel3);
            this.splitContainer.Panel2MinSize = 470;
            this.splitContainer.Size = new System.Drawing.Size(894, 681);
            this.splitContainer.SplitterDistance = 379;
            this.splitContainer.SplitterWidth = 3;
            this.splitContainer.TabIndex = 24;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(894, 681);
            this.Controls.Add(this.splitContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(910, 510);
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Начало работы";
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            this.loaderListPanel.ResumeLayout(false);
            this.loaderListPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.hider.ResumeLayout(false);
            this.hider.PerformLayout();
            this.loaderExamPanel.ResumeLayout(false);
            this.loaderExamPanel.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Label header;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.ListBox examsList;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button startSessionButton;
        private System.Windows.Forms.ListBox resultsList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button printResultButton;
        private System.Windows.Forms.Label creatorText;
        private System.Windows.Forms.Label disciplineText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label descriptionText;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label executionTimeText;
        private System.Windows.Forms.Label firstNumberText;
        private System.Windows.Forms.Label lastChangeText;
        private System.Windows.Forms.Label creationText;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button deleteResultButton;
        private System.Windows.Forms.ComboBox ticketsBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button printTaskButton;
        private System.Windows.Forms.Button printBlankButton;
        private System.Windows.Forms.Label nameText;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel hider;
        private System.Windows.Forms.Label infoText;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Panel loaderExamPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel loaderListPanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label dbInfoLabel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
    }
}