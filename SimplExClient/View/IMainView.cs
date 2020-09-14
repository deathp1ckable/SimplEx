using System.Collections.Generic;
using SimplExModel.Model;
using SimplExModel.NetworkData;

namespace SimplExClient.View
{
    public interface IMainView : IHideableView
    {
        int FirstQuestionNumber { set; }
        double Time { get; set; }
        string GroupName { get; set; }
        Ticket Ticket { get; set; }
        IList<Theme> Themes { get; set; }
        ClientStatus ClientStatus { get; set; }

        Question CurrentQuestion { get; }

        int ExexutedQuestions { set; }

        ISessionInformationView SessionInformationView { get; set; }
        IQuestionView QuestionView { get; set; }
        IChatView ChatView { get; set; }

        event ViewActionHandler<IMainView> QuestionChanged;
        event ViewActionHandler<IMainView> ViewLeaved;
        event ViewActionHandler<IMainView> Disconnected;

        void ShowChatToolTip();
        void WarnAboutStart();

        bool SelectNextQuestion();
        bool SelectPrevQuestion();

        void ShowError(string message);
        void Invoke(Action action);
    }
}
