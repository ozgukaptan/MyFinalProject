﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            productManager.GetAll();

            foreach (var p in productManager.GetByUnitPrice(50,100))
            {
                Console.WriteLine(p.ProductName);
            }
            
            //Console.WriteLine("Hello World!");
        }
    }
}
