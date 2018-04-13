using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SuperTray2
{
    public class ContextMenu
    {
        #region Variables

        private readonly ContextMenuStrip ctxMenuApp;
        public event EventHandler SetupRequested = delegate {};
        public event EventHandler QuitRequested = delegate {};
        public event EventHandler<ApplicationEntry> ApplicationStartRequested = delegate {};

        #endregion

        #region Constructors

        public ContextMenu()
        {
            ctxMenuApp = new ContextMenuStrip();
            var mnuSetup = new ToolStripMenuItem();
            var mnuQuit = new ToolStripMenuItem();
            var mnuSeparator = new ToolStripSeparator();
            ctxMenuApp.SuspendLayout();

            // 
            // ctxMenuApp
            // 
            ctxMenuApp.ImageScalingSize = new Size(16, 16);
            ctxMenuApp.Items.AddRange(new ToolStripItem[] {
                mnuSetup,
                mnuQuit,
                mnuSeparator});
            ctxMenuApp.Name = "contextMenuStrip1";
            ctxMenuApp.Size = new Size(143, 100);
            // 
            // mnuSetup
            // 
            mnuSetup.Name = "mnuSetup";
            mnuSetup.Size = new Size(198, 30);
            mnuSetup.Text = "Setup...";
            mnuSetup.Click += mnuSetup_Click;
            // 
            // mnuQuit
            // 
            mnuQuit.Name = "mnuQuit";
            mnuQuit.Size = new Size(198, 30);
            mnuQuit.Text = "&Quit";
            mnuQuit.Click += mnuQuit_Click;
            // 
            // toolStripSeparator1
            // 
            mnuSeparator.Name = "toolStripSeparator1";
            mnuSeparator.Size = new Size(195, 6);
            mnuSeparator.Visible = true;

            ctxMenuApp.ResumeLayout(false);
        }

        #endregion

        #region Events

        private void mnuSetup_Click(object sender, EventArgs e)
        {
            SetupRequested.RaiseEvent(sender, e);
        }

        private void mnuQuit_Click(object sender, EventArgs e)
        {
            QuitRequested.RaiseEvent(sender, e);
        }

        private void mnuEntry_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mnuItem = (ToolStripMenuItem) sender;
            ApplicationEntry entry = (ApplicationEntry) mnuItem.Tag;

            ApplicationStartRequested(sender, entry);
        }

        #endregion

        #region Private Methods

        private void Add(ApplicationEntry entry)
        {
            var mnuEntry = new ToolStripMenuItem
            {
                Text = entry.Name,
                Tag = entry,
                ImageScaling = ToolStripItemImageScaling.None
            };

            var droppedFileInfo = new RichFileInfo(entry.ExecutablePath);
            mnuEntry.Image = droppedFileInfo.Icon16;

            mnuEntry.Click += mnuEntry_Click;
            ctxMenuApp.Items.Add(mnuEntry);
        }

        private void RemoveAllApplicationEntries()
        {
            for (int i = ctxMenuApp.Items.Count - 1; i >= 0; i--)
            {
                if (ctxMenuApp.Items[i] is ToolStripMenuItem tsItem)
                {
                    if (tsItem.Tag is ApplicationEntry)
                    {
                        // this is the right thing
                        ctxMenuApp.Items.RemoveAt(i);                        
                    }
                }
            }
        }

        #endregion

        #region Public Methods

        public void Add(List<ApplicationEntry> appList)
        {
            RemoveAllApplicationEntries();

            foreach (var entry in appList)
            {
                Add(entry);
            }            
        }

        #endregion

        #region Properties

        public ContextMenuStrip ContextMenuStrip => ctxMenuApp;

        #endregion
    }
}