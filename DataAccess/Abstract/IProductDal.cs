using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        //ürüne ait özel özellikler için
        //tamamen productdala özgü bir join 
        List<ProductDetailDto> GetProductDetails();
    }
}
//code refactoring 