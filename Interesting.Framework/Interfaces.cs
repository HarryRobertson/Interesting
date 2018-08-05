using System;
using System.Xml.Linq;

namespace Interesting.Framework
{
    public interface IPlugin
    {
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
    {
        string FirstName { get; }
        string LastName { get; }
        TimeSpan Age { get; }
    }
}
