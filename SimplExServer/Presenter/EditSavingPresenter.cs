using SimplExModel.Model;
using SimplExServer.Builders;
using SimplExServer.Common;
using SimplExServer.Service;
using SimplExServer.View;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplExServer.Presenter
{
    class EditSavingPresenter : IntegrablePresenter<EditArgumnet, IEditSavingView>
    {
        private bool savingFailed;
        private readonly List<QuestionBuilder> questionBuilders = new List<QuestionBuilder>();
        public EditSavingPresenter(IEditSavingView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.Shown += ViewShown;
            view.Saved += ViewSaved;
            view.SavedAs += ViewSavedAs;
            view.SavedDb += ViewSavedDb;
            view.WatchTask += ViewWatchTask;
            view.WatchKey += ViewWatchKey;
            view.WatchBlank += ViewWatchBlank;
        }

        private async void ViewWatchBlank(IEditSavingView sender)
        {
            try
            {
                Exam exam = GetCheckedExam();
                if (exam == null)
                    return;
                int ticketNumber = sender.CurrentTicket.Instance.TicketNumber;
                Ticket ticket = GetTicket(exam, ticketNumber);
                bool setRightAnswer = sender.SetRightAnswers;
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

        private async void ViewWatchKey(IEditSavingView sender)
        {
            try
            {
                Exam exam = GetCheckedExam();
                if (exam == null)
                    return;
                int ticketNumber = sender.CurrentTicket.Instance.TicketNumber;
                Ticket ticket = GetTicket(exam, ticketNumber);
                await ApplicationController.Run<LoadingContextPresenter<object>, Task<object>>(Task.Run(() =>
                {
                    DocXService.GetInstance().ExamDocXWorker.OpenTask(exam, ticket, true);
                    return LoadingContextPresenter<object>.EmptyObject;
                })).GetTask();
            }
            catch (Exception ex)
            {
                View.ShowError(ex.Message);
            }
        }
        private async void ViewWatchTask(IEditSavingView sender)
        {
            try
            {
                Exam exam = GetCheckedExam();
                if (exam == null)
                    return;
                int ticketNumber = sender.CurrentTicket.Instance.TicketNumber;
                Ticket ticket = GetTicket(exam, ticketNumber);
                await ApplicationController.Run<LoadingContextPresenter<object>, Task<object>>(Task.Run(() =>
                {
                    DocXService.GetInstance().ExamDocXWorker.OpenTask(exam, ticket, false);
                    return LoadingContextPresenter<object>.EmptyObject;
                })).GetTask();
            }
            catch (Exception ex)
            {
                View.ShowError(ex.Message);
            }
        }
        private async void ViewSavedDb(IEditSavingView sender)
        {
            DatabaseService databaseService = DatabaseService.GetInstance();
            if (databaseService.ExamDatabaseWorker == null)
                ApplicationController.Run<LogInDbPresenter, object>(null);
            if (databaseService.ExamDatabaseWorker == null)
            {
                sender.ShowError("Подключение к базе данных не установлено.");
                return;
            }
            ExamsListService examsState = ExamsListService.GetInstance();
            Exam exam = GetCheckedExam();
            if (exam == null)
                return;
            IExamSaver examSaver = new DatabaseExamSaver(null, exam.Name);
            if (await ApplicationController.Run<LoadingContextPresenter<bool>, Task<bool>>(Task.Run(() => examSaver.Save(exam))).GetTask())
            {
                Argument.ExamSaver = examSaver;
                examsState.Add(examSaver);
                IList<string> temp = View.Warnings;
                temp.Add("Сохранено!");
                sender.Warnings = temp;
                sender.AllowSave = true;
                savingFailed = false;
            }
            else
            {
                sender.ShowError($"Непредвиденная ошибка сохранения.{ Environment.NewLine }Ошибка: {examSaver.LastExceptionMessage}");
            }
        }

        private async void ViewSaved(IEditSavingView sender)
        {
            Exam exam = GetCheckedExam();
            if (exam == null)
                return;
            if (await ApplicationController.Run<LoadingContextPresenter<bool>, Task<bool>>(Task.Run(() => Argument.ExamSaver.Save(exam))).GetTask())
            {
                IList<string> temp = View.Warnings;
                temp.Add("Сохранено!");
                sender.Warnings = temp;
            }
            else
            {
                sender.ShowError($"Непредвиденная ошибка сохранения.{ Environment.NewLine }Ошибка: {Argument.ExamSaver.LastExceptionMessage}");
                sender.AllowSave = false;
                savingFailed = true;
            }
        }

        private async void ViewSavedAs(IEditSavingView sender, SaveExamEventArgs e)
        {
            Exam exam = GetCheckedExam();
            if (exam == null)
                return;
            IExamSaver loaded = null;
            ExamsListService examsList = ExamsListService.GetInstance();
            try
            {
                loaded = new FileExamSaver(e.FilePath, exam.Password, exam.Name);
                int index = examsList.ExamSavers.IndexOf(loaded);
                if (index >= 0)
                    loaded = examsList.ExamSavers[index];
            }
            catch
            { }
            if (loaded == null)
                loaded = new FileExamSaver(e.FilePath, exam.Password, exam.Name);
            Argument.ExamSaver = loaded;
            if (await ApplicationController.Run<LoadingContextPresenter<bool>, Task<bool>>(Task.Run(() => Argument.ExamSaver.Save(exam))).GetTask())
            {
                examsList.Add(loaded);
                IList<string> temp = View.Warnings;
                temp.Add("Сохранено!");
                sender.Warnings = temp;
                sender.AllowSave = true;
                savingFailed = false;
            }
            else
                sender.ShowError($"Непредвиденная ошибка сохранения.{ Environment.NewLine }Ошибка: {Argument.ExamSaver.LastExceptionMessage}");
        }

        private void ViewShown(IEditSavingView sender)
        {
            sender.TicketBuiders = Argument.ExamBuilder.TicketBuilders;
            if (sender.TicketBuiders.Count != 0)
                sender.CurrentTicket = sender.TicketBuiders[0];
            if (Argument.ExamSaver == null || savingFailed)
                sender.AllowSave = false;
            else sender.AllowSave = true;
        }
        private Exam GetCheckedExam()
        {
            List<string> warnings = new List<string>();
            if (Argument.ExamBuilder.ThemeBuilders.Count == 0)
            {
                Argument.ExamBuilder.AddTheme("Новая тема");
                View.Warnings = warnings;
                View.ShowError("Экзамен не содержал тем. Сохранение не произошло.");
                return null;
            }
            if (Argument.ExamBuilder.Password == null)
                Argument.ExamBuilder.Password = string.Empty;
            questionBuilders.Clear();
            for (int i = 0; i < Argument.ExamBuilder.TicketBuilders.Count; i++)
            {
                QuestionBuilder[] questionBuilders = Argument.ExamBuilder.TicketBuilders[i].GetQuestionBuilders();
                if (questionBuilders.Length == 0)
                {
                    View.Warnings = warnings;
                    View.ShowError($"Билет '{Argument.ExamBuilder.TicketBuilders[i].TicketName}' не содержал вопросов. Сохранение не произошло.");
                    return null;
                }
                this.questionBuilders.AddRange(questionBuilders);
            }
            for (int i = 0; i < questionBuilders.Count; i++)
            {
                if (questionBuilders[i].ThemeBuilder == null)
                {
                    questionBuilders[i].ThemeBuilder = Argument.ExamBuilder.ThemeBuilders[0];
                    warnings.Add($"Для Вопроса №{questionBuilders[i].QuestionNumber + 1} не была определена тема. Определена первая из списка.");
                }
            }
            View.Warnings = warnings;
            Exam exam = Argument.ExamBuilder.GetBuildedInstance();
            return exam;
        }
        private static Ticket GetTicket(Exam exam, int ticketNumber)
        {
            Ticket ticket = null;
            if (exam.Tickets.Count <= ticketNumber)
                throw new Exception();
            else if (exam.Tickets[ticketNumber].TicketNumber == ticketNumber)
                ticket = exam.Tickets[ticketNumber];
            else
                for (int i = 0; i < exam.Tickets.Count; i++)
                    if (exam.Tickets[i].TicketNumber == ticketNumber)
                    {
                        ticket = exam.Tickets[i];
                        break;
                    }
            if (ticket is null)
                throw new Exception();
            return ticket;
        }
    }
}
