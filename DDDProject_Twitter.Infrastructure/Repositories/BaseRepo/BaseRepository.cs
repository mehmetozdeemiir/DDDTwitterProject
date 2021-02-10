using DDDProject_Twitter.Domain.Entities.Interface;
using DDDProject_Twitter.Domain.Repositories.BaseRepo;
using DDDProject_Twitter.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DDDProject_Twitter.Infrastructure.Repositories.BaseRepo
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class, IBaseEntity
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _table;

        public BaseRepository(ApplicationDbContext context)
        {
            this._context = context;
            this._table = _context.Set<T>();
        }


        public async Task Add(T entity) => await _table.AddAsync(entity);


        public async Task<bool> Any(Expression<Func<T, bool>> expression) => await _table.AnyAsync(expression);


        public void Delete(T entity) => _table.Remove(entity);//remove da await yazılmaz


        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> expression) => await _table.Where(expression).FirstOrDefaultAsync();


        public async Task<List<T>> Get(Expression<Func<T, bool>> expression) => await _table.Where(expression).ToListAsync();


        public async Task<List<T>> GetAll() => await _table.ToListAsync();


        public async Task<T> GetById(int id) => await _table.FindAsync(id);


        public async Task<TResult> GetFilteredFirstOrDefault<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracing = true)
        {
            IQueryable<T> query = _table; //hangi table üzerinde filtreleme uyguluycaksam atmam gerekiyor 
            if (disableTracing) query = query.AsNoTracking();//Tracking i kapatmıs oluyorum . Tracking: varlık üzerindeki değişikliklere bakıyodu biz bir filtreleme yaptıgmız için değişikliğe gerek yok onun için kapattık. 
            if (include != null) query = include(query); //Herşeyi query içerisine atıyoruz 
            if (expression != null) query = query.Where(expression); //expression doluysa query nın icine at
            if (orderby != null) return await orderby(query).Select(selector).FirstOrDefaultAsync();
            else return await query.Select(selector).FirstOrDefaultAsync();
        }

        public async Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracing = true, int pageIndex = 3, int pageSize = 3)
        {
            IQueryable<T> query = _table;
            if (disableTracing) query = query.AsNoTracking();
            if (include != null) query = include(query);
            if (expression != null) query = query.Where(expression);
            if (orderby != null) return await orderby(query).Select(selector).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            else return await query.Select(selector).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

    }
}
