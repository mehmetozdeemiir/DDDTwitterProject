using DDDProject_Twitter.Domain.Entities.Interface;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DDDProject_Twitter.Domain.Repositories.BaseRepo
{
   public interface IRepository<T> where T:class,IBaseEntity
    {
        //Task olarak kullanıyoruz yani asenkron programlama uyguluyoruz.

        Task<List<T>> GetAll(); //hepsini listele
        Task<List<T>> Get(Expression<Func<T, bool>> expression); //istediğim linq sorgusunu listeli bir şekilde getir
        Task<T> GetById(int id); //id den yakaka
        Task<T> FirstOrDefault(Expression<Func<T, bool>> expression); //İstediğim linq sorgusuyla ilk sorguyu getir
        Task<bool> Any(Expression<Func<T, bool>> expression);

        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);


        //Bir sorguya bir cok tablonun girmesi ve onların ayarlanması

        Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<T, TResult>> selector,
                                                  Expression<Func<T, bool>> expression = null,
                                                  Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
                                                  Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                                  bool disableTracing = true,
                                                  int pageIndex = 3, int pageSize = 3//page index i 3 den başlıycak size ı 3 tane alıcak 
);

        Task<TResult> GetFilteredFirstOrDefault<TResult>(Expression<Func<T, TResult>> selector,
        Expression<Func<T, bool>> expression = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
        bool disableTracing = true);
    }
}
