using Newtonsoft.Json.Serialization;
using System;
namespace SimplExServer.Model.Data
{
    public class MarkSystemData
    {
        public string MarkSystemTypeName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public MarkSystemData()
        { }
        public MarkSystemData(MarkSystem markSystem)
        {
            MarkSystemTypeName = markSystem.GetType().ToString();
            Description = markSystem.Description;
            Content = markSystem.Content;
        }
        public MarkSystem CreateMarkSystem()
        {
            MarkSystem result = (MarkSystem)Activator.CreateInstance(Type.GetType(MarkSystemTypeName));
            result.Content = Content;
            result.Description = Description;
            return result;
        }
    }
}
