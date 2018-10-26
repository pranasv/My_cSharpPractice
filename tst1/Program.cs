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
            var item = new Item();
            new Item();
            item.AddSubItem();
            item.AddSubItem();
            item.AddSubItem();            
            Console.WriteLine(item);
            Console.WriteLine(Item.id[1]);
            Item.id[2].AddSubItem(1);            
            Console.WriteLine(Item.id[2]);
            Console.ReadKey();
        }
    }
}
