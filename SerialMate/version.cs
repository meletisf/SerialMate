using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SerialMate
{
    class version
    {
        public string[] RequestVersion()
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                string[] version_data = new string[3];
                doc.Load("http://internetlabs.eu/projects/serialmate/version.xml");
                foreach (XmlNode node in doc.DocumentElement)
                {
                    string version = node.Attributes[0].Value;
                    string date = node["date"].InnerText;
                    string changelog = node["changelog"].InnerText;

                    version_data[0] = version;
                    version_data[1] = date;
                    version_data[2] = changelog;

                    return version_data;

                }
            }
            catch
            {
                return null;
            }
            return null;
        }
    }
}
