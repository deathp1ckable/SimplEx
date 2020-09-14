using SimplExServer.Builders;
using SimplExServer.Common;
using SimplExModel.Model;
using SimplExServer.Service;
using SimplExServer.View;
using System;
using System.Threading.Tasks;
namespace SimplExServer.Presenter
{
    class StartPresenter : Presenter<object, IStartView>
    {
        private IExamSaver currentExamSaver;
        public StartPresenter(IStartView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.SessionStarted += ViewSessionStarted;
            view.ViewShown += ViewViewShown;
            view.ConnectionAsked += ViewConnected;
            view.ExamSelectionChanged += ViewExamChanged;
            view.ExamDeleted += ViewDeleted;
            view.FileOpened += ViewOpened;
            view.DeleteResult += ViewDeleteResult;
            view.ExamEdited += ViewExamEdited;
            view.ExamCreated += ViewExamCreated;
            view.WatchTask += ViewWatchTask;
            view.WatchResult += ViewWatchResult;
            view.WatchBlank += ViewWatchBlank;
            ExamsListService examsList = ExamsListService.GetInstance();
            examsList.ListRefreshed += ExamsListListRefreshed;
            DatabaseService databaseService = DatabaseService.GetInstance();
            databaseService.ConnctionEstablished += DatabaseServiceConnctionEstablished;
            databaseService.ConnctionLosted += DatabaseServiceConnctionLosted;
        }

        private async void ViewWatchBlank(IStartView sender)
        {
            try
            {
                Exam exam = sender.CurrentExam;
                Ticket ticket = sender.CurrentTicket;
                bool setRightAnswer = sender.SetRightAnswer;
                await ApplicationController.Run<LoadingContextPresenter<object>, Task<object>>(Task.Run(() =>
                {
                    DocXService.GetInstance().ExamDocXWorker.OpenBlank(exam, ticket, setRightAnswer);
                    return LoadingContextPresenter<object>.EmptyObject;
                })).GetTask();
            }
            catch (Exception ex)
            {
                View.ShowError(ex.Message);
            }
        }

        private async void ViewWatchResult(IStartView sender)
        {
            try
            {
                Exam exam = sender.CurrentExam;
                ExecutionResult result = sender.CurrentExecutionResult;
                await ApplicationController.Run<LoadingContextPresenter<object>, Task<object>>(Task.Run(() =>
                {
                    DocXService.GetInstance().ExamDocXWorker.OpenResult(exam, result);
                    return LoadingContextPresenter<object>.EmptyObject;
                })).GetTask();
            }
            catch (Exception ex)
            {
                View.ShowError(ex.Message);
            }
        }

        private async void ViewWatchTask(IStartView sender)
        {
            try
            {
                Exam exam = sender.CurrentExam;
                Ticket ticket = sender.CurrentTicket;
                bool setRightAnswer = sender.SetRightAnswer;
                await ApplicationController.Run<LoadingContextPresenter<object>, Task<object>>(Task.Run(() =>
                {
                    DocXService.GetInstance().ExamDocXWorker.OpenTask(exam, ticket, setRightAnswer);
                    return LoadingContextPresenter<object>.EmptyObject;
                })).GetTask();
            }
            catch (Exception ex)
            {
                View.ShowError(ex.Message);
            }
        }

        private void ViewSessionStarted(IStartView sender)
        {
            View.Hide();
            ApplicationController.Run<StartSessionPresenter, StartSessionArgument>(new StartSessionArgument(sender.CurrentExam, currentExamSaver));
            View.Show();
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

        private void ViewExamCreated(IStartView sender)
        {
            View.Hide();
            ApplicationController.Run<EditMainPresenter, EditArgumnet>(new EditArgumnet(null, new ExamBuilder()));
            View.Show();
        }

        private void ViewExamEdited(IStartView sender)
        {
            View.Hide();
            ApplicationController.Run<EditMainPresenter, EditArgumnet>(new EditArgumnet(currentExamSaver, new ExamBuilder(sender.CurrentExam)));
            View.Show();
        }

        private void ViewDeleteResult(IStartView sender)
        {
            sender.RefreshResults();
            if (!currentExamSaver.DeleteResult(sender.CurrentExecutionResult))
            {
                sender.ShowError($"Не удалось удалить результат экзамен. Он был удален из списка. {currentExamSaver.LastExceptionMessage}");
            }
            sender.CurrentExam.ExecutionResults.Remove(sender.CurrentExecutionResult);
            sender.CurrentExam = sender.CurrentExam;
        }

        private async void ViewOpened(IStartView sender, OpenExamEventArgs e)
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
                sender.CurrentExam = exam;
                currentExamSaver = loaded;
            }
            else
            {
                sender.ShowError($"Не удалось открыть экзамен. {loaded.LastExceptionMessage}");
            }
        }
        public override void Run(object argument)
        {
            View.DbInfoText = "Не удалось подключится к базе данных.";
            ApplicationController.Run<LogInDbPresenter, object>(null);
            View.PasswordEnterView = ApplicationController.Run<PasswordEnterPresenter, object>(null).View;
            View.Show();
            if (DatabaseService.GetInstance().ExamDatabaseWorker != null)
                View.DbInfoText = "Подключение к базе данных установлено.";
        }
        private async void ViewDeleted(IStartView sender)
        {
            ExamsListService examsList = ExamsListService.GetInstance();
            if (!await Task.Run(() => currentExamSaver.Delete()))
                sender.ShowError("Не удалось удалить экзамен из его расположения.\nОн удален из списка.");
            examsList.Remove(currentExamSaver);
            currentExamSaver = null;
        }

        private async void ViewExamChanged(IStartView sender)
        {
            if (!ReferenceEquals(sender.CurrentExamSaver, currentExamSaver))
            {
                sender.IsExamLoading = true;
                ExamsListService examsList = ExamsListService.GetInstance();
                IExamSaver saver = sender.CurrentExamSaver;
                Exam exam = await ApplicationController.Run<LoadingContextPresenter<Exam>, Task<Exam>>(Task.Run(() => saver.GetExam())).GetTask();
                if (exam == null)
                {
                    sender.ShowError($"Не удалось загрузить экзамен.\nОн был удален из списка.{saver.LastExceptionMessage}");
                    try
                    {
                        examsList.Remove(sender.CurrentExamSaver);
                    }
                    catch { }
                    currentExamSaver = null;
                    sender.IsExamLoading = false;
                    return;
                }
                else
                {
                    currentExamSaver = sender.CurrentExamSaver;
                    sender.CurrentExam = exam;
                    sender.IsExamLoading = false;
                }
            }
        }
        private void ViewConnected(IStartView sender)
        {
            currentExamSaver = null;
            ApplicationController.Run<LogInDbPresenter, object>(null);
            if (DatabaseService.GetInstance().ExamDatabaseWorker == null)
                View.DbInfoText = "Не удалось подключится к базе данных.";
            else
                View.DbInfoText = "Подключение к базе данных установлено.";
        }

        private void ViewViewShown(IStartView sender)
        {
            sender.IsListLoading = true;
            currentExamSaver = null;
            sender.ExamSavers = ExamsListService.GetInstance().ExamSavers;
            sender.IsListLoading = false;
            SessionService sessionService = SessionService.GetInstance();
            if (sessionService.Session != null)
            {
                sessionService.Session.Abort();
                sessionService.Session = null;
            }
        }
    }
}
