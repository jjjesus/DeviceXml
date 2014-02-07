using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JohnJesus.DeviceModel;

namespace JohnJesus.DeviceViewModel
{
    public class RackViewModel
    {
        Rack _rack;
        public string Name
        {
            get { return _rack.Name; }
        }
        public RackViewModel(Rack rack)
        {
            this._rack = rack;
        }
    }
}
