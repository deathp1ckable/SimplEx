using System;
using SimplExServer.View;
using System.Windows.Forms;
using SimplExServer.Model.Inherited;
using System.Drawing;

namespace SimplExServer.Controls
{
    public partial class EditMarkSystemPropertiesControl : UserControl, IEditMarkSystemPropertiesView
    {
        private Type tempType;
        private Type[] markSystemTypes;

        public event ViewActionHandler<IEditMarkSystemPropertiesView> SaveChanges;
        public event ViewActionHandler<IEditMarkSystemPropertiesView> CancelChanges;
        public event ViewActionHandler<IEditMarkSystemPropertiesView> Changed;
        public event ViewActionHandler<IEditMarkSystemPropertiesView> MarkSystemTypeChanged;

        private int CurrentType { get => markSystemTypeList.SelectedIndex; set => markSystemTypeList.SelectedIndex = value; }
        public IEditMarkSystemView EditMarkSystemView { get; private set; }
        public Type MarkSystemType
        {
            get => MarkSystemTypes[CurrentType];
            set
            {
                if (markSystemTypes != null)
                {
                    for (int i = 0; i < markSystemTypes.Length; i++)
                        if (markSystemTypes[i] == value)
                        {
                            CurrentType = i;
                            MarkSystemTypeChanged?.Invoke(this);
                            return;
                        }
                    throw new Exception("Type not assigned");
                }
                else tempType = value;
            }
        }
        public Type[] MarkSystemTypes
        {
            get => markSystemTypes;
            set
            {
                markSystemTypes = value;
                markSystemTypeList.Items.Clear();
                for (int i = 0; i < markSystemTypes.Length; i++)
                {
                    if (markSystemTypes[i] == typeof(FiveStepMarkSystem))
                        markSystemTypeList.Items.Add("Обычная пятиступенчатая");
                }
                MarkSystemType = tempType;
            }
        }
        public string Description { get => descriptionBox.Text; set => descriptionBox.Text = value; }
        public bool Saved { get => EditMarkSystemView?.Saved ?? false; set => EditMarkSystemView.Saved = value; }

        public EditMarkSystemPropertiesControl()
        {
            InitializeComponent();
        }
        public void Close() => Dispose();
        public void SetEditMarkSystemView(IEditMarkSystemView view)
        {
            view.Changed += InvokeChanged;
            if (EditMarkSystemView != null)
                EditMarkSystemView.Changed -= InvokeChanged;
            EditMarkSystemView = view;
            UserControl control = (UserControl)EditMarkSystemView;
            control.Parent = propertiesPanel;
            control.Size = propertiesPanel.Size;
            control.Location = new Point(0, 0);
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }
        private void SaveButtonClick(object sender, EventArgs e)
        {
            EditMarkSystemView.CallSaveChanges();
            SaveChanges?.Invoke(this);
        }
        private void CancelButtonClick(object sender, EventArgs e)
        {
            EditMarkSystemView.CallCancelChanges();
            CancelChanges?.Invoke(this);
        }
        private void MarkSystemTypeListSelectedIndexChanged(object sender, EventArgs e)
        {
            MarkSystemType = MarkSystemTypes[markSystemTypeList.SelectedIndex];
            Changed?.Invoke(this);
        }
        private void InvokeChanged(IEditMarkSystemView sender)
        {
            Saved = false;
            Changed?.Invoke(this);
        }
        private void ChangedHandle(object sender, EventArgs e) => InvokeChanged(EditMarkSystemView);
        private void MarkSystemTypeListResize(object sender, EventArgs e) => ((Control)sender).Invalidate();

    }
}
