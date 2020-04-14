using System;
namespace SimplExModel.Model
{
    public abstract class Question : ICloneable
    {
        private Answer rightAnswer;

        public int QuestionNumber { get; set; }
        public double Points { get; set; }
        public abstract string Content { get; set; }
        public Answer Answer
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
        public Question() { }
        public abstract object Clone();
        public abstract double CheckAnswer(Answer answer);
    }
}
