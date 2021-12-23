using System.Text;
using System.Xml;

namespace SantaClauseConsoleApp
{
    public class Item
    {
        private UniqueId _itemId;
        private string _itemName;

        public Item(string itemName)
        {
            _itemId = new UniqueId();
            _itemName = itemName;
        }

        public UniqueId ItemId
        {
            get { return _itemId; }
        }

        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }

        public override string ToString()
        {
            StringBuilder itemString = new StringBuilder();
            itemString.Append("Item object ->\n");
            itemString.Append($"Id: {_itemId}\n");
            itemString.Append($"Name: {_itemName}\n\n");
            return itemString.ToString();
        }

    }
}
