using System;
using System.Xml.Linq;
using Interesting.Framework;
using Xunit;

namespace Interesting.Plugins.Tests
{
    public class InteractiveTests
    {
        private const string pluginConfig =
            "<Plugin name=\"Interactive\" plugin=\"Interesting.Plugins.Interactive\" source=\"Interesting.Plugins.dll\">" +
                "<Datasource name=\"MockSource\" plugin=\"Interesting.Plugins.Tests.MockSource\" source=\"Interesting.Plugins.Tests.dll\" />" +
                "<Datasink name=\"MockSink\" plugin=\"Interesting.Plugins.Tests.MockSink\" source=\"Interesting.Plugins.Tests.dll\" />" +
            "</Plugin>";

        [Fact]
        public void Execute_CopiesDataFromInputSourceToOutputSink()
        {
            Interactive interactive = new Interactive();
            interactive.Configure(XDocument.Parse(pluginConfig));

            Assert.NotEqual(MockSource.Source, MockSink.Sink);
            interactive.Execute();
            Assert.Equal(MockSource.Source, MockSink.Sink);
        }
    }

    internal class MockSource : AbstractPlugin, IDatasource
    {
        internal static readonly IUser Source = new User
        {
            FirstName = "Foo",
            LastName = "Bar",
            Age = new TimeSpan(1, 1, 3, 8)
        };

        public IUser Read()
        {
            return Source;
        }
    }

    internal class MockSink : AbstractPlugin, IDatasink
    {
        internal static IUser Sink;

        public void Write(IUser user)
        {
            Sink = user;
        }
    }
}
