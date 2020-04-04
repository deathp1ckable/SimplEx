using SimplExServer.Builders;
using SimplExServer.Common;
using SimplExServer.View;
using System.Linq;
using System.Collections.Generic;
using System;

namespace SimplExServer.Presenter
{
    class EditMarkSystemPresenter : IntegrablePresenter<ExamBuilder, IEditMarkSystemPropertiesView>
    {
        private readonly List<IEditMarkSystemPresenter> presenters = new List<IEditMarkSystemPresenter>();

        public EditMarkSystemPresenter(IEditMarkSystemPropertiesView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.MarkSystemTypeChanged += MarkSystemTypeChanged;
            view.Saved += ViewSaveChanges;
            view.Canceled += ViewCanceled;
        }
        public override void Run(ExamBuilder argument)
        {
            Argument = argument;

            presenters.Add(ApplicationController.Run<EditFiveStepMarkSystemPresenter, MarkSystemBuilder>(Argument.MarkSystemBuilder));

            View.Description = Argument.MarkSystemBuilder.Description;
            View.MarkSystemTypes = new[] { typeof(FiveStepMarkSystemBuilder) };
            View.MarkSystemType = Argument.MarkSystemBuilder.GetType();
            MarkSystemTypeChanged(View);
        }
        private void ViewCanceled(IEditMarkSystemPropertiesView sender)
        {
            sender.Description = Argument.MarkSystemBuilder.Description;
            sender.MarkSystemType = Argument.MarkSystemBuilder.GetType();
            sender.EditMarkSystemView = GetMarkSystemPresenter(sender.MarkSystemType).View;
        }
        private void ViewSaveChanges(IEditMarkSystemPropertiesView sender)
        {
            Argument.MarkSystemBuilder = GetMarkSystemPresenter(sender.MarkSystemType).MarkSystemBuilder;
            Argument.MarkSystemBuilder.Description = sender.Description;
        }
        private void MarkSystemTypeChanged(IEditMarkSystemPropertiesView sender)
        {
            IEditMarkSystemPresenter presenter = GetMarkSystemPresenter(sender.MarkSystemType);
            sender.EditMarkSystemView  = presenter.View;
            Argument.MarkSystemBuilder = presenter.MarkSystemBuilder;
        }
        private IEditMarkSystemPresenter GetMarkSystemPresenter(Type markSystemType) => presenters.Single(a => a.MarkSystemBuilder.GetType() == markSystemType);
    }
}
