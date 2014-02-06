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

            var connectors = XDoc.Descendants("connector");
            var conn_sources = XDoc.Descendants("connector_src");
            var conn_dests = XDoc.Descendants("connector_dst");
            foreach (var c in connectors)
            {
                string id = c.Element("id").Value;
                var conns = from _src in conn_sources
                            join
                            _dst in conn_dests
                            on _src.Element("connector_id").Value equals _dst.Element("connector_id").Value
                            select new
                            {
                                Source = _src.Element("card_id").Value,
                                Dest = _dst.Element("card_id").Value
                            };
                foreach (var conn in conns)
                {
                    Console.WriteLine("Src:{0} Dst:{1}", conn.Source, conn.Dest);
                }
            }
        }
    }
}
