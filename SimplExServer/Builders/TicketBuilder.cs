using SimplExModel.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SimplExServer.Builders
{
    public class TicketBuilder : Builder<Ticket>
    {
        private readonly List<QuestionGroupBuilder> questionGroupBuilders = new List<QuestionGroupBuilder>();
        private readonly List<QuestionBuilder> sortedQuestionBuilders = new List<QuestionBuilder>();

        public string TicketName { get; set; }

        public ExamBuilder ParentExamBuilder { get; private set; }
        public ReadOnlyCollection<QuestionGroupBuilder> QuestionGroupBuilders { get; private set; }
        public ReadOnlyCollection<QuestionBuilder> SortedQuestionBuilders { get; private set; }

        public TicketBuilder(Ticket instance, ExamBuilder examBuilder)
        {
            QuestionGroupBuilders = new ReadOnlyCollection<QuestionGroupBuilder>(questionGroupBuilders);
            SortedQuestionBuilders = new ReadOnlyCollection<QuestionBuilder>(sortedQuestionBuilders);
            ParentExamBuilder = examBuilder;
            if (ParentExamBuilder == null)
                throw new ArgumentNullException(nameof(examBuilder));
            Load(instance);
        }

        public QuestionGroupBuilder AddQuestionGroup(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            QuestionGroup questionGroup = new QuestionGroup() { QuestionGroupName = name };
            QuestionGroupBuilder result = new QuestionGroupBuilder(questionGroup, this);
            questionGroupBuilders.Add(result);
            return result;
        }
        public QuestionGroupBuilder AddQuestionGroup(QuestionGroup questionGroup)
        {
            if (questionGroup == null)
                throw new ArgumentNullException(nameof(questionGroup));
            QuestionGroupBuilder result = new QuestionGroupBuilder((QuestionGroup)questionGroup.Clone(), this);
            questionGroupBuilders.Add(result);
            RegisterQuestionGroup(result);
            return result;
        }
        public QuestionGroupBuilder AddQuestionGroup(QuestionGroupBuilder questionGroupBuilder)
        {
            if (questionGroupBuilder == null)
                throw new ArgumentNullException(nameof(questionGroupBuilder));
            if (GetQuestionGroupBuilders().Contains(questionGroupBuilder))
                throw new Exception("This builder was already assigned to the parent builder.");
            questionGroupBuilders.Add(questionGroupBuilder);
            RegisterQuestionGroup(questionGroupBuilder);
            questionGroupBuilder.GetType().GetProperty("ParentTicketBuilder").SetValue(questionGroupBuilder, this);
            questionGroupBuilder.GetType().GetProperty("ParentQuestionGroupBuilder").SetValue(questionGroupBuilder, null);
            return questionGroupBuilder;
        }
        public bool RemoveQuestionGroup(QuestionGroupBuilder questionGroupBuilder)
        {
            if (questionGroupBuilder == null)
                throw new ArgumentNullException(nameof(questionGroupBuilder));
            bool result = questionGroupBuilders.Remove(questionGroupBuilder);
            if (result)
                UnregisterQuestionGroup(questionGroupBuilder);
            return result;
        }

        public void RegisterQuestion(QuestionBuilder toRegister)
        {
            if (!GetQuestionBuilders().Contains(toRegister))
                throw new ArgumentException();
            if (toRegister == null)
                throw new ArgumentNullException(nameof(toRegister));
            if (sortedQuestionBuilders.Contains(toRegister))
                return;
            sortedQuestionBuilders.Add(toRegister);
            toRegister.RefreshNumber();
        }
        public void RegisterQuestionGroup(QuestionGroupBuilder toRegister)
        {
            if (!GetQuestionGroupBuilders().Contains(toRegister))
                throw new ArgumentException();
            if (toRegister == null)
                throw new ArgumentNullException(nameof(toRegister));
            QuestionBuilder[] questionBuilders = toRegister.GetQuestionBuilders();
            for (int i = 0; i < questionBuilders.Length; i++)
                if (!sortedQuestionBuilders.Contains(questionBuilders[i]))
                    sortedQuestionBuilders.Add(questionBuilders[i]);
            RefreshNumeration();
        }
        public void SetNumeration(QuestionBuilder[] questionBuilders)
        {
            if (questionBuilders.Length != sortedQuestionBuilders.Count)
                throw new Exception("Invalid of amount questions for numbering.");
            for (int i = 0; i < questionBuilders.Length; i++)
                if (!ReferenceEquals(questionBuilders[i].ParentQuestionGroupBuilder.GetParentTicketBuilder(), this))
                    throw new Exception("Unapproved questions cannot be numbered.");
            sortedQuestionBuilders.Clear();
            sortedQuestionBuilders.AddRange(questionBuilders);
            RefreshNumeration();
        }
        public void SwapNumeration(QuestionBuilder questionA, QuestionBuilder questionB)
        {
            if (questionA == null )
                throw new ArgumentNullException(nameof(questionA));
            if(questionB == null)
                throw new ArgumentNullException(nameof(questionB));
            int questionIndexA = sortedQuestionBuilders.IndexOf(questionA);
            int questionIndexB = sortedQuestionBuilders.IndexOf(questionB);
            if (questionIndexA < 0 || questionIndexB < 0)
                throw new ArgumentException();
            QuestionBuilder temp = sortedQuestionBuilders[questionIndexA];
            sortedQuestionBuilders[questionIndexA] = sortedQuestionBuilders[questionIndexB];
            sortedQuestionBuilders[questionIndexB] = temp;
            sortedQuestionBuilders[questionIndexB].RefreshNumber();
            sortedQuestionBuilders[questionIndexA].RefreshNumber();
        }
        public void RefreshNumeration()
        {
            for (int i = 0; i < sortedQuestionBuilders.Count; i++)
                sortedQuestionBuilders[i].RefreshNumber();
        }
        public void UnregisterQuestion(QuestionBuilder toUnregister)
        {
            sortedQuestionBuilders.Remove(toUnregister);
            RefreshNumeration();
        }
        public void UnregisterQuestionGroup(QuestionGroupBuilder toUnregister)
        {
            QuestionBuilder[] questionGroups = toUnregister.GetQuestionBuilders();
            for (int i = 0; i < questionGroups.Length; i++)
                sortedQuestionBuilders.Remove(questionGroups[i]);
            RefreshNumeration();
        }

        public QuestionBuilder[] GetQuestionBuilders()
        {
            List<QuestionBuilder> result = new List<QuestionBuilder>();
            for (int i = 0; i < questionGroupBuilders.Count; i++)
                result.AddRange(questionGroupBuilders[i].GetQuestionBuilders());
            return result.ToArray();
        }

        public QuestionGroupBuilder[] GetQuestionGroupBuilders()
        {
            List<QuestionGroupBuilder> result = new List<QuestionGroupBuilder>(questionGroupBuilders);
            int i;
            for (i = 0; i < questionGroupBuilders.Count; i++)
                result.AddRange(questionGroupBuilders[i].GetQuestionGroupBuilders());
            return result.ToArray();
        }

        public override void Reset()
        {
            questionGroupBuilders.Clear();
            sortedQuestionBuilders.Clear();
            Instance = new Ticket();
        }
        public override void Load(Ticket instance)
        {
            base.Load(instance);
            TicketName = instance.TicketName;
            for (int i = 0; i < Instance.QuestionGroups.Count; i++)
                questionGroupBuilders.Add(new QuestionGroupBuilder(Instance.QuestionGroups[i], this));
            sortedQuestionBuilders.AddRange(GetQuestionBuilders());
            sortedQuestionBuilders.Sort((a, b) =>
            {
                if (a.QuestionNumber == b.QuestionNumber)
                    return 0;
                else if (a.QuestionNumber < b.QuestionNumber)
                    return -1;
                else return 1;
            });
        }
        public override Ticket GetBuildedInstance()
        {
            if (!ParentExamBuilder.TicketBuilders.Contains(this))
                throw new Exception("This builder is not assigned to the parent builder.");
            RefreshNumeration();
            Instance.QuestionGroups.Clear();
            Instance.TicketName = TicketName;
            int i;
            for (i = 0; i < questionGroupBuilders.Count; i++)
            {
                QuestionGroup group = questionGroupBuilders[i].GetBuildedInstance();
                group.ParentTicket = Instance;
                group.ParentQuestionGroup = null;
                Instance.QuestionGroups.Add(group);
            }
            return Instance;
        }
        public override string ToString() => $"{TicketName}";
    }
}
