using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

using YamlDotNet.RepresentationModel;

namespace Drexyia.Yaml.Configuration {
    public sealed class ConfigurationManager {

        bool _isDirty = true;
        ConfigurationFileWatcher _fileWatcher;

        NameValueCollection _appSettings;

        public NameValueCollection AppSettings {
            get {

                if (_isDirty) {
                    ReadAppSettings();
                    _isDirty = false;

                    //only start watching the file for changes after it has been first accessed
                    _fileWatcher.StartWatching();

                }

                return _appSettings;
            }
        }

        void ReadAppSettings() {
            _appSettings = new NameValueCollection();

            using (TextReader reader = File.OpenText(@"App.config.yaml")) {
                var yaml = new YamlStream();
                yaml.Load(reader);

                var mapping = (YamlMappingNode)yaml.Documents[0].RootNode;

                foreach (var entry in mapping.Children) {
                    var rootNode = (YamlScalarNode)entry.Key;
                    if (rootNode.Value == "app-settings") {

                        var appSettings = (YamlMappingNode)entry.Value;
                        foreach (var appSetting in appSettings.Children) {

                            var nodeKey = (YamlScalarNode)appSetting.Key;
                            var nodeValue = (YamlScalarNode)appSetting.Value;

                            _appSettings[nodeKey.Value] = nodeValue.Value;
                        }
                    }
                }
            }
        }

        void _fileWatcher_FileChanged(object sender, EventArgs e) {
            _isDirty = true;
        }
        
        #region singleton pattern

        private static volatile ConfigurationManager instance;
        private static object syncRoot = new Object();

        private ConfigurationManager() {
            _fileWatcher = new ConfigurationFileWatcher();
            _fileWatcher.FileChanged += _fileWatcher_FileChanged;
        }

        public static ConfigurationManager Instance {
            get {
                if (instance == null) {
                    lock (syncRoot) {
                        if (instance == null)
                            instance = new ConfigurationManager();
                    }
                }

                return instance;
            }
        }

         #endregion
   
    }
}
