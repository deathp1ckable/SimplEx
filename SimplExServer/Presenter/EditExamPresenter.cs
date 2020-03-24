using SimplExServer.Builders;
using SimplExServer.Common;
using SimplExServer.View;
using System.Text.RegularExpressions;
namespace SimplExServer.Presenter
{
    class EditExamPresenter : IntegrablePresenter<ExamBuilder, IEditPropertiesView>
    {
        private static readonly Regex passwordRegex = new Regex("([a-zA-Z0-9]{4,})$");
        public EditExamPresenter(IEditPropertiesView view, IApplicationController applicationController) : base(view, applicationController)
        {
            View.CancelChanges += CancelProperties;
            View.SaveChanges += SaveProperties;
            View.Changed += PropertiesChanged;
        }
        public override void Run(ExamBuilder argumnet)
        {
            Argumnet = argumnet;
            View.ExamName = Argumnet.ExamName;
            View.Discipline = Argumnet.Discipline;
            View.Password = Argumnet.Password;
            View.CreatorName = Argumnet.CreatorName;
            View.CreatorSurname = Argumnet.CreatorSurname;
            View.CreatorPatronimyc = Argumnet.CreatorPatronimyc;
            View.ExaminationTime = Argumnet.ExaminationTime;
            View.FirstNumber = Argumnet.FirstNumber;
            View.Description = Argumnet.Description;
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
            Argumnet.ExamName = sender.ExamName;
            Argumnet.Discipline = sender.Discipline;
            Argumnet.Password = sender.Password;
            Argumnet.CreatorName = sender.CreatorName;
            Argumnet.CreatorSurname = sender.CreatorSurname;
            Argumnet.CreatorPatronimyc = sender.CreatorPatronimyc;
            Argumnet.ExaminationTime = sender.ExaminationTime;
            Argumnet.FirstNumber = sender.FirstNumber;
            Argumnet.Description = sender.Description;

            View.Saved = true;
        }
        private void CancelProperties(IEditPropertiesView sender)
        {

            sender.ExamName = Argumnet.ExamName;
            sender.Description = Argumnet.Discipline;
            sender.Password = Argumnet.Password;
            sender.CreatorName = Argumnet.CreatorName;
            sender.CreatorSurname = Argumnet.CreatorSurname;
            sender.CreatorPatronimyc = Argumnet.CreatorPatronimyc;
            sender.ExaminationTime = Argumnet.ExaminationTime;
            sender.FirstNumber = Argumnet.FirstNumber;
            sender.Description = Argumnet.Description;
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
