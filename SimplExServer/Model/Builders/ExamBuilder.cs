using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplExServer.Model.Builders
{
    class ExamBuilder : IBuilder<Exam>
    {
        private Exam Exam { get; set; }
        public string ExamName { get => Exam.ExamName; set => Exam.ExamName = value; }
        public string Discipline { get => Exam.Discipline; set => Exam.Discipline = value; }
        public string Password { get => Exam.Password; set => Exam.Password = value; }
        public string CreatorName { get => Exam.CreatorName; set => Exam.CreatorName = value; }
        public string CreatorSurname { get => Exam.CreatorSurname; set => Exam.CreatorSurname = value; }
        public string CreatorPatronimyc { get => Exam.CreatorPatronimyc; set => Exam.CreatorPatronimyc = value; }
        public double ExaminationTime { get => Exam.ExaminationTime; set => Exam.ExaminationTime = value; }
        public int FirstNumber { get => Exam.FirstNumber; set => Exam.FirstNumber = value; }
        public string Description { get => Exam.Description; set => Exam.Description = value; } 
        public DateTime? CreationDate { get => Exam.CreationDate; set => Exam.CreationDate = value; }
        public DateTime? LastChangeDate { get => Exam.LastChangeDate; set => Exam.LastChangeDate = value; }
        public ExamBuilder() => Exam = new Exam();
        public ExamBuilder(Exam exam)
        {
            Exam = exam;
            Exam.ExecutionResults = new List<ExecutionResult>();
        }
        public Exam GetBuildedInstance()
        {
            Exam result = Exam;
            Reset();
            return result;
        }
        public void Reset() => Exam = new Exam();
    }
}
