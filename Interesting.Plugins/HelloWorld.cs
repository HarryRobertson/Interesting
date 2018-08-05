using System;
using Interesting.Framework;

namespace Interesting.Plugins
{
    class HelloWorld : AbstractPlugin, IExecutable
    {
        public void Execute()
        {
            Console.WriteLine("Hello world!");
        }
    }
}
