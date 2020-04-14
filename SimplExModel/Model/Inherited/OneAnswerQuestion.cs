using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SimplExModel.Model.Inherited
{
    public class OneAnswerQuestion : Question
    {
        public class OneAnswerQuestionContent
        {
            public string Text { get; set; } = string.Empty;
            public string Letters { get; set; } = string.Empty;
            public string Devider { get; set; } = string.Empty;
            public IList<string> Answers { get; set; } = new List<string>();
        }
        public OneAnswerQuestionContent QuestionContent { get; private set; } = new OneAnswerQuestionContent();
        public override string Content
        {
            get => JsonConvert.SerializeObject(QuestionContent);
            set => QuestionContent = JsonConvert.DeserializeObject<OneAnswerQuestionContent>(value);
        }
        public override double CheckAnswer(Answer answer)
        {
            if (answer.Content == Answer.Content)
                return Points;
            else return 0;
        }

        public override object Clone()
        {
            OneAnswerQuestion result = new OneAnswerQuestion()
            {
                Content = Content,
                Points = Points,
                Answer = (Answer)Answer?.Clone()
            };
            if (result.Answer != null)
                result.Answer.Question = result;
            return result;
        }
        public override string ToString()
        {
            string result = QuestionContent.Text + Environment.NewLine;
            for (int i = 0; i < QuestionContent.Answers.Count; i++)
                result += QuestionContent.Letters[i] + QuestionContent.Devider + " " + QuestionContent.Answers[i] + Environment.NewLine;
            return result;
        }
    }
}
