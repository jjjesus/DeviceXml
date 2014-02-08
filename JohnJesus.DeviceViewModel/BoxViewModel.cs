using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JohnJesus.DeviceModel;
using JohnJesus.DataService;

namespace JohnJesus.DeviceViewModel
{
    public class BoxViewModel : BaseViewModel
    {
        Box _box;
        public string Name
        {
            get { return _box.Name; }
        }
        public List<CardViewModel> ChildViewModelList { get; set; }
        public BoxViewModel(Box box)
        {
            this._box = box;
            ChildViewModelList = new List<CardViewModel>();

            List<Card> myCardList = DeviceDataService.GetMyCards(_box.Name);

            foreach (Card card in myCardList)
            {
                ChildViewModelList.Add(new CardViewModel(card));
            }
        }
    }
}
