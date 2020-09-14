using SimplExClient.View;
using SimplExModel.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimplExClient.Controls
{
    public partial class OneAnswerQuestionControl : UserControl, IOneAnswerQuestionView
    {
        IList<string> answers = new List<string>();
        private string letters = string.Empty;
        private string devider = string.Empty;
        private Answer answer;

        public string QuestionText { set => textBox.Text = value; }
        public string Devider
        {
            set
            {
                devider = value;
                ReloadAnswer();
            }
        }
        public string Letters
        {
            set
            {
                letters = value;
                ReloadAnswer();
            }
        }
        public IList<string> Answers
        {
            set
            {
                answers = value;
                ReloadAnswer();
            }
        }
        public Answer Answer
        {
            get => answer; set
            {
                answer = value;
                ReloadAnswer();
            }
        }

        public event ViewActionHandler<IQuestionControlView> Shown;
        public event ViewActionHandler<IQuestionControlView> Hiden;
        public event ViewActionHandler<IQuestionControlView> Answered;
        public event ViewActionHandler<IQuestionControlView> AnswerChanged;
        public event ViewActionHandler<IQuestionControlView> AnswerCanceled;

        public OneAnswerQuestionControl()
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
        public void Close()
        {
            Dispose();
        }
        public void AskForSaving()
        {
            DialogResult dialogResult = MessageBox.Show("Сохранить ответ?", "Изменения не сохранены", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
                Answered?.Invoke(this);
        }
        private void AnswersDataGridResize(object sender, EventArgs e)
        {
            answersDataGrid.Columns["AnswerColumn"].Width = answersDataGrid.Width - 170;
        }
        private void AnswersDataGridCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            answerButton.Enabled = false;
            if (e.ColumnIndex == 0)
            {
                if (!(bool)answersDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                {
                    answerButton.Enabled = true;
                    for (int i = 0; i < answersDataGrid.Rows.Count; i++)
                        answersDataGrid.Rows[i].Cells["IsRight"].Value = false;
                    answersDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                    answer = new Answer
                    {
                        Content = answersDataGrid.Rows[e.RowIndex].Cells["AnswerColumn"].Value.ToString()
                    };
                    AnswerChanged?.Invoke(this);
                }
                else
                {
                    Answer = null;
                    AnswerCanceled?.Invoke(this);
                }
            }
        }

        private void AnswerButtonClick(object sender, EventArgs e)
        {
            Answer = answer;
            Answered?.Invoke(this);
        }
        private void ReloadAnswer()
        {
            answerButton.Enabled = false;
            answersDataGrid.Rows.Clear();
            for (int i = 0; i < answers.Count; i++)
                answersDataGrid.Rows.Add(false, i < letters.Length ? letters[i].ToString() : "*" + devider, answers[i]);
            for (int i = 0; i < answersDataGrid.Rows.Count; i++)
                answersDataGrid.Rows[i].Cells["IsRight"].Value = false;
            if (answer != null)
            {
                for (int i = 0; i < answersDataGrid.Rows.Count; i++)
                    if (answersDataGrid.Rows[i].Cells["AnswerColumn"].Value.ToString() == answer.Content)
                    {
                        answersDataGrid.Rows[i].Cells["IsRight"].Value = true;
                        answerButton.Enabled = false;
                        break;
                    }
            }
            else
            {
                answerButton.Enabled = false;
            }
            if (answers.Count == 0)
            {
                answerButton.Enabled = false;
            }
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            Answer = null;
            AnswerCanceled?.Invoke(this);
        }
    }
}
