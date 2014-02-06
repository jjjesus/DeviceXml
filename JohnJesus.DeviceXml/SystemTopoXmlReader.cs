﻿using System;
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
            var connectors = XDoc.Descendants("connector");
            var conns = from _src in XDoc.Descendants("connector_src")
                        join
                        _dst in XDoc.Descendants("connector_dst")
                        on _src.Element("connector_id").Value equals _dst.Element("connector_id").Value
                        select new
                        {
                            //Name = c.Element("name").Value,
                            Source = _src.Element("card_id").Value,
                            Dest = _dst.Element("card_id").Value
                        };
            foreach (var conn in conns)
            {
                var src = (from _card in XDoc.Descendants("card")
                            where _card.Element("id").Value == conn.Source
                            select _card)
                          .First();
                var dst = (from _card in XDoc.Descendants("card")
                           where _card.Element("id").Value == conn.Dest
                           select _card)
                          .First();
                Console.WriteLine("Src:{0} Dst:{1}", 
                    src.Element("name").Value, dst.Element("name").Value);
            }
        }
    }
}
