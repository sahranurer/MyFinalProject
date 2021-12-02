using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

//core evrensel katmanım 
// tüm dot.net projelerimde kullanabilirim.
namespace Core.DataAccess
{//generic constraint-generic kısıt where T:class
    //class : referans tip
    //IEntity : IEntity olabilir veya IEntity implemente eden bir nesne olabilir
    // new(): new lenebilir olmalı
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null); //bu yapı ile ayrı ayrı metotlar yazmaya gerek yok
        T Get(Expression<Func<T, bool>> filter); //tek data getirmek için
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        
    }
}
