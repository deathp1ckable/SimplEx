using SimplExClient.Common;
using SimplExClient.View;
using SimplExModel.NetworkData;
using System;
using System.Collections.Generic;

namespace SimplExClient.Presenter
{
    class SessionInformationPresenter : IntegrablePresenter<ClientArgument, ISessionInformationView>
    {
        List<string> violations = new List<string>();
        public SessionInformationPresenter(ISessionInformationView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.Shown += ViewShown;
            view.ClientDataChanged += ViewClientDataChanged;
        }

        public override void Run(ClientArgument argument)
        {
            Argument = argument;

            View.ClientStatus = Argument.Client.ClientStatus;

            View.ExamName = Argument.Client.Exam.Name;
            View.Discipline = Argument.Client.Exam.Discipline;
            View.Description = Argument.Client.Exam.Description;
            View.CreatorName = Argument.Client.Exam.CreatorName;
            View.CreatorSurname = Argument.Client.Exam.CreatorSurname;
            View.CreatorPatronymic = Argument.Client.Exam.CreatorPatronymic;
            View.ExaminationTime = Argument.Client.Exam.Time;
            View.FirstQuestionNumber = Argument.Client.Exam.FirstQuestionNumber;
            View.MarkSystemType = Argument.Client.Exam.MarkSystem.GetType();
            View.MarkSystemDescription = Argument.Client.Exam.Description;
            View.TeacherName = Argument.Client.TeacherName;
            View.TeacherSurname = Argument.Client.TeacherSurname;
            View.TeacherPatronymic = Argument.Client.TeacherPatronymic;
            View.GroupName = Argument.Client.GroupName;
            View.ReconnectionTime = Argument.Client.ReconnectionTime;
            View.ViolationsLimit = Argument.Client.ViolationsLimit;
            View.EnableChat = Argument.Client.EnableChat;
            View.Mixing = Argument.Client.Mixing;
            View.TrackStatus = Argument.Client.TrackStatus;
            View.Tickets = Argument.Client.Exam.Tickets;
            View.ConnectionName = Argument.Client.Name;
            View.ConnectionSurname = Argument.Client.Surname;
            View.ConnectionPatronymic = Argument.Client.Patronymic;
            View.CurrentTicket = Argument.Client.Ticket;

            View.MinMark = Argument.Client.Exam.MarkSystem.MinMark();
            View.MaxMark = Argument.Client.Exam.MarkSystem.MaxMark();

            View.MaxPoints = Argument.Client.Ticket.MaxPoints;
            View.MinPoints = 0;

            View.ExecutedQuestions = Argument.Client.Answers.Count;
            View.CurrentQuestionNumber = Argument.Client.Exam.FirstQuestionNumber + Argument.Client.CurrentQuestionNumber;

            Argument.Client.StatusChanged += ArgumentStatusChanged;
            Argument.Client.Violation += ArgumentViolation;
        }

        private void ViewClientDataChanged(ISessionInformationView sender)
        {
            Argument.Client.UpdateClientConnectionData(new ClientConnectionData(sender.ConnectionName, sender.ConnectionSurname, sender.ConnectionPatronymic, sender.CurrentTicket.TicketNumber));
            Argument.MainView.Ticket = sender.CurrentTicket;
            View.MaxPoints = sender.CurrentTicket.MaxPoints;
            View.MinPoints = 0;
        }

        private void ViewShown(ISessionInformationView sender)
        {
            View.ExecutedQuestions = Argument.Client.Answers.Count;
            View.CurrentQuestionNumber = Argument.Client.Exam.FirstQuestionNumber + Argument.Client.CurrentQuestionNumber;

            RefreshViolations();
        }

        private void ArgumentViolation(object sender, EventArgs e)
        {
            View.Invoke(() =>
            {
                RefreshViolations();
            });
        }

        private void ArgumentStatusChanged(object sender, EventArgs e)
        {
            View.Invoke(() =>
            {
                View.ClientStatus = Argument.Client.ClientStatus;
            });
        }
        private void RefreshViolations()
        {
            violations.Clear();
            for (int i = 0; i < Argument.Client.Violations.Count; i++)
                violations.Add($"№{i + 1} [{Argument.Client.BeginingTime.Value.AddSeconds(Argument.Client.Violations[i].TimeOffset)}] " +
                    $"{Argument.Client.Violations[i].Content}");
            View.Violations = violations;
        }
    }
}
