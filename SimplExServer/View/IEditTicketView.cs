using SimplExServer.Builders;
using System.Collections.Generic;

namespace SimplExServer.View
{
    public interface IEditTicketView : IHideableView
    {
        QuestionBuilder CurrentQuestion { get; }
        IList<QuestionBuilder> Questions { get; set; }
        string TicketName { get; set; }
        int GroupsCount { set; }
        int QuestionsCount { set; }

        event ViewActionHandler<IEditTicketView> GroupAdded;
        event ViewActionHandler<IEditTicketView> Deleted;
        event ViewActionHandler<IEditTicketView> Saved;
        event ViewActionHandler<IEditTicketView> QuestionWatched;
        event ViewActionHandler<IEditTicketView> Changed;
        event ViewActionHandler<IEditTicketView> Shown;
        event ViewActionHandler<IEditTicketView> Hiden;

        void AskForSaving();
    }
}
