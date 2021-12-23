using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SantaClauseConsoleApp
{
    public class Letter
    {
        private UniqueId _letterId;
        private DateTime _dateWritten;
        private List<Item> _itemsList;

        public Letter(DateTime dateWritten, List<Item> itemsList)
        {
            _letterId = new UniqueId();
            _dateWritten = dateWritten;
            _itemsList = itemsList;
        }

        public UniqueId LetterId 
        { 
            get { return _letterId; }
        }

        public DateTime DateWritten
        {
            get { return _dateWritten; }
            set { _dateWritten = value; }
        }

        public List<Item> ItemsList
        {
            get { return _itemsList; }
        }

        public void addItem(Item newItem)
        {
            _itemsList.Add(newItem);
        }

        public bool removeItem (Item oldItem)
        {
            return _itemsList.Remove(oldItem);
        }

        public override string ToString()
        {
            StringBuilder letterString = new StringBuilder();
            letterString.Append("Letter object ->\n");
            letterString.Append($"Id: {_letterId}\n");
            letterString.Append($"Date when letter was written: {_dateWritten.ToString("MM/dd/yyyy")}\n");
            letterString.Append($"Wishlist:\n");
            foreach(Item it in _itemsList)
            {
                letterString.Append($"{it.ItemName}\n");
            }
            return letterString.ToString();
        }

        
    }
}
                                        