using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JohnJesus.DeviceModel;
using JohnJesus.DataService;

namespace JohnJesus.DeviceViewModel
{
    public class RackViewModel
    {
        public List<BoxViewModel> ChildViewModelList { get; set; }

        Rack _rack;
        public string Name
        {
            get { return _rack.Name; }
        }
        public RackViewModel(Rack rack)
        {
            this._rack = rack;
            ChildViewModelList = new List<BoxViewModel>();
            List<Box> myBoxList = DeviceDataService.GetMyBoxes(_rack.Name);

            foreach (Box box in myBoxList)
            {
                ChildViewModelList.Add(new BoxViewModel(box));
            }
        }
    }
}
