using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        //Category ile ilgili dış dünyaya neyi servis etmek istiyorsam bu
        //operasyonlar ICategoryService içerisinde yer alır
        IDataResult<List<Category>>  GetAll(); //Tümünü listeler
        IDataResult<Category> GetById(int categoryId); //bir categorynin detayına gitmek için



    }
}
