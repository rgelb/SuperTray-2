using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperTray2
{
    public partial class frmAppDescription : Form
    {
        #region Constructors

        public frmAppDescription()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public ApplicationEntry ApplicationEntry { get; set; } = new ApplicationEntry();

        #endregion

        #region Events

        private void frmAppDescription_Load(object sender, EventArgs e)
        {
            txtName.DataBindings.Add("Text", ApplicationEntry, "Name", true, DataSourceUpdateMode.OnPropertyChanged, string.Empty); 
            txtExecutablePath.DataBindings.Add("Text", ApplicationEntry, "ExecutablePath", true, DataSourceUpdateMode.OnPropertyChanged, string.Empty); 
            txtArguments.DataBindings.Add("Text", ApplicationEntry, "Arguments", true, DataSourceUpdateMode.OnPropertyChanged, string.Empty); 
            txtStartInFolder.DataBindings.Add("Text", ApplicationEntry, "StartInFolder", true, DataSourceUpdateMode.OnPropertyChanged, string.Empty); 
        }

        private void frmAppDescription_DragDrop(object sender, DragEventArgs e)
        {
            string [] fileNames = (string[]) e.Data.GetData(DataFormats.FileDrop);
            txtExecutablePath.Text = fileNames[0];
        }

        private void frmAppDescription_DragEnter(object sender, DragEventArgs e)
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

        private void frmAppDescription_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
                e.Cancel = true;
        }

        private void txtExecutablePath_TextChanged(object sender, EventArgs e)
        {            
            var droppedFileInfo = new RichFileInfo(txtExecutablePath.Text);
            picAppIcon.Image = droppedFileInfo.Icon32;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                ApplicationEntry.Name = droppedFileInfo.Name;
            }

            // set directory
            if (string.IsNullOrWhiteSpace(txtStartInFolder.Text))
            {
                ApplicationEntry.StartInFolder = droppedFileInfo.StartInFolder;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidateEntry())
                this.DialogResult = DialogResult.None;
        }

        #endregion

        #region Private Methods

        private bool ValidateEntry()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please Enter a Name", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtExecutablePath.Text))
            {
                MessageBox.Show("Please Enter a Target", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        #endregion
    }
}
