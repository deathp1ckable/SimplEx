using SimplExServer.View;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimplExServer.Controls
{
    public partial class EditOneAnswerQuestionControl : UserControl, IEditOneAnswerQuestionView
    {
        public string QuestionText { get => textBox.Text; set => textBox.Text = value; }
        public string Devider { get => deviderBox.Text; set => deviderBox.Text = value; }
        public string Letters
        {
            get
            {
                string result = string.Empty;
                for (int i = 0; i < answersDataGrid.Rows.Count; i++)
                    result += answersDataGrid.Rows[i].Cells["Letter"].Value;
                return result;
            }

            set
            {
                for (int i = 0; i < answersDataGrid.Rows.Count; i++)
                    answersDataGrid.Rows[i].Cells["Letter"].Value = value[i];
            }
        }
        public double Points { get => (double)pointsUpDown.Value; set => pointsUpDown.Value = (decimal)value; }
        public IList<string> Answers
        {
            get
            {
                List<string> result = new List<string>();
                for (int i = 0; i < answersDataGrid.Rows.Count; i++)
                    result.Add(answersDataGrid.Rows[i].Cells["Answer"].Value?.ToString() ?? string.Empty);
                return result;
            }
            set
            {
                answersDataGrid.Rows.Clear();
                for (int i = 0; i < value.Count; i++)
                    answersDataGrid.Rows.Add(false, "А", value[i]);
            }
        }
        public int RightAnswerIndex
        {
            get
            {
                for (int i = 0; i < answersDataGrid.Rows.Count; i++)
                    if ((bool)answersDataGrid.Rows[i].Cells["IsRight"].Value)
                        return i;
                return 0;
            }
            set
            {
                for (int i = 0; i < answersDataGrid.Rows.Count; i++)
                    answersDataGrid.Rows[i].Cells["IsRight"].Value = false;
                if (answersDataGrid.Rows.Count > 0)
                    answersDataGrid.Rows[value].Cells["IsRight"].Value = true;
            }
        }

        public event ViewActionHandler<IEditOneAnswerQuestionView> Saved;
        public event ViewActionHandler<IEditOneAnswerQuestionView> Changed;
        public event ViewActionHandler<IEditOneAnswerQuestionView> Shown;
        public event ViewActionHandler<IEditOneAnswerQuestionView> Hiden;

        public EditOneAnswerQuestionControl()
        {
            InitializeComponent();
        }
        public new void Show()
        {
            base.Show();
            Shown?.Invoke(this);
        }
        public new void Hide()
        {
            base.Hide();
            Hiden?.Invoke(this);
        }
        public void AskForSaving()
        {
            saveButton.Enabled = false;
            if (answersDataGrid.Rows.Count == 0)
                AddAnswerButtonClick(null, null);
            DialogResult dialogResult = MessageBox.Show("Сохранить вопроc?", "Изменения не сохранены", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
                Saved?.Invoke(this);
        }

        public void Close() => Dispose();

        private void AddAnswerButtonClick(object sender, EventArgs e)
        {
            bool isRight = false;
            if (answersDataGrid.Rows.Count == 0)
                isRight = true;
            answersDataGrid.Rows.Add(isRight, "A", "Новый Ответ " + (answersDataGrid.Rows.Count + 1));
            saveButton.Enabled = true;
            RecheckMovers();
            Changed?.Invoke(this);
        }

        private void DeleteAnswerButtonClick(object sender, EventArgs e)
        {
            if ((bool)answersDataGrid.CurrentRow.Cells["IsRight"].Value)
                if (answersDataGrid.Rows.Count - 1 > 0)
                    answersDataGrid.Rows[0].Cells["IsRight"].Value = true;
                else
                    deleteAnswerButton.Enabled = false;
            saveButton.Enabled = true;
            answersDataGrid.Rows.Remove(answersDataGrid.CurrentRow);
            RecheckMovers();
            Changed?.Invoke(this);
        }

        private void PointsUpDownValueChanged(object sender, EventArgs e)
        {
            saveButton.Enabled = true;
            Changed?.Invoke(this);
        }

        private void DeviderBoxTextChanged(object sender, EventArgs e)
        {
            saveButton.Enabled = true;
            Changed?.Invoke(this);
        }

        private void UpButtonClick(object sender, EventArgs e)
        {
            int index = answersDataGrid.CurrentRow.Index;
            DataGridViewRow temp = answersDataGrid.Rows[answersDataGrid.CurrentRow.Index - 1];
            answersDataGrid.Rows.Remove(temp);
            answersDataGrid.Rows.Insert(index, temp);
            RecheckMovers();
            Changed?.Invoke(this);
        }

        private void DownButtonClick(object sender, EventArgs e)
        {
            int index = answersDataGrid.CurrentRow.Index;
            DataGridViewRow temp = answersDataGrid.Rows[answersDataGrid.CurrentRow.Index + 1];
            answersDataGrid.Rows.Remove(temp);
            answersDataGrid.Rows.Insert(index, temp);
            RecheckMovers();
            Changed?.Invoke(this);
        }
        private void SaveButtonClick(object sender, EventArgs e)
        {
            try
            { 
                RightAnswerIndex = RightAnswerIndex; 
            }
            catch (Exception)
            {
                RightAnswerIndex = 0; 
            }
            saveButton.Enabled = false;
            Saved?.Invoke(this);
        }

        private void TextBoxTextChanged(object sender, EventArgs e)
        {
            saveButton.Enabled = true;
            Changed?.Invoke(this);
        }

        private void AnswersDataGridSelectionChanged(object sender, EventArgs e) => RecheckMovers();
        private void RecheckMovers()
        {
            if (answersDataGrid.CurrentRow != null)
            {
                deleteAnswerButton.Enabled = true;
                if (answersDataGrid.CurrentRow.Index > 0)
                    upButton.Enabled = true;
                else
                    upButton.Enabled = false;
                if (answersDataGrid.CurrentRow.Index < answersDataGrid.Rows.Count - 1)
                    downButton.Enabled = true;
                else
                    downButton.Enabled = false;
            }
            else
            {
                deleteAnswerButton.Enabled = false;
                upButton.Enabled = false;
                downButton.Enabled = false;
            }
        }

        private void AnswersDataGridCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (!(bool)answersDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                {
                    for (int i = 0; i < answersDataGrid.Rows.Count; i++)
                        answersDataGrid.Rows[i].Cells["IsRight"].Value = false;
                    answersDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                }
            }
        }

        private void AnswersDataGridResize(object sender, EventArgs e)
        {
            answersDataGrid.Columns["Answer"].Width = answersDataGrid.Width - 170;
        }

        private void AnswersDataGridCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                if (e.ColumnIndex == 1)
                    if (answersDataGrid.Rows[e.RowIndex].Cells[1].Value == null || answersDataGrid.Rows[e.RowIndex].Cells[1].Value.ToString().Length == 0)
                        answersDataGrid.Rows[e.RowIndex].Cells[1].Value = "A";
        }
    }
}
