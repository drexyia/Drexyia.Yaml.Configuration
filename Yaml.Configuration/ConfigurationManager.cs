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
    public static class ConfigurationManager {

        public static NameValueCollection AppSettings {
            get {

                var nameValues = new NameValueCollection();

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

                                nameValues[nodeKey.Value] = nodeValue.Value;
                            }
                        }
                    }
                }

                return nameValues;

            }
        }
    }
}
