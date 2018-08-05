using System.Linq;
using System.Xml.Linq;
using Xunit;

namespace Interesting.Framework.Tests
{
    public class PluginLoaderTests
    {
        private const string SimplePlugin = "<Application><Plugin name=\"Simple\" plugin=\"Interesting.Framework.Tests.Plugins.SimplePlugin\" source=\"Interesting.Framework.Tests.dll\" /></Application>";

        [Fact]
        public void LoadMethod_PassedSimplePluginConfig_LoadsSimplePluginWithCorrectName()
        {
            IPlugin simple = PluginLoader.Load(XDocument.Parse(SimplePlugin)).First();
            Assert.Equal("Simple", simple.Name);
        }
    }
}
