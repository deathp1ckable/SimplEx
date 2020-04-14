using SimplExModel.Model;
using SimplExModel.Model.Inherited;
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
        public List<string> Answers { get; set; }
        public string Devider { get; set; }
        public string Letters { get; set; }
        public OneAnswerQuestionBuilder(OneAnswerQuestion instance, QuestionGroupBuilder questionGroupBuilder) : base(questionGroupBuilder) => Load(instance);

        public override Question GetDuplicate()
        {
            OneAnswerQuestion result = new OneAnswerQuestion();
            result.QuestionContent.Text = Text;
            result.QuestionContent.Answers = Answers;
            result.QuestionContent.Letters = Letters;
            result.QuestionContent.Devider = Devider;
            result.Points = Points;
            if (Answers.Count != 0)
                result.Answer = new Answer() { Content = Answers[rightAnswerIndex] };
            else result.Answer = null;
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
            Letters = Instance.QuestionContent.Letters;
            Devider = Instance.QuestionContent.Devider;
            if (Instance.Answer != null)
                rightAnswerIndex = Answers.IndexOf(Instance.Answer.Content);
        }
        public override Question GetBuildedInstance()
        {
            if (!ParentQuestionGroupBuilder.QuestionBuilders.Contains(this))
                throw new Exception("This builder is not assigned to the parent builder.");
            Instance.QuestionNumber = QuestionNumber;
            Instance.QuestionContent.Text = Text;
            Instance.QuestionContent.Answers = Answers;
            Instance.Points = Points;
            Instance.QuestionContent.Letters = Letters;
            if (Answers.Count > 0)
                Instance.Answer = new Answer() { Content = Answers[rightAnswerIndex] };
            return Instance;
        }
        public override string ToString()
        {
            string result = Text + Environment.NewLine;
            for (int i = 0; i < Answers.Count; i++)
                result += Letters[i] + Devider + " " + Answers[i] + Environment.NewLine;
            return result;
        }
    }
}
