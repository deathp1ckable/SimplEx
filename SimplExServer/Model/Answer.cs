namespace SimplExServer.Model
{
    public class Answer
    {
        public int QuestionNumber { get; set; }
        public int TicketNumber { get; set; }
        public string Content { get; set; }
        public Answer(Ticket ticket, QuestionData question, string content)
        {
            TicketNumber = ticket.TicketNumber;
            QuestionNumber = question.QuestionNumber;
            Content = content;
        }
        public Answer() { }
    }
}
