using SimplExServer.Service;
using SimplExServer.View;

namespace SimplExServer.Presenter
{
    class SessionArgument
    {
        public Session Session { get; private set; }
        public ISessionView SessionView { get; private set; }
        public SessionArgument(Session session, ISessionView sessionView)
        {
            Session = session;
            SessionView = sessionView;
        }
    }
}
