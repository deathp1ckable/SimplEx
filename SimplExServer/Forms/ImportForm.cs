using SimplExServer.Model;
using SimplExServer.Services;
using SimplExServer.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SimplExServer.Forms
{
    public partial class ImportForm : Form, IImportView
    {
        private IPasswordEnterView passwordEnterView;
        private IList<Question> bufferedQuestions;
        private IList<IExamSaver> examSavers;
        private IList<Question> questions;
        private string currentPath;

        public string SearchText { get => searchBox.Text; set => searchBox.Text = value; }
        public IExamSaver CurrentExamSaver { get => examSavers[examsList.SelectedIndex]; set => examsList.SelectedIndex = examSavers.IndexOf(value); }
        public Question CurrentQuestion { get => questions[questionsList.SelectedIndex]; set => questionsList.SelectedIndex = questions.IndexOf(value); }
        public IList<IExamSaver> ExamSavers
        {
            get => examSavers; set
            {
                examSavers = value;
                examsList.Items.Clear();
                for (int i = 0; i < examSavers.Count; i++)
                    examsList.Items.Add($"Экзамен '{examSavers[i].SaverName}'");
            }
        }
        public IList<Question> Questions
        {
            get => questions; set
            {
                questions = value;
                if (questions == null || questions.Count == 0)
                {
                    hider.Visible = true;
                    searchButton.Enabled = false;
                    return;
                }
                hider.Visible = false;
                questionsList.Items.Clear();
                for (int i = 0; i < questions.Count; i++)
                    questionsList.Items.Add($"Вопрос №{1 + questions[i].QuestionNumber}");
            }
        }
        public IPasswordEnterView PasswordEnterView
        {
            get => passwordEnterView; set
            {
                if (passwordEnterView != null)
                {
                    passwordEnterView.Entered -= PasswordEnterViewEntered;
                    passwordEnterView.Canceled -= PasswordEnterViewCanceled;
                }
                passwordEnterView = value;
                passwordEnterView.Canceled += PasswordEnterViewCanceled;
                passwordEnterView.Entered += PasswordEnterViewEntered;
                passwordEnterView.Hide();
            }
        }
        public bool IsExamLoading { get => loaderExamPanel.Visible; set => loaderExamPanel.Visible = value; }
        public bool IsListLoading { get => loaderListPanel.Visible; set => loaderListPanel.Visible = value; }
        public string DbInfoText { get => dbInfoLabel.Text; set => dbInfoLabel.Text = value; }

        public event ViewActionHandler<IImportView> Imported;
        public event ViewActionHandler<IImportView> Searched;
        public event ViewActionHandler<IImportView> ViewClosed;
        public event ViewActionHandler<IImportView> SelectedExamChanged;
        public event ViewActionHandler<IImportView> ConnectionAsked;
        public event ViewActionHandler<IImportView, OpenExamEventArgs> FileOpened;

        public ImportForm()
        {
            InitializeComponent();
            openFileButton.BackColor = leftPanel.BackColor = Color.FromArgb(171, 31, 47);
            questionContentToolTip.SetToolTip(questionsList, "");
        }
        public new void Show()
        {
            ShowDialog();
        }
        private void PasswordEnterViewCanceled(IPasswordEnterView sender)
        {
            sender.Hide();
        }

        private void PasswordEnterViewEntered(IPasswordEnterView sender)
        {
            sender.Hide();
            FileOpened.Invoke(this, new OpenExamEventArgs(currentPath, sender.Password));
        }

        private void SkipButtonButtonClick(object sender, EventArgs e)
        {
            Close();
            ViewClosed?.Invoke(this);
        }
        private void ImportButtonClick(object sender, EventArgs e)
        {
            if (questionsList.Items.Count > 0)
                Imported?.Invoke(this);
        }
        private void SearchButtonClick(object sender, EventArgs e)
        {
            if (!searchBox.Items.Contains(searchBox.Text))
                searchBox.SelectedIndex = searchBox.Items.Add(searchBox.Text);
            else searchBox.SelectedIndex = searchBox.Items.IndexOf(searchBox.Text);
            cancelButton.Enabled = true;
            bufferedQuestions = questions;
            Searched?.Invoke(this);
        }
        private void ImportQuestionFormFormClosed(object sender, FormClosedEventArgs e)
        {
            ViewClosed?.Invoke(this);
        }
        private void CancelButtonClick(object sender, EventArgs e)
        {
            SearchText = string.Empty;
            cancelButton.Enabled = false;
            Questions = bufferedQuestions;
        }

        private void OpenFileButtonClick(object sender, EventArgs e) => openFileDialog.ShowDialog();

        private void ExamsListMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (examsList.Items.Count > 0)
            {
                SelectedExamChanged?.Invoke(this);
                nameText.Text = $"Экзамен '{CurrentExamSaver.SaverName}'";
            }
        }
        private void OpenFileDialogFileOk(object sender, CancelEventArgs e)
        {
            currentPath = Path.GetFullPath(openFileDialog.FileName);
            passwordEnterView.Password = string.Empty;
            passwordEnterView.Show();
        }
        private void ConnectButtonClick(object sender, EventArgs e)
        {
            ConnectionAsked?.Invoke(this);
        }
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void QuestionsListSelectedIndexChanged(object sender, EventArgs e)
        {
            if (questionsList.SelectedIndex >= 0 && questionsList.SelectedIndex < questionsList.Items.Count)
            {
                Rectangle rectangle = questionsList.GetItemRectangle(questionsList.SelectedIndex);
                questionContentToolTip.Show(CurrentQuestion.ToString(), (Control)sender, rectangle.X + rectangle.Width / 2, rectangle.Y + rectangle.Height / 2, 5000);
            }
        }
        public void Invoke(Action action)
        {
            try
            {
                base.Invoke(action);
            }
            catch { }
        }
    }
}
