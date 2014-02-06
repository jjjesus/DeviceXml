using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JohnJesus.DeviceXml;

namespace JohnJesus.TryDeviceXml
{
    class Program
    {
        static void Main(string[] args)
        {
            SystemTopoXmlReader xmlReader = new SystemTopoXmlReader();
            xmlReader.LoadEmbeddedXml();
            xmlReader.CreateObjects();
            Console.WriteLine("Hit any key to continue");
            Console.ReadKey();
        }
    }
}
