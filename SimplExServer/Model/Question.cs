using System;
namespace SimplExServer.Model
{
    public abstract class Question : ICloneable
    {
        private Answer rightAnswer;

        public int QuestionNumber { get; set; }
        public double Points { get; set; }
        public abstract string Content { get; set; }
        public Answer RightAnswer
        {
            get
            {
                if (rightAnswer != null)
                    rightAnswer.Question = this;
                return rightAnswer;
            }
            set => rightAnswer = value;
        }
        public Theme Theme { get; set; }

        public QuestionGroup ParentQuestionGroup { get; set; }

        public Question(QuestionData data)
        {
            Theme = data.Theme;
            Points = data.Points;
            Content = data.Content;
            RightAnswer = data.RightAnswer;
            QuestionNumber = data.QuestionNumber;
            ParentQuestionGroup = data.ParentQuestionGroup;
        }
        public Question() { }
        public QuestionData GetQuestionData()
        {
            return new QuestionData()
            {
                Theme = Theme,
                Points = Points,
                Content = Content,
                RightAnswer = RightAnswer,
                QuestionNumber = QuestionNumber,
                ParentQuestionGroup = ParentQuestionGroup
            };
        }
        public abstract object Clone();
        public abstract double CheckAnswer(Answer answer);
    }
}
