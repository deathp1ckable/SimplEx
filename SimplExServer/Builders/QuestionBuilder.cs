using SimplExServer.Model;
using SimplExServer.Model.Inherited;
using System;
using System.Linq;

namespace SimplExServer.Builders
{
    public abstract class QuestionBuilder : Builder<Question>
    {
        private ThemeBuilder themeBuilder;
        public QuestionGroupBuilder ParentQuestionGroupBuilder { get; private set; }
        public ThemeBuilder ThemeBuilder
        {
            get => themeBuilder;
            set
            {
                if(value == null)
                {
                    themeBuilder = null;
                    return;
                }
                if (value.ParentExamBuilder != ParentQuestionGroupBuilder.GetParentTicketBuilder().ParentExamBuilder)
                    throw new Exception("This builder is not assigned to the parent builder.");
                themeBuilder = value;
            }
        }
        public int QuestionNumber { get; private set; }
        protected QuestionBuilder(QuestionGroupBuilder questionGroupBuilder)
        {
            ParentQuestionGroupBuilder = questionGroupBuilder;
            if (ParentQuestionGroupBuilder == null)
                throw new ArgumentNullException();
        }
        public static QuestionBuilder CreateBuilder(Question instance, QuestionGroupBuilder questionGroupBuilder)
        {
            if (instance == null)
                throw new ArgumentNullException();
            if (instance is OneAnswerQuestion oneAnswerQuestion)
                return new OneAnswerQuestionBuilder(oneAnswerQuestion, questionGroupBuilder);
            else
                return null;
        }
        public void RefreshNumber()
        {
            QuestionNumber = ParentQuestionGroupBuilder.GetParentTicketBuilder().SortedQuestionBuilders.IndexOf(this);
            if (QuestionNumber < 0)
                throw new Exception("This builder is not assigned to the parent builder.");
        }
        public override void Load(Question instance)
        {
            base.Load(instance);
            QuestionNumber = Instance.QuestionNumber;
            if (Instance.Theme != null)
                ThemeBuilder = ParentQuestionGroupBuilder.GetParentTicketBuilder().ParentExamBuilder.ThemeBuilders.Single(a =>
                     ReferenceEquals(Instance.Theme, a.Instance));
        }
        public abstract Question GetDuplicate();
    }
}
