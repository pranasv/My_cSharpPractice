using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
	public abstract class Entity
    {

		public int Id{get;set;}
		public string Name{get;set;}		
		public  Entity (string name)
		{
			Name = name;
		}
		public override string ToString()
		{
			return "Name: " + Name + "  Id: " + Id;
		}
	}
}
