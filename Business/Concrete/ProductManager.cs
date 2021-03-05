using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Castle.Core.Internal;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using FluentValidation;
using Business.BusinessAspects.Autofac;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {

        IProductDal _productDal;
        ICategoryService _categoryService;

        // bir entity manager kendisi hariç başka bir dalı enjekte edemez
        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları
            if (DateTime.Now.Hour == 15)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }


            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        //Claim yetki demek.

        [SecuredOperation("product.add")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {

            // bussines Code
            // Eğer mevcut kategoery sayısı 15 i geçtiyse sisteme Yeni ürün eklenemez.
            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId)
                 , CheckIfProductNameExist(product.ProductName),CheckIfCategoryLimitExceded());
            
            if (result != null)
            {
                return result;
            }

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);

        }
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 00)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.getProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            // Bir kategoride en fazla 10 ürün olabilir.
            var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.PrpductCountOfCategoryError);
            }

            // bussines Code
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductAdded);
        }


        // İş kuralı
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            // önce tüm data çekilmez 
            // select count (*) from products where categoryId=1
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.PrpductCountOfCategoryError);
            }

            return new SuccessResult();
        }

        private IResult CheckIfProductNameExist(string productName)
        {
            // önce tüm data çekilmez 
            // select count (*) from products where categoryId=1
            // Any sorgu içinde eleman var mı diye bakar
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.PrpductNameAlreadyExist);
            }

            return new SuccessResult();
        }

        // Bunu kategory managere yazarsak başlıbaşına bir servis olur.
        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }

            return new SuccessResult();
        }
    }
}
