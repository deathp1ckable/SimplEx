namespace SimplExServer.Model
{
    public class Ticket
    {
        public int TicketNumber { get; set; }
        public QuestionGroup[] QuestionGroups { get; set; }
        public Question GetQuestionByNumber(int number)
        {
            for (int i = 0, j; i < QuestionGroups.Length; i++)
                for (j = 0; j < QuestionGroups[i].Questions.Length; j++)
                    if (QuestionGroups[i].Questions[j].QuestionNumber == number)
                        return QuestionGroups[i].Questions[j];
            return null;
        }
    }
}
