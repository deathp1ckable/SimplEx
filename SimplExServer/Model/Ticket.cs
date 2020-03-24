using System;
using System.Collections.Generic;
namespace SimplExServer.Model
{
    public class Ticket : ICloneable
    {
        public string TicketName { get; set; } = string.Empty;
        public int TicketNumber { get; set; } = 0;
        public List<QuestionGroup> QuestionGroups { get; set; } = new List<QuestionGroup>();

        public Question[] GetQuestions()
        {
            List<Question> result = new List<Question>();
            for (int i = 0; i < QuestionGroups.Count; i++)
                result.AddRange(QuestionGroups[i].GetQuestions());
            return result.ToArray();
        }
        public QuestionGroup[] GetQuestionGroups()
        {
            List<QuestionGroup> result = new List<QuestionGroup>(QuestionGroups);
            for (int i = 0; i < QuestionGroups.Count; i++)
                result.AddRange(QuestionGroups[i].GetQuestionGroups());
            return result.ToArray();
        }
        public object Clone()
        {
            Ticket result = new Ticket();
            result.TicketName = TicketName;
            int i;
            for (i = 0; i < QuestionGroups.Count; i++)
                result.QuestionGroups.Add((QuestionGroup)QuestionGroups[i].Clone());
            QuestionGroup[] questionGroups = result.GetQuestionGroups();
            for (i = 0; i < questionGroups.Length; i++)
                questionGroups[i].ParentTicket = result;
            return result;
        }
    }
}
