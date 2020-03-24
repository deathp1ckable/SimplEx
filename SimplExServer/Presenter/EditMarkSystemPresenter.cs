using SimplExServer.Builders;
using SimplExServer.Common;
using SimplExServer.View;
using System;
using System.Collections.Generic;

namespace SimplExServer.Presenter
{
    class EditMarkSystemPresenter : IntegrablePresenter<ExamBuilder, IEditMarkSystemPropertiesView>
    {
        readonly Dictionary<Type, IEditMarkSystemPresenter> presenters = new Dictionary<Type, IEditMarkSystemPresenter>();
        public EditMarkSystemPresenter(IEditMarkSystemPropertiesView view, IApplicationController applicationController) : base(view, applicationController)
            => view.MarkSystemTypeChanged += MarkSystemTypeChanged;
        private void MarkSystemTypeChanged(IEditMarkSystemPropertiesView sender)
        {
            presenters[sender.MarkSystemType].Integrate(sender.SetEditMarkSystemView);
            Argumnet.MarkSystemBuilder = presenters[sender.MarkSystemType].MarkSystem;
        }
        public override void Run(ExamBuilder argumnet)
        {
            Argumnet = argumnet;
            presenters.Add(typeof(FiveStepMarkSystemBuilder), ApplicationController.Run<EditFiveStepMarkSystemPresenter, MarkSystemBuilder>(Argumnet.MarkSystemBuilder));
            View.Description = Argumnet.MarkSystemBuilder.Description;
            View.MarkSystemType = Argumnet.MarkSystemBuilder.GetType();
            View.MarkSystemTypes = new[] { Argumnet.MarkSystemBuilder.GetType() };
            MarkSystemTypeChanged(View);
        }
    }
}
