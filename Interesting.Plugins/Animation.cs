using System;
using System.Linq;
using System.Threading;
using System.Xml.Linq;
using Interesting.Framework;

namespace Interesting.Plugins
{
    class Animation : AbstractPlugin, IExecutable
    {
        private int _windowFraction;
        private int _sleepTime;

        public override void Configure(XDocument config)
        {
            base.Configure(config);

            _windowFraction = int.Parse(config.Root.Element(XName.Get("WindowFraction")).Value);
            _sleepTime = int.Parse(config.Root.Element(XName.Get("SleepTime")).Value);
        }

        public void Execute()
        {
            const string title = "Animated console application title... very interesting.";
            string scrollTitle = title.Aggregate(string.Empty, (current, c) => current + " ") + title;
            int length = scrollTitle.Length;
            int window = length / _windowFraction; 

            for (int start = 0; true; start++)
            {
                if (start > length - 1) start = 0;

                Console.Title = start + window > length ? scrollTitle.Substring(start) : scrollTitle.Substring(start, window);
                Thread.Sleep(_sleepTime);
            }
        }
    }
}