using System.Collections.Generic;
using System;
namespace SimplExServer.Model
{
    public class QuestionGroup : ICloneable
    {
        public string QuestionGroupName { get; set; } = string.Empty;

        public QuestionGroup ParentQuestionGroup { get; set; }
        public Ticket ParentTicket { get; set; }

        public List<QuestionGroup> QuestionGroups { get; set; } = new List<QuestionGroup>();
        public List<Question> Questions { get; set; } = new List<Question>();

        public override string ToString() => $"{QuestionGroupName}";

        public Question[] GetQuestions()
        {
            List<Question> result = new List<Question>(Questions);
            for (int i = 0; i < QuestionGroups.Count; i++)
                result.AddRange(QuestionGroups[i].GetQuestions());
            return result.ToArray();
        }
        public QuestionGroup[] GetQuestionGroups()
        {
            List<QuestionGroup> result = new List<QuestionGroup>(QuestionGroups);
            int i;
            for (i = 0; i < QuestionGroups.Count; i++)
                result.AddRange(QuestionGroups[i].GetQuestionGroups());
            return result.ToArray();
        }

        public object Clone()
        {
            int i;
            QuestionGroup result = new QuestionGroup();
            result.QuestionGroupName = QuestionGroupName;
            for (i = 0; i < Questions.Count; i++)
            {
                Question question = (Question)Questions[i].Clone();
                question.ParentQuestionGroup = result;
                result.Questions.Add(question);
            }
            for (i = 0; i < QuestionGroups.Count; i++)
            {
                QuestionGroup group = (QuestionGroup)QuestionGroups[i].Clone();
                group.ParentQuestionGroup = result;
                result.QuestionGroups.Add(group);
            }
            return result;
        }
    }
}
