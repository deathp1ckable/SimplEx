using SimplExServer.Builders;
using SimplExServer.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SimplExServer.Controls
{
    public partial class EditTreeControl : UserControl, IEditTreeView
    {
        private readonly List<object> visitedObjects = new List<object>();
        private int visitedOffset;

        private IList<ThemeBuilder> themesBuilders;
        private IList<TicketBuilder> ticketBuilders;
        private TreeNode[] bufferedCollection;
        private ContextMenu contextMenu;
        private bool questionGroupCopied;
        private bool questionCopied;

        private bool IsSearched { get => cancelButton.Enabled; set => cancelButton.Enabled = value; }

        public event ViewActionHandler<IEditTreeView> Refreshed;
        public event ViewActionHandler<IEditTreeView> NodeChanged;
        public event ViewActionHandler<IEditTreeView> GoToProperties;
        public event ViewActionHandler<IEditTreeView> Searched;
        public event ViewActionHandler<IEditTreeView, StructChangedArgs> StructureChanged;
        public event ViewActionHandler<IEditTreeView, QuestionCopiedArgs> QuestionCopied;
        public event ViewActionHandler<IEditTreeView, QuestionPastedArgs> QuestionPasted;
        public event ViewActionHandler<IEditTreeView, QuestionGroupCopiedArgs> QuestionGroupCopied;
        public event ViewActionHandler<IEditTreeView, QuestionGroupPastedArgs> QuestionGroupPasted;

        public IList<ThemeBuilder> ThemeBuilders
        {
            get => themesBuilders;
            set
            {
                themesBuilders = value;
                tree.Nodes["Themes"].Nodes.Clear();
                for (int i = 0; i < themesBuilders.Count; i++)
                    tree.Nodes["Themes"].Nodes.Add(LoadTheme(themesBuilders[i]));
            }
        }
        public IList<TicketBuilder> TicketBuilders
        {
            get => ticketBuilders;
            set
            {
                ticketBuilders = value;
                tree.Nodes["Tickets"].Nodes.Clear();
                for (int i = 0; i < ticketBuilders.Count; i++)
                    tree.Nodes["Tickets"].Nodes.Add(LoadTicket(ticketBuilders[i]));
            }
        }
        public object CurrentObject { get; private set; }
        public string SearchText { get => searchBox.Text; set => searchBox.Text = value; }
        public int MaxVisitedNodes { get; set; } = 100;

        public object[] SearchResult
        {
            set
            {
                if (IsSearched)
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (value[i] is ThemeBuilder themeBuilder)
                            tree.Nodes["Themes"].Nodes.Add($"Тема '{themeBuilder.ThemeName}'").Tag = themeBuilder;
                        else if (value[i] is TicketBuilder ticketBuilder)
                            tree.Nodes["Tickets"].Nodes.Add($"Билет '{ticketBuilder.TicketName}'").Tag = ticketBuilder;
                        else if (value[i] is QuestionGroupBuilder questionGroupBuilder)
                            tree.Nodes["Groups"].Nodes.Add($"Группа '{questionGroupBuilder.QuestionGroupName}'").Tag = questionGroupBuilder;
                        else if (value[i] is QuestionBuilder questionBuilder)
                            tree.Nodes["Questions"].Nodes.Add($"Вопрос №{1 + questionBuilder.QuestionNumber}").Tag = questionBuilder;
                    }
                else throw new InvalidOperationException("Cannot set search results when the search was not done.");
            }
        }

        public Section CurrentSection
        {
            get
            {
                if (tree.SelectedNode == null)
                    return Section.Themes;
                if (ReferenceEquals(tree.Nodes["Tickets"], tree.SelectedNode))
                    return Section.Tickets;
                else if (ReferenceEquals(tree.Nodes["Themes"], tree.SelectedNode))
                    return Section.Themes;
                if (ContainsNode(tree.Nodes["Themes"], tree.SelectedNode))
                    return Section.Tickets;
                else return Section.Themes;
            }
        }

        public EditTreeControl()
        {
            InitializeComponent();
            contextMenu = new ContextMenu();
            contextMenu.Popup += ContextMenuPopup;
            contextMenu.MenuItems.Add("Вставить", ContextMenuPaste);
            contextMenu.MenuItems.Add("-");
            contextMenu.MenuItems.Add("Копировать", ContextMenuCopy);
            contextMenu.MenuItems.Add("Вырезать", ContextMenuCut);
            contextMenu.MenuItems.Add("-");
            contextMenu.MenuItems.Add("Перейти к свойствам", (a, b) =>
            {
                GoToProperties?.Invoke(this);
                tree.SelectedNode.Expand();
            });
            contextMenu.MenuItems[0].Enabled = false;
            tree.Nodes["Themes"].Tag = new object();
            tree.Nodes["Tickets"].Tag = new object();
            tree.Nodes["Themes"].ContextMenu = contextMenu;
            tree.Nodes["Tickets"].ContextMenu = contextMenu;
        }
        public void Close() => Dispose();

        public void SelectObject(object obj)
        {
            if (ReferenceEquals(tree.SelectedNode?.Tag, obj))
                return;
            if (obj == null)
                tree.SelectedNode = tree.Nodes["Themes"];
            tree.SelectedNode = tree.GetAllNodes().Where(a => ReferenceEquals(a.Tag, obj)).FirstOrDefault();
            if (tree.SelectedNode == null)
                return;
            tree.SelectedNode.Expand();
            SelectNode();
        }
        public void SelectObject(Section section)
        {
            if (section == Section.Themes)
                tree.SelectedNode = tree.Nodes["Themes"];
            else
                tree.SelectedNode = tree.Nodes["Tickets"];
            tree.SelectedNode.Expand();
            SelectNode();
        }
        public void RefreshTickets()
        {
            TicketBuilders = ticketBuilders;
            Refreshed?.Invoke(this);
        }
        public void RefreshThemes()
        {
            ThemeBuilders = themesBuilders;
            Refreshed?.Invoke(this);
        }
        public void RefreshObject(object obj)
        {
            TreeNode node = tree.GetAllNodes().Where(a => ReferenceEquals(a.Tag, obj)).FirstOrDefault();
            if (node == null)
                return;
            int index = node.Index;
            if (node.Tag is ThemeBuilder themeBuilder)
                node.Replace(LoadTheme(themeBuilder));
            else if (node.Tag is TicketBuilder ticketBuilder)
                node.Replace(LoadTicket(ticketBuilder));
            else if (node.Tag is QuestionGroupBuilder questionGroupBuilder)
                node.Replace(LoadQuestionGroup(questionGroupBuilder));
            else if (node.Tag is QuestionBuilder questionBuilder)
                node.Replace(LoadQuestion(questionBuilder));
            Refreshed?.Invoke(this);
        }

        private void ContextMenuPaste(object sender, EventArgs e)
        {
            if (questionCopied)
                QuestionPasted?.Invoke(this, new QuestionPastedArgs(CurrentObject as QuestionGroupBuilder));
            if (questionGroupCopied)
                if (CurrentObject is QuestionGroupBuilder questionGroupBuilder)
                    QuestionGroupPasted?.Invoke(this, new QuestionGroupPastedArgs(questionGroupBuilder));
                else if (CurrentObject is TicketBuilder ticketBuilder)
                    QuestionGroupPasted?.Invoke(this, new QuestionGroupPastedArgs(ticketBuilder));
        }
        private void ContextMenuCopy(object sender, EventArgs e)
        {
            if (CurrentObject is QuestionBuilder questionBuilder)
            {
                questionGroupCopied = !(questionCopied = true);
                QuestionCopied?.Invoke(this, new QuestionCopiedArgs(false, questionBuilder));
            }
            else if (CurrentObject is QuestionGroupBuilder questionGroupBuilder)
            {
                questionCopied = !(questionGroupCopied = true);
                QuestionGroupCopied?.Invoke(this, new QuestionGroupCopiedArgs(false, questionGroupBuilder));
            }
        }
        private void ContextMenuCut(object sender, EventArgs e)
        {
            if (CurrentObject is QuestionBuilder questionBuilder)
            {
                questionGroupCopied = !(questionCopied = true);
                QuestionCopied?.Invoke(this, new QuestionCopiedArgs(true, questionBuilder));
            }
            else if (CurrentObject is QuestionGroupBuilder questionGroupBuilder)
            {
                questionCopied = !(questionGroupCopied = true);
                QuestionGroupCopied?.Invoke(this, new QuestionGroupCopiedArgs(true, questionGroupBuilder));
            }
        }
        private void ContextMenuPopup(object sender, EventArgs e)
        {
            if (questionCopied)
                contextMenu.MenuItems[0].Enabled = CurrentObject is QuestionGroupBuilder;
            else if (questionGroupCopied)
                contextMenu.MenuItems[0].Enabled = CurrentObject is QuestionGroupBuilder || CurrentObject is TicketBuilder;
            if (!(CurrentObject is QuestionBuilder) && !(CurrentObject is QuestionGroupBuilder))
                contextMenu.MenuItems[2].Enabled = contextMenu.MenuItems[3].Enabled = false;
            else
                contextMenu.MenuItems[2].Enabled = contextMenu.MenuItems[3].Enabled = true;
        }

        private void TreeAfterSelect(object sender, TreeViewEventArgs e)
        {
            CheckMovers();
            CheckVisitedObjects();
        }

        private void TreeItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ((TreeNode)e.Item).Tag is QuestionGroupBuilder)
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
            if (tree.SelectedNode != null)
            {
                TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
                if (tree.SelectedNode.Tag is QuestionGroupBuilder || (tree.SelectedNode.Tag is TicketBuilder && ContainsNode(tree.SelectedNode, draggedNode)))
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
                QuestionGroupBuilder group = (QuestionGroupBuilder)draggedNode.Tag;
                if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode) || (targetNode.Tag is TicketBuilder && ContainsNode(targetNode, draggedNode)))
                {
                    if (e.Effect == DragDropEffects.Move)
                    {
                        draggedNode.Remove();
                        targetNode.Nodes.Add(draggedNode);
                        if (targetNode.Tag is QuestionGroupBuilder parentGroup)
                            StructureChanged?.Invoke(this, new StructChangedArgs(group, parentGroup));
                        else
                            StructureChanged?.Invoke(this, new StructChangedArgs(group, targetNode.Tag as TicketBuilder));
                    }
                    targetNode.Expand();
                }
            }
        }
        private void TreeMouseClick(object sender, MouseEventArgs e)
        {
            TreeNode selectedNode = tree.SelectedNode;
            tree.SelectedNode = tree.GetNodeAt(new Point(e.X, e.Y));
            if (!ReferenceEquals(tree.SelectedNode, selectedNode))
            {
                SelectNode();
                if (visitedOffset > 0)
                    visitedObjects.RemoveRange(visitedObjects.Count - visitedOffset, visitedOffset);
                visitedOffset = 0;
                AddVisitedObject(tree.SelectedNode.Tag);
                CheckVisitedObjects();
            }
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
                    SearchText = string.Empty;
                    cancelButton.Enabled = false;
                    tree.AllowDrop = true;
                    tree.SelectedNode = tree.GetAllNodes().Single(a => a.Tag?.Equals(obj) ?? false);
                }
                GoToProperties?.Invoke(this);
            }
        }

        private void SearchBoxSelectedTextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(searchBox.Text.Trim()))
                searchButton.Enabled = true;
            else
                searchButton.Enabled = false;
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
            SearchText = string.Empty;
            cancelButton.Enabled = false;
            tree.AllowDrop = true;
        }

        private bool ContainsNode(TreeNode nodeA, TreeNode nodeB)
        {
            if (nodeB.Parent == null)
                return false;
            if (nodeB.Parent.Equals(nodeA))
                return true;
            return ContainsNode(nodeA, nodeB.Parent);
        }
        private void SelectNode()
        {
            CurrentObject = tree.SelectedNode?.Tag;
            if (ReferenceEquals(tree.SelectedNode, tree.Nodes["Themes"]) || ReferenceEquals(tree.SelectedNode, tree.Nodes["Tickets"]))
                CurrentObject = null;
            NodeChanged?.Invoke(this);
            CheckMovers();
        }
        private void CheckMovers()
        {
            if (CurrentObject != null)
            {
                if (tree.SelectedNode.PrevNode != null)
                    upButton.Enabled = true;
                else
                    upButton.Enabled = false;
                if (tree.SelectedNode.NextNode != null)
                    downButton.Enabled = true;
                else
                    downButton.Enabled = false;
            }
            else
            {
                upButton.Enabled = false;
                downButton.Enabled = false;
            }
        }
        private void CheckVisitedObjects()
        {
            if (visitedOffset > 0)
                nextButton.Enabled = true;
            else
                nextButton.Enabled = false;
            if (visitedObjects.Count > visitedOffset + 1)
                backButton.Enabled = true;
            else
                backButton.Enabled = false;
        }
        private void AddVisitedObject(object obj)
        {
            visitedObjects.Add(obj);
            if (visitedObjects.Count > MaxVisitedNodes)
                visitedObjects.RemoveAt(0);
        }

        private TreeNode LoadTheme(ThemeBuilder themeBuilder)
        {
            TreeNode result = new TreeNode($"Тема '{themeBuilder.ThemeName}'");
            result.Tag = themeBuilder;
            result.ContextMenu = contextMenu;
            return result;
        }
        private TreeNode LoadTicket(TicketBuilder ticketBuilder)
        {
            TreeNode result = new TreeNode($"Билет '{ticketBuilder.TicketName}'");
            result.Tag = ticketBuilder;
            result.ContextMenu = contextMenu;
            for (int i = 0; i < ticketBuilder.QuestionGroupBuilders.Count; i++)
                result.Nodes.Add(LoadQuestionGroup(ticketBuilder.QuestionGroupBuilders[i]));
            return result;
        }
        private TreeNode LoadQuestionGroup(QuestionGroupBuilder group)
        {
            TreeNode result = new TreeNode($"Группа '{group.QuestionGroupName}'");
            result.Tag = group;
            result.ContextMenu = contextMenu;
            int i;
            for (i = 0; i < group.QuestionGroupBuilders.Count; i++)
                result.Nodes.Add(LoadQuestionGroup(group.QuestionGroupBuilders[i]));
            for (i = 0; i < group.QuestionBuilders.Count; i++)
                result.Nodes.Add(LoadQuestion(group.QuestionBuilders[i]));
            return result;
        }
        private TreeNode LoadQuestion(QuestionBuilder questionBuilder)
        {
            TreeNode result = new TreeNode($"Вопрос №{1 + questionBuilder.QuestionNumber}");
            result.Tag = questionBuilder;
            result.ContextMenu = contextMenu;
            return result;
        }

        private void SearchBoxResize(object sender, EventArgs e) => ((Control)sender).Invalidate();

        private void UpButtonClick(object sender, EventArgs e)
        {
            TreeNode prevNode = tree.SelectedNode.PrevNode;
            TreeNode selectedNode = tree.SelectedNode;
            TreeNode clonedSelectedNode = (TreeNode)tree.SelectedNode.Clone();
            selectedNode.Replace((TreeNode)prevNode.Clone());
            prevNode.Replace(clonedSelectedNode);
            tree.SelectedNode = clonedSelectedNode;
            CheckMovers();
        }
        private void DownButtonClick(object sender, EventArgs e)
        {
            TreeNode nextNode = tree.SelectedNode.NextNode;
            TreeNode selectedNode = tree.SelectedNode;
            TreeNode clonedSelectedNode = (TreeNode)tree.SelectedNode.Clone();
            selectedNode.Replace((TreeNode)nextNode.Clone());
            nextNode.Replace(clonedSelectedNode);
            tree.SelectedNode = clonedSelectedNode;
            CheckMovers();
        }

        private void BackButtonClick(object sender, EventArgs e)
        {
            visitedOffset++;
            SelectObject(visitedObjects[visitedObjects.Count - 1 - visitedOffset]);
            tree.Focus();
        }
        private void NextButtonClick(object sender, EventArgs e)
        {
            visitedOffset--;
            SelectObject(visitedObjects[visitedObjects.Count - 1 - visitedOffset]);
            tree.Focus();
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
        internal static void Replace(this TreeNode toReplace, TreeNode value)
        {
            TreeNode parentNode = toReplace.Parent;
            int index = parentNode.Nodes.IndexOf(toReplace);
            parentNode.Nodes.RemoveAt(index);
            parentNode.Nodes.Insert(index, value);
        }

        internal static IList<TreeNode> ToList(this TreeNodeCollection collection)
        {
            return collection.Cast<TreeNode>().ToList();
        }
        internal static TreeNode[] ToArray(this TreeNodeCollection collection)
        {
            return collection.Cast<TreeNode>().ToArray();
        }
    }
    class NodeTagEqualityComparer : IEqualityComparer<TreeNode>
    {
        public bool Equals(TreeNode x, TreeNode y)
        {
            return ReferenceEquals(x.Tag, y.Tag);
        }
        public int GetHashCode(TreeNode obj)
        {
            return obj.Tag.GetHashCode();
        }
    }
}
