using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Xml;

namespace Interesting.Framework
{
    public class PluginLoader : IConfigurationSectionHandler
    {
        private const string TYPE_ATTRIBUTE = "type";

        public object Create(object parent, object configContext, XmlNode section)
        {
            List<IPlugin> plugins = new List<IPlugin>();
            foreach (XmlNode node in section.ChildNodes)
            {
                try
                {
                    string typeName = node?.Attributes?[TYPE_ATTRIBUTE]?.Value;
                    if (typeName == null) continue;

                    string className = typeName.Split(',')[0]?.Trim();
                    string assemblyName = typeName.Split(',')[1]?.Trim();
                    if (className == null || assemblyName == null) continue;

                    Assembly assembly = Assembly.LoadFrom(assemblyName);
                    Type type = assembly.GetType(className);
                    if (type == null) continue;

                    IPlugin plugin = (IPlugin) Activator.CreateInstance(type);
                    plugins.Add(plugin);
                }
                catch (FileNotFoundException e) 
                {
                    // just continue, might need better handling later
                }
            }
            return plugins;
        }
    }
}
