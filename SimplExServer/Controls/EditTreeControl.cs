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
        private ContextMenu contextMenu;
        public event ViewActionHandler<IEditTreeView> Pasted;
        public event ViewActionHandler<IEditTreeView> NodeChanged;
        public event ViewActionHandler<IEditTreeView> GoToProperties;
        public event ViewActionHandler<IEditTreeView> Searched;
        public event ViewActionHandler<IEditTreeView> Copied;
        public event ViewActionHandler<IEditTreeView, StructChangedArgs> StructureChanged;

        public List<Theme> Themes
        {
            get => themes;
            set
            {
                themes = value;
                tree.Nodes["Themes"].Nodes.Clear();
                for (int i = 0; i < themes.Count; i++)
                    tree.Nodes["Themes"].Nodes.Add($"Тема '{themes[i].ThemeName}'").Tag = themes[i];
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
                    TreeNode node = tree.Nodes["Tickets"].Nodes.Add("Билет №" + tickets[i].TicketNumber);
                    node.Tag = tickets[i];
                    node.ContextMenu = contextMenu;
                    for (j = 0; j < tickets[i].QuestionGroups.Count; j++)
                        LoadQuestionGroup(node, tickets[i].QuestionGroups[j]);
                }
            }
        }
        public object CurrentObject { get; private set; }
        public string SearchText { get => searchBox.Text; set => searchBox.Text = value; }
        public bool IsSearched => cancelButton.Enabled;
        public bool IsCopied { get; private set; }
        public object[] SearchResult
        {
            set
            {
                if (IsSearched)
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (value[i] is Theme theme)
                            tree.Nodes["Themes"].Nodes.Add($"Тема '{theme.ThemeName}'").Tag = theme;
                        else if (value[i] is Ticket ticket)
                            tree.Nodes["Tickets"].Nodes.Add("Билет №" + ticket.TicketNumber).Tag = ticket;
                        else if (value[i] is QuestionGroup questionGroup)
                            tree.Nodes["Groups"].Nodes.Add($"Группа '{questionGroup.QuestionGroupName}'").Tag = questionGroup;
                        else if (value[i] is Question question)
                            tree.Nodes["Questions"].Nodes.Add($"Вопрос №{question.QuestionNumber}").Tag = question;
                    }
                else throw new InvalidOperationException("Cannot set search results when the search was not done.");
            }
        }

        public EditTreeControl()
        {
            InitializeComponent();
            contextMenu = new ContextMenu();
            contextMenu.Popup += OnContextMenuOpened;
            contextMenu.MenuItems.Add("Копировать", (a, e) => Copied?.Invoke(this));
            contextMenu.MenuItems.Add("Вырезать", (a, e) => Copied?.Invoke(this));
            contextMenu.MenuItems.Add("-");
            contextMenu.MenuItems.Add("Вставить", (a, e) => Pasted?.Invoke(this));
            tree.Nodes["Themes"].Tag = null;
            tree.Nodes["Tickets"].Tag = null;
        }
        public void Close() => Dispose();
        private void LoadQuestionGroup(TreeNode parentNode, QuestionGroup group)
        {
            TreeNode node = parentNode.Nodes.Add($"Группа '{group.QuestionGroupName}'");
            node.Tag = group;
            node.ContextMenu = contextMenu;
            for (int i = 0; i < group.ChildQuestionGroups.Count; i++)
                LoadQuestionGroup(node, group.ChildQuestionGroups[i]);
            for (int i = 0; i < group.Questions.Count; i++)
            {
                TreeNode treeNode = node.Nodes.Add($"Вопрос №{group.Questions[i].QuestionNumber}");
                treeNode.Tag = group.Questions[i];
                treeNode.ContextMenu = contextMenu;
            }
        }
        private void TreeAfterSelect(object sender, TreeViewEventArgs e)
        {
            CurrentObject = tree.SelectedNode.Tag;
            NodeChanged?.Invoke(this);
        }
        private void TreeItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ((TreeNode)e.Item).Tag is QuestionGroup)
                DoDragDrop(e.Item, DragDropEffects.Move);
        }
        private void TreeDragEnter(object sender, DragEventArgs e) => e.Effect = e.AllowedEffect;
        private void TreeDragOver(object sender, DragEventArgs e)
        {
            Point targetPoint = tree.PointToClient(new Point(e.X, e.Y));
            tree.SelectedNode = tree.GetNodeAt(targetPoint);
            if (tree.SelectedNode != null)
            {
                TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
                if (tree.SelectedNode.Tag is QuestionGroup || (tree.SelectedNode.Tag is Ticket && ContainsNode(tree.SelectedNode, draggedNode)))
                    e.Effect = e.AllowedEffect;
                else
                    e.Effect = DragDropEffects.None;
            }
        }
        private void TreeDragDrop(object sender, DragEventArgs e)
        {
            if (tree.SelectedNode != null)
            {
                Point targetPoint = tree.PointToClient(new Point(e.X, e.Y));
                TreeNode targetNode = tree.GetNodeAt(targetPoint);
                TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
                QuestionGroup group = (QuestionGroup)draggedNode.Tag;
                if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode) || (targetNode.Tag is Ticket && ContainsNode(targetNode, draggedNode)))
                {
                    if (e.Effect == DragDropEffects.Move)
                    {
                        draggedNode.Remove();
                        targetNode.Nodes.Add(draggedNode);
                        if (targetNode.Tag is QuestionGroup parentGroup)
                            StructureChanged?.Invoke(this, new StructChangedArgs(group, parentGroup));
                        else
                            StructureChanged?.Invoke(this, new StructChangedArgs(group, targetNode.Tag as Ticket));
                    }
                    targetNode.Expand();
                }
            }
        }
        private bool ContainsNode(TreeNode nodeA, TreeNode nodeB)
        {
            if (nodeB.Parent == null)
                return false;
            if (nodeB.Parent.Equals(nodeA))
                return true;
            return ContainsNode(nodeA, nodeB.Parent);
        }
        private void SearchButtonClick(object sender, EventArgs e)
        {
            if (!searchBox.Items.Contains(searchBox.Text))
                searchBox.SelectedIndex = searchBox.Items.Add(searchBox.Text);
            else searchBox.SelectedIndex = searchBox.Items.IndexOf(searchBox.Text);
            bufferedCollection = new TreeNode[tree.Nodes.Count];
            cancelButton.Enabled = true;
            tree.AllowDrop = false;
            tree.Nodes.CopyTo(bufferedCollection, 0);
            tree.Nodes.Clear();
            tree.Nodes.Add("Themes", "Темы");
            tree.Nodes.Add("Tickets", "Билеты");
            tree.Nodes.Add("Groups", "Группы");
            tree.Nodes.Add("Questions", "Вопросы");
            Searched?.Invoke(this);
        }
        private void CancelButtonClick(object sender, EventArgs e)
        {
            tree.Nodes.Clear();
            tree.Nodes.AddRange(bufferedCollection);
            cancelButton.Enabled = false;
            tree.AllowDrop = true;
        }
        private void TreeMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (tree.SelectedNode != null && tree.SelectedNode.Tag != null)
            {
                if (IsSearched)
                {
                    object obj = tree.SelectedNode.Tag;
                    tree.Nodes.Clear();
                    tree.Nodes.AddRange(bufferedCollection);
                    cancelButton.Enabled = false;
                    tree.SelectedNode = tree.GetAllNodes().Where(a => a.Tag?.Equals(obj) ?? false).FirstOrDefault();
                }
                GoToProperties?.Invoke(this);
            }
        }
        private void SearchBoxSelectedTextChanged(object sender, EventArgs e)
        {
            if (searchBox.Text.Length > 0)
                searchButton.Enabled = true;
            else
                searchButton.Enabled = false;
        }
        private void TreeMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tree.SelectedNode = tree.GetNodeAt(new Point(e.X, e.Y));
                TreeAfterSelect(sender, null);
            }
        }
        private void OnContextMenuOpened(object sender, EventArgs e)
        {
            if (tree.SelectedNode.Tag is Ticket)
            {
                contextMenu.MenuItems[0].Enabled = false;
                contextMenu.MenuItems[1].Enabled = false;
            }
            else
            {
                contextMenu.MenuItems[0].Enabled = true;
                contextMenu.MenuItems[1].Enabled = true;
            }
            contextMenu.MenuItems[3].Enabled = IsCopied;
        }
    }
    static class TreeExtensions
    {
        internal static List<TreeNode> GetAllNodes(this TreeView self)
        {
            List<TreeNode> result = new List<TreeNode>();
            foreach (TreeNode child in self.Nodes)
                result.AddRange(child.GetAllNodes());
            return result;
        }
        internal static List<TreeNode> GetAllNodes(this TreeNode self)
        {
            List<TreeNode> result = new List<TreeNode>();
            result.Add(self);
            foreach (TreeNode child in self.Nodes)
                result.AddRange(child.GetAllNodes());
            return result;
        }
    }
}
