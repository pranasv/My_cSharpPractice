using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tst1
{
    class Item
    {
        public static List<Item> id = new List<Item>();
        private int ID { get; set; }
        private List<int> FatherID { get;  set; } = new List<int>();
        private List<int> ChildID { get;  set; } = new List<int>();
        public string Name { get; set; }
        public string Description { get; set; }
        public Item()
        {
            this.ID = ID_Counter.value;
            ID_Counter.value++;
            id.Add(this);
        }
        public void AddSubItem(int subitemID = 0)
        {
            if (subitemID == 0)
            {
                var newitem = new Item();
                ChildID.Add(newitem.ID);
                newitem.FatherID.Add(this.ID);
            }
            else
            {
                ChildID.Add(subitemID);
                Item.id[subitemID].FatherID.Add(this.ID);
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
            if (ChildID != null)
            {
                foreach (int item in ChildID)
                {
                    Contains += item + "; ";
                }
            }
            return "ID: " + ID + "   Name: " + Name + "   Description: " + Description + "   Used in Items(ID): " + WhereUsed + "   Contains subitems(ID): " + Contains;
        }

    }
}
