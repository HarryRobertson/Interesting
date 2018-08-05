using System;
using System.Xml.Linq;
using Interesting.Framework;

namespace Interesting.Plugins
{
    class HelloWorld : IPlugin, IExecutable
    {
        public string Name { get; private set; }

        public void Configure(XDocument config)
        {
            Name = config.Root?.Attribute(XName.Get("name"))?.Value;
        }

        public void Execute()
        {
            Console.WriteLine("Hello world!");
#if DEBUG
            Console.ReadKey();
#endif
        }
    }
}
