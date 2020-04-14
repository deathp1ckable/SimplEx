using System;
namespace SimplExModel.Model.Data
{
    public class AnswerData : ICloneable
    {
        public int TicketNumber { get; set; }
        public int QuestionNumber { get; set; }
        public string Content { get; set; } = string.Empty;

        public AnswerData(Answer answer)
        {
            Content = answer.Content;
            QuestionNumber = answer.Question.QuestionNumber;
            TicketNumber = answer.Question.ParentQuestionGroup.GetParentTicket().TicketNumber;
        }
        public Answer CreateAnswer(Exam owner)
        {
            Ticket ownerTicket = null;
            int i;
            for (i = 0; i < owner.Tickets.Count; i++)
                if (owner.Tickets[i].TicketNumber == TicketNumber)
                {
                    ownerTicket = owner.Tickets[i];
                    break;
                }
            if (ownerTicket == null)
                throw new Exception();
            Question ownerQuestion = null;
            Question[] questions = ownerTicket.GetQuestions();
            for (i = 0; i < questions.Length; i++)
                if (questions[i].QuestionNumber == QuestionNumber)
                {
                    ownerQuestion = questions[i];
                    break;
                }
            if(ownerQuestion == null)
                throw new Exception();
            return new Answer() { Question = ownerQuestion, Content = Content };
        }
        public AnswerData() { }
        public override string ToString() => $"{Content}";
        public object Clone() => MemberwiseClone();
    }
}
