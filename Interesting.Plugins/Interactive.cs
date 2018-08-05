using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using Interesting.Framework;

namespace Interesting.Plugins
{
    class Interactive : AbstractPlugin, IExecutable
    {
        private IDatasource _datasource;
        private IDatasink _datasink;

        public override void Configure(XDocument config)
        {
            base.Configure(config);

            XElement xElements = new XElement("root", (config?.FirstNode as XElement)?.Elements());
            XDocument dependencyConfig = new XDocument(xElements);
            IEnumerable<IPlugin> dependencies = PluginLoader.Load(dependencyConfig).ToArray(); // force immediate execution
            if (!dependencies.Any(p => p is IDatasource) || !dependencies.Any(p => p is IDatasink))
                throw new ConfigurationErrorsException("Interactive plugin requires a valid Datasource and a valid Datasink.");

            _datasource = dependencies.First(p => p is IDatasource) as IDatasource;
            _datasink = dependencies.First(p => p is IDatasink) as IDatasink;
        }

        public void Execute()
        {
            _datasink.Write(_datasource.Read());
        }
    }

    class Interrogator : AbstractPlugin, IDatasource
    {
        public IUser Read() // In a real application this would read from an actual datasource rather than from the console IO.
        {
            User user = new User();
            Console.Write("Please enter your full name: ");
            string[] fullName = Console.ReadLine()?.Split(' '); // so many things that could go wrong here...
            user.FirstName = fullName?.First();
            user.LastName = fullName?.Last();
            Console.Write("Please enter your date of birth: ");
            DateTime dob = DateTime.Parse(Console.ReadLine()); // ... and here, but for initial implementation it will do
            user.Age = DateTime.Now - dob;
            return user;
        }
    }

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

        public void Write(IUser user) // Similarly, in a real application this would write to an actual datasink.
        {
            Console.WriteLine($"Hi {user.FirstName}, I'm Interesting.");
            Console.WriteLine($"You've been on Earth for {(int)user.Age.TotalDays} days.");
            int distance = (int) (user.Age.TotalDays * _distancePerDay);
            Console.WriteLine($"In that time you've travelled approximately {distance} million km around the Sun.");
        }
    }

    internal struct User : IUser
    {
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public TimeSpan Age { get; internal set; }
    }
}
