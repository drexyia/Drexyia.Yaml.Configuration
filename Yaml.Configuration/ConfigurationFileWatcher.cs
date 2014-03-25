using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Drexyia.Yaml.Configuration {
    
    public class ConfigurationFileWatcher {

        bool _isWatching = false;
        FileSystemWatcher _watcher;

        public event EventHandler FileChanged;

        public ConfigurationFileWatcher() { 
            _watcher = new FileSystemWatcher();
            _watcher.Path = System.IO.Directory.GetCurrentDirectory();
            _watcher.Filter = "App.config.yaml";
            _watcher.Changed += watcher_Changed;
        }

        public void StartWatching() {
            if (!_isWatching) {
                _watcher.EnableRaisingEvents = true;
            }
        }

        void watcher_Changed(object sender, FileSystemEventArgs e) {
            if (FileChanged != null) {
                FileChanged(sender, e);
            }
        }   

    }
}
