using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JohnJesus.DeviceModel
{
    public class Box
    {
        Rack _parent;
        public Rack Parent
        {
            get { return _parent; }
        }

        static List<Box> _boxList;
        public static List<Box> BoxList
        {
            get { return _boxList; }
            set { _boxList = value; }
        }
        static Box()
        {
            _boxList = new List<Box>();
        }

        public string Name { get; set; }

        public Box(string name, Rack parent)
        {
            this.Name = name;
            this._parent = parent;
            _boxList.Add(this);
        }
    }
}
