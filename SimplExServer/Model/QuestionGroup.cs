using System;
using System.Collections.Generic;

namespace SimplExServer.Model
{
    public class QuestionGroup : ICloneable
    {
        public string QuestionGroupName { get; set; } = string.Empty;
        public QuestionGroup ParentQuestionGroup { get; set; }
        public Ticket ParentTicket { get; set; }
        public List<QuestionGroup> ChildQuestionGroups { get; set; } = new List<QuestionGroup>();
        public List<Question> Questions { get; set; } = new List<Question>();
      
        public override string ToString() => $"{QuestionGroupName}";

        public Question[] GetQuestions()
        {
            List<Question> result = new List<Question>(Questions);
            for (int i = 0; i < ChildQuestionGroups.Count; i++)
                result.AddRange(ChildQuestionGroups[i].GetQuestions());
            return result.ToArray();
        }
        public QuestionGroup[] GetQuestionGroups()
        {
            List<QuestionGroup> result = new List<QuestionGroup>(ChildQuestionGroups);
            int i;
            for (i = 0; i < ChildQuestionGroups.Count; i++)
                result.AddRange(ChildQuestionGroups[i].GetQuestionGroups());
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
            for (i = 0; i < ChildQuestionGroups.Count; i++)
            {
                QuestionGroup group = (QuestionGroup)ChildQuestionGroups[i].Clone();
                group.ParentQuestionGroup = result;
                result.ChildQuestionGroups.Add(group);
            }
            return result;
        }
    }
}
