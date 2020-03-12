using SimplExServer.Common;
using SimplExServer.Model;
using SimplExServer.Model.Inherited;
using SimplExServer.View;
using System;

namespace SimplExServer.Presenter
{
    class EditFiveStepMarkSystemPresenter : IntegrablePresenter<MarkSystem, IEditFiveStepMarkSystemView>, IEditMarkSystemPresenter
    {
        FiveStepMarkSystem fiveStepMarkSystem;
        public MarkSystem MarkSystem { get => fiveStepMarkSystem; set => fiveStepMarkSystem = (FiveStepMarkSystem)value; }
        public EditFiveStepMarkSystemPresenter(IEditFiveStepMarkSystemView view, IApplicationController applicationController) : base(view, applicationController)
        {
            View.SaveChanges += SaveChanges;
            View.Changed += Changed;
            View.CancelChanges += CancelChanges;
        }
        private void SaveChanges()
        {
            fiveStepMarkSystem.fivePercent = View.FivePercent;
            fiveStepMarkSystem.fourPercent = View.FourPercent;
            fiveStepMarkSystem.threePercent = View.ThreePercent;
            fiveStepMarkSystem.twoPercent = View.TwoPercent;
            fiveStepMarkSystem.onePercent = View.OnePercent;
            View.Saved = true;
        }
        private void CancelChanges()
        {
            View.FivePercent = fiveStepMarkSystem.fivePercent;
            View.FourPercent = fiveStepMarkSystem.fourPercent;
            View.ThreePercent = fiveStepMarkSystem.threePercent;
            View.TwoPercent = fiveStepMarkSystem.twoPercent;
            View.OnePercent = fiveStepMarkSystem.onePercent;
            View.Saved = true;
        }
        private void Changed() => View.Saved = false;
        public override void Run(MarkSystem argumnet)
        {
            MarkSystem = argumnet;
            View.FivePercent = fiveStepMarkSystem.fivePercent;
            View.FourPercent = fiveStepMarkSystem.fourPercent;
            View.ThreePercent = fiveStepMarkSystem.threePercent;
            View.TwoPercent = fiveStepMarkSystem.twoPercent;
            View.OnePercent = fiveStepMarkSystem.onePercent;
            View.Saved = true;
        }
        public void Integrate(Action<IEditMarkSystemView> integrator) => base.Integrate(integrator);
    }
}
