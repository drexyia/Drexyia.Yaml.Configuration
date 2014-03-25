using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Threading;

using msConfig = System.Configuration;
using drexyiaConfig = Drexyia.Yaml.Configuration;

//should we be able to write to the settings file
namespace Sample.ConsoleUI {
    class Program {

        static void Main(string[] args) {

            ConfigFile configFile = new ConfigFile();

            WaitCallback callBack = new WaitCallback(configFile.Run);
            ThreadPool.QueueUserWorkItem(callBack);

            for(;;) {

                Console.Write("Press v to view config settings, any other key to exit: ");
                var input = Console.ReadLine();

                if (input != "v") {
                    break;
                }

                Console.WriteLine();
                configFile.WriteConfigValues();
                Console.WriteLine();

            } 

            
         
        }
    }
}
