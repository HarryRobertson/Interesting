using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Interesting.Framework;

namespace Interesting.Plugins
{
    class MultiThreaded : AbstractPlugin, IExecutable 
    {
        private IEnumerable<IExecutable> _threads;

        public override void Configure(XDocument config)
        {
            base.Configure(config);

            XElement xElements = new XElement("root", (config?.FirstNode as XElement)?.Elements());
            XDocument dependencyConfig = new XDocument(xElements);
            IEnumerable<IPlugin> threads = PluginLoader.Load(dependencyConfig).ToArray(); // force immediate execution
            if (threads.Any(p => !(p is IExecutable)))
                throw new ConfigurationErrorsException("All sub-plugins must implement IExecutable.");

            _threads = threads.Cast<IExecutable>();
        }

        public void Execute()
        {
            Parallel.ForEach(_threads, thread => thread.Execute());
        }
    }
}