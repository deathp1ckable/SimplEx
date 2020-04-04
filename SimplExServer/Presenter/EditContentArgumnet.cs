using SimplExServer.Builders;
using SimplExServer.View;

namespace SimplExServer.Presenter
{
    class EditContentArgumnet
    {
        public ExamBuilder ExamBuilder { get; private set; }
        public IEditTreeView EditTreeView { get; private set; }
        public EditContentArgumnet(ExamBuilder examBuilder, IEditTreeView editTreeView)
        {
            ExamBuilder = examBuilder;
            EditTreeView = editTreeView;
        }
    }
}
