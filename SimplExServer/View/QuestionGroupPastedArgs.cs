using SimplExServer.Builders;
using System;
namespace SimplExServer.View
{
    public class QuestionGroupPastedArgs : EventArgs
    {
        public TicketBuilder TicketBuilder { get; private set; }
        public QuestionGroupBuilder QuestionGroupBuilder { get; private set; }
        public QuestionGroupPastedArgs(TicketBuilder ticketBuilder)
        {
            TicketBuilder = ticketBuilder;
        }
        public QuestionGroupPastedArgs(QuestionGroupBuilder questionBuilder)
        {
            QuestionGroupBuilder = questionBuilder;
        }
    }
}
