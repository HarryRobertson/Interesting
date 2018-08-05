using System;
using System.Linq;
using Interesting.Framework;

namespace Interesting.Plugins
{
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
}