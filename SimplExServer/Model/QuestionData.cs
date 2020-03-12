using System;
namespace SimplExServer.Model
{
    public class QuestionData
    {
        public int QuestionNumber { get; set; }
        public int TicketNumber { get; set; }
        public double Points { get; set; }
        public string Content { get; set; }
        public Answer RightAnswer { get; set; }
        public Theme QuestionTheme { get; set; }
        public string QuestionTypeName { get; set; }
    }
}
