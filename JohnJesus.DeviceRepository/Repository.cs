using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JohnJesus.DeviceXml;

namespace JohnJesus.DeviceRepository
{
    public class Repository
    {
        static public void Load()
        {
            SystemTopoXmlReader xmlReader = new SystemTopoXmlReader();
            xmlReader.LoadEmbeddedXml();
            xmlReader.CreateObjects();
        }
    }
}
