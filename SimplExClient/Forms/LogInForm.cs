using SimplExClient.View;
using System.Windows.Forms;
namespace SimplExClient
{
    public partial class LogInForm : Form, ILogInView
    {
        private ApplicationContext context;
        public LogInForm(ApplicationContext context)
        {
            InitializeComponent();
            this.context = context;
        }
        public new void Show()
        {
            context.MainForm = this;
            base.Show();
        }
    }
}
