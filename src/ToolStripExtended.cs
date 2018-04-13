using System.Windows.Forms;

namespace SuperTray2
{
    /// <summary>
    /// The purpose of this class is to extend the ToolStrip
    /// so that it responds to mouse clicks even when the 
    /// application is not the active one
    /// </summary>
    public class ToolStripExtended: ToolStrip
    {
        const uint WM_LBUTTONDOWN = 0x201;
        const uint WM_LBUTTONUP   = 0x202;

        private static bool down;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg==WM_LBUTTONUP && !down) {
                m.Msg=(int)WM_LBUTTONDOWN; base.WndProc(ref m);
                m.Msg=(int)WM_LBUTTONUP;
            }

            if (m.Msg==WM_LBUTTONDOWN) down=true;
            if (m.Msg==WM_LBUTTONUP)   down=false;

            base.WndProc(ref m);
        }
    }
}
