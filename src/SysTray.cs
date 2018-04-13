using System;
using System.Reflection;
using System.Windows.Forms;
using SuperTray2.Properties;

namespace SuperTray2
{
    public class SysTray: IDisposable 
    {
        #region Variables

        private readonly NotifyIcon appSysTray;

        #endregion

        #region Constructors

        public SysTray(ContextMenuStrip ctxMenuApp)
        {
            appSysTray = new NotifyIcon
            {
                BalloonTipText = "SuperTray/2",
                ContextMenuStrip = ctxMenuApp,
                Text = "SuperTray/2",
                Icon = Resources.SysTray_3D_Icon_Legacy,
                Visible = true
            };

            appSysTray.MouseClick += appSysTray_MouseClick;
        }

        #endregion

        #region Private Methods

        // enable context menu for the left click as well.
        private void appSysTray_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", 
                    BindingFlags.Instance |BindingFlags.NonPublic);
                if (mi != null) mi.Invoke(appSysTray, null);
            }
        }

        #endregion

        #region Overridden Methods

        public void Dispose()
        {
            appSysTray.Visible = false;
            appSysTray.Dispose();
        }

        #endregion
    }
}