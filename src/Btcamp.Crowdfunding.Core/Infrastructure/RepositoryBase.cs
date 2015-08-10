using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Btcamp.Crowdfunding.Core.Infrastructure
{
    public class RepositoryBase<T> where T : class
    {
        private DbContext dbContext;

        private IDbSet<T> dbSet;

        public RepositoryBase(IDbContextFactory dbfactory)
        {
            this.dbContext = dbfactory.DataContext;
            dbSet = DataContext.Set<T>();
        }

        public DbContext DataContext
        {
            get
            {
                return dbContext;
            }
        }
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            DataContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public T GetById(string id)
        {
            return dbSet.Find(id);
        }

        public T GetById(Guid id)
        {
            return dbSet.Find(id);
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault();
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).AsEnumerable();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.AsEnumerable();
        }

        public IPagedList<T> GetPage<TOrder>(Page page, Expression<Func<T, bool>> where, Expression<Func<T, TOrder>> order)
        {
            var result = dbSet.Where(where).OrderBy(order).GetPage(page);
            var count = dbSet.Count(where);
            return new StaticPagedList<T>(result, page.PageIndex, page.PageSize, count);
        }

        public IPagedList<T> GetPage<TOrder>(Page page, Expression<Func<T, bool>> where, Expression<Func<T, TOrder>> order, bool isDesc)
        {
            if (isDesc)
            {

                var result = dbSet.Where(where).OrderByDescending(order).GetPage(page);
                var count = dbSet.Count(where);
                return new StaticPagedList<T>(result, page.PageIndex, page.PageSize, count);
            }
            else
            {
                return GetPage<TOrder>(page, where, order);
            }
        }

        public T GetAsNoTracking(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).AsNoTracking().FirstOrDefault();
        }

        public IEnumerable<T> GetManyAsNoTracking(Expression<Func<T, bool>> where)
        {
            return dbSet.AsNoTracking().Where(where).AsEnumerable();
        }

        public IEnumerable<T> GetAllAsNoTracking()
        {
            return dbSet.AsNoTracking().AsEnumerable();
        }

        public IPagedList<T> GetPageAsNoTracking<TOrder>(Page page, Expression<Func<T, bool>> where,
            Expression<Func<T, TOrder>> order)
        {
            var result = dbSet.AsNoTracking().Where(where).OrderBy(order).GetPage(page);
            var count = dbSet.AsNoTracking().Count(where);
            return new StaticPagedList<T>(result, page.PageIndex, page.PageSize, count);
        }
        public IPagedList<T> GetPageAsNoTracking<TOrder>(Page page, Expression<Func<T, bool>> where,
            Expression<Func<T, TOrder>> order, bool isDesc)
        {
            if (isDesc)
            {
                var result = dbSet.AsNoTracking().Where(where).OrderByDescending(order).GetPage(page);
                var count = dbSet.AsNoTracking().Count(where);
                return new StaticPagedList<T>(result, page.PageIndex, page.PageSize, count);
            }
            else
            {
                return GetPageAsNoTracking(page, where, order);
            }

        }


    }
}
