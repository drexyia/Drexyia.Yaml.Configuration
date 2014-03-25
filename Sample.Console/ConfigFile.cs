using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using drexyiaConfig = Drexyia.Yaml.Configuration;

namespace Sample.ConsoleUI {
    public class ConfigFile {

        public void Run(object state) {

        }

        public void WriteConfigValues() {

            var value1 = drexyiaConfig.ConfigurationManager.Instance.AppSettings["key1"];
            var value2 = drexyiaConfig.ConfigurationManager.Instance.AppSettings["key2"];

            Console.WriteLine("key1: " + value1);
            Console.WriteLine("key2: " + value2);
        }
    }
}
