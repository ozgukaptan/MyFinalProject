using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return new List<Product> {
                new Product{ProductId = 1, CategoryId = 1,ProductName="EfBardak",UnitInStok = 15 , UnitPrice = 15},
                new Product{ProductId = 2, CategoryId = 1,ProductName="EfKamera",UnitInStok = 3 , UnitPrice = 500},
                new Product{ProductId = 3, CategoryId = 2,ProductName="EfTelefon",UnitInStok = 2 , UnitPrice = 1500},
                new Product{ProductId = 4, CategoryId = 2,ProductName="EfKlavye",UnitInStok = 65 , UnitPrice = 150},
                new Product{ProductId = 5, CategoryId = 2,ProductName="EFFare",UnitInStok = 1 , UnitPrice = 85}
            };
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
