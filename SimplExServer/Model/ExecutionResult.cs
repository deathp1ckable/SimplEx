using System;
using System.Collections.Generic;

namespace SimplExServer.Model
{
    public class ExecutionResult
    {
        public string ExecutorName { get; set; } = string.Empty;
        public string ExecutorSurname { get; set; } = string.Empty;
        public string ExecutorPatronimyc { get; set; } = string.Empty;
        public string ExecutorGroup { get; set; } = string.Empty;
        public DateTime ExecutionDate { get; set; }
        public double ExecutionTime { get; set; }
        public double Mark { get; set; }
        public List<ExecutorAnswer> Answers { get; set; } = new List<ExecutorAnswer>();
        public override string ToString() => $"{ExecutorName} {ExecutorPatronimyc} {ExecutorGroup} {ExecutionDate} {ExecutionTime} {Mark}";
    }
}
