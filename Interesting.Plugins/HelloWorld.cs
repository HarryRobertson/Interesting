using System;
using Interesting.Framework;

namespace Interesting.Plugins
{
    class HelloWorld : IPlugin, IConsole
    {
        public string Name => GetType().Name;

        public void Configure(object variant)
        {
            throw new NotImplementedException();
        }

        public void Execute(string[] args)
        {
            Console.WriteLine("Hello world!");
#if DEBUG
            Console.ReadKey();
#endif
        }
    }
}
