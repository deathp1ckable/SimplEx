using SimplExServer.Builders;
using SimplExServer.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SimplExServer.Controls
{
    public partial class EditTicketControl : UserControl, IEditTicketView
    {
        private IList<QuestionBuilder> questions;
        public QuestionBuilder CurrentQuestion { get => questions[questionsList.SelectedIndex]; }
        public IList<QuestionBuilder> Questions
        {
            get => questions;
            set
            {
                questions = value;
                questionsList.Items.Clear();
                for (int i = 0; i < questions.Count; i++)
                    questionsList.Items.Add($"Вопрос №{1 + questions[i].QuestionNumber}");
            }
        }
        public string TicketName { get => ticketBox.Text; set => ticketBox.Text = value; }
        public int GroupsCount { set => groupCountLabel.Text = "Количество групп вопросов: " + value; }
        public int QuestionsCount { set => questionsCountLabel.Text = "Количество вопросов: " + value; }

        public event ViewActionHandler<IEditTicketView> GroupAdded;
        public event ViewActionHandler<IEditTicketView> Deleted;
        public event ViewActionHandler<IEditTicketView> Saved;
        public event ViewActionHandler<IEditTicketView> QuestionWatched;
        public event ViewActionHandler<IEditTicketView> Changed;
        public event ViewActionHandler<IEditTicketView> Shown;
        public event ViewActionHandler<IEditTicketView> Hiden;

        public EditTicketControl()
        {
            InitializeComponent();
            questionContentToolTip.SetToolTip(questionsList, "");
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
            DialogResult dialogResult = MessageBox.Show("Сохранить билет?", "Изменения не сохранены", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
                Saved?.Invoke(this);
        }

        public void Close() => Dispose();
        private void DeleteButtonClick(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Удалить билет?", "Удаление билета", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
                Deleted?.Invoke(this);
        }
        private void WatchButtonClick(object sender, EventArgs e) => QuestionWatched?.Invoke(this);
        private void AddGroupButtonClick(object sender, EventArgs e) => GroupAdded?.Invoke(this);
        private void UpButtonClick(object sender, EventArgs e)
        {
            QuestionBuilder temp = CurrentQuestion;
            questions[questionsList.SelectedIndex] = questions[questionsList.SelectedIndex - 1];
            questions[questionsList.SelectedIndex - 1] = temp;
            string tempText = questionsList.SelectedItem.ToString();
            questionsList.Items[questionsList.SelectedIndex] = questionsList.Items[questionsList.SelectedIndex - 1];
            questionsList.Items[questionsList.SelectedIndex - 1] = tempText;
            questionsList.SelectedIndex -= 1;
            Changed?.Invoke(this);
            RecheckSelection();
        }
        private void DownButtonClick(object sender, EventArgs e)
        {
            QuestionBuilder temp = CurrentQuestion;
            questions[questionsList.SelectedIndex] = questions[questionsList.SelectedIndex + 1];
            questions[questionsList.SelectedIndex + 1] = temp;
            string tempText = questionsList.SelectedItem.ToString();
            questionsList.Items[questionsList.SelectedIndex] = questionsList.Items[questionsList.SelectedIndex + 1];
            questionsList.Items[questionsList.SelectedIndex + 1] = tempText;
            questionsList.SelectedIndex += 1;
            Changed?.Invoke(this);
            RecheckSelection();
        }

        private void QuestionsListSelectedIndexChanged(object sender, EventArgs e)
        {
            RecheckSelection();
            if (questionsList.SelectedIndex >= 0 && questionsList.SelectedIndex < questionsList.Items.Count)
            {
                Rectangle rectangle = questionsList.GetItemRectangle(questionsList.SelectedIndex);
                questionContentToolTip.Show(CurrentQuestion.ToString(), (Control)sender, rectangle.X + rectangle.Width / 2, rectangle.Y + rectangle.Height / 2, 5000);
            }
        }

        private void RecheckSelection()
        {
            if (questionsList.Items.Count > 0)
                watchButton.Enabled = true;
            if (questionsList.SelectedIndex > 0 && questionsList.Items.Count > 0)
                upButton.Enabled = true;
            else
                upButton.Enabled = false;
            if (questionsList.SelectedIndex < questions.Count - 1)
                downButton.Enabled = true;
            else
                downButton.Enabled = false;
        }
        private void TicketBoxTextChanged(object sender, EventArgs e) => Changed?.Invoke(this);
        private void SaveButtonClick(object sender, EventArgs e) => Saved?.Invoke(this);
    }
}
