using System;
namespace SimplExServer.Model
{
    public class QuestionData
    {
        public int QuestionNumber { get; set; }
        public double Points { get; set; }
        public string Content { get; set; } = string.Empty;
        public string QuestionTypeName { get; set; } = string.Empty;
        public Answer RightAnswer { get; set; }
        public Theme Theme { get; set; }
        public QuestionGroup ParentQuestionGroup { get; set; }
    }
}
