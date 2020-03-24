using Newtonsoft.Json;
using System.Collections.Generic;

namespace SimplExServer.Model.Inherited
{
    public class OneAnswerQuestion : Question
    {
        public class OneAnswerQuestionContent
        {
            public string Text { get; set; } = string.Empty;
            public List<string> Answers { get; set; } = new List<string>();
        }
        public OneAnswerQuestionContent QuestionContent { get; private set; } = new OneAnswerQuestionContent();
        public override string Content
        {
            get => JsonConvert.SerializeObject(QuestionContent);
            set => QuestionContent = JsonConvert.DeserializeObject<OneAnswerQuestionContent>(value);
        }
        public override double CheckAnswer(Answer answer)
        {
            if (answer.Content == RightAnswer.Content)
                return Points;
            else return 0;
        }

        public override object Clone()
        {
            OneAnswerQuestion result = new OneAnswerQuestion()
            {
                Content = Content,
                Points = Points,
                RightAnswer = (Answer)RightAnswer?.Clone()
            };
            if (result.RightAnswer != null)
                result.RightAnswer.Question = result;
            return result;
        }
    }
}
