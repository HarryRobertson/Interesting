using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace Interesting.Framework
{
    public static class PluginLoader 
    {
        public static IEnumerable<IPlugin> Load(XDocument config)
        {
            foreach (XElement pluginConfig in config.Elements())
            {
                string name = pluginConfig.Attribute(XName.Get("name"))?.Value;
                string plugin = pluginConfig.Attribute(XName.Get("plugin"))?.Value;
                string source = pluginConfig.Attribute(XName.Get("source"))?.Value;
                if (name == null || plugin == null || source == null)
                    throw new ConfigurationErrorsException("Plugin definition must include a name, plugin and source.");

                Type type;
                try { 
                    Assembly assembly = Assembly.LoadFrom(source);
                    type = assembly.GetType(plugin);
                    if (type == null)
                        throw new ConfigurationErrorsException("The plugin definition was not valid.");
                }
                catch (FileNotFoundException e)
                {
                    throw new ConfigurationErrorsException("The plugin definition was not valid.", e);
                }

                IPlugin p = (IPlugin) Activator.CreateInstance(type);

                if (pluginConfig.Name == "Executable" && !(p is IExecutable)) 
                    throw  new ConfigurationErrorsException("The plugin loaded was not of the type defined.");

                p.Configure(new XDocument(pluginConfig));
                yield return p;
            }
        }
    }
}
