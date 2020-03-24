using System;

namespace SimplExServer.Model
{
    public class ExecutorAnswer 
    {
        public Question Question { get; set; }
        public string Content { get; set; } = string.Empty;
        public ExecutorAnswer(Question question, string content)
        {
            Question = question;
            Content = content;
        }
        public ExecutorAnswer() { }
    }
}
