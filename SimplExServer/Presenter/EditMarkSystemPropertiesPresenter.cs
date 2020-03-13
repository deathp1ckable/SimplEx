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
        Exam exam;
        readonly Dictionary<Type, IEditMarkSystemPresenter> presenters = new Dictionary<Type, IEditMarkSystemPresenter>();
        public EditMarkSystemPropertiesPresenter(IEditMarkSystemPropertiesView view, IApplicationController applicationController) : base(view, applicationController)
            => view.MarkSystemTypeChanged += MarkSystemTypeChanged;
        private void MarkSystemTypeChanged(IEditMarkSystemPropertiesView sender)
        {
            presenters[sender.MarkSystemType].Integrate(sender.SetEditMarkSystemView);
            exam.MarkSystem = presenters[sender.MarkSystemType].MarkSystem;
        }
        public override void Run(Exam argumnet)
        {
            exam = argumnet;
            presenters.Add(typeof(FiveStepMarkSystem), ApplicationController.Run<EditFiveStepMarkSystemPresenter, MarkSystem>(exam.MarkSystem));
            View.Description = exam.MarkSystem.Description;
            View.MarkSystemType = exam.MarkSystem.GetType();
            View.MarkSystemTypes = new[] { exam.MarkSystem.GetType() };
            MarkSystemTypeChanged(View);
        }
    }
}
