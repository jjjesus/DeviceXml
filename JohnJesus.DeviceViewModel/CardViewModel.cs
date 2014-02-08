using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JohnJesus.DeviceModel;

namespace JohnJesus.DeviceViewModel
{
    public class CardViewModel : BaseViewModel
    {
        Card _card;
        public string Name
        {
            get { return _card.Name; }
        }
        public CardViewModel(Card card)
        {
            this._card = card;
        }
    }
}
