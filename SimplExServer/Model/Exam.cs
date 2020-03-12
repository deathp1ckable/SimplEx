using System;
namespace SimplExServer.Model
{
    public class Exam
    {
        public string ExamName { get; set; }
        public string Discipline { get; set; }
        public string Password { get; set; }
        public string CreatorName { get; set; }
        public string CreatorSurname { get; set; }
        public string CreatorPatronimyc { get; set; }
        public double ExaminationTime { get; set; }
        public int FirstNumber { get; set; }
        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public Theme[] Themes { get; set; }
        public Ticket[] Tickets { get; set; }
        public ExecutionResult[] ExecutionResults { get; set; }
        public MarkSystem MarkSystem { get; set; }
    }
}
