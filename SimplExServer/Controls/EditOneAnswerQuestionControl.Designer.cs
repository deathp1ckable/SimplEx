namespace SimplExServer.Controls
{
    partial class EditOneAnswerQuestionControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.answersDataGrid = new System.Windows.Forms.DataGridView();
            this.IsRight = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Letter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Answer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addAnswerButton = new System.Windows.Forms.Button();
            this.deleteAnswerButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.deviderBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pointsUpDown = new System.Windows.Forms.NumericUpDown();
            this.saveButton = new System.Windows.Forms.Button();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.answersDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // answersDataGrid
            // 
            this.answersDataGrid.AllowUserToAddRows = false;
            this.answersDataGrid.AllowUserToDeleteRows = false;
            this.answersDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.answersDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.answersDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.answersDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.answersDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsRight,
            this.Letter,
            this.Answer});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.answersDataGrid.DefaultCellStyle = dataGridViewCellStyle9;
            this.answersDataGrid.EnableHeadersVisualStyles = false;
            this.answersDataGrid.Location = new System.Drawing.Point(3, 30);
            this.answersDataGrid.Name = "answersDataGrid";
            this.answersDataGrid.RowHeadersVisible = false;
            this.answersDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.answersDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.answersDataGrid.Size = new System.Drawing.Size(708, 185);
            this.answersDataGrid.TabIndex = 0;
            this.answersDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AnswersDataGridCellContentClick);
            this.answersDataGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.AnswersDataGridCellValueChanged);
            this.answersDataGrid.SelectionChanged += new System.EventHandler(this.AnswersDataGridSelectionChanged);
            this.answersDataGrid.Resize += new System.EventHandler(this.AnswersDataGridResize);
            // 
            // IsRight
            // 
            this.IsRight.Frozen = true;
            this.IsRight.HeaderText = "";
            this.IsRight.Name = "IsRight";
            this.IsRight.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IsRight.Width = 50;
            // 
            // Letter
            // 
            this.Letter.Frozen = true;
            this.Letter.HeaderText = "Буква";
            this.Letter.MaxInputLength = 1;
            this.Letter.Name = "Letter";
            this.Letter.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Letter.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Answer
            // 
            this.Answer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Answer.DefaultCellStyle = dataGridViewCellStyle8;
            this.Answer.Frozen = true;
            this.Answer.HeaderText = "Ответ";
            this.Answer.MaxInputLength = 327670;
            this.Answer.Name = "Answer";
            this.Answer.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Answer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Answer.Width = 59;
            // 
            // addAnswerButton
            // 
            this.addAnswerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addAnswerButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addAnswerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addAnswerButton.Location = new System.Drawing.Point(3, 221);
            this.addAnswerButton.Name = "addAnswerButton";
            this.addAnswerButton.Size = new System.Drawing.Size(142, 23);
            this.addAnswerButton.TabIndex = 66;
            this.addAnswerButton.Text = "Добавить вариант ответа";
            this.addAnswerButton.UseVisualStyleBackColor = false;
            this.addAnswerButton.Click += new System.EventHandler(this.AddAnswerButtonClick);
            // 
            // deleteAnswerButton
            // 
            this.deleteAnswerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteAnswerButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.deleteAnswerButton.Enabled = false;
            this.deleteAnswerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteAnswerButton.Location = new System.Drawing.Point(151, 221);
            this.deleteAnswerButton.Name = "deleteAnswerButton";
            this.deleteAnswerButton.Size = new System.Drawing.Size(142, 23);
            this.deleteAnswerButton.TabIndex = 67;
            this.deleteAnswerButton.Text = "Удалить вариант ответа";
            this.deleteAnswerButton.UseVisualStyleBackColor = false;
            this.deleteAnswerButton.Click += new System.EventHandler(this.DeleteAnswerButtonClick);
            // 
            // downButton
            // 
            this.downButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.downButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.downButton.Enabled = false;
            this.downButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.downButton.Location = new System.Drawing.Point(641, 221);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(70, 23);
            this.downButton.TabIndex = 69;
            this.downButton.Text = "▼";
            this.downButton.UseVisualStyleBackColor = false;
            this.downButton.Click += new System.EventHandler(this.DownButtonClick);
            // 
            // upButton
            // 
            this.upButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.upButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.upButton.Enabled = false;
            this.upButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.upButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.upButton.Location = new System.Drawing.Point(565, 221);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(70, 23);
            this.upButton.TabIndex = 68;
            this.upButton.Text = "▲";
            this.upButton.UseVisualStyleBackColor = false;
            this.upButton.Click += new System.EventHandler(this.UpButtonClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 19);
            this.label3.TabIndex = 35;
            this.label3.Text = "Настройки вопроса:";
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox.Location = new System.Drawing.Point(3, 47);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(709, 150);
            this.textBox.TabIndex = 72;
            this.textBox.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(-1, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 19);
            this.label1.TabIndex = 71;
            this.label1.Text = "Текст вопроса:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // deviderBox
            // 
            this.deviderBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deviderBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.deviderBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deviderBox.Location = new System.Drawing.Point(131, 203);
            this.deviderBox.Name = "deviderBox";
            this.deviderBox.Size = new System.Drawing.Size(580, 21);
            this.deviderBox.TabIndex = 96;
            this.deviderBox.TextChanged += new System.EventHandler(this.DeviderBoxTextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(9, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 19);
            this.label4.TabIndex = 95;
            this.label4.Text = "Разделитель:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(9, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 19);
            this.label2.TabIndex = 97;
            this.label2.Text = "Балл за вопрос:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pointsUpDown
            // 
            this.pointsUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pointsUpDown.DecimalPlaces = 2;
            this.pointsUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pointsUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.pointsUpDown.Location = new System.Drawing.Point(131, 230);
            this.pointsUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.pointsUpDown.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.pointsUpDown.Name = "pointsUpDown";
            this.pointsUpDown.Size = new System.Drawing.Size(580, 21);
            this.pointsUpDown.TabIndex = 98;
            this.pointsUpDown.ThousandsSeparator = true;
            this.pointsUpDown.ValueChanged += new System.EventHandler(this.PointsUpDownValueChanged);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveButton.Enabled = false;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(5, 537);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(718, 23);
            this.saveButton.TabIndex = 99;
            this.saveButton.Text = "Сохранить вопрос";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Location = new System.Drawing.Point(5, 6);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.textBox);
            this.splitContainer.Panel1.Controls.Add(this.label3);
            this.splitContainer.Panel1.Controls.Add(this.pointsUpDown);
            this.splitContainer.Panel1.Controls.Add(this.label1);
            this.splitContainer.Panel1.Controls.Add(this.label2);
            this.splitContainer.Panel1.Controls.Add(this.label4);
            this.splitContainer.Panel1.Controls.Add(this.deviderBox);
            this.splitContainer.Panel1MinSize = 150;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.AutoScrollMargin = new System.Drawing.Size(5, 5);
            this.splitContainer.Panel2.Controls.Add(this.label5);
            this.splitContainer.Panel2.Controls.Add(this.answersDataGrid);
            this.splitContainer.Panel2.Controls.Add(this.addAnswerButton);
            this.splitContainer.Panel2.Controls.Add(this.downButton);
            this.splitContainer.Panel2.Controls.Add(this.deleteAnswerButton);
            this.splitContainer.Panel2.Controls.Add(this.upButton);
            this.splitContainer.Panel2MinSize = 150;
            this.splitContainer.Size = new System.Drawing.Size(718, 525);
            this.splitContainer.SplitterDistance = 262;
            this.splitContainer.SplitterWidth = 5;
            this.splitContainer.TabIndex = 100;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(-1, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 19);
            this.label5.TabIndex = 70;
            this.label5.Text = "Настройки ответов:";
            // 
            // EditOneAnswerQuestionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.saveButton);
            this.Name = "EditOneAnswerQuestionControl";
            this.Size = new System.Drawing.Size(730, 569);
            ((System.ComponentModel.ISupportInitialize)(this.answersDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointsUpDown)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView answersDataGrid;
        private System.Windows.Forms.Button addAnswerButton;
        private System.Windows.Forms.Button deleteAnswerButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox deviderBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown pointsUpDown;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsRight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Letter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Answer;
    }
}
