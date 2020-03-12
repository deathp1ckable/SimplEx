using Newtonsoft.Json;
namespace SimplExServer.Model.Inherited
{
    public class OneAnswerQuestion : Question
    {
        public class OneAnswerQuestionContent
        {
            public string QuestionContent { get; set; }
            public string[] Answers { get; set; }
        }
        private OneAnswerQuestionContent content;
        public override string Content
        {
            get => JsonConvert.SerializeObject(content);
            set => content = JsonConvert.DeserializeObject<OneAnswerQuestionContent>(value);
        }
        public override double CheckAnswer(Answer answer)
        {
            if (answer.Content == RightAnswer.Content)
                return Points;
            else return 0;
        }
    }
}
