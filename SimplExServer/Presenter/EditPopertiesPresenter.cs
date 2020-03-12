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
        private void PropertiesChanged()
        {
            View.Saved = false;
        }
        private void SaveProperties()
        {
            if (View.ExamName.Length <= 0)
            {
                View.MessageWrongExamName("Введите название теста.");
                return;
            }
            if (View.Discipline.Length <= 0)
            {
                View.MessageWrongDiscipline("Введите дисциплину.");
                return;
            }
            if (View.CreatorName.Length <= 0)
            {
                View.MessageWrongCreatorName("Введите имя автора.");
                return;
            }
            if (View.CreatorSurname.Length <= 0)
            {
                View.MessageWrongCreatorSurname("Введите фамилию автора.");
                return;
            }
            if (View.CreatorPatronimyc.Length <= 0)
            {
                View.MessageWrongCreatorPatronimyc("Введите отчество автора.");
                return;
            }
            if (View.Password != null)
            {
                if (!passwordRegex.IsMatch(View.Password))
                {
                    View.MessageWrongPassword("Пароль должен быть длиннее 3 символов и состоять из латиницы и цифр.");
                    return;
                }
                if (View.Password != View.RepeatPassword)
                {
                    View.MessageWrongRepeat("Пароли не совпадают.");
                    return;
                }
            }
            exam.ExamName = View.ExamName;
            exam.Discipline = View.Discipline;
            exam.Password = View.Password;
            exam.CreatorName = View.CreatorName;
            exam.CreatorSurname = View.CreatorSurname;
            exam.CreatorPatronimyc = View.CreatorPatronimyc;
            exam.ExaminationTime = View.ExaminationTime;
            exam.FirstNumber = View.FirstNumber;
            exam.Description = View.Description;

            View.Saved = true;
        }
        private void CancelProperties()
        {

            View.ExamName = exam.ExamName;
            View.Description = exam.Discipline;
            View.Password = exam.Password;
            View.CreatorName = exam.CreatorName;
            View.CreatorSurname = exam.CreatorSurname;
            View.CreatorPatronimyc = exam.CreatorPatronimyc;
            View.ExaminationTime = exam.ExaminationTime;
            View.FirstNumber = exam.FirstNumber;
            View.Description = exam.Description;
            if (View.ExamName.Length <= 0)
            {
                View.MessageWrongExamName("Введите название теста.");
                return;
            }
            if (View.Discipline.Length <= 0)
            {
                View.MessageWrongDiscipline("Введите дисциплину.");
                return;
            }
            if (View.CreatorName.Length <= 0)
            {
                View.MessageWrongCreatorName("Введите имя автора.");
                return;
            }
            if (View.CreatorSurname.Length <= 0)
            {
                View.MessageWrongCreatorSurname("Введите фамилию автора.");
                return;
            }
            if (View.CreatorPatronimyc.Length <= 0)
            {
                View.MessageWrongCreatorPatronimyc("Введите отчество автора.");
                return;
            }
            if (View.Password != null)
            {
                if (!passwordRegex.IsMatch(View.Password))
                {
                    View.MessageWrongPassword("Пароль должен быть длиннее 3 символов и состоять из латиницы и цифр.");
                    return;
                }
                if (View.Password != View.RepeatPassword)
                {
                    View.MessageWrongRepeat("Пароли не совпадают.");
                    return;
                }
            }
            View.Saved = true;
        }
    }
}
