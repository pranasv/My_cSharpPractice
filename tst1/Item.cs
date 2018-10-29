using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tst1
{
    class Item
    {
        public static Dictionary<int, Item> ItemsCollection { get; private set; } = new Dictionary<int, Item>();
        private int ID { get; set; }
        private List<int> FatherID { get; set; } = new List<int>();        
        private Dictionary<int, int> SubItem = new Dictionary<int, int>(); // Subitem ID & Qty in Item
        private static int ID_Counter = 1;
        public string Name { get; set; }
        public string Description { get; set; }
        public Item(string name = "New Item", string description = "")
        {
            this.ID = ID_Counter;
            ID_Counter++;
            ItemsCollection.Add(ID, this);
            Name = name;
            Description = description;
        }
        public void AddSubItem(int subitemID = 0, int qty = 1)
        {
            if (subitemID == 0)
            {
                var newitem = new Item();              
                SubItem.Add(newitem.ID, qty);
                newitem.FatherID.Add(this.ID);
            }
            else
            {
                int total;
                SubItem.TryGetValue(subitemID, out total);
                total += qty;
                SubItem[subitemID] = total;
                if (!ItemsCollection[subitemID].FatherID.Contains(this.ID))
                {
                    ItemsCollection[subitemID].FatherID.Add(this.ID);
                }
            }
        }
        public static void PrintAllItems()
        {
            foreach (KeyValuePair<int, Item> item in ItemsCollection)
            {
                Console.WriteLine(item.Value);
            }
        }
        public override string ToString()
        {
            string WhereUsed = "";
            if (FatherID != null)
            {
                foreach (int item in FatherID)
                {
                    WhereUsed += item + "; ";
                }
            }
            string Contains = "";
            if (SubItem != null)
            {
                foreach (KeyValuePair<int, int> item in SubItem)
                {
                    Contains += item.Key + ", "+item.Value+"; ";
                }
            }
            return "ID: " + ID + "   Name: " + Name + "   Description: " + Description + "   Used in Items(ID): " + WhereUsed + "   Contains subitems(ID, qty): " + Contains;
        }

    }
}
