namespace SimplExServer.Model
{
    public class QuestionGroup
    {
        public string QuestionGroupName { get; set; }
        public QuestionGroup ParentQuestionGroup { get; set; }
        public QuestionGroup[] ChildQuestionGroups { get; set; }
        public Question[] Questions { get; set; }
    }
}
