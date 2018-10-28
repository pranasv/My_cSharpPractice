using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tst1
{
    class Program
    {
        static void Main(string[] args)
        {
            var item = new Item("Myfirst Item");                   
            item.AddSubItem();          
            new Item("anoteher one Item");
            Item.ItemsCollection[2].AddSubItem(3);
            Item.PrintAllItems();
            Console.ReadKey();
        }
    }
}
