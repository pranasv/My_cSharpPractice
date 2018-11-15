using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
	public interface IRepository <T> where T : Entity
	{
		 void Add(T item);
		 void Delete(int id);
		 T Get(int id);
		 List<T> GetAll();
		 void Update(T item);
	}
}
