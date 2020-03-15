using SimplExServer.Model;
using System;
using System.Collections.Generic;
namespace SimplExServer.View
{
    public interface IEditTreeView : IView
    {
        List<Theme> Themes { get; set; }
        List<Ticket> Tickets { get; set; }
        object CurrentObject { get; }
        string SearchText { get; set; }
        bool IsSearched { get; }
        bool IsCopied { get; }
        object[] SearchResult { set; }
        event ViewActionHandler<IEditTreeView> NodeChanged;
        event ViewActionHandler<IEditTreeView> GoToProperties;
        event ViewActionHandler<IEditTreeView> Searched;
        event ViewActionHandler<IEditTreeView> Pasted;
        event ViewActionHandler<IEditTreeView> Copied;
        event ViewActionHandler<IEditTreeView, StructChangedArgs> StructureChanged;
    }
    public class StructChangedArgs : EventArgs
    {
        public QuestionGroup Group { get; private set; }
        public QuestionGroup NewParentGroup { get; private set; }
        public Ticket Ticket { get; private set; }
        public StructChangedArgs(QuestionGroup group, QuestionGroup newParentGroup)
        {
            Group = group;
            NewParentGroup = newParentGroup;
        }
        public StructChangedArgs(QuestionGroup group, Ticket ticket)
        {
            Group = group;
            Ticket = ticket;
        }
    }
}
