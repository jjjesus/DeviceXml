using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JohnJesus.DeviceModel;
using JohnJesus.DataService;

namespace JohnJesus.DeviceViewModel
{
    public class SystemViewModel
    {
        public List<RackViewModel> RackViewModelList { get; set; }

        public SystemViewModel()
        {
            DeviceDataService.Load();
            RackViewModelList = new List<RackViewModel>();

            foreach (Rack rack in Rack.RackList)
            {
                RackViewModelList.Add(new RackViewModel(rack));
            }
        }
    }
}
