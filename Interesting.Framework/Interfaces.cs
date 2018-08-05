using System;
using System.Xml.Linq;

namespace Interesting.Framework
{
    public interface IPlugin
    {   // every plugin needs to implement this, but they'll also likely implement a behavioural interface too
        string Name {get;}
        void Configure(XDocument config);
    }

    public interface IExecutable
    {
        void Execute();
    }

    public interface IDatasource
    {
        IUser Read();
    }

    public interface IDatasink
    {
        void Write(IUser user);
    }

    public interface IUser
    {   // for example - a proper application would want to return something more complex to handle multiple datatypes
        string FirstName { get; }
        string LastName { get; }
        TimeSpan Age { get; }
    }
}
