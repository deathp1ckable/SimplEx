using SimplExServer.Common;
using SimplExModel.Model;
using SimplExServer.Service;
using SimplExServer.View;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SimplExServer.Presenter
{
    class ImportPresenter : Presenter<Action<Question>, IImportView>
    {
        private IExamSaver currentExamSaver;
        public ImportPresenter(IImportView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.ViewShown += ViewViewShown;  
            view.ConnectionAsked += ViewConnectionAsked;
            view.FileOpened += ViewFileOpened;
            view.Searched += ViewSearched;
            view.SelectedExamChanged += ViewSelectedExamChanged;
            view.Imported += ViewImported;
            ExamsListService examsList = ExamsListService.GetInstance();
            examsList.ListRefreshed += ExamsListListRefreshed;
            DatabaseService databaseService = DatabaseService.GetInstance();
            databaseService.ConnctionEstablished += DatabaseServiceConnctionEstablished;
            databaseService.ConnctionLosted += DatabaseServiceConnctionLosted;
        }

        private void ViewViewShown(IImportView sender)
        {
            DatabaseService databaseService = DatabaseService.GetInstance();
            if (databaseService.ExamDatabaseWorker == null)
                sender.DbInfoText = "Не удалось подключится к базе данных.";
            else
                sender.DbInfoText = "Подключение к базе данных установлено.";
        }

        private void DatabaseServiceConnctionLosted(object sender, EventArgs e)
        {
            View.Invoke(() => View.DbInfoText = "Не удалось подключится к базе данных.");
        }

        private void DatabaseServiceConnctionEstablished(object sender, EventArgs e)
        {
            View.Invoke(() => View.DbInfoText = "Подключение к базе данных установлено.");
        }

        private void ExamsListListRefreshed(object sender, EventArgs e)
        {
            View.Invoke(() =>
            {
                View.IsListLoading = true;
                View.ExamSavers = (sender as ExamsListService).ExamSavers;
                View.IsListLoading = false;
            });
        }

        public override void Run(Action<Question> argument)
        {
            Argument = argument;
            View.PasswordEnterView = ApplicationController.Run<PasswordEnterPresenter, object>(null).View;
            LoadExamsList(View);
            View.Show();
        }

        private void ViewImported(IImportView sender)
        {
            Argument(sender.CurrentQuestion);
            View.Close();
        }

        private async void ViewSelectedExamChanged(IImportView sender)
        {
            if (!ReferenceEquals(sender.CurrentExamSaver, currentExamSaver))
            {
                sender.IsExamLoading = true;
                sender.IsExamLoading = true;
                ExamsListService examsList = ExamsListService.GetInstance();
                IExamSaver saver = sender.CurrentExamSaver;
                Exam exam = await Task.Run(() => saver.GetExam());
                if (exam == null)
                {
                    sender.ShowError("Не удалось загрузить экзамен.\nОн был удален из списка.");
                    examsList.Remove(sender.CurrentExamSaver);
                    currentExamSaver = null;
                    sender.IsExamLoading = false;
                    return;
                }
                else
                {
                    currentExamSaver = sender.CurrentExamSaver;
                    List<Question> questions = new List<Question>();
                    for (int i = 0; i < exam.Tickets.Count; i++)
                        questions.AddRange(exam.Tickets[i].GetQuestions());
                    sender.Questions = questions;
                    sender.IsExamLoading = false;
                }
            }
        }

        private void ViewSearched(IImportView sender)
        {
            List<Question> questions = new List<Question>();
            for (int i = 0; i < sender.Questions.Count; i++)
                if (sender.Questions[i].ToString().Contains(sender.SearchText))
                    questions.Add(sender.Questions[i]);
            sender.Questions = questions;
        }

        private void ViewConnectionAsked(IImportView sender)
        {
            sender.DbInfoText = "Не удалось подключится к базе данных.";
            ApplicationController.Run<LogInDbPresenter, object>(null);
            LoadExamsList(sender);
        }
        private async void ViewFileOpened(IImportView sender, OpenExamEventArgs e)
        {
            Exam exam = null;
            IExamSaver loaded = null;
            ExamsListService examsList = ExamsListService.GetInstance();
            try
            {
                loaded = new FileExamSaver(e.FilePath, e.Password, sender.CurrentExamSaver.SaverName);
                int index = examsList.ExamSavers.IndexOf(loaded);
                if (index >= 0)
                {
                    sender.CurrentExamSaver = examsList.ExamSavers[index];
                    currentExamSaver = examsList.ExamSavers[index];
                    return;
                }
            }
            catch
            { }
            loaded = new FileExamSaver(e.FilePath, e.Password, "");
            exam = await Task.Run(() => loaded.GetExam());
            if (exam != null)
            {
                loaded = new FileExamSaver(e.FilePath, e.Password, exam.Name);
                examsList.Add(loaded);
                List<Question> questions = new List<Question>();
                for (int i = 0; i < exam.Tickets.Count; i++)
                    questions.AddRange(exam.Tickets[i].GetQuestions());
                sender.Questions = questions;
                currentExamSaver = loaded;
            }
            else
            {
                sender.ShowError("Не удалось открыть экзамен.");
            }
        }
        private void LoadExamsList(IImportView view)
        {
            view.IsListLoading = true;
            currentExamSaver = null;
            view.ExamSavers = ExamsListService.GetInstance().ExamSavers;
            view.IsListLoading = false;
        }
    }
}
