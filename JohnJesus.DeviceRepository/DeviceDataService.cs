using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JohnJesus.DeviceXml;
using JohnJesus.DeviceModel;

namespace JohnJesus.DataService
{
    public class DeviceDataService
    {
        static public void Load()
        {
            SystemTopoXmlReader xmlReader = new SystemTopoXmlReader();
            xmlReader.LoadEmbeddedXml();
            xmlReader.CreateObjects();
            // TODO: Temporary load from hard-coded arrays
            LoadFromArrays();
        }

        private static void LoadFromArrays()
        {
            Rack.RackList = new List<Rack>()
            {
                new Rack("RACK-1"),
                new Rack("RACK-2"),
            };
        }
    }
}
