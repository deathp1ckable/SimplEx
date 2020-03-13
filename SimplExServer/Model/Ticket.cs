using System.Collections.Generic;
namespace SimplExServer.Model
{
    public class Ticket
    {
        public int TicketNumber { get; set; } = 0;
        public List<QuestionGroup> QuestionGroups { get; set; } = new List<QuestionGroup>();
        public Question[] GetQuestions()
        {
            List<Question> result = new List<Question>();
            for (int i = 0; i < QuestionGroups.Count; i++)
                result.AddRange(QuestionGroups[i].GetQuestions(QuestionGroups[i]));
            return result.ToArray();
        }
        public QuestionGroup[] GetQuestionGroups()
        {
            List<QuestionGroup> result = new List<QuestionGroup>(QuestionGroups);
            for (int i = 0; i < QuestionGroups.Count; i++)
                result.AddRange(QuestionGroups[i].GetQuestionGroups(QuestionGroups[i]));
            return result.ToArray();
        }
        public override string ToString() => $"{TicketNumber}";
    }
}
