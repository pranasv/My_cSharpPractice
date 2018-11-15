using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        public void Add(T entity)
        {
            var id = Items.Any() ? Items.Last().Id++ : 1;
            entity.Id = id;
            Items.Add(entity);
        }

        public void Delete(int id)
        {
            var item = Items.FirstOrDefault(c => c.Id == id);
            Items.Remove(item);
        }

        public T GetById(int id)
        {
            return Items.FirstOrDefault(i => i.Id == id);
        }

        public List<T> GetAll()
        {
            return Items;
        }

        public void Update(T entity)
        {
            var item = Items.FirstOrDefault(c => c.Id == entity.Id);
            Items.Remove(entity);
            Items.Add(item);
        }
        private static List<T> Items = new List<T>();
    }
}

