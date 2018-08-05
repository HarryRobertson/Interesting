using System;
using System.Xml.Linq;
using Interesting.Framework;

namespace Interesting.Plugins
{
    class Responder : AbstractPlugin, IDatasink
    {
        private double _distancePerDay;

        public override void Configure(XDocument config)
        {
            base.Configure(config);

            double distancePerYear = double.Parse(config.Root.Element(XName.Get("DistancePerYear")).Value);
            double daysPerYear = double.Parse(config.Root.Element(XName.Get("DaysPerYear")).Value);

            _distancePerDay = distancePerYear / daysPerYear;
        }

        public void Write(IUser user) // In a real application this would write to an actual datasink.
        {
            Console.WriteLine($"Hi {user.FirstName}, I'm Interesting.");
            Console.WriteLine($"You've been on Earth for {(int)user.Age.TotalDays} days.");
            int distance = (int) (user.Age.TotalDays * _distancePerDay);
            Console.WriteLine($"In that time you've travelled approximately {distance} million km around the Sun.");
        }
    }
}