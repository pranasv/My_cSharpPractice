using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
	public class WorkOperation : Entity
	{
		public double CostPerMinute{get;set;}
		public WorkOperation(string name):base (name)
		{
			
		}
	}
}
