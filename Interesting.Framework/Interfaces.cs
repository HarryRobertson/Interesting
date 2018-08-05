namespace Interesting.Framework
{
    public interface IPlugin
    {
        string Name {get;}
        void Configure(object variant);
    }

    public interface IConsole
    {
        void Execute(string[] args);
    }
}
