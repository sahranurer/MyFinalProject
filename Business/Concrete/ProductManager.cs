﻿using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        //[LogAspect] //Bir metodun önünde sonunda bir metot hata verdiğinde çalışan kod parçacıkları aop yapılır
        //[Validate]
        //[RemoveCache]
        //[Transaction]
        //[Performance]
        public IResult Add(Product product)
        {

            if (product.ProductName.Length<2)
            {
                //magic strings
                return new ErrorResult(Messages.ProductNameInvalid);
            }

            //business codes
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductNameInvalid);
        }

        public IDataResult<List<Product>> GetAll()
        {
            //Bir iş sınıfı başka classları newlemez
            //iş kodları yetkisi var mı
            //örnk getAll metotunda filtreleme yaparak çağırmak için Expression ihtyaç duyrız
            if (DateTime.Now.Hour == 10)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>> ( _productDal.GetAll(),Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>> (_productDal.GetAll(p=>p.CategoryId==id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult< Product >(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>( _productDal.GetAll(p => 
            p.UnitPrice >= min && p.UnitPrice <= min));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new  ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>( _productDal.GetProductDetails());
        }
    }
}
