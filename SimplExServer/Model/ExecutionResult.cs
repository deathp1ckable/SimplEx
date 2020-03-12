using System;
namespace SimplExServer.Model
{
    public class ExecutionResult
    {
        public string ExecutorName { get; set; }
        public string ExecutorSurname { get; set; }
        public string ExecutorPatronimyc { get; set; }
        public string ExecutorGroup { get; set; }
        public DateTime ExecutionDate { get; set; }
        public double ExecutionTime { get; set; }
        public double Mark { get; set; }
        public ExecutorAnswer[] Answers { get; set; }
    }
}
