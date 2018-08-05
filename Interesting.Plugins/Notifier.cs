using System;
using Interesting.Framework;

namespace Interesting.Plugins
{
    class Notifier : AbstractPlugin, IDatasink
    {
        public void Write(IUser user) // In a real application this would write to an actual datasink.
        {
            Console.WriteLine($"Hello {user.FirstName} {user.LastName}, have you seen the title bar animation?");
        }
    }
}