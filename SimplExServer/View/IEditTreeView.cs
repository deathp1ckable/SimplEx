using SimplExServer.Model;
using System;
namespace SimplExServer.View
{
    public interface IEditTreeView : IView
    {
        Theme[] Themes { get; set; }
        Ticket[] Tickets { get; set; }
        object CurrentObject { get; }
        NodeType CurrentNodeType { get; }
        event Action NodeChanged;
    }
    public enum NodeType { Themes, Theme, Tickets, Ticket, QuestionGroup, Question };
}
