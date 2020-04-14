using SimplExClient.Common;
using SimplExClient.View;

namespace SimplExClient.Presenter
{
    class ResultPresenter : Presenter<ResultArgument, IResultView>
    {
        public ResultPresenter(IResultView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.Continued += ViewContinued;
        }
        public override void Run(ResultArgument argument)
        {
            Argument = argument;
            View.Result = Argument.Result;
            View.Mark = Argument.Mark;
            View.Points = Argument.Points;
            View.Show();
        }
        private void ViewContinued(IResultView sender)
        {
            View.Close();
        }
    }
}
