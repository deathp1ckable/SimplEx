using SimplExServer.View;
using System.Drawing;
using System.Windows.Forms;

namespace SimplExServer.Forms
{
    public partial class EditPropertiesForm : Form, IEditDetachedView
    {
        public IIntegrableView View { get; private set; }
        public event ViewActionHandler<IEditDetachedView> WindowActivated;
        public EditPropertiesForm()
        {
            InitializeComponent();
        }

        public void SetView(IIntegrableView view)
        {
            View = view;
            UserControl control = (UserControl)View;
            control.Parent = propertiesPanel;
            control.Size = propertiesPanel.Size;
            control.Location = new Point(0, 0);
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }
        private void EditPropertiesFormActivated(object sender, System.EventArgs e) => WindowActivated?.Invoke(this);
    }
}
