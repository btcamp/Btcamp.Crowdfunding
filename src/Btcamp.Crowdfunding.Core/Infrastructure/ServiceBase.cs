using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Btcamp.Crowdfunding.Core.Infrastructure
{
    public class ServiceBase<T> where T : class
    {
        IRepository<T> _repositroy = null;
        public ServiceBase(IRepository<T> repository)
        {
            this._repositroy = repository;
        }
        public virtual void Add(T entity)
        {
            _repositroy.Add(entity);
        }

        public void Update(T entity)
        {
            _repositroy.Update(entity);
        }

        public void Delete(T entity)
        {
            _repositroy.Delete(entity);
        }

        public T GetById(int id)
        {
            return _repositroy.GetById(id);
        }

        public T GetById(string id)
        {
            return _repositroy.GetById(id);
        }

        public T GetById(Guid id)
        {
            return _repositroy.GetById(id);
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return _repositroy.Get(where);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _repositroy.GetMany(where);
        }

        public IEnumerable<T> GetAll()
        {
            return _repositroy.GetAll();
        }

        public IPagedList<T> GetPage<TOrder>(Page page, Expression<Func<T, bool>> where, Expression<Func<T, TOrder>> order)
        {
            return _repositroy.GetPage<TOrder>(page, where, order);
        }

        public IPagedList<T> GetPage<TOrder>(Page page, Expression<Func<T, bool>> where, Expression<Func<T, TOrder>> order, bool isDesc)
        {
            return _repositroy.GetPage<TOrder>(page, where, order, isDesc);
        }

        public T GetAsNoTracking(Expression<Func<T, bool>> where)
        {
            return _repositroy.GetAsNoTracking(where);
        }

        public IEnumerable<T> GetManyAsNoTracking(Expression<Func<T, bool>> where)
        {
            return _repositroy.GetManyAsNoTracking(where);
        }

        public IEnumerable<T> GetAllAsNoTracking()
        {
            return _repositroy.GetAllAsNoTracking();
        }

        public IPagedList<T> GetPageAsNoTracking<TOrder>(Page page, Expression<Func<T, bool>> where,
            Expression<Func<T, TOrder>> order)
        {
            return _repositroy.GetPageAsNoTracking<TOrder>(page, where, order);
        }

        public IPagedList<T> GetPageAsNoTracking<TOrder>(Page page, Expression<Func<T, bool>> where,
            Expression<Func<T, TOrder>> order, bool isDesc)
        {
            return _repositroy.GetPageAsNoTracking<TOrder>(page, where, order, isDesc);
        }

    }
}
