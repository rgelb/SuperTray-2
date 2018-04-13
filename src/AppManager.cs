using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SuperTray2
{
    public class AppManager
    {
        #region Constructors

        public AppManager()
        {
            Load();
        }

        #endregion

        #region Private Methods

        private void Load()
        {
            if (!File.Exists(this.SettingsPath)) return;

            string content = File.ReadAllText(this.SettingsPath);
            this.AppList = JsonConvert.DeserializeObject<List<ApplicationEntry>>(content);
        }

        #endregion

        #region Public Methods

        public void Save()
        {
            var content = JsonConvert.SerializeObject(this.AppList, Formatting.Indented);
            File.WriteAllText(this.SettingsPath, content);
        }

        #endregion

        #region Properties

        public List<ApplicationEntry> AppList { get; set; } = new List<ApplicationEntry>();

        private string SettingsPath 
        { 
            get
            {
                var appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                
                string appFolder = "SuperTray";
                string fileTitle = "appList.json";

                var fullDirectory = Path.Combine(appDataFolder, appFolder);
                if (!Directory.Exists(fullDirectory))
                    Directory.CreateDirectory(fullDirectory);

                return Path.Combine(fullDirectory, fileTitle);
            } 
        }

        #endregion
    }
}
