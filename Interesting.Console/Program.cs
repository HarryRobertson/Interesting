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
            string config = Directory.EnumerateFiles(configPath).First(f => f.EndsWith(pluginName) || f.EndsWith($"{pluginName}.xml") );

            IEnumerable<IPlugin> plugins = PluginLoader.Load(XDocument.Load(new FileStream(config, FileMode.Open)));
            foreach (IPlugin plugin in plugins)
            {
                if (plugin is IExecutable console)
                    console.Execute();
            }
        }
    }
}
