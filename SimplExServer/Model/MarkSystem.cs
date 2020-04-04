using System;
namespace SimplExServer.Model
{
    public abstract class MarkSystem : ICloneable
    {
        public string Description { get; set; } = string.Empty;
        public abstract string Content { get; set; }
        public abstract double MinMark();
        public abstract double MaxMark();
        public abstract double GetMark(double percent);
        public MarkSystem() { }
        public abstract object Clone();
    }
}
