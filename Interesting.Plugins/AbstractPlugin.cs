using System.Xml.Linq;
using Interesting.Framework;

namespace Interesting.Plugins
{
    abstract class AbstractPlugin : IPlugin
    {
        public string Name { get; set; }
        public virtual void Configure(XDocument config)
        {
            Name = config.Root.Attribute(XName.Get("name")).Value;
        }
    }
}
