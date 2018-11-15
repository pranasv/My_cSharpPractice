using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
	public class Uom:Entity
	{
		public Uom (string name):base(name)
		{			
		}
		public override string ToString()
		{
			return Name;
		}
	}
}
