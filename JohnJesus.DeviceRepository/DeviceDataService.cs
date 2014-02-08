using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JohnJesus.DeviceXml;
using JohnJesus.DeviceModel;

namespace JohnJesus.DataService
{
    public class DeviceDataService
    {
        static public void Load()
        {
            SystemTopoXmlReader xmlReader = new SystemTopoXmlReader();
            xmlReader.LoadEmbeddedXml();
            xmlReader.CreateObjects();
            // TODO: Temporary load from hard-coded arrays
            LoadFromArrays();
        }

        private static void LoadFromArrays()
        {
            Rack.RackList = new List<Rack>()
            {
                new Rack("RACK-1"),
                new Rack("RACK-2"),
            };
            Box.BoxList = new List<Box>()
            {
                new Box("Box-1", Rack.RackList[0]),
                new Box("Box-2", Rack.RackList[0]),

                new Box("NO_BOX", Rack.RackList[1]),
                new Box("Box-4", Rack.RackList[1]),
                new Box("Box-5", Rack.RackList[1]),
            };
            Card.CardList = new List<Card>()
            {
                new Card("Card-1", Box.BoxList[0]),
                new Card("Card-2", Box.BoxList[0]),
                new Card("Card-3", Box.BoxList[0]),
                new Card("Card-4", Box.BoxList[0]),
                new Card("Card-5", Box.BoxList[0]),

                new Card("Card-11", Box.BoxList[1]),
                new Card("Card-12", Box.BoxList[1]),

                new Card("Card-21", Box.BoxList[2]),
                new Card("Card-22", Box.BoxList[2]),

                new Card("Card-31", Box.BoxList[3]),
                new Card("Card-32", Box.BoxList[3]),
                new Card("Card-33", Box.BoxList[3]),
                new Card("Card-34", Box.BoxList[3]),

                new Card("Card-41", Box.BoxList[4]),
                new Card("Card-42", Box.BoxList[4]),
                new Card("Card-43", Box.BoxList[4]),
            };
        }

        public static List<Card> GetMyCards(string name)
        {
            var cards = from _card in Card.CardList
                        where _card.Parent.Name == name
                        select _card;
            List<Card> myCards = new List<Card>();
            foreach (var card in cards)
            {
                myCards.Add(card);
            }
            return myCards;
        }

        public static List<Box> GetMyBoxes(string name)
        {
            var boxes = from _box in Box.BoxList
                        where _box.Parent.Name == name
                        select _box;
            List<Box> myBoxes = new List<Box>();
            foreach (var box in boxes)
            {
                myBoxes.Add(box);
            }
            return myBoxes;
        }
    }
}
