using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using Interesting.Framework;

namespace Interesting.Plugins
{
    class Interactive : AbstractPlugin, IExecutable // this plugin really needs a better name that isn't so context dependent
    {
        private IDatasource _datasource;
        private IDatasink _datasink;

        public override void Configure(XDocument config)
        {
            base.Configure(config);

            XElement xElements = new XElement("root", (config?.FirstNode as XElement)?.Elements());
            XDocument dependencyConfig = new XDocument(xElements);
            IEnumerable<IPlugin> dependencies = PluginLoader.Load(dependencyConfig).ToArray(); // force immediate execution
            if (!dependencies.Any(p => p is IDatasource) || !dependencies.Any(p => p is IDatasink))
                throw new ConfigurationErrorsException("Interactive plugin requires a valid Datasource and a valid Datasink.");

            _datasource = dependencies.First(p => p is IDatasource) as IDatasource;
            _datasink = dependencies.First(p => p is IDatasink) as IDatasink;
        }

        public void Execute()
        {
            _datasink.Write(_datasource.Read());
        }
    }
}
