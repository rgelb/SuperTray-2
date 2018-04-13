using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SuperTray2
{
    public partial class frmAppList : Form
    {
        #region Variables

        private List<ApplicationEntry> appList;
        private bool listChanged;

        public event EventHandler<List<ApplicationEntry>> SaveChangesRequested = delegate {};

        #endregion

        #region Constructors

        public frmAppList()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public List<ApplicationEntry> AppList
        {
            get => appList;
            set
            {
                // clone so that changes are not persisted until Save Changes is clicked
                appList = Utilities.Clone(value);
                PopulateListView();
            }
        }

        #endregion

        #region Events

        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            AddEntry();
        }

        private void btnEditEntry_Click(object sender, EventArgs e)
        {
            // find selected item
            ListViewItem item = GetSelectedItem();
            if (item == null)
            {
                MessageBox.Show("Select Item");
                return;
            }

            var entry = (ApplicationEntry) item.Tag;
            EditItem(entry);
        }

        private void btnRemoveEntry_Click(object sender, EventArgs e)
        {
            // find selected item
            ListViewItem item = GetSelectedItem();
            if (item == null)
            {
                MessageBox.Show("Select Item");
                return;
            }

            // remove the item in the list
            var entry = (ApplicationEntry)item.Tag;
            RemoveEntry(entry);
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        private void btnMoveDownEntry_Click(object sender, EventArgs e)
        {
            ListViewItem item = GetSelectedItem();
            if (item == null)
            {
                MessageBox.Show("Select Item");
                return;
            }

            // can't move down if only a single item in list
            if (lvAppList.Items.Count == 1) return;

            // can't move down the last item
            if (item.Index == lvAppList.Items.Count - 1) return;

            // save index before the list gets repopulated
            int selectedIndex = item.Index;

            Utilities.Swap(appList, item.Index, item.Index + 1);
            PopulateListView();

            lvAppList.Items[selectedIndex + 1].Selected = true;
            listChanged = true;

        }

        private void btnMoveUpEntry_Click(object sender, EventArgs e)
        {
            ListViewItem item = GetSelectedItem();
            if (item == null)
            {
                MessageBox.Show("Select Item");
                return;
            }

            // can't move up if only a single item in list
            if (lvAppList.Items.Count == 1) return;
            if (item.Index == 0) return;

            // save index before the list gets repopulated
            int selectedIndex = item.Index;

            Utilities.Swap(appList, item.Index, item.Index - 1);
            PopulateListView();

            lvAppList.Items[selectedIndex - 1].Selected = true;
            listChanged = true;
        }

        private void lvAppList_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;    // by default do not allow
            bool isFileDrop = e.Data.GetDataPresent(DataFormats.FileDrop);

            if (isFileDrop)
            {
                // make sure it's a single file being dropped
                string [] fileNames = (string[]) e.Data.GetData(DataFormats.FileDrop);

                if (fileNames.Length == 1)
                {
                    e.Effect = DragDropEffects.Link;
                }
            }
        }

        private void lvAppList_DragDrop(object sender, DragEventArgs e)
        {
            string [] fileNames = (string[]) e.Data.GetData(DataFormats.FileDrop);


            var appEntry = new ApplicationEntry {ExecutablePath = fileNames[0]};

            var richFileInfo = new RichFileInfo(appEntry.ExecutablePath);
            appEntry.Name = richFileInfo.Name;
            appEntry.StartInFolder = richFileInfo.StartInFolder;

            // if the name could not be ascertained, bring up the editor
            if (string.IsNullOrWhiteSpace(appEntry.Name))
            {
                var frm = new frmAppDescription() {ApplicationEntry = appEntry};
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    AppList.Add(appEntry);
                    PopulateListView();
                    listChanged = true;
                }
            }
            else
            {
                AppList.Add(appEntry);
                PopulateListView();
                listChanged = true;
            }
        }

        private void lvAppList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = lvAppList.HitTest(e.X, e.Y);
            ListViewItem item = info.Item;

            if (item != null)
            {
                var appEntry = (ApplicationEntry) item.Tag;
                EditItem(appEntry);
            }
        }

        private void frmAppList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (listChanged)
            {
                DialogResult result = MessageBox.Show("Would you like to save the changes?", "Question", 
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch (result)
                {
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                    case DialogResult.Yes:
                        SaveChanges();
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        #endregion

        #region Private Methods

        private void PopulateListView()
        {
            lvAppList.Items.Clear();
            imgList.Images.Clear();

            foreach (var entry in appList)
            {
                var item = new ListViewItem(entry.Name);
                item.SubItems.Add(entry.ExecutablePath);
                item.Tag = entry;

                try
                {
                    var richFileInfo = new RichFileInfo(entry.ExecutablePath);

                    imgList.Images.Add (richFileInfo.Icon32);
                    item.ImageIndex = imgList.Images.Count - 1;
                }
                catch
                {
                    // ignore - nothing to be done
                }

                lvAppList.Items.Add(item);
            }
        }

        private void SaveChanges()
        {
            var clonedList = Utilities.Clone(appList);
            SaveChangesRequested(this, clonedList);
            listChanged = false;
        }

        private ListViewItem GetSelectedItem()
        {
            var selectedItems = lvAppList.SelectedItems;
            return selectedItems.Count == 1 ? selectedItems[0] : null;
        }

        private void AddEntry()
        {
            var frm = new frmAppDescription();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                appList.Add(frm.ApplicationEntry);

                // repaint the list view
                PopulateListView();

                listChanged = true;
            }
        }

        private void EditItem(ApplicationEntry appEntry)
        {
            var frm = new frmAppDescription() {ApplicationEntry = appEntry};
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // repaint the list view
                PopulateListView();

                listChanged = true;
            }
        }

        private void RemoveEntry(ApplicationEntry entry)
        {
            appList.Remove(entry);

            PopulateListView();

            listChanged = true;
        }

        #endregion

    }
}
