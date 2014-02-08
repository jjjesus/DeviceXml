using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JohnJesus.DeviceModel
{
    public class Connector
    {
        static List<Connector> _connectorList;
        public static List<Connector> ConnectorList
        {
            get { return _connectorList; }
            set { _connectorList = value; }
        }
        static Connector()
        {
            _connectorList = new List<Connector>();
        }

        public string Name { get; set; }

        public Connector(string name)
        {
            this.Name = name;
            _connectorList.Add(this);
        }
    }
}
