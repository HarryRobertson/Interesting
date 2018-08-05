using System;
using System.Linq;
using System.Threading;
using Interesting.Framework;

namespace Interesting.Plugins
{
    class Animation : AbstractPlugin, IExecutable 
    {
        public void Execute()
        {
            const string title = "Animated console application title... very interesting.";
            string scrollTitle = title.Aggregate(string.Empty, (current, c) => current + " ") + title;
            int length = scrollTitle.Length;
            int window = length / 3;

            for (int start = 0; true; start++)
            {
                if (start > length - 1) start = 0;

                Console.Title = start + window > length ? scrollTitle.Substring(start) : scrollTitle.Substring(start, window);
                Thread.Sleep(100);
            }
        }
    }
}