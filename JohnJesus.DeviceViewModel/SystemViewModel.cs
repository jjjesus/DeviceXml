using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JohnJesus.DeviceModel;
using JohnJesus.DataService;

namespace JohnJesus.DeviceViewModel
{
    public class SystemViewModel : BaseViewModel
    {
        public List<RackViewModel> ChildViewModelList { get; set; }

        public SystemViewModel()
        {
            DeviceDataService.Load();
            ChildViewModelList = new List<RackViewModel>();

            foreach (Rack rack in Rack.RackList)
            {
                ChildViewModelList.Add(new RackViewModel(rack));
            }
        }
    }
}
