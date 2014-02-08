using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JohnJesus.DeviceModel
{
    public class Rack
    {
        static List<Rack> _rackList;
        public static List<Rack> RackList
        {
            get { return _rackList; }
            set { _rackList = value; }
        }
        static Rack()
        {
            _rackList = new List<Rack>();
        }

        public string Name { get; set; }

        public Rack(string name)
        {
            this.Name = name;
            _rackList.Add(this);
        }
    }
}
