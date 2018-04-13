using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTray2
{
    public class RichFileInfo
    {
        public RichFileInfo(string executablePath)
        {
            // if item is a file, set the startIn folder
            if (File.Exists(executablePath))
            {
                var fi = new FileInfo(executablePath);
                this.StartInFolder = fi.DirectoryName;
            }            

            // obtain name of file/folder
            if (File.Exists(executablePath))
            {
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(executablePath);
                this.Name = fvi.FileDescription;
            }
            else if (Directory.Exists(executablePath))
            {
                DirectoryInfo di = new DirectoryInfo(executablePath);
                this.Name = di.Name;
            }

            // obtain icon
            if (File.Exists(executablePath))
            {
                this.Icon = Icon.ExtractAssociatedIcon(executablePath);
            }
            else if (Directory.Exists(executablePath))
            {
                this.Icon = DefaultIcons.FolderLarge;
            }

        }

        public Icon Icon { get; private set; }

        public Bitmap Icon32
        {
            get
            {
                if (this.Icon != null)
                {
                    return Utilities.ResizeImage(this.Icon.ToBitmap(), 32, 32);
                }
                return null;
            }
        }

        public Bitmap Icon16
        {
            get
            {
                if (this.Icon != null)
                {
                    return Utilities.ResizeImage(this.Icon.ToBitmap(), 16, 16);
                }
                return null;
            }
        }

        public string Name { get; private set; }

        public string StartInFolder { get; private set; }
    }
}
