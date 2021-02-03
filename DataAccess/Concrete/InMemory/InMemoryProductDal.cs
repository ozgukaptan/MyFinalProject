﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product> {
                new Product{ProductId = 1, CategoryId = 1,ProductName="Bardak",UnitsInStock = 15 , UnitPrice = 15},
                new Product{ProductId = 2, CategoryId = 1,ProductName="Kamera",UnitsInStock = 3 , UnitPrice = 500},
                new Product{ProductId = 3, CategoryId = 2,ProductName="Telefon",UnitsInStock = 2 , UnitPrice = 1500},
                new Product{ProductId = 4, CategoryId = 2,ProductName="Klavye",UnitsInStock = 65 , UnitPrice = 150},
                new Product{ProductId = 5, CategoryId = 2,ProductName="Fare",UnitsInStock = 1 , UnitPrice = 85}
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query
            //Lambda

            //Product productToDelete = null;
            //foreach (var p in _products)
            //{
            //    if(product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}

            // SingleOrDefault Tektek dolaşmaya yarar
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);

            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }
       
        public void Update(Product product)
        {
            // Gönderdiğim ürün Id sine sahip olan listedeki ütrünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.CategoryId = product.CategoryId;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
           return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
