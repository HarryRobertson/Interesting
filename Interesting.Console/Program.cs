using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Interesting.Framework;

namespace Interesting.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string pluginName = args[0];
            string configPath = ConfigurationManager.AppSettings.Get("configPath");
            string config = Directory.EnumerateFiles(configPath).First(f => f.EndsWith(pluginName) || f.EndsWith($"{pluginName}.xml"));

            System.Console.CancelKeyPress += (sender, eventArgs) => Environment.Exit(0);
            // Need this ^ for the Animation plugin as it loops forever, but I know it's not very clean.
            // An alternative is to add an Exit/Stop method on the IExecutable interface and call into that.

            IEnumerable<IPlugin> plugins = PluginLoader.Load(XDocument.Load(new FileStream(config, FileMode.Open)));
            foreach (IPlugin plugin in plugins)
            {
                if (plugin is IExecutable console)
                    console.Execute();
            }
#if  DEBUG
            System.Console.ReadKey();
#endif
            Environment.Exit(0);
        }
    }
}
