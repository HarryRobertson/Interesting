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
}
