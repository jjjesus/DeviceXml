using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JohnJesus.DeviceModel;
using JohnJesus.DataService;

namespace JohnJesus.DeviceViewModel
{
    public class RackViewModel : BaseViewModel
    {
        public List<BaseViewModel> ChildViewModelList { get; set; }

        Rack _rack;
        public string Name
        {
            get { return _rack.Name; }
        }
        public RackViewModel(Rack rack)
        {
            this._rack = rack;
            ChildViewModelList = new List<BaseViewModel>();
            List<Box> myBoxList = DeviceDataService.GetMyBoxes(_rack.Name);

            foreach (Box box in myBoxList)
            {
                if (box.Name != "NO_BOX")
                    ChildViewModelList.Add(new BoxViewModel(box));
                else
                {
                    List<Card> myCardList = DeviceDataService.GetMyCards(box.Name);
                    foreach (Card card in myCardList)
                    {
                        ChildViewModelList.Add(new CardViewModel(card));
                    }
                }
            }
        }
    }
}
