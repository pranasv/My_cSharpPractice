using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class ProductService
    {
        private readonly IRepository<Product> _productRepository = new ProductRepository();
        private readonly ChildProductInfoRepository _ChildProductInfoRepository = new ChildProductInfoRepository();

        public ProductService()
        {

        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }
               
        public Product GetProduct(int id)
        {
            return _productRepository.Get(id);
        }

        public List<int> WhereUsed(Product item) // returns list of parents id's
        {
            var result = new List<int>();
            foreach (ChildProductInfo _item in _ChildProductInfoRepository.GetAll())
            {
                if (_item.ChildId == item.Id)
                {
                    result.Add(_item.ParentId);
                }
            }
            return result;
        }

        public List<int> GetProductChildsIds(Product item)
        {
            var result = new List<int>();
            foreach (ChildProductInfo _item in _ChildProductInfoRepository.GetAll())
            {
                if (_item.ParentId == item.Id)
                {
                    result.Add(_item.ChildId);
                }
            }
            return result;
        }

        public List<Product> GetProductChilds(Product item)
        {
            var result = new List<Product>();
            foreach (ChildProductInfo _item in _ChildProductInfoRepository.GetAll())
            {
                if (_item.ParentId == item.Id)
                {
                    result.Add(GetProduct(_item.ChildId));
                }
            }
            return result;
        }

        public void AddProduct(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _productRepository.Add(item);
        }

        public void AddChildProduct(int parentId, Product item) // adds subitem to item
        {
            //check for duplicate
            _ChildProductInfoRepository.Add(parentId, item.Id);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.Delete(id);
        }

        public void DeleteChildProduct(int parentId, int childId)
        {
            _ChildProductInfoRepository.Delete(parentId, childId);
        }
    }
}
