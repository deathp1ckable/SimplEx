using System;
using System.Collections.Generic;

namespace SimplExModel.Model
{
    public class Theme : ICloneable
    {
        public int ThemeNumber { get; set; }
        public string ThemeName { get; set; } = string.Empty;
        public Question[] GetQuestions(Ticket ticket)
        {
            List<Question> result = new List<Question>();
            Question[] questions = ticket.GetQuestions();
            for (int i = 0; i < questions.Length; i++)
                if (questions[i].Theme.ThemeNumber == ThemeNumber)
                    result.Add(questions[i]);
            return result.ToArray();
        }
        public object Clone() => MemberwiseClone();
    }
}
