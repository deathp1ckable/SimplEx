using System.Collections.Generic;
using System;
namespace SimplExServer.Model
{
    public class QuestionGroup : ICloneable
    {
        public QuestionGroup ParentQuestionGroup { get; set; }
        public string QuestionGroupName { get; set; } = string.Empty;
        public List<QuestionGroup> ChildQuestionGroups { get; set; } = new List<QuestionGroup>();
        public List<Question> Questions { get; set; } = new List<Question>();
        public override string ToString() => $"{QuestionGroupName}";
        public Question[] GetQuestions(QuestionGroup group)
        {
            List<Question> result = new List<Question>(Questions);
            int i;
            for (i = 0; i < group.ChildQuestionGroups.Count; i++)
                result.AddRange(GetQuestions(group.ChildQuestionGroups[i]));
            return result.ToArray();
        }
        public QuestionGroup[] GetQuestionGroups(QuestionGroup group)
        {
            List<QuestionGroup> result = new List<QuestionGroup>();
            int i;
            for (i = 0; i < group.ChildQuestionGroups.Count; i++)
                result.AddRange(GetQuestionGroups(group.ChildQuestionGroups[i]));
            result.AddRange(group.ChildQuestionGroups);
            return result.ToArray();
        }
        public object Clone()
        {
            int i;
            QuestionGroup result = new QuestionGroup()
            {
                QuestionGroupName = QuestionGroupName,
                ParentQuestionGroup = ParentQuestionGroup
            };
            for (i = 0; i < Questions.Count; i++)
                result.Questions.Add((Question)Questions[i].Clone());
            for (i = 0; i < ChildQuestionGroups.Count; i++)
                result.ChildQuestionGroups.Add((QuestionGroup)ChildQuestionGroups[i].Clone());
            return result;
        }
    }
}
