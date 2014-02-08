using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JohnJesus.DeviceModel;
using JohnJesus.DeviceRepository;

namespace JohnJesus.DeviceViewModel
{
    public class SystemViewModel
    {
        List<Rack> _rackList;
        public List<Rack> RackList
        {
            get { return _rackList; }
            set { _rackList = value; }
        }
        public List<RackViewModel> RackViewModelList { get; set; }

        public SystemViewModel()
        {
            Repository.Load();
            RackList = new List<Rack>()
            {
                new Rack("RACK-1"),
                new Rack("RACK-2"),
            };
            RackViewModelList = new List<RackViewModel>();

            foreach (Rack rack in _rackList)
            {
                RackViewModelList.Add(new RackViewModel(rack));
            }
        }
    }
}
