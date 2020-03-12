namespace SimplExServer.Model
{
    public abstract class MarkSystem
    {
        public string Description { get; set; }
        public abstract string Content { get; set; }
        public abstract double MinMark();
        public abstract double MaxMark();
        public abstract double GetMark(double percent);
        public MarkSystem() { }
        public MarkSystem(MarkSystemData markSystemData)
        {
            Description = markSystemData.Description;
            Content = markSystemData.Content;
        }
        public virtual MarkSystemData GetData()
        {
            return new MarkSystemData()
            {
                Content = Content,
                Description = Description,
                MarkSystemTypeName = GetType().ToString()
            };
        }
    }
}
