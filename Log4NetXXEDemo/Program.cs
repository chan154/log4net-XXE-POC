using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using log4net;
using log4net.Config;

namespace Log4NetXXEDemo
{
    class Program
    {
        // Create a static logger
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            // 1. Point log4net to the config file with XXE
            FileInfo configFile = new FileInfo("log4net.config");

            // 2. Configure log4net using the vulnerable XmlConfigurator
            XmlConfigurator.ConfigureAndWatch(configFile);

            // 3. Write a test log
            Logger.Info("Attempting to log with a malicious XXE config...");

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
