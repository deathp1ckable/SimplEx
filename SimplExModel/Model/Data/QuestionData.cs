using System;
using System.Reflection;

namespace SimplExModel.Model.Data
{
    public class QuestionData
    {
        public int QuestionNumber { get; set; }
        public double Points { get; set; }
        public string Content { get; set; } = string.Empty;
        public string QuestionTypeName { get; set; } = string.Empty;
        public Answer Answer { get; set; }
        public Theme Theme { get; set; }
        public QuestionGroup ParentQuestionGroup { get; set; }
        public QuestionData()
        { }
        public QuestionData(Question question)
        {
            QuestionNumber = question.QuestionNumber;
            Points = question.Points;
            Content = question.Content;
            QuestionTypeName = question.GetType().ToString();
            Answer = question.Answer;
            Theme = question.Theme;
            ParentQuestionGroup = question.ParentQuestionGroup;
        }
        public Question CreateQuestion()
        {
            Question result = (Question)Activator.CreateInstance(Assembly.GetAssembly(typeof(Question)).GetType(QuestionTypeName));
            result.QuestionNumber = QuestionNumber;
            result.Points = Points;
            result.ParentQuestionGroup = ParentQuestionGroup;
            result.Content = Content;
            result.Theme = Theme;
            result.Answer = Answer;
            return result;
        }
    }
}
