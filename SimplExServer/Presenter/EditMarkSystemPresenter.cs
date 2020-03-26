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
          => view.MarkSystemTypeChanged += MarkSystemTypeChanged;

        public override void Run(ExamBuilder argumnet)
        {
            Argument = argumnet;

            presenters.Add(ApplicationController.Run<EditFiveStepMarkSystemPresenter, MarkSystemBuilder>(Argument.MarkSystemBuilder));

            View.Description = Argument.MarkSystemBuilder.Description;
            View.MarkSystemTypes = new[] { typeof(FiveStepMarkSystemBuilder) };
            View.MarkSystemType = Argument.MarkSystemBuilder.GetType();
            MarkSystemTypeChanged(View);
        }

        private void MarkSystemTypeChanged(IEditMarkSystemPropertiesView sender)
        {
            IEditMarkSystemPresenter presenter = GetMarkSystemPresenter(sender.MarkSystemType);
            presenter.Integrate(sender.SetEditMarkSystemView);
            Argument.MarkSystemBuilder = presenter.MarkSystemBuilder;
        }
        private IEditMarkSystemPresenter GetMarkSystemPresenter(Type markSystemType) => presenters.Single(a => a.MarkSystemBuilder.GetType() == markSystemType);
    }
}
