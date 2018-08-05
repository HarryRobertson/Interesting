using System.Xml.Linq;
using Interesting.Framework;

namespace Interesting.Plugins
{
    abstract class AbstractPlugin : IPlugin
    {
        public string Name { get; set; }
        public virtual void Configure(XDocument config)
        {   // I don't get why there isn't an overload of Attribute that just accepts a string. I would like to implement a 
            Name = config.Root.Attribute(XName.Get("name")).Value; // config handler that encapsulates XDocument to handle this.
        }
    }
}
