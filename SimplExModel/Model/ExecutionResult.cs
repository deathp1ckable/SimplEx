using System;
using System.Collections.Generic;
namespace SimplExModel.Model
{
    public class ExecutionResult
    {
        public string ExecutorName { get; set; } = string.Empty;
        public string ExecutorSurname { get; set; } = string.Empty;
        public string ExecutorPatronymic { get; set; } = string.Empty;
        public string ExecutorGroup { get; set; } = string.Empty;
        public DateTime? ExecutionDate { get; set; }
        public double ExecutionTime { get; set; }
        public double Mark { get; set; }
        public double Points
        {
            get
            {
                double result = 0;
                Answer temp = new Answer();
                for (int i = 0; i < Answers.Count; i++)
                {
                    temp.Question = Answers[i].Question;
                    temp.Content = Answers[i].Content;
                    if (Answers[i].Question.Answer is null)
                        continue;
                    result += Answers[i].Question.CheckAnswer(temp);
                }
                return result;
            }
        }
        public Ticket Ticket { get; set; }
        public List<ExecutorAnswer> Answers { get; set; } = new List<ExecutorAnswer>();
    }
}
