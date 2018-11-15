using System;
using System.Collections.Generic;
using System.Text;


namespace DataLayer
{
    public class Product : Entity
    {
        public double Cost { get; set; }      
        public int UomId { get; set; }
    }
}
