using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace SuperTray2
{
    static class Program
    {
        #region Variables

        private static SysTray sysTray;
        private static ContextMenu ctxMenu;
        private static bool setupWindowActive;

        #endregion

        #region Entry Point

        [STAThread]
        static void Main()
        {
            // Enable high DPI support for .NET 9.0 to fix fuzzy fonts
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // setup the menu
            ctxMenu = new ContextMenu();
            ctxMenu.SetupRequested += ctxMenu_SetupRequested;
            ctxMenu.QuitRequested += ctxMenu_QuitRequested;
            ctxMenu.ApplicationStartRequested += ctxMenu_ApplicationStartRequested;

            // setup sys tray
            sysTray = new SysTray(ctxMenu.ContextMenuStrip);

            // read the app list
            var appMgr = new AppManager();
            ctxMenu.Add(appMgr.AppList);

            Application.Run();
        }

        #endregion

        #region Private Methods

        private static void StartProcess(ApplicationEntry entry)
        {
            try
            {
                var psi = new ProcessStartInfo(entry.ExecutablePath, entry.Arguments);
                if (!string.IsNullOrWhiteSpace(entry.StartInFolder))
                {
                    psi.WorkingDirectory = entry.StartInFolder;
                }

                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Events

        private static void frmAppList_SaveChangesRequested(object sender, List<ApplicationEntry> e)
        {
            var appMgr = new AppManager {AppList = e};
            appMgr.Save();

            // reset the context menu
            ctxMenu.Add(e);
        }

        private static void ctxMenu_ApplicationStartRequested(object sender, ApplicationEntry entry)
        {
            StartProcess(entry);
        }

        private static void ctxMenu_QuitRequested(object sender, EventArgs e)
        {
            sysTray.Dispose();
            Application.Exit();
        }

        private static void ctxMenu_SetupRequested(object sender, EventArgs e)
        {
            if (setupWindowActive) return;

            try
            {
                setupWindowActive = true;

                // read the app list
                var appMgr = new AppManager();

                var frm = new frmAppList();
                frm.AppList = appMgr.AppList;
                frm.SaveChangesRequested += frmAppList_SaveChangesRequested;
                frm.ShowDialog();
                frm.Dispose();

            }
            finally
            {
                setupWindowActive = false;
            }
        }

        #endregion

        #region Test Data
        //private static void addtestdata()
        //{
        //    var appMgr = new AppManager();

        //    var ae1 = new ApplicationEntry
        //    {
        //        Name = "Notepad",
        //        Arguments = @"\because:thisFile.txt",
        //        ExecutablePath = @"c:\windows\notepad.exe",
        //        StartInFolder = @"c:\windows"
        //    };

        //    var ae2 = new ApplicationEntry
        //    {
        //        Name = "WordPad",
        //        Arguments = @"\because:that.txt",
        //        ExecutablePath = @"c:\windows\write.exe",
        //        StartInFolder = @"c:\windows"
        //    };

        //    var ae3 = new ApplicationEntry
        //    {
        //        Name = "Microsoft Paint",
        //        Arguments = @"\because:theother.txt",
        //        ExecutablePath = @"c:\windows\paint.exe",
        //        StartInFolder = @"c:\windows"
        //    };

        //    appMgr.AppList.Add(ae1);
        //    appMgr.AppList.Add(ae2);
        //    appMgr.AppList.Add(ae3);

        //    appMgr.Save();

        //}
        #endregion
    }
}
