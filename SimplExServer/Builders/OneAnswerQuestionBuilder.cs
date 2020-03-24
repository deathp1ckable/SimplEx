using SimplExServer.Model;
using SimplExServer.Model.Inherited;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimplExServer.Builders
{
    public class OneAnswerQuestionBuilder : QuestionBuilder
    {
        private int rightAnswerIndex;
        private new OneAnswerQuestion Instance => (OneAnswerQuestion)base.Instance;

        public string Text { get; set; }
        public double Points { get; set; }
        public int RightAnswerIndex
        {
            get => rightAnswerIndex;
            set
            {
                if (value > Answers.Count || value < 0)
                    throw new ArgumentException();
                rightAnswerIndex = value;
            }
        }
        public List<string> Answers { get; private set; }
        public OneAnswerQuestionBuilder(OneAnswerQuestion instance, QuestionGroupBuilder questionGroupBuilder) : base(questionGroupBuilder) => Load(instance);

        public override Question GetDuplicate()
        {
            OneAnswerQuestion result = new OneAnswerQuestion();
            result.QuestionContent.Text = Text;
            result.QuestionContent.Answers = Answers;
            result.Points = Points;
            if (Answers.Count != 0)
                result.RightAnswer = new Answer() { Content = Answers[rightAnswerIndex] };
            else result.RightAnswer = null;
            return result;
        }

        public override void Reset()
        {
            base.Instance = new OneAnswerQuestion();
            rightAnswerIndex = 0;
            Answers = new List<string>();
        }
        public override void Load(Question instance)
        {
            base.Load(instance);
            Points = Instance.Points;
            Text = Instance.QuestionContent.Text;
            Answers = new List<string>(Instance.QuestionContent.Answers);
            if (Instance.RightAnswer != null)
                rightAnswerIndex = Answers.IndexOf(Instance.RightAnswer.Content);
        }
        public override Question GetBuildedInstance()
        {
            if (!ParentQuestionGroupBuilder.QuestionBuilders.Contains(this))
                throw new Exception("This builder is not assigned to the parent builder.");
            Instance.QuestionNumber = QuestionNumber;
            Instance.QuestionContent.Text = Text;
            Instance.QuestionContent.Answers = Answers;
            Instance.Points = Points;
            Instance.RightAnswer = new Answer() { Content = Answers[rightAnswerIndex] };
            return base.GetBuildedInstance();
        }
        public override string ToString() => $"{QuestionNumber} {Points} {Text} {(Answers.Count > 0 ? Answers[RightAnswerIndex] : "")} {ThemeBuilder?.ThemeName ?? ""}";
    }
}
