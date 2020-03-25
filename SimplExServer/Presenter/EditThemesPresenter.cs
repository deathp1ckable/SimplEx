using SimplExServer.Builders;
using SimplExServer.Common;
using SimplExServer.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplExServer.Presenter
{
    class EditThemesPresenter : IntegrablePresenter<EditArgumnet, IEditThemesView>
    {
        public EditThemesPresenter(IEditThemesView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.ThemeAdded += ViewThemeAdded;
        }
        private void ViewThemeAdded(IEditThemesView sender)
        {
            ThemeBuilder builder = Argumnet.ExamBuilder.AddTheme("Новая Тема");
            Argumnet.EditTreeView.RefreshThemes();
            Argumnet.EditTreeView.SelectObject(builder);
        }
    }
    class EditArgumnet
    {
        public ExamBuilder ExamBuilder { get; private set; }
        public IEditTreeView EditTreeView { get; private set; }
        public EditArgumnet(ExamBuilder examBuilder, IEditTreeView editTreeView)
        {
            ExamBuilder = examBuilder;
            EditTreeView = editTreeView;
        }
    }
}
