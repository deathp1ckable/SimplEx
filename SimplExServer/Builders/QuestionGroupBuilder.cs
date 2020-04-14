using SimplExModel.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SimplExServer.Builders
{
    public class QuestionGroupBuilder : Builder<QuestionGroup>
    {
        private readonly List<QuestionGroupBuilder> questionGroupBuilders = new List<QuestionGroupBuilder>();
        private readonly List<QuestionBuilder> questionBuilders = new List<QuestionBuilder>();

        public string QuestionGroupName { get; set; }
        public QuestionGroupBuilder ParentQuestionGroupBuilder { get; private set; }
        public TicketBuilder ParentTicketBuilder { get; private set; }
        public ReadOnlyCollection<QuestionGroupBuilder> QuestionGroupBuilders { get; private set; }
        public ReadOnlyCollection<QuestionBuilder> QuestionBuilders { get; private set; }

        private QuestionGroupBuilder()
        {
            QuestionGroupBuilders = new ReadOnlyCollection<QuestionGroupBuilder>(questionGroupBuilders);
            QuestionBuilders = new ReadOnlyCollection<QuestionBuilder>(questionBuilders);
        }

        public QuestionGroupBuilder(QuestionGroup instance, TicketBuilder ticketBuilder) : this()
        {
            ParentTicketBuilder = ticketBuilder;
            if (ParentTicketBuilder == null)
                throw new ArgumentNullException(nameof(ticketBuilder));
            Load(instance);
        }
        public QuestionGroupBuilder(QuestionGroup instance, QuestionGroupBuilder questionGroupBuilder) : this()
        {
            ParentQuestionGroupBuilder = questionGroupBuilder;
            if (ParentQuestionGroupBuilder == null)
                throw new ArgumentNullException(nameof(questionGroupBuilder));
            Load(instance);
        }
        public QuestionGroup GetDuplicate()
        {
            QuestionGroup result = new QuestionGroup();
            int i;
            result.QuestionGroupName = QuestionGroupName;
            for (i = 0; i < questionGroupBuilders.Count; i++)
            {
                QuestionGroup group = questionGroupBuilders[i].GetDuplicate();
                group.ParentQuestionGroup = result;
                group.ParentTicket = null;
                result.ChildQuestionGroups.Add(group);
            }
            for (i = 0; i < questionBuilders.Count; i++)
            {
                Question question = questionBuilders[i].GetDuplicate();
                question.ParentQuestionGroup = result;
                result.Questions.Add(question);
            }
            return result;
        }

        public QuestionGroupBuilder AddQuestionGroup(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            QuestionGroup group = new QuestionGroup() { QuestionGroupName = name };
            QuestionGroupBuilder result = new QuestionGroupBuilder(group, this);
            questionGroupBuilders.Add(result);
            return result;
        }
        public QuestionGroupBuilder AddQuestionGroup(QuestionGroup questionGroup)
        {
            if (questionGroup == null)
                throw new ArgumentNullException(nameof(questionGroup));
            QuestionGroupBuilder result = new QuestionGroupBuilder((QuestionGroup)questionGroup.Clone(), this);
            questionGroupBuilders.Add(result);
            GetParentTicketBuilder().RegisterQuestionGroup(result);
            return result;
        }
        public QuestionGroupBuilder AddQuestionGroup(QuestionGroupBuilder questionGroupBuilder)
        {
            if (questionGroupBuilder == null)
                throw new ArgumentNullException(nameof(questionGroupBuilder));
            if (GetParentTicketBuilder().GetQuestionGroupBuilders().Contains(questionGroupBuilder))
                throw new Exception("This builder was already assigned to the parent builder.");
            questionGroupBuilders.Add(questionGroupBuilder);
            GetParentTicketBuilder().RegisterQuestionGroup(questionGroupBuilder);
            questionGroupBuilder.ParentQuestionGroupBuilder = this;
            questionGroupBuilder.ParentTicketBuilder = null;
            return questionGroupBuilder;
        }
        public bool RemoveQuestionGroup(QuestionGroupBuilder questionGroupBuilder)
        {
            if (questionGroupBuilder == null)
                throw new ArgumentNullException(nameof(questionGroupBuilder));
            bool result = questionGroupBuilders.Remove(questionGroupBuilder);
            if (result)
                GetParentTicketBuilder().UnregisterQuestionGroup(questionGroupBuilder);
            return result;
        }

        public QuestionBuilder AddQuestion(Question question)
        {
            if (question == null)
                throw new ArgumentNullException(nameof(question));
            QuestionBuilder result = QuestionBuilder.CreateBuilder((Question)question.Clone(), this);
            questionBuilders.Add(result);
            GetParentTicketBuilder().RegisterQuestion(result);
            return result;
        }
        public bool RemoveQuestion(QuestionBuilder questionBuilder)
        {
            if (questionBuilder == null)
                throw new ArgumentNullException(nameof(questionBuilder));
            bool result = questionBuilders.Remove(questionBuilder);
            if (result)
                GetParentTicketBuilder().UnregisterQuestion(questionBuilder);
            return result;
        }

        public QuestionBuilder[] GetQuestionBuilders()
        {
            List<QuestionBuilder> result = new List<QuestionBuilder>(questionBuilders);
            for (int i = 0; i < questionGroupBuilders.Count; i++)
                result.AddRange(questionGroupBuilders[i].GetQuestionBuilders());
            return result.ToArray();
        }
        public QuestionGroupBuilder[] GetQuestionGroupBuilders()
        {
            List<QuestionGroupBuilder> result = new List<QuestionGroupBuilder>(questionGroupBuilders);
            for (int i = 0; i < questionGroupBuilders.Count; i++)
                result.AddRange(questionGroupBuilders[i].GetQuestionGroupBuilders());
            return result.ToArray();
        }

        public void SetParent(QuestionGroupBuilder questionGroupBuilder)
        {
            if (questionGroupBuilder == null)
                throw new ArgumentNullException(nameof(questionGroupBuilder));
            TicketBuilder ticketBuilder = GetParentTicketBuilder();
            if (questionGroupBuilder.GetParentTicketBuilder() != ticketBuilder)
                throw new ArgumentException();
            if (ReferenceEquals(ParentQuestionGroupBuilder, questionGroupBuilder))
                return;
            QuestionBuilder[] questionBuilders = ticketBuilder.SortedQuestionBuilders.ToArray();
            ParentQuestionGroupBuilder?.questionGroupBuilders.Remove(this);
            ParentTicketBuilder?.RemoveQuestionGroup(this);
            questionGroupBuilder.AddQuestionGroup(this);
            ticketBuilder.SetNumeration(questionBuilders);
        }
        public void SetParent(TicketBuilder ticketBuilder)
        {
            if (ticketBuilder == null)
                throw new ArgumentNullException(nameof(ticketBuilder));
            if (ticketBuilder != GetParentTicketBuilder())
                throw new ArgumentException();
            if (ReferenceEquals(ParentTicketBuilder, ticketBuilder))
                return;
            QuestionBuilder[] questionBuilders = ticketBuilder.SortedQuestionBuilders.ToArray();
            ParentQuestionGroupBuilder?.questionGroupBuilders.Remove(this);
            ParentTicketBuilder?.RemoveQuestionGroup(this);
            ticketBuilder.AddQuestionGroup(this);
            ticketBuilder.SetNumeration(questionBuilders);
        }
        public override void Load(QuestionGroup instance)
        {
            base.Load(instance);
            QuestionGroupName = Instance.QuestionGroupName;
            for (int i = 0; i < Instance.Questions.Count; i++)
                questionBuilders.Add(QuestionBuilder.CreateBuilder(Instance.Questions[i], this));
            for (int i = 0; i < Instance.ChildQuestionGroups.Count; i++)
                questionGroupBuilders.Add(new QuestionGroupBuilder(Instance.ChildQuestionGroups[i], this));
        }
        public override void Reset()
        {
            Instance = new QuestionGroup();
            questionGroupBuilders.Clear();
            questionBuilders.Clear();
        }
        public override QuestionGroup GetBuildedInstance()
        {
            if (ParentTicketBuilder != null && ParentQuestionGroupBuilder == null && !ParentTicketBuilder.QuestionGroupBuilders.Contains(this))
                throw new Exception("This builder is not assigned to the parent builder.");
            else if (ParentQuestionGroupBuilder != null && !ParentQuestionGroupBuilder.QuestionGroupBuilders.Contains(this))
                throw new Exception("This builder is not assigned to the parent builder.");
            int i;
            Instance.ChildQuestionGroups.Clear();
            Instance.Questions.Clear();
            Instance.QuestionGroupName = QuestionGroupName;
            for (i = 0; i < questionGroupBuilders.Count; i++)
            {
                QuestionGroup group = questionGroupBuilders[i].GetBuildedInstance();
                group.ParentQuestionGroup = Instance;
                group.ParentTicket = null;
                Instance.ChildQuestionGroups.Add(group);
            }
            for (i = 0; i < questionBuilders.Count; i++)
            {
                Question question = questionBuilders[i].GetBuildedInstance();
                question.ParentQuestionGroup = Instance;
                question.Theme = questionBuilders[i].ThemeBuilder.Instance;
                Instance.Questions.Add(question);
            }
            return Instance;
        }
        public TicketBuilder GetParentTicketBuilder()
        {
            if (ParentTicketBuilder != null)
                return ParentTicketBuilder;
            else return ParentQuestionGroupBuilder.GetParentTicketBuilder();
        }
        public override string ToString() => $"{QuestionGroupName}";
    }
}
