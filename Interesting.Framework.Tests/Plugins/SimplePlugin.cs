using System.Xml.Linq;

namespace Interesting.Framework.Tests.Plugins
{
    class SimplePlugin : IPlugin
    {
        public string Name { get; private set; }

        public void Configure(XDocument config)
        {
            Name = config.Root?.Attribute(XName.Get("name"))?.Value;
        }
    }
}
