using SimplExServer.Model;
using SimplExServer.View;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SimplExServer.Controls
{
    public partial class EditTreeControl : UserControl, IEditTreeView
    {
        private List<Theme> themes;
        private List<Ticket> tickets;
        private TreeNode[] bufferedCollection;
        public event ViewActionHandler<IEditTreeView> NodeChanged;
        public event ViewActionHandler<IEditTreeView> StructureChanged;
        public event ViewActionHandler<IEditTreeView> GoToProperties;
        public List<Theme> Themes
        {
            get => themes;
            set
            {
                themes = value;
                tree.Nodes["Themes"].Nodes.Clear();
                for (int i = 0; i < themes.Count; i++)
                {
                    TreeNode node = tree.Nodes["Themes"].Nodes.Add("Theme" + themes[i].ThemeName, themes[i].ThemeName);
                    node.Tag = new NodeInfo(node, NodeType.Theme, themes[i]);
                }
            }
        }
        public List<Ticket> Tickets
        {
            get => tickets;
            set
            {
                tickets = value;
                tree.Nodes["Tickets"].Nodes.Clear();
                for (int i = 0, j; i < tickets.Count; i++)
                {
                    TreeNode node = tree.Nodes["Tickets"].Nodes.Add("Ticket" + tickets[i].TicketNumber, "Билет №" + tickets[i].TicketNumber);
                    node.Tag = new NodeInfo(node, NodeType.Ticket, tickets[i]);
                    for (j = 0; j < tickets[i].QuestionGroups.Count; j++)
                        LoadQuestionGroup(node, tickets[i].QuestionGroups[j]);
                }
            }
        }
        public object CurrentObject { get; private set; }
        public NodeType CurrentNodeType { get; private set; }

        public bool IsSearched => cancelButton.Enabled;

        public EditTreeControl()
        {
            InitializeComponent();
            tree.Nodes["Themes"].Tag = new NodeInfo(tree.Nodes["Themes"], NodeType.Themes, null);
            tree.Nodes["Tickets"].Tag = new NodeInfo(tree.Nodes["Tickets"], NodeType.Tickets, null);
        }
        public void Close() => Dispose();
        private void LoadQuestionGroup(TreeNode parentNode, QuestionGroup group)
        {
            TreeNode node = parentNode.Nodes.Add("QustionGroup" + group.QuestionGroupName, $"Группа '{group.QuestionGroupName}'");
            node.Tag = new NodeInfo(node, NodeType.QuestionGroup, group);
            for (int i = 0; i < group.ChildQuestionGroups.Count; i++)
                LoadQuestionGroup(node, group.ChildQuestionGroups[i]);
            for (int i = 0; i < group.Questions.Count; i++)
            {
                TreeNode treeNode = node.Nodes.Add("Question" + group.Questions[i].QuestionNumber, $"Вопрос №{group.Questions[i].QuestionNumber}");
                treeNode.Tag = new NodeInfo(treeNode, NodeType.Question, group.Questions[i]);
            }
        }
        private void TreeAfterSelect(object sender, TreeViewEventArgs e)
        {
            NodeInfo node = ((NodeInfo)tree.SelectedNode.Tag);
            CurrentNodeType = node.nodeType;
            CurrentObject = node.nodeObj;
            NodeChanged?.Invoke(this);
        }
        private void TreeItemDrag(object sender, ItemDragEventArgs e)
        {
            NodeInfo nodeInfo = ((NodeInfo)((TreeNode)e.Item).Tag);
            if (e.Button == MouseButtons.Left && nodeInfo.nodeType == NodeType.QuestionGroup)
                DoDragDrop(e.Item, DragDropEffects.Move);
        }
        private void TreeDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }
        private void TreeDragOver(object sender, DragEventArgs e)
        {
            Point targetPoint = tree.PointToClient(new Point(e.X, e.Y));
            tree.SelectedNode = tree.GetNodeAt(targetPoint);
            if (((NodeInfo)tree.SelectedNode.Tag).nodeType != NodeType.QuestionGroup)
                e.Effect = DragDropEffects.None;
            else e.Effect = e.AllowedEffect;
        }
        private void TreeDragDrop(object sender, DragEventArgs e)
        {
            Point targetPoint = tree.PointToClient(new Point(e.X, e.Y));
            TreeNode targetNode = tree.GetNodeAt(targetPoint);
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
            if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode) && ((NodeInfo)targetNode.Tag).nodeType == NodeType.QuestionGroup)
            {
                if (e.Effect == DragDropEffects.Move)
                {
                    draggedNode.Remove();
                    targetNode.Nodes.Add(draggedNode);
                    ChangeParenteGroup((QuestionGroup)((NodeInfo)draggedNode.Tag).nodeObj, (QuestionGroup)((NodeInfo)targetNode.Tag).nodeObj);
                }
                targetNode.Expand();
                StructureChanged?.Invoke(this);
            }
        }
        private bool ContainsNode(TreeNode nodeA, TreeNode nodeB)
        {
            if (nodeB.Parent == null) return false;
            if (nodeB.Parent.Equals(nodeA)) return true;
            return ContainsNode(nodeA, nodeB.Parent);
        }
        private void ChangeParenteGroup(QuestionGroup group, QuestionGroup newParent)
        {
            if (group.ParentQuestionGroup != null)
                group.ParentQuestionGroup.ChildQuestionGroups.Remove(group);
            else
                tickets.Where(a => a.QuestionGroups.Contains(group)).FirstOrDefault().QuestionGroups.Remove(group);
            group.ParentQuestionGroup = newParent;
            newParent.ChildQuestionGroups.Add(group);
        }
        private void SearchButtonClick(object sender, EventArgs e)
        {
            if (!searchBox.Items.Contains(searchBox.Text))
                searchBox.SelectedIndex = searchBox.Items.Add(searchBox.Text);
            else searchBox.SelectedIndex = searchBox.Items.IndexOf(searchBox.Text);
            bufferedCollection = new TreeNode[tree.Nodes.Count];
            tree.Nodes.CopyTo(bufferedCollection, 0);
            tree.Nodes.Clear();

            tree.Nodes.Add("Themes", "Темы");
            Theme[] findedThemes = themes.Where(a => a.ToString().Contains(searchBox.Text)).ToArray();
            for (int i = 0; i < findedThemes.Length; i++)
                tree.Nodes["Themes"].Nodes.Add("Theme" + i, themes[i].ThemeName);

            tree.Nodes.Add("Tickets", "Билеты");
            Ticket[] findedTickets = tickets.Where(a => a.ToString().Contains(searchBox.Text)).ToArray();
            for (int i = 0; i < findedThemes.Length; i++)
                tree.Nodes["Tickets"].Nodes.Add("Ticket" + i, "Билет №" + findedTickets[i].TicketNumber);

            tree.Nodes.Add("Groups", "Группы");
            List<QuestionGroup> questionGroups = new List<QuestionGroup>();
            for (int i = 0; i < tickets.Count; i++)
                questionGroups.AddRange(tickets[i].GetQuestionGroups());
            QuestionGroup[] findedQuestionGroups = questionGroups.Where(a => a.ToString().Contains(searchBox.Text)).ToArray();
            for (int i = 0; i < findedQuestionGroups.Length; i++)
                tree.Nodes["Groups"].Nodes.Add("Group" + i, $"Группа '{findedQuestionGroups[i].QuestionGroupName}'");

            tree.Nodes.Add("Questions", "Вопросы");
            List<Question> questions = new List<Question>();
            for (int i = 0; i < tickets.Count; i++)
                questions.AddRange(tickets[i].GetQuestions());
            Question[] findedQuestions = questions.Where(a => a.ToString().Contains(searchBox.Text)).ToArray();
            for (int i = 0; i < findedQuestions.Length; i++)
                tree.Nodes["Questions"].Nodes.Add("Questions" + i, $"Вопрос №{findedQuestions[i].QuestionNumber}");
            cancelButton.Enabled = true;
        }
        private void CancelButtonClick(object sender, EventArgs e)
        {
            tree.Nodes.Clear();
            tree.Nodes.AddRange(bufferedCollection);
            cancelButton.Enabled = false;
        }
        private void TreeMouseDoubleClick(object sender, MouseEventArgs e) => GoToProperties?.Invoke(this);
        private void SearchBoxSelectedTextChanged(object sender, EventArgs e)
        {
            if (searchBox.Text.Length > 0)
                searchButton.Enabled = true;
            else searchButton.Enabled = false;
        }
        class NodeInfo
        {
            public readonly TreeNode node;
            public readonly NodeType nodeType;
            public object nodeObj;
            public NodeInfo(TreeNode node, NodeType nodeType, object nodeObj)
            {
                this.node = node;
                this.nodeType = nodeType;
                this.nodeObj = nodeObj;
            }
        }
    }
}
