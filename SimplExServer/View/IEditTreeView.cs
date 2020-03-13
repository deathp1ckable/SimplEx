using SimplExServer.Model;
using System.Collections.Generic;
namespace SimplExServer.View
{
    public interface IEditTreeView : IView
    {
        List<Theme> Themes { get; set; }
        List<Ticket> Tickets { get; set; }
        object CurrentObject { get; }
        bool IsSearched { get; }
        NodeType CurrentNodeType { get; }
        event ViewActionHandler<IEditTreeView> NodeChanged;
        event ViewActionHandler<IEditTreeView> StructureChanged;
        event ViewActionHandler<IEditTreeView> GoToProperties;
    }
    public enum NodeType { Themes, Theme, Tickets, Ticket, QuestionGroup, Question };
}
