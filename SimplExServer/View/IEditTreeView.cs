using SimplExServer.Builders;
using System.Collections.Generic;
namespace SimplExServer.View
{
    public interface IEditTreeView : IHideableView
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
        event ViewActionHandler<IEditTreeView> Refreshed;
        event ViewActionHandler<IEditTreeView, StructChangedArgs> StructureChanged;
        event ViewActionHandler<IEditTreeView, QuestionCopiedArgs> QuestionCopied;
        event ViewActionHandler<IEditTreeView, QuestionPastedArgs> QuestionPasted;
        event ViewActionHandler<IEditTreeView, QuestionGroupCopiedArgs> QuestionGroupCopied;
        event ViewActionHandler<IEditTreeView, QuestionGroupPastedArgs> QuestionGroupPasted;
        void SelectObject(object obj);
        void SelectObject(Section section);
        void RefreshTickets();
        void RefreshThemes();
        void RefreshObject(object obj);
    }
    public enum Section { Themes, Tickets };
}
