using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

using msConfig = System.Configuration;
using drexyiaConfig = Drexyia.Yaml.Configuration;

namespace ConsoleUI {
    class Program {
        static void Main(string[] args) {

            var msValue1 = msConfig.ConfigurationManager.AppSettings["key1"];
            var drexyiaValue1 = drexyiaConfig.ConfigurationManager.AppSettings["key1"];

            Debug.Assert(msValue1 == drexyiaValue1);

            msValue1 = msConfig.ConfigurationManager.AppSettings["key2"];
            drexyiaValue1 = drexyiaConfig.ConfigurationManager.AppSettings["key2"];

            Debug.Assert(msValue1 == drexyiaValue1);

            msValue1 = msConfig.ConfigurationManager.AppSettings[0];
            drexyiaValue1 = drexyiaConfig.ConfigurationManager.AppSettings[0];

            Debug.Assert(msValue1 == drexyiaValue1);

            msValue1 = msConfig.ConfigurationManager.AppSettings[1];
            drexyiaValue1 = drexyiaConfig.ConfigurationManager.AppSettings[1];

            Debug.Assert(msValue1 == drexyiaValue1);

        }
    }
}
