using SimplExModel.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SimplExServer.Builders
{
    public class ExamBuilder : Builder<Exam>
    {
        private readonly List<ThemeBuilder> themeBuilders = new List<ThemeBuilder>();
        private readonly List<TicketBuilder> ticketBuilders = new List<TicketBuilder>();
        private MarkSystemBuilder markSystemBuilder;

        public string ExamName { get; set; }
        public string Discipline { get; set; }
        public string Password { get; set; }
        public string CreatorName { get; set; }
        public string CreatorSurname { get; set; }
        public string CreatorPatronymic { get; set; }
        public double ExaminationTime { get; set; }
        public int FirstNumber { get; set; }
        public string Description { get; set; }
        public DateTime? CreationDate { get; private set; }
        public DateTime? LastChangeDate { get; private set; }
        public ReadOnlyCollection<ThemeBuilder> ThemeBuilders { get; private set; }
        public ReadOnlyCollection<TicketBuilder> TicketBuilders { get; private set; }
        public MarkSystemBuilder MarkSystemBuilder
        {
            get => markSystemBuilder;
            set
            {
                markSystemBuilder = value;
                if (markSystemBuilder == null)
                    throw new ArgumentNullException(nameof(value));
            }
        }

        public ExamBuilder(Exam instance)
        {
            ThemeBuilders = new ReadOnlyCollection<ThemeBuilder>(themeBuilders);
            TicketBuilders = new ReadOnlyCollection<TicketBuilder>(ticketBuilders);
            Load(instance);
        }
        public ExamBuilder() : this(new Exam()) { }

        public void SetMarkSystem(MarkSystem markSystem) => MarkSystemBuilder = MarkSystemBuilder.CreateBuilder((MarkSystem)markSystem.Clone(), this);

        public ThemeBuilder AddTheme(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            Theme theme = new Theme() { ThemeName = name };
            ThemeBuilder result = new ThemeBuilder(theme, this);
            themeBuilders.Add(result);
            return result;
        }
        public ThemeBuilder AddTheme(Theme theme)
        {
            if (theme == null)
                throw new ArgumentNullException(nameof(theme));
            ThemeBuilder result = new ThemeBuilder((Theme)theme.Clone(), this);
            themeBuilders.Add(result);
            return result;
        }
        public bool RemoveTheme(ThemeBuilder themeBuilder)
        {
            if (themeBuilder == null)
                throw new ArgumentNullException(nameof(themeBuilder));
            bool result = themeBuilders.Remove(themeBuilder);
            QuestionBuilder[] questions = GetQuestionBuilders();
            for (int i = 0; i < questions.Length; i++)
                if (ReferenceEquals(questions[i].ThemeBuilder, themeBuilder))
                    questions[i].ThemeBuilder = null;
            return result;
        }

        public TicketBuilder AddTicket(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            Ticket ticket = new Ticket() { TicketName = name };
            TicketBuilder ticketBuilder = new TicketBuilder(ticket, this);
            ticketBuilders.Add(ticketBuilder);
            return ticketBuilder;
        }
        public TicketBuilder AddTicket(Ticket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException(nameof(ticket));
            TicketBuilder result = new TicketBuilder((Ticket)ticket.Clone(), this);
            ticketBuilders.Add(result);
            return result;
        }
        public bool RemoveTicket(TicketBuilder ticketBuider)
        {
            if (ticketBuider == null)
                throw new ArgumentNullException(nameof(ticketBuider));
            return ticketBuilders.Remove(ticketBuider);
        }

        public QuestionGroupBuilder[] GetQuestionGroupBuilders()
        {
            List<QuestionGroupBuilder> questionBuilders = new List<QuestionGroupBuilder>();
            for (int i = 0; i < ticketBuilders.Count; i++)
                questionBuilders.AddRange(ticketBuilders[i].GetQuestionGroupBuilders());
            return questionBuilders.ToArray();
        }
        public QuestionBuilder[] GetQuestionBuilders()
        {
            List<QuestionBuilder> questionBuilders = new List<QuestionBuilder>();
            for (int i = 0; i < ticketBuilders.Count; i++)
                questionBuilders.AddRange(ticketBuilders[i].GetQuestionBuilders());
            return questionBuilders.ToArray();
        }

        public override void Reset()
        {
            Instance = new Exam();
            themeBuilders.Clear();
            ticketBuilders.Clear();
            MarkSystemBuilder = MarkSystemBuilder.CreateBuilder(Instance.MarkSystem, this);
        }
        public override void Load(Exam instance)
        {
            base.Load((Exam)instance.Clone());

            CreatorName = Instance.CreatorName;
            CreatorSurname = Instance.CreatorSurname;
            CreatorPatronymic = Instance.CreatorPatronymic;
            ExamName = Instance.Name;
            Discipline = Instance.Discipline;
            Description = Instance.Description;
            Password = Instance.Password;
            FirstNumber = Instance.FirstQuestionNumber;
            ExaminationTime = Instance.Time;

            CreationDate = Instance.CreationDate;
            LastChangeDate = Instance.LastChangeDate;

            MarkSystemBuilder = MarkSystemBuilder.CreateBuilder(Instance.MarkSystem, this);

            if (Instance.CreationDate == null)
            {
                CreationDate = DateTime.Now;
                LastChangeDate = DateTime.Now;
                CreatorName = "Имя автора";
                CreatorSurname = "Фамилия автора";
                CreatorPatronymic = "Отчество автора";
                ExamName = "Новый экзамен";
                Discipline = "Без Дисциплины";
                Description = "Без описания";
            }

            int i;
            for (i = 0; i < Instance.Themes.Count; i++)
                themeBuilders.Add(new ThemeBuilder(Instance.Themes[i], this));
            for (i = 0; i < Instance.Tickets.Count; i++)
                ticketBuilders.Add(new TicketBuilder(Instance.Tickets[i], this));
            ticketBuilders.Sort((a, b) =>
           {
               if (a.Instance.TicketNumber == b.Instance.TicketNumber)
                   return 0;
               else if (a.Instance.TicketNumber < b.Instance.TicketNumber)
                   return -1;
               else return 1;
           });
        }
        public override Exam GetBuildedInstance()
        {
            Instance.LastChangeDate = DateTime.Now;
            Instance.CreationDate = CreationDate;

            Instance.CreatorName = CreatorName;
            Instance.CreatorSurname = CreatorSurname;
            Instance.CreatorPatronymic = CreatorPatronymic;
            Instance.Name = ExamName;
            Instance.Discipline = Discipline;
            Instance.Description = Description;
            Instance.Password = Password;
            Instance.FirstQuestionNumber = FirstNumber;
            Instance.Time = ExaminationTime;

            Instance.ExecutionResults.Clear();
            Instance.Themes.Clear();
            Instance.Tickets.Clear();
            Instance.MarkSystem = MarkSystemBuilder.GetBuildedInstance();

            int i;
            for (i = 0; i < ticketBuilders.Count; i++)
            {
                Instance.Tickets.Add(ticketBuilders[i].GetBuildedInstance());
                Instance.Tickets[i].TicketNumber = i;
            }
            for (i = 0; i < themeBuilders.Count; i++)
            {
                Theme theme = themeBuilders[i].GetBuildedInstance();
                theme.ThemeNumber = i;
                Instance.Themes.Add(theme);
            }
            return Instance;
        }
    }
}
