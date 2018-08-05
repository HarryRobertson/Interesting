using System.Collections.Generic;
using System.Configuration;
using Interesting.Framework;

namespace Interesting.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<IPlugin> plugins = (IEnumerable<IPlugin>) ConfigurationManager.GetSection("plugins");
            foreach (IPlugin plugin in plugins)
            {
                if (plugin is IConsole console)
                    console.Execute(args);
            }
        }
    }
}
