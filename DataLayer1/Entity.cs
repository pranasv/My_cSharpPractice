using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public abstract class Entity
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return "Name: " + Name + "  Id: " + Id;
        }
    }
}
