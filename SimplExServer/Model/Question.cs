using System.Collections.Generic;
using System;
namespace SimplExServer.Model
{
    public abstract class Question : ICloneable
    {
        public int QuestionNumber { get; set; }
        public int TicketNumber { get; set; }
        public double Points { get; set; }
        public abstract string Content { get; set; }
        public Answer RightAnswer { get; set; }
        public Theme QuestionTheme { get; set; }
        public abstract double CheckAnswer(Answer answer);
        public Question() { }
        public Question(QuestionData questionData)
        {
            Content = questionData.Content;
            QuestionNumber = questionData.QuestionNumber;
            Points = questionData.Points;
            RightAnswer = questionData.RightAnswer;
            QuestionTheme = questionData.QuestionTheme;
            TicketNumber = questionData.TicketNumber;
        }
        public virtual QuestionData GetData()
        {
            return new QuestionData()
            {
                Content = Content,
                QuestionNumber = QuestionNumber,
                Points = Points,
                RightAnswer = RightAnswer,
                QuestionTheme = QuestionTheme,
                TicketNumber = TicketNumber,
                QuestionTypeName = GetType().ToString()
            };
        }
        public override string ToString() => $"{QuestionNumber} {TicketNumber} {Points} {Content} {RightAnswer?.Content ?? ""} {QuestionTheme?.ThemeName ?? ""}";
        public abstract object Clone();
    }
}
