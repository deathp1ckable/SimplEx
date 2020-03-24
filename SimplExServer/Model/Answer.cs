using System;

namespace SimplExServer.Model
{
    public class Answer : ICloneable
    {
        public Question Question{ get; set; }
        public string Content { get; set; } = string.Empty;
        public Answer(Question question, string content)
        {
            Question = question;
            Content = content;
        }
        public Answer() { }
        public override string ToString() => $"{Content}";
        public object Clone() => new Answer() { Content = Content };
    }
}
