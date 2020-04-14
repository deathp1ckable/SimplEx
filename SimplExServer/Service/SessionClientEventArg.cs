using System;

namespace SimplExServer.Service
{
    class SessionClientEventArg : EventArgs
    {
        public SessionClient SessionClient { get; private set; }
        public SessionClientEventArg(SessionClient sessionClient)
        {
            SessionClient = sessionClient;
        }

    }
}
