using SimplExServer.Builders;
using SimplExServer.Common;
using SimplExServer.Model;
using SimplExServer.Services;
using SimplExServer.View;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimplExServer.Presenter
{
    class EditSavingPresenter : IntegrablePresenter<EditArgumnet, IEditSavingView>
    {
        public EditSavingPresenter(IEditSavingView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.Shown += ViewShown;
            view.Saved += ViewSaved;
            view.SavedAs += ViewSavedAs;
            view.SavedDb += ViewSavedDb;
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
            IExamSaver examSaver = new DatabaseExamSaver(null, databaseService, exam.Name);
            if (await ApplicationController.Run<LoadingContextPresnter<bool>, Task<bool>>(Task.Run(() => examSaver.Save(exam))).GetTask())
            {
                Argument.ExamSaver = examSaver;
                examsState.Add(examSaver);
                IList<string> temp = View.Warnings;
                temp.Add("Сохранено!");
                sender.Warnings = temp;
                sender.AllowSave = true;
            }
            else
            {
                sender.ShowError($"Непредвиденная ошибка сохранения.");
            }
        }

        private async void ViewSaved(IEditSavingView sender)
        {
            Exam exam = GetCheckedExam();
            if (exam == null)
                return;
            if (await ApplicationController.Run<LoadingContextPresnter<bool>, Task<bool>>(Task.Run(() => Argument.ExamSaver.Save(exam))).GetTask())
            {
                IList<string> temp = View.Warnings;
                Argument.ExamSaver.SaverName = exam.Name;
                temp.Add("Сохранено!");
                sender.Warnings = temp;
            }
            else
            {
                sender.ShowError($"Непредвиденная ошибка сохранения.");
                sender.AllowSave = false;
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
            if (await ApplicationController.Run<LoadingContextPresnter<bool>, Task<bool>>(Task.Run(() => Argument.ExamSaver.Save(exam))).GetTask())
            {
                examsList.Add(loaded);
                IList<string> temp = View.Warnings;
                temp.Add("Сохранено!");
                sender.Warnings = temp;
                sender.AllowSave = true;
            }
            else
                sender.ShowError($"Непредвиденная ошибка сохранения.");
        }

        private void ViewShown(IEditSavingView sender)
        {
            sender.TicketBuiders = Argument.ExamBuilder.TicketBuilders;
            if (sender.TicketBuiders.Count != 0)
                sender.CurrentTicket = sender.TicketBuiders[0];
            if (Argument.ExamSaver == null)
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
            QuestionBuilder[] questionBuilders = Argument.ExamBuilder.GetQuestionBuilders();
            for (int i = 0; i < questionBuilders.Length; i++)
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
    }
}
