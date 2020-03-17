using SimplExServer.Common;
using SimplExServer.Model;
using SimplExServer.Model.Inherited;
using SimplExServer.View;
using System;
using System.Collections.Generic;

namespace SimplExServer.Presenter
{
    class EditMarkSystemPropertiesPresenter : IntegrablePresenter<Exam, IEditMarkSystemPropertiesView>
    {
        readonly Dictionary<Type, IEditMarkSystemPresenter> presenters = new Dictionary<Type, IEditMarkSystemPresenter>();
        public EditMarkSystemPropertiesPresenter(IEditMarkSystemPropertiesView view, IApplicationController applicationController) : base(view, applicationController)
            => view.MarkSystemTypeChanged += MarkSystemTypeChanged;
        private void MarkSystemTypeChanged(IEditMarkSystemPropertiesView sender)
        {
            presenters[sender.MarkSystemType].Integrate(sender.SetEditMarkSystemView);
            Argumnet.MarkSystem = presenters[sender.MarkSystemType].MarkSystem;
        }
        public override void Run(Exam argumnet)
        {
            Argumnet = argumnet;
            presenters.Add(typeof(FiveStepMarkSystem), ApplicationController.Run<EditFiveStepMarkSystemPresenter, MarkSystem>(Argumnet.MarkSystem));
            View.Description = Argumnet.MarkSystem.Description;
            View.MarkSystemType = Argumnet.MarkSystem.GetType();
            View.MarkSystemTypes = new[] { Argumnet.MarkSystem.GetType() };
            MarkSystemTypeChanged(View);
        }
    }
}
