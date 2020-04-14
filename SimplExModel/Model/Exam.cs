using SimplExModel.Model.Inherited;
using SimplExModel.Service;
using System;
using System.Collections.Generic;

namespace SimplExModel.Model
{
    public class Exam : ICloneable
    {
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Discipline { get; set; } = string.Empty;
        public string CreatorName { get; set; } = string.Empty;
        public string CreatorSurname { get; set; } = string.Empty;
        public string CreatorPatronymic { get; set; } = string.Empty;
        public DateTime? CreationDate { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public double Time { get; set; }
        public int FirstNumber { get; set; } = 1;
        public string Description { get; set; } = string.Empty;
        public List<Theme> Themes { get; set; } = new List<Theme>();
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
        public List<ExecutionResult> ExecutionResults { get; set; } = new List<ExecutionResult>();
        public MarkSystem MarkSystem { get; set; } = new FiveStepMarkSystem();
        public object Clone() => DeepCloner.Clone(this);
    }
}
