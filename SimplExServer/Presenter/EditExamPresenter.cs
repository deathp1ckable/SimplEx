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
            Argument = argumnet;
            View.ExamName = Argument.ExamName;
            View.Discipline = Argument.Discipline;
            View.Password = Argument.Password;
            View.CreatorName = Argument.CreatorName;
            View.CreatorSurname = Argument.CreatorSurname;
            View.CreatorPatronimyc = Argument.CreatorPatronimyc;
            View.ExaminationTime = Argument.ExaminationTime;
            View.FirstNumber = Argument.FirstNumber;
            View.Description = Argument.Description;
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
            Argument.ExamName = sender.ExamName;
            Argument.Discipline = sender.Discipline;
            Argument.Password = sender.Password;
            Argument.CreatorName = sender.CreatorName;
            Argument.CreatorSurname = sender.CreatorSurname;
            Argument.CreatorPatronimyc = sender.CreatorPatronimyc;
            Argument.ExaminationTime = sender.ExaminationTime;
            Argument.FirstNumber = sender.FirstNumber;
            Argument.Description = sender.Description;

            View.Saved = true;
        }
        private void CancelProperties(IEditPropertiesView sender)
        {

            sender.ExamName = Argument.ExamName;
            sender.Description = Argument.Discipline;
            sender.Password = Argument.Password;
            sender.CreatorName = Argument.CreatorName;
            sender.CreatorSurname = Argument.CreatorSurname;
            sender.CreatorPatronimyc = Argument.CreatorPatronimyc;
            sender.ExaminationTime = Argument.ExaminationTime;
            sender.FirstNumber = Argument.FirstNumber;
            sender.Description = Argument.Description;
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
