namespace SimplExClient.Controls
{
    partial class OneAnswerQuestionControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.answersDataGrid = new System.Windows.Forms.DataGridView();
            this.IsRight = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Letter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnswerColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.answerButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.answersDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 19);
            this.label5.TabIndex = 70;
            this.label5.Text = "Варианты ответа:";
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox.Location = new System.Drawing.Point(3, 41);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(713, 169);
            this.textBox.TabIndex = 72;
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Location = new System.Drawing.Point(3, 3);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.textBox);
            this.splitContainer.Panel1.Controls.Add(this.label3);
            this.splitContainer.Panel1.Controls.Add(this.label1);
            this.splitContainer.Panel1MinSize = 200;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.AutoScrollMargin = new System.Drawing.Size(5, 5);
            this.splitContainer.Panel2.Controls.Add(this.label5);
            this.splitContainer.Panel2.Controls.Add(this.answersDataGrid);
            this.splitContainer.Size = new System.Drawing.Size(722, 408);
            this.splitContainer.SplitterDistance = 215;
            this.splitContainer.SplitterWidth = 3;
            this.splitContainer.TabIndex = 102;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(-1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(346, 19);
            this.label3.TabIndex = 35;
            this.label3.Text = "Тестовый вопрос с одним правильным ответом";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 19);
            this.label1.TabIndex = 71;
            this.label1.Text = "Текст вопроса:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // answersDataGrid
            // 
            this.answersDataGrid.AllowUserToAddRows = false;
            this.answersDataGrid.AllowUserToDeleteRows = false;
            this.answersDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.answersDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.answersDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.answersDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.answersDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsRight,
            this.Letter,
            this.AnswerColumn});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.answersDataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.answersDataGrid.EnableHeadersVisualStyles = false;
            this.answersDataGrid.Location = new System.Drawing.Point(3, 22);
            this.answersDataGrid.Name = "answersDataGrid";
            this.answersDataGrid.RowHeadersVisible = false;
            this.answersDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.answersDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.answersDataGrid.Size = new System.Drawing.Size(713, 163);
            this.answersDataGrid.TabIndex = 0;
            this.answersDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AnswersDataGridCellContentClick);
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
            this.Letter.MaxInputLength = 327670;
            this.Letter.Name = "Letter";
            this.Letter.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Letter.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AnswerColumn
            // 
            this.AnswerColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AnswerColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.AnswerColumn.Frozen = true;
            this.AnswerColumn.HeaderText = "Ответ";
            this.AnswerColumn.MaxInputLength = 327670;
            this.AnswerColumn.Name = "AnswerColumn";
            this.AnswerColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AnswerColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AnswerColumn.Width = 59;
            // 
            // answerButton
            // 
            this.answerButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.answerButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.answerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.answerButton.Location = new System.Drawing.Point(3, 415);
            this.answerButton.Name = "answerButton";
            this.answerButton.Size = new System.Drawing.Size(722, 23);
            this.answerButton.TabIndex = 103;
            this.answerButton.Text = "Ответить";
            this.answerButton.UseVisualStyleBackColor = false;
            this.answerButton.Click += new System.EventHandler(this.AnswerButtonClick);
            // 
            // OneAnswerQuestionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.answerButton);
            this.Controls.Add(this.splitContainer);
            this.Name = "OneAnswerQuestionControl";
            this.Size = new System.Drawing.Size(730, 445);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.answersDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView answersDataGrid;
        private System.Windows.Forms.Button answerButton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsRight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Letter;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnswerColumn;
    }
}
