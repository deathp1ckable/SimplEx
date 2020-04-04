using SimplExServer.Model;
using SimplExServer.Services;
using SimplExServer.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SimplExServer
{
    public partial class StartForm : Form, IStartView
    {
        private string currentPath;
        private Exam exam;
        private ApplicationContext context;
        private IList<ExamInfo> examInfos;
        private IPasswordEnterView passwordEnterView;
        public ExamInfo CurrentExamInfo { get => examInfos[examsList.SelectedIndex]; set => examsList.SelectedIndex = examInfos.IndexOf(value); }
        public Ticket CurrentTicket { get => exam.Tickets[ticketsBox.SelectedIndex]; set => ticketsBox.SelectedIndex = exam.Tickets.IndexOf(value); }
        public ExecutionResult CurrentExecutionResult { get => exam.ExecutionResults[resultsList.SelectedIndex]; set => resultsList.SelectedIndex = exam.ExecutionResults.IndexOf(value); }
        public IList<ExamInfo> ExamInfos
        {
            get => examInfos;
            set
            {
                examInfos = value;
                examsList.Items.Clear();
                for (int i = 0; i < examInfos.Count; i++)
                    examsList.Items.Add($"Экзамен '{examInfos[i].ExamName}'");
                if (examInfos.Count == 0)
                    examsList.Items.Add($"Список пуст.");
                hider.Visible = true;
                infoText.Text = "Выберете экзамен для работы";
            }
        }
        public Exam CurrentExam
        {
            get => exam;
            set
            {
                exam = value;
                if (exam == null)
                {
                    hider.Visible = true;
                    return;
                }
                hider.Visible = false;
                nameText.Text = $"Экзамен '{exam.Name}'";
                authorText.Text = $"Имя автора: {exam.CreatorSurname} {exam.CreatorName} {exam.CreatorPatronimyc}";
                disciplineText.Text = $"Дисциплина: {exam.Discipline}";
                descriptionText.Text = $"{exam.Description}";
                creationText.Text = $"Дата создания: {exam.CreationDate}";
                lastChangeText.Text = $"Дата изменнения: {exam.LastChangeDate}";
                firstNumberText.Text = $"Номер первого вопроса: {exam.FirstNumber}";
                executionTimeText.Text = $"Время выполнения: {exam.Time}";
                ticketsBox.Items.Clear();
                RefreshTickets();
                RefreshResults();
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

        public event ViewActionHandler<IStartView, OpenExamEventArgs> FileOpened;
        public event ViewActionHandler<IStartView> PrintResult;
        public event ViewActionHandler<IStartView> DeleteResult;
        public event ViewActionHandler<IStartView> PrintTask;
        public event ViewActionHandler<IStartView> PrintBlank;
        public event ViewActionHandler<IStartView> SessionStarted;
        public event ViewActionHandler<IStartView> ExamEdited;
        public event ViewActionHandler<IStartView> ExamDeleted;
        public event ViewActionHandler<IStartView> ConnectionAsked;
        public event ViewActionHandler<IStartView> ExamCreated;
        public event ViewActionHandler<IStartView> ViewShown;
        public event ViewActionHandler<IStartView> ViewHiden;
        public event ViewActionHandler<IStartView> ExamSelectionChanged;

        public StartForm(ApplicationContext context)
        {
            InitializeComponent();
            rightPanel.BackColor = Color.FromArgb(171, 31, 47);
            this.context = context;
        }
        private void PasswordEnterViewEntered(IPasswordEnterView sender)
        {
            sender.Hide();
            FileOpened.Invoke(this, new OpenExamEventArgs(currentPath, sender.Password));
        }
        private void PasswordEnterViewCanceled(IPasswordEnterView sender)
        {
            sender.Hide();
        }
        public new void Show()
        {
            context.MainForm = this;
            ViewShown?.Invoke(this);
            base.Show();
        }
        public new void Hide()
        {
            ViewHiden?.Invoke(this);
            base.Hide();
        }
        public void ShowError(string message) => MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void ConnectButtonClick(object sender, EventArgs e)
        {
            ConnectionAsked?.Invoke(this);
        }

        private void ExamsListMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (examsList.Items.Count > 0 && examsList.Items[0].ToString() != "Список пуст.")
            {
                ExamSelectionChanged?.Invoke(this);
            }
        }
        private void DeleteButtonClick(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Удалить экзамен?", "Удаление экзамена", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                hider.Visible = true;
                if (exam != null)
                    ExamDeleted?.Invoke(this);
            }
        }
        private void ChangeButtonClick(object sender, EventArgs e)
        {
            if (exam != null)
                ExamEdited?.Invoke(this);
        }
        private void StartSessionButtonClick(object sender, EventArgs e)
        {
            if (exam != null)
                SessionStarted?.Invoke(this);
        }
        private void PrintBlankButtonClick(object sender, EventArgs e)
        {
            if (ticketsBox.Items.Count > 0)
                PrintBlank?.Invoke(this);
        }
        private void PrintTaskButtonClick(object sender, EventArgs e)
        {
            if (ticketsBox.Items.Count > 0)
                PrintTask?.Invoke(this);
        }
        private void DeleteResultButtonClick(object sender, EventArgs e)
        {
            if (resultsList.Items.Count > 0)
                PrintResult?.Invoke(this);
            hider.Visible = true;
        }
        private void PrintResultClick(object sender, EventArgs e)
        {
            if (resultsList.Items.Count > 0)
                DeleteResult?.Invoke(this);
        }
        private void OpenFileButtonClick(object sender, EventArgs e) => openFileDialog.ShowDialog();
        private void OpenFileDialogFileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            currentPath = Path.GetFullPath(openFileDialog.FileName);
            passwordEnterView.Password = string.Empty;
            passwordEnterView.Show();
        }

        private void CreateButtonClick(object sender, EventArgs e) => ExamCreated?.Invoke(this);

        public void RefreshTickets()
        {
            for (int i = 0; i < exam.Tickets.Count; i++)
                ticketsBox.Items.Add($"Билет '{exam.Tickets[i].TicketName}'");

            if (exam.Tickets.Count == 0)
            {
                printBlankButton.Enabled = false;
                printTaskButton.Enabled = false;
                ticketsBox.Items.Clear();
                resultsList.Items.Add("Нет билетов.");
            }
            else
            {
                printBlankButton.Enabled = true;
                printTaskButton.Enabled = true;
                ticketsBox.SelectedIndex = 0;
            }
        }
        public void RefreshResults()
        {
            for (int i = 0; i < exam.ExecutionResults.Count; i++)
                ticketsBox.Items.Add($"Резльтат выполнения.{exam.ExecutionResults[i].ExecutorSurname} {exam.ExecutionResults[i].ExecutorName} {exam.ExecutionResults[i].ExecutorPatronimyc}.");
            if (exam.ExecutionResults.Count == 0)
            {
                deleteResultButton.Enabled = false;
                printResultButton.Enabled = false;
                resultsList.Items.Clear();
                resultsList.Items.Add("Нет результатов.");
            }
            else
            {
                deleteResultButton.Enabled = true;
                printResultButton.Enabled = true;
                resultsList.SelectedIndex = 0;
            }
        }
    }
}
