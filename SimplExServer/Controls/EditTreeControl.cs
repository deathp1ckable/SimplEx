using SimplExServer.Model;
using SimplExServer.View;
using System;
using System.Windows.Forms;

namespace SimplExServer.Controls
{
    public partial class EditTreeControl : UserControl, IEditTreeView
    {
        private Theme[] themes;
        private Ticket[] tickets;

        public Theme[] Themes
        {
            get => themes;
            set
            {
                themes = value;
                tree.Nodes["Themes"].Nodes.Clear();
                for (int i = 0; i < themes.Length; i++)
                {
                    TreeNode node = tree.Nodes["Themes"].Nodes.Add("Theme" + themes[i].ThemeName, themes[i].ThemeName);
                    node.Tag = new NodeInfo(NodeType.Theme, themes[i]);
                }
            }
        }
        public Ticket[] Tickets
        {
            get => tickets;
            set
            {
                tickets = value;
                tree.Nodes["Tickets"].Nodes.Clear();
                for (int i = 0, j; i < tickets.Length; i++)
                {
                    TreeNode node = tree.Nodes["Tickets"].Nodes.Add("Ticket" + tickets[i].TicketNumber, "Билет №" + tickets[i].TicketNumber);
                    node.Tag = new NodeInfo(NodeType.Ticket, tickets[i]);
                    for (j = 0; j < tickets[i].QuestionGroups.Length; j++)
                        LoadQuestionGroup(node, tickets[i].QuestionGroups[j]);
                }
            }
        }
        public object CurrentObject { get; private set; }
        public NodeType CurrentNodeType { get; private set; }
        public event Action NodeChanged;
        public EditTreeControl()
        {
            InitializeComponent();
            tree.Nodes["Themes"].Tag = new NodeInfo(NodeType.Themes, null);
            tree.Nodes["Tickets"].Tag = new NodeInfo(NodeType.Tickets, null);
        }
        public void Close() => Dispose();
        private void LoadQuestionGroup(TreeNode parentNode, QuestionGroup group)
        {
            TreeNode node = parentNode.Nodes.Add("QustionGroup" + group.QuestionGroupName, $"Группа '{group.QuestionGroupName}'");
            node.Tag = new NodeInfo(NodeType.QuestionGroup, group);
            for (int i = 0; i < group.ChildQuestionGroups.Length; i++)
                LoadQuestionGroup(node, group.ChildQuestionGroups[i]);
            for (int i = 0; i < group.Questions.Length; i++)
                node.Nodes.Add("Question" + group.Questions[i].QuestionNumber, $"Вопрос №{group.Questions[i].QuestionNumber}").Tag = new NodeInfo(NodeType.Question, group.Questions[i]);
        }
        private void TreeAfterSelect(object sender, TreeViewEventArgs e)
        {
            NodeInfo node = ((NodeInfo)tree.SelectedNode.Tag);
            CurrentNodeType = node.nodeType;
            CurrentObject = node.nodeObj;
            NodeChanged?.Invoke();
        }
        class NodeInfo
        {
            public readonly NodeType nodeType;
            public object nodeObj;
            public NodeInfo(NodeType nodeType, object nodeObj)
            {
                this.nodeType = nodeType;
                this.nodeObj = nodeObj;
            }
        }
    }
}
