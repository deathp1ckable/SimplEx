using SimplExServer.Common;
using SimplExServer.Model;
using SimplExServer.View;
using System.Text.RegularExpressions;
namespace SimplExServer.Presenter
{
    class EditPopertiesPresenter : IntegrablePresenter<Exam, IEditPropertiesView>
    {
        Exam exam;
        private static readonly Regex passwordRegex = new Regex("([a-zA-Z0-9]{4,})$");
        public EditPopertiesPresenter(IEditPropertiesView view, IApplicationController applicationController) : base(view, applicationController)
        {
            View.CancelChanges += CancelProperties;
            View.SaveChanges += SaveProperties;
            View.Changed += PropertiesChanged;
        }
        public override void Run(Exam argumnet)
        {
            exam = argumnet;
            View.ExamName = exam.ExamName;
            View.Discipline = exam.Discipline;
            View.Password = exam.Password;
            View.CreatorName = exam.CreatorName;
            View.CreatorSurname = exam.CreatorSurname;
            View.CreatorPatronimyc = exam.CreatorPatronimyc;
            View.ExaminationTime = exam.ExaminationTime;
            View.FirstNumber = exam.FirstNumber;
            View.Description = exam.Description;
        }
        private void PropertiesChanged(IEditPropertiesView sender)
        {
            sender.Saved = false;
        }
        private void SaveProperties(IEditPropertiesView sender)
        {
            if (sender.ExamName.Length <= 0)
            {
                sender.MessageWrongExamName("Введите название теста.");
                return;
            }
            if (sender.Discipline.Length <= 0)
            {
                sender.MessageWrongDiscipline("Введите дисциплину.");
                return;
            }
            if (sender.CreatorName.Length <= 0)
            {
                sender.MessageWrongCreatorName("Введите имя автора.");
                return;
            }
            if (sender.CreatorSurname.Length <= 0)
            {
                sender.MessageWrongCreatorSurname("Введите фамилию автора.");
                return;
            }
            if (sender.CreatorPatronimyc.Length <= 0)
            {
                sender.MessageWrongCreatorPatronimyc("Введите отчество автора.");
                return;
            }
            if (sender.Password != null)
            {
                if (!passwordRegex.IsMatch(sender.Password))
                {
                    sender.MessageWrongPassword("Пароль должен быть длиннее 3 символов и состоять из латиницы и цифр.");
                    return;
                }
                if (View.Password != sender.RepeatPassword)
                {
                    sender.MessageWrongRepeat("Пароли не совпадают.");
                    return;
                }
            }
            exam.ExamName = sender.ExamName;
            exam.Discipline = sender.Discipline;
            exam.Password = sender.Password;
            exam.CreatorName = sender.CreatorName;
            exam.CreatorSurname = sender.CreatorSurname;
            exam.CreatorPatronimyc = sender.CreatorPatronimyc;
            exam.ExaminationTime = sender.ExaminationTime;
            exam.FirstNumber = sender.FirstNumber;
            exam.Description = sender.Description;

            View.Saved = true;
        }
        private void CancelProperties(IEditPropertiesView sender)
        {

            sender.ExamName = exam.ExamName;
            sender.Description = exam.Discipline;
            sender.Password = exam.Password;
            sender.CreatorName = exam.CreatorName;
            sender.CreatorSurname = exam.CreatorSurname;
            sender.CreatorPatronimyc = exam.CreatorPatronimyc;
            sender.ExaminationTime = exam.ExaminationTime;
            sender.FirstNumber = exam.FirstNumber;
            sender.Description = exam.Description;
            if (sender.ExamName.Length <= 0)
            {
                sender.MessageWrongExamName("Введите название теста.");
                return;
            }
            if (sender.Discipline.Length <= 0)
            {
                sender.MessageWrongDiscipline("Введите дисциплину.");
                return;
            }
            if (sender.CreatorName.Length <= 0)
            {
                sender.MessageWrongCreatorName("Введите имя автора.");
                return;
            }
            if (sender.CreatorSurname.Length <= 0)
            {
                sender.MessageWrongCreatorSurname("Введите фамилию автора.");
                return;
            }
            if (sender.CreatorPatronimyc.Length <= 0)
            {
                sender.MessageWrongCreatorPatronimyc("Введите отчество автора.");
                return;
            }
            if (sender.Password != null)
            {
                if (!passwordRegex.IsMatch(sender.Password))
                {
                    sender.MessageWrongPassword("Пароль должен быть длиннее 3 символов и состоять из латиницы и цифр.");
                    return;
                }
                if (sender.Password != sender.RepeatPassword)
                {
                    sender.MessageWrongRepeat("Пароли не совпадают.");
                    return;
                }
            }
            sender.Saved = true;
        }
    }
}
