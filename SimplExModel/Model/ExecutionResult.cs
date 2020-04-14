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
        public Ticket Ticket { get; set; }
        public List<ExecutorAnswer> Answers { get; set; } = new List<ExecutorAnswer>();
    }
}
