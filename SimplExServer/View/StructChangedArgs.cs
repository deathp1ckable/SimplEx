using SimplExServer.Builders;
using System;
namespace SimplExServer.View
{
    public class StructChangedArgs : EventArgs
    {
        public QuestionGroupBuilder Group { get; private set; }
        public QuestionGroupBuilder NewParentGroup { get; private set; }
        public TicketBuilder Ticket { get; private set; }
        public StructChangedArgs(QuestionGroupBuilder group, QuestionGroupBuilder newParentGroup)
        {
            Group = group;
            NewParentGroup = newParentGroup;
        }
        public StructChangedArgs(QuestionGroupBuilder group, TicketBuilder ticket)
        {
            Group = group;
            Ticket = ticket;
        }
    }
}
