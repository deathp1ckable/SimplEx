using System;

namespace SimplExServer.Model
{
    public class Answer : ICloneable
    {
        public int QuestionNumber { get; set; }
        public int TicketNumber { get; set; }
        public string Content { get; set; } = string.Empty;
        public Answer(Ticket ticket, QuestionData question, string content)
        {
            TicketNumber = ticket.TicketNumber;
            QuestionNumber = question.QuestionNumber;
            Content = content;
        }
        public Answer() { }
        public override string ToString() => $"{QuestionNumber} {TicketNumber} {Content}";
        public object Clone() => new Answer() { QuestionNumber = QuestionNumber, TicketNumber = TicketNumber, Content = Content };
    }
}
