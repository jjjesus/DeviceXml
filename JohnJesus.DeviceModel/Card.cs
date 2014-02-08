using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JohnJesus.DeviceModel
{
    public class Card
    {
        Box _parent;
        public Box Parent
        {
            get { return _parent; }
        }
        static List<Card> _cardList;
        public static List<Card> CardList
        {
            get { return _cardList; }
            set { _cardList = value; }
        }
        static Card()
        {
            _cardList = new List<Card>();
        }

        public string Name { get; set; }

        public Card(string name, Box parent)
        {
            this.Name = name;
            this._parent = parent;
            _cardList.Add(this);
        }
    }
}
