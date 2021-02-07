using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
            //Ioc
            //CategoryTest();


            //Console.WriteLine("Hello World!");
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCateoryDal());

            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            productManager.GetAll();

            foreach (var p in productManager.getProductDetails())
            {
                Console.WriteLine(p.ProductName + "/" + p.CategoryName);
            }
        }
    }
}
