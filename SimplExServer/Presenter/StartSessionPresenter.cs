using SimplExServer.Common;
using SimplExServer.Service;
using SimplExServer.View;
using SimplExModel.NetworkData;
using System.Threading.Tasks;
using System;

namespace SimplExServer.Presenter
{
    class StartSessionPresenter : Presenter<StartSessionArgument, IStartSessionView>
    {
        public StartSessionPresenter(IStartSessionView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.Canceled += ViewCanceled;
            view.Started += ViewStarted;
        }

        private void ViewStarted(IStartSessionView sender)
        {
            SessionService sessionService = SessionService.GetInstance();
            Session session = new Session(new ServerConnectionData(Argument.Exam, View.GroupName.Trim(), 
                View.TeacherName.Trim(), 
                View.TeacherSurname.Trim(), 
                View.TeacherPatronymic.Trim(), 
                View.EnableChat, 
                View.TrackStatusCheck, 
                View.Mixing, 
                View.ViolationsLimit, 
                View.ReconnectionTime),
                View.SaveResults ? Argument.ExamSaver : null);
            sessionService.Session = session;
            session.SessionInitialized += SessionSessionInitialized;
            session.InitializationFailed += SessionInitializationFailed;
            ApplicationController.Run<LoadingContextPresenter<object>, Task<object>>(Task.Run(() =>
            {
                session.Initialize();
                return LoadingContextPresenter<object>.EmptyObject;
            }));
        }

        private void SessionInitializationFailed(object sender, EventArgs e)
        {
            View.Invoke(() =>
            {
                Session session = sender as Session;
                session.InitializationFailed -= SessionInitializationFailed;
                View.ShowError("Не удалось запустить сессию.");
            });
        }
        private void SessionSessionInitialized(object sender, EventArgs e)
        {
            View.Invoke(() =>
            {
                Session session = sender as Session;
                session.SessionInitialized -= SessionSessionInitialized;
                View.Hide();
                ApplicationController.Run<SessionPresenter, Session>(session);
                View.Close();
            });
        }
        private void ViewCanceled(IStartSessionView sender)
        {
            sender.Close();
        }
    }
}
