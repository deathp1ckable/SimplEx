using SimplExServer.Builders;
using SimplExServer.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace SimplExServer.Controls
{
    public partial class EditMarkSystemControl : UserControl, IEditMarkSystemPropertiesView
    {
        private Type tempType;
        private IList<Type> markSystemTypes;
        private IEditMarkSystemView editMarkSystemView;

        public event ViewActionHandler<IEditMarkSystemPropertiesView> Saved;
        public event ViewActionHandler<IEditMarkSystemPropertiesView> Canceled;
        public event ViewActionHandler<IEditMarkSystemPropertiesView> Changed;
        public event ViewActionHandler<IEditMarkSystemPropertiesView> MarkSystemTypeChanged;

        private int CurrentType { get => markSystemTypesList.SelectedIndex; set => markSystemTypesList.SelectedIndex = value; }
        public IEditMarkSystemView EditMarkSystemView
        {
            get => editMarkSystemView;
            set
            {
                if (editMarkSystemView != null)
                    editMarkSystemView.Changed -= InvokeChanged;
                editMarkSystemView = value;
                editMarkSystemView.Changed += InvokeChanged;
                UserControl control = (UserControl)editMarkSystemView;
                control.Parent = propertiesPanel;
                control.Size = propertiesPanel.Size;
                control.Location = new Point(0, 0);
                control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            }
        }
        public Type MarkSystemType
        {
            get => markSystemTypes[CurrentType];
            set
            {
                if (markSystemTypes != null)
                {
                    for (int i = 0; i < markSystemTypes.Count; i++)
                        if (markSystemTypes[i] == value)
                        {
                            CurrentType = i;
                            MarkSystemTypeChanged?.Invoke(this);
                            return;
                        }
                    throw new Exception("Type not assigned.");
                }
                else tempType = value;
            }
        }
        public IList<Type> MarkSystemTypes
        {
            set
            {
                markSystemTypes = value;
                markSystemTypesList.Items.Clear();
                for (int i = 0; i < markSystemTypes.Count; i++)
                {
                    if (markSystemTypes[i] == typeof(FiveStepMarkSystemBuilder))
                        markSystemTypesList.Items.Add("Обычная пятиступенчатая");
                }
                if (tempType != null)
                    MarkSystemType = tempType;
            }
        }
        public string Description { get => descriptionBox.Text; set => descriptionBox.Text = value; }
        public bool IsSaved
        {
            get => editMarkSystemView?.Saved ?? false; set
            {
                if (editMarkSystemView != null)
                    editMarkSystemView.Saved = value;
            }
        }

        public EditMarkSystemControl() => InitializeComponent();
        public void Close() => Dispose();
        private void SaveButtonClick(object sender, EventArgs e)
        {
            EditMarkSystemView.CallSaveChanges();
            Saved?.Invoke(this);
        }
        private void CancelButtonClick(object sender, EventArgs e)
        {
            EditMarkSystemView.CallCancelChanges();
            Canceled?.Invoke(this);
        }
        private void MarkSystemTypeListSelectedIndexChanged(object sender, EventArgs e)
        {
            MarkSystemType = markSystemTypes[markSystemTypesList.SelectedIndex];
            Changed?.Invoke(this);
        }
        private void InvokeChanged(IEditMarkSystemView sender)
        {
            IsSaved = false;
            Changed?.Invoke(this);
        }
        private void ChangedHandle(object sender, EventArgs e) => InvokeChanged(EditMarkSystemView);
        private void MarkSystemTypeListResize(object sender, EventArgs e) => ((Control)sender).Invalidate();
    }
}
