namespace SimplExServer.Controls
{
    partial class ConnectionStatusControl
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label10 = new System.Windows.Forms.Label();
            this.connectionPatronymicBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.connectionSurnameBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.connectionNameBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.statusBox = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.statusHeaderLabel = new System.Windows.Forms.Label();
            this.currentQuestionBox = new System.Windows.Forms.TextBox();
            this.currentQuestionLabel = new System.Windows.Forms.Label();
            this.executedQuestionLabel = new System.Windows.Forms.Label();
            this.executedQuestionBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.violationsList = new System.Windows.Forms.ListBox();
            this.violationLabel = new System.Windows.Forms.Label();
            this.addViolationButton = new System.Windows.Forms.Button();
            this.violationContentBox = new System.Windows.Forms.TextBox();
            this.violationContentLabel = new System.Windows.Forms.Label();
            this.connectionLabel = new System.Windows.Forms.Label();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.openResultButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.chartLabel = new System.Windows.Forms.Label();
            this.executionChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ticketBox = new System.Windows.Forms.TextBox();
            this.markBox = new System.Windows.Forms.TextBox();
            this.markLabel = new System.Windows.Forms.Label();
            this.pointsBox = new System.Windows.Forms.TextBox();
            this.pointsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.executionChart)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(221, 19);
            this.label10.TabIndex = 82;
            this.label10.Text = "Информация о подключении:";
            // 
            // connectionPatronymicBox
            // 
            this.connectionPatronymicBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectionPatronymicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.connectionPatronymicBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.connectionPatronymicBox.Location = new System.Drawing.Point(167, 73);
            this.connectionPatronymicBox.Name = "connectionPatronymicBox";
            this.connectionPatronymicBox.ReadOnly = true;
            this.connectionPatronymicBox.Size = new System.Drawing.Size(549, 21);
            this.connectionPatronymicBox.TabIndex = 81;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(86, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 19);
            this.label8.TabIndex = 80;
            this.label8.Text = "Отчество:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // connectionSurnameBox
            // 
            this.connectionSurnameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectionSurnameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.connectionSurnameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.connectionSurnameBox.Location = new System.Drawing.Point(167, 46);
            this.connectionSurnameBox.Name = "connectionSurnameBox";
            this.connectionSurnameBox.ReadOnly = true;
            this.connectionSurnameBox.Size = new System.Drawing.Size(549, 21);
            this.connectionSurnameBox.TabIndex = 79;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(84, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 19);
            this.label7.TabIndex = 78;
            this.label7.Text = "Фамилия:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // connectionNameBox
            // 
            this.connectionNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectionNameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.connectionNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.connectionNameBox.Location = new System.Drawing.Point(167, 19);
            this.connectionNameBox.Name = "connectionNameBox";
            this.connectionNameBox.ReadOnly = true;
            this.connectionNameBox.Size = new System.Drawing.Size(549, 21);
            this.connectionNameBox.TabIndex = 77;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(119, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 19);
            this.label6.TabIndex = 76;
            this.label6.Text = "Имя:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // statusBox
            // 
            this.statusBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusBox.Location = new System.Drawing.Point(167, 149);
            this.statusBox.Name = "statusBox";
            this.statusBox.ReadOnly = true;
            this.statusBox.Size = new System.Drawing.Size(549, 21);
            this.statusBox.TabIndex = 84;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusLabel.Location = new System.Drawing.Point(105, 149);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(56, 19);
            this.statusLabel.TabIndex = 83;
            this.statusLabel.Text = "Статус:";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // statusHeaderLabel
            // 
            this.statusHeaderLabel.AutoSize = true;
            this.statusHeaderLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusHeaderLabel.Location = new System.Drawing.Point(3, 127);
            this.statusHeaderLabel.Name = "statusHeaderLabel";
            this.statusHeaderLabel.Size = new System.Drawing.Size(187, 19);
            this.statusHeaderLabel.TabIndex = 85;
            this.statusHeaderLabel.Text = "Состояние подключения:";
            // 
            // currentQuestionBox
            // 
            this.currentQuestionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentQuestionBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currentQuestionBox.Enabled = false;
            this.currentQuestionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentQuestionBox.Location = new System.Drawing.Point(167, 176);
            this.currentQuestionBox.Name = "currentQuestionBox";
            this.currentQuestionBox.ReadOnly = true;
            this.currentQuestionBox.Size = new System.Drawing.Size(549, 21);
            this.currentQuestionBox.TabIndex = 87;
            // 
            // currentQuestionLabel
            // 
            this.currentQuestionLabel.AutoSize = true;
            this.currentQuestionLabel.Enabled = false;
            this.currentQuestionLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentQuestionLabel.Location = new System.Drawing.Point(38, 176);
            this.currentQuestionLabel.Name = "currentQuestionLabel";
            this.currentQuestionLabel.Size = new System.Drawing.Size(123, 19);
            this.currentQuestionLabel.TabIndex = 86;
            this.currentQuestionLabel.Text = "Текущий вопрос:";
            this.currentQuestionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // executedQuestionLabel
            // 
            this.executedQuestionLabel.AutoSize = true;
            this.executedQuestionLabel.Enabled = false;
            this.executedQuestionLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.executedQuestionLabel.Location = new System.Drawing.Point(3, 203);
            this.executedQuestionLabel.Name = "executedQuestionLabel";
            this.executedQuestionLabel.Size = new System.Drawing.Size(158, 19);
            this.executedQuestionLabel.TabIndex = 88;
            this.executedQuestionLabel.Text = "Выполнено вопросов:";
            this.executedQuestionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // executedQuestionBox
            // 
            this.executedQuestionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.executedQuestionBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.executedQuestionBox.Enabled = false;
            this.executedQuestionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.executedQuestionBox.Location = new System.Drawing.Point(167, 203);
            this.executedQuestionBox.Name = "executedQuestionBox";
            this.executedQuestionBox.ReadOnly = true;
            this.executedQuestionBox.Size = new System.Drawing.Size(549, 21);
            this.executedQuestionBox.TabIndex = 89;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(108, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 19);
            this.label5.TabIndex = 90;
            this.label5.Text = "Билет:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // violationsList
            // 
            this.violationsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.violationsList.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.violationsList.FormattingEnabled = true;
            this.violationsList.IntegralHeight = false;
            this.violationsList.ItemHeight = 19;
            this.violationsList.Location = new System.Drawing.Point(3, 576);
            this.violationsList.Name = "violationsList";
            this.violationsList.Size = new System.Drawing.Size(713, 80);
            this.violationsList.TabIndex = 92;
            // 
            // violationLabel
            // 
            this.violationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.violationLabel.AutoSize = true;
            this.violationLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.violationLabel.Location = new System.Drawing.Point(3, 554);
            this.violationLabel.Name = "violationLabel";
            this.violationLabel.Size = new System.Drawing.Size(94, 19);
            this.violationLabel.TabIndex = 93;
            this.violationLabel.Text = "Нарушения:";
            // 
            // addViolationButton
            // 
            this.addViolationButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addViolationButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addViolationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addViolationButton.Location = new System.Drawing.Point(3, 689);
            this.addViolationButton.Name = "addViolationButton";
            this.addViolationButton.Size = new System.Drawing.Size(713, 23);
            this.addViolationButton.TabIndex = 94;
            this.addViolationButton.Text = "Добавить нарушение";
            this.addViolationButton.UseVisualStyleBackColor = false;
            this.addViolationButton.Click += new System.EventHandler(this.AddViolationButtonClick);
            // 
            // violationContentBox
            // 
            this.violationContentBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.violationContentBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.violationContentBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.violationContentBox.Location = new System.Drawing.Point(167, 662);
            this.violationContentBox.Name = "violationContentBox";
            this.violationContentBox.Size = new System.Drawing.Size(549, 21);
            this.violationContentBox.TabIndex = 95;
            // 
            // violationContentLabel
            // 
            this.violationContentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.violationContentLabel.AutoSize = true;
            this.violationContentLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.violationContentLabel.Location = new System.Drawing.Point(20, 662);
            this.violationContentLabel.Name = "violationContentLabel";
            this.violationContentLabel.Size = new System.Drawing.Size(141, 19);
            this.violationContentLabel.TabIndex = 96;
            this.violationContentLabel.Text = "Состав нарушения:";
            this.violationContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // connectionLabel
            // 
            this.connectionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.connectionLabel.AutoSize = true;
            this.connectionLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.connectionLabel.Location = new System.Drawing.Point(3, 817);
            this.connectionLabel.Name = "connectionLabel";
            this.connectionLabel.Size = new System.Drawing.Size(209, 19);
            this.connectionLabel.TabIndex = 97;
            this.connectionLabel.Text = "Управление подключением:";
            // 
            // disconnectButton
            // 
            this.disconnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.disconnectButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.disconnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disconnectButton.Location = new System.Drawing.Point(3, 839);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(713, 23);
            this.disconnectButton.TabIndex = 99;
            this.disconnectButton.Text = "Отключить";
            this.disconnectButton.UseVisualStyleBackColor = false;
            this.disconnectButton.Click += new System.EventHandler(this.DisconnectButtonClick);
            // 
            // openResultButton
            // 
            this.openResultButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openResultButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.openResultButton.Enabled = false;
            this.openResultButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openResultButton.Location = new System.Drawing.Point(3, 791);
            this.openResultButton.Name = "openResultButton";
            this.openResultButton.Size = new System.Drawing.Size(713, 23);
            this.openResultButton.TabIndex = 102;
            this.openResultButton.Text = "Просмотреть результат выполнения";
            this.openResultButton.UseVisualStyleBackColor = false;
            this.openResultButton.Click += new System.EventHandler(this.OpenResultButtonClick);
            // 
            // resultLabel
            // 
            this.resultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultLabel.AutoSize = true;
            this.resultLabel.Enabled = false;
            this.resultLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultLabel.Location = new System.Drawing.Point(3, 715);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(171, 19);
            this.resultLabel.TabIndex = 101;
            this.resultLabel.Text = "Результат выполнения:";
            // 
            // chartLabel
            // 
            this.chartLabel.AutoSize = true;
            this.chartLabel.Enabled = false;
            this.chartLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chartLabel.Location = new System.Drawing.Point(3, 227);
            this.chartLabel.Name = "chartLabel";
            this.chartLabel.Size = new System.Drawing.Size(156, 19);
            this.chartLabel.TabIndex = 103;
            this.chartLabel.Text = "График выполнения:";
            // 
            // executionChart
            // 
            this.executionChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.Title = "Хронология";
            chartArea1.AxisY.Title = "Количество выполненных вопросов";
            chartArea1.Name = "chartArea";
            this.executionChart.ChartAreas.Add(chartArea1);
            this.executionChart.Enabled = false;
            this.executionChart.IsSoftShadows = false;
            legend1.Name = "executionSpeedLegend";
            this.executionChart.Legends.Add(legend1);
            this.executionChart.Location = new System.Drawing.Point(3, 249);
            this.executionChart.Name = "executionChart";
            series1.BorderWidth = 4;
            series1.ChartArea = "chartArea";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "executionSpeedLegend";
            series1.LegendText = "График выполнения";
            series1.Name = "executionSeries";
            series2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(31)))), ((int)(((byte)(47)))));
            series2.BorderWidth = 5;
            series2.ChartArea = "chartArea";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series2.Legend = "executionSpeedLegend";
            series2.LegendText = "Нарушения";
            series2.Name = "violationsSeries";
            this.executionChart.Series.Add(series1);
            this.executionChart.Series.Add(series2);
            this.executionChart.Size = new System.Drawing.Size(713, 302);
            this.executionChart.TabIndex = 104;
            // 
            // ticketBox
            // 
            this.ticketBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ticketBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ticketBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ticketBox.Location = new System.Drawing.Point(167, 100);
            this.ticketBox.Name = "ticketBox";
            this.ticketBox.ReadOnly = true;
            this.ticketBox.Size = new System.Drawing.Size(549, 21);
            this.ticketBox.TabIndex = 105;
            // 
            // markBox
            // 
            this.markBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.markBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.markBox.Enabled = false;
            this.markBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.markBox.Location = new System.Drawing.Point(167, 764);
            this.markBox.Name = "markBox";
            this.markBox.ReadOnly = true;
            this.markBox.Size = new System.Drawing.Size(549, 21);
            this.markBox.TabIndex = 109;
            // 
            // markLabel
            // 
            this.markLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.markLabel.AutoSize = true;
            this.markLabel.Enabled = false;
            this.markLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.markLabel.Location = new System.Drawing.Point(96, 764);
            this.markLabel.Name = "markLabel";
            this.markLabel.Size = new System.Drawing.Size(65, 19);
            this.markLabel.TabIndex = 108;
            this.markLabel.Text = "Оценка:";
            this.markLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pointsBox
            // 
            this.pointsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pointsBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pointsBox.Enabled = false;
            this.pointsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pointsBox.Location = new System.Drawing.Point(167, 737);
            this.pointsBox.Name = "pointsBox";
            this.pointsBox.ReadOnly = true;
            this.pointsBox.Size = new System.Drawing.Size(549, 21);
            this.pointsBox.TabIndex = 107;
            // 
            // pointsLabel
            // 
            this.pointsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pointsLabel.AutoSize = true;
            this.pointsLabel.Enabled = false;
            this.pointsLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pointsLabel.Location = new System.Drawing.Point(115, 737);
            this.pointsLabel.Name = "pointsLabel";
            this.pointsLabel.Size = new System.Drawing.Size(46, 19);
            this.pointsLabel.TabIndex = 106;
            this.pointsLabel.Text = "Балл:";
            this.pointsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ConnectionStatusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.markBox);
            this.Controls.Add(this.markLabel);
            this.Controls.Add(this.pointsBox);
            this.Controls.Add(this.pointsLabel);
            this.Controls.Add(this.ticketBox);
            this.Controls.Add(this.executionChart);
            this.Controls.Add(this.chartLabel);
            this.Controls.Add(this.openResultButton);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.connectionLabel);
            this.Controls.Add(this.violationContentLabel);
            this.Controls.Add(this.violationContentBox);
            this.Controls.Add(this.addViolationButton);
            this.Controls.Add(this.violationLabel);
            this.Controls.Add(this.violationsList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.executedQuestionBox);
            this.Controls.Add(this.executedQuestionLabel);
            this.Controls.Add(this.currentQuestionBox);
            this.Controls.Add(this.currentQuestionLabel);
            this.Controls.Add(this.statusHeaderLabel);
            this.Controls.Add(this.statusBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.connectionPatronymicBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.connectionSurnameBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.connectionNameBox);
            this.Controls.Add(this.label6);
            this.Name = "ConnectionStatusControl";
            this.Size = new System.Drawing.Size(721, 867);
            ((System.ComponentModel.ISupportInitialize)(this.executionChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox connectionPatronymicBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox connectionSurnameBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox connectionNameBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox statusBox;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label statusHeaderLabel;
        private System.Windows.Forms.TextBox currentQuestionBox;
        private System.Windows.Forms.Label currentQuestionLabel;
        private System.Windows.Forms.Label executedQuestionLabel;
        private System.Windows.Forms.TextBox executedQuestionBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox violationsList;
        private System.Windows.Forms.Label violationLabel;
        private System.Windows.Forms.Button addViolationButton;
        private System.Windows.Forms.TextBox violationContentBox;
        private System.Windows.Forms.Label violationContentLabel;
        private System.Windows.Forms.Label connectionLabel;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Button openResultButton;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label chartLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart executionChart;
        private System.Windows.Forms.TextBox ticketBox;
        private System.Windows.Forms.TextBox markBox;
        private System.Windows.Forms.Label markLabel;
        private System.Windows.Forms.TextBox pointsBox;
        private System.Windows.Forms.Label pointsLabel;
    }
}
