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
        public event ViewActionHandler<IEditTreeView> NodeChanged;
        public event ViewActionHandler<IEditTreeView> GoToProperties;
        public event ViewActionHandler<IEditTreeView, StructChangedArgs> StructureChanged;

        public List<Theme> Themes
        {
            get => themes;
            set
            {
                themes = value;
                tree.Nodes["Themes"].Nodes.Clear();
                for (int i = 0; i < themes.Count; i++)
                {
                    TreeNode node = tree.Nodes["Themes"].Nodes.Add($"Тема '{themes[i].ThemeName}'");
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
                    TreeNode node = tree.Nodes["Tickets"].Nodes.Add("Билет №" + tickets[i].TicketNumber);
                    node.Tag = new NodeInfo(node, NodeType.Ticket, tickets[i]);
                    node.ContextMenu = contextMenu;
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
            contextMenu = new ContextMenu();
            contextMenu.Popup += OnContextMenuOpened;
            contextMenu.MenuItems.Add("Копировать");
            contextMenu.MenuItems.Add("Вырезать");
            contextMenu.MenuItems.Add("-");
            contextMenu.MenuItems.Add("Вставить");
            tree.Nodes["Themes"].Tag = new NodeInfo(tree.Nodes["Themes"], NodeType.Themes, null);
            tree.Nodes["Tickets"].Tag = new NodeInfo(tree.Nodes["Tickets"], NodeType.Tickets, null);
        }
        public void Close() => Dispose();
        private void LoadQuestionGroup(TreeNode parentNode, QuestionGroup group)
        {
            TreeNode node = parentNode.Nodes.Add($"Группа '{group.QuestionGroupName}'");
            node.Tag = new NodeInfo(node, NodeType.QuestionGroup, group);
            node.ContextMenu = contextMenu;
            for (int i = 0; i < group.ChildQuestionGroups.Count; i++)
                LoadQuestionGroup(node, group.ChildQuestionGroups[i]);
            for (int i = 0; i < group.Questions.Count; i++)
            {
                TreeNode treeNode = node.Nodes.Add($"Вопрос №{group.Questions[i].QuestionNumber}");
                treeNode.Tag = new NodeInfo(treeNode, NodeType.Question, group.Questions[i]);
                treeNode.ContextMenu = contextMenu;
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
        private void TreeDragEnter(object sender, DragEventArgs e) => e.Effect = e.AllowedEffect;
        private void TreeDragOver(object sender, DragEventArgs e)
        {
            Point targetPoint = tree.PointToClient(new Point(e.X, e.Y));
            tree.SelectedNode = tree.GetNodeAt(targetPoint);
            if (tree.SelectedNode != null)
            {
                NodeInfo node = (NodeInfo)tree.SelectedNode.Tag;
                TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
                if (node.nodeType == NodeType.QuestionGroup || (node.nodeType == NodeType.Ticket && ContainsNode(tree.SelectedNode, draggedNode)))
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
                NodeInfo node = (NodeInfo)targetNode.Tag;
                QuestionGroup group = (QuestionGroup)((NodeInfo)draggedNode.Tag).nodeObj;
                if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode) || (node.nodeType == NodeType.Ticket && ContainsNode(targetNode, draggedNode)))
                {
                    if (e.Effect == DragDropEffects.Move)
                    {
                        draggedNode.Remove();
                        targetNode.Nodes.Add(draggedNode);
                        if (node.nodeType == NodeType.QuestionGroup)
                            StructureChanged?.Invoke(this, new StructChangedArgs(group, (QuestionGroup)((NodeInfo)targetNode.Tag).nodeObj));
                        else
                            StructureChanged?.Invoke(this, new StructChangedArgs(group, (Ticket)((NodeInfo)targetNode.Tag).nodeObj));
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
            tree.Nodes.CopyTo(bufferedCollection, 0);

            TreeNode[] result = tree.GetAllNodes().ToArray();
            TreeNode tmp;
            tree.Nodes.Clear();

            tree.Nodes.Add("Themes", "Темы");
            tree.Nodes.Add("Tickets", "Билеты");
            tree.Nodes.Add("Groups", "Группы");
            tree.Nodes.Add("Questions", "Вопросы");
            for (int i = 0; i < result.Length; i++)
                if (result[i].Tag != null)
                {
                    NodeInfo node = ((NodeInfo)result[i].Tag);
                    if (node.nodeObj != null && node.nodeObj.ToString().Contains(searchBox.Text))
                    {
                        tmp = (TreeNode)result[i].Clone();
                        tmp.Remove();
                        switch (node.nodeType)
                        {
                            case NodeType.Question:
                                tree.Nodes["Questions"].Nodes.Add(tmp);
                                break;
                            case NodeType.QuestionGroup:
                                tree.Nodes["Groups"].Nodes.Add(tmp);
                                break;
                            case NodeType.Ticket:
                                tree.Nodes["Tickets"].Nodes.Add(tmp);
                                break;
                            case NodeType.Theme:
                                tree.Nodes["Themes"].Nodes.Add(tmp);
                                break;
                            default: continue;
                        }
                    }
                }
            cancelButton.Enabled = true;
            tree.AllowDrop = false;
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
            if (tree.SelectedNode != null)
            {
                if (IsSearched)
                {
                    NodeInfo info = (NodeInfo)tree.SelectedNode.Tag;
                    tree.Nodes.Clear();
                    tree.Nodes.AddRange(bufferedCollection);
                    cancelButton.Enabled = false;
                    TreeNode[] result = tree.GetAllNodes().ToArray();
                    tree.SelectedNode = result.Where(a => a.Tag.Equals(info)).FirstOrDefault();
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
                Point targetPoint = new Point(e.X, e.Y);
                TreeNode targetNode = tree.GetNodeAt(targetPoint);
                contextMenu.Tag = targetNode.Tag;
            }
        }
        private void OnContextMenuOpened(object sender, EventArgs e)
        {
            if ((contextMenu.Tag as NodeInfo).nodeType == NodeType.Ticket)
            {
                contextMenu.MenuItems[0].Enabled = false;
                contextMenu.MenuItems[1].Enabled = false;
            }
            else
            {
                contextMenu.MenuItems[0].Enabled = true;
                contextMenu.MenuItems[1].Enabled = true;
            }
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
