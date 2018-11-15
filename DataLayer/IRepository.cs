using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
	public interface IRepository <T> where T : Entity
	{
		 void Add(T entity);
		 void Delete(int id);
		 T GetById(int id);
		 List<T> GetAll();
		 void Update(T entity);
	}
}
