using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;


namespace JohnJesus.DeviceXml
{
    public class SystemTopoXmlReader
    {
        public XDocument XDoc { get; set; }
        public void LoadEmbeddedXml()
        {
            var asm = Assembly.GetExecutingAssembly();
            using (var stream = asm.GetManifestResourceStream("JohnJesus.DeviceXml.SystemTopology.xml"))
            {
                XDoc = LoadFromStream(stream);
            }
        }
        public XDocument LoadFromStream(Stream stream)
        {
            using (XmlReader reader = XmlReader.Create(stream))
            {
                return XDocument.Load(reader);
            }
        }
        public void CreateObjects()
        {
            var racks = XDoc.Descendants("rack");
            foreach (var r in racks)
            {
                Console.WriteLine("{0}", r.Element("name").Value);
            }
        }
    }
}
