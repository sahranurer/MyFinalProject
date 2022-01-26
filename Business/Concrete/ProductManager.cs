using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
      
        //bir entity manager başka bir entity enjekte edemez
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        //[LogAspect] //Bir metodun önünde sonunda bir metot hata verdiğinde çalışan kod parçacıkları aop yapılır
        //[Validate]
        //[RemoveCache]
        //[Transaction]
        //[Performance]
        [ValidationAspect(typeof(ProductValidator))]
        //[SecuredOperation("product.add,admin")]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
           IResult result =  BusinessRules.Run(CheckIfProductNameExists(product.ProductName),
                CheckIfProductCountOfCategoryCorrect(product.CategoryId),CheckIfCategoryLimitExceded());
            if (result !=null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductNameInvalid);

        }

        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            //Bir iş sınıfı başka classları newlemez
            //iş kodları yetkisi var mı
            //örnk getAll metotunda filtreleme yaparak çağırmak için Expression ihtyaç duyrız
            //if (DateTime.Now.Hour == 10)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<Product>> ( _productDal.GetAll(),Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>> (_productDal.GetAll(p=>p.CategoryId==id));
        }

        [CacheAspect]
        [PerformanceAspect(5)] // 5 saniye gecikme yaşanırsa uyar
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

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
           
            //business code
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductNameInvalid);

        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
        
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOdCategory);
            }
            return new SuccessResult();

        }

        private IResult CheckIfProductNameExists(string productName)
        {
            //Any var mı demek true false dondürür
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new  SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitexceded);
            }
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            throw new NotImplementedException();
        }

       

    }
}
