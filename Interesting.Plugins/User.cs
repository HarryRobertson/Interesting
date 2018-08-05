using System;
using Interesting.Framework;

namespace Interesting.Plugins
{
    internal struct User : IUser
    {
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public TimeSpan Age { get; internal set; }
    }
}