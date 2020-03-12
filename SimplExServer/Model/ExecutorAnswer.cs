namespace SimplExServer.Model
{
    public class ExecutorAnswer
    {
        public int QuestionNumber { get; set; }
        public int TicketNumber { get; set; }
        public string Content { get; set; }
        public ExecutorAnswer(Ticket ticket, QuestionData question, string content)
        {
            TicketNumber = ticket.TicketNumber;
            QuestionNumber = question.QuestionNumber;
            Content = content;
        }
        public ExecutorAnswer() { }
    }
}
