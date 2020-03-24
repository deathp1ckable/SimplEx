using SimplExServer.Builders;
using SimplExServer.Model;
using System;
using System.Collections.Generic;
namespace SimplExServer.View
{
    public interface IEditTreeView : IView
    {
        IList<ThemeBuilder> ThemeBuilders { get; set; }
        IList<TicketBuilder> TicketBuilders { get; set; }
        Section CurrentSection { get; }
        object CurrentObject { get; }
        string SearchText { get; set; }
        object[] SearchResult { set; }
        event ViewActionHandler<IEditTreeView> NodeChanged;
        event ViewActionHandler<IEditTreeView> GoToProperties;
        event ViewActionHandler<IEditTreeView> Searched;
        event ViewActionHandler<IEditTreeView, StructChangedArgs> StructureChanged;
        event ViewActionHandler<IEditTreeView, QuestionCopiedArgs> QuestionCopied;
        event ViewActionHandler<IEditTreeView, QuestionPastedArgs> QuestionPasted;
        event ViewActionHandler<IEditTreeView, QuestionGroupCopiedArgs> QuestionGroupCopied;
        event ViewActionHandler<IEditTreeView, QuestionGroupPastedArgs> QuestionGroupPasted;

        void SelectObject(object obj);
        void RefreshTickets();
        void RefreshThemes();
    }
    public enum Section { Themes, Tickets };
    public class StructChangedArgs : EventArgs
    {
        public QuestionGroupBuilder Group { get; private set; }
        public QuestionGroupBuilder NewParentGroup { get; private set; }
        public TicketBuilder Ticket { get; private set; }
        public StructChangedArgs(QuestionGroupBuilder group, QuestionGroupBuilder newParentGroup)
        {
            Group = group;
            NewParentGroup = newParentGroup;
        }
        public StructChangedArgs(QuestionGroupBuilder group, TicketBuilder ticket)
        {
            Group = group;
            Ticket = ticket;
        }
    }
    public class QuestionCopiedArgs : EventArgs
    {
        public bool IsCut { get; private set; }
        public QuestionBuilder QuestionBuilder { get; private set; }
        public QuestionCopiedArgs(bool isCut, QuestionBuilder questionBuilder)
        {
            IsCut = isCut;
            QuestionBuilder = questionBuilder;
        }
    }
    public class QuestionPastedArgs : EventArgs
    {
        public QuestionGroupBuilder QuestionGroupBuilder { get; private set; }
        public QuestionPastedArgs(QuestionGroupBuilder questionGroupBuilder)
        {
            QuestionGroupBuilder = questionGroupBuilder;
        }
    }
    public class QuestionGroupCopiedArgs : EventArgs
    {
        public bool IsCut { get; private set; }
        public QuestionGroupBuilder QuestionBuilder { get; private set; }
        public QuestionGroupCopiedArgs(bool isCut, QuestionGroupBuilder questionBuilder)
        {
            IsCut = isCut;
            QuestionBuilder = questionBuilder;
        }
    }
    public class QuestionGroupPastedArgs : EventArgs
    {
        public TicketBuilder TicketBuilder { get; private set; }
        public QuestionGroupBuilder QuestionGroupBuilder { get; private set; }
        public QuestionGroupPastedArgs(TicketBuilder ticketBuilder)
        {
            TicketBuilder = ticketBuilder;
        }
        public QuestionGroupPastedArgs(QuestionGroupBuilder questionBuilder)
        {
            QuestionGroupBuilder = questionBuilder;
        }
    }
}
