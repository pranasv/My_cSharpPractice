using System;
using System.Collections.Generic;
using System.Text;


namespace DataLayer
{
    public class Product : Entity
    {
        public Uom uom { get; set; }
        public double Qty { get; set; }
        public double Cost { get; set; }
        public List<int> PrentId { get; set; }
        public List<int> ChildId { get; set; }
        public int UomId { get; set; }
        public Product(string name) : base(name)
        {
        }
    }
}
