using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Core.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public DbContext _dataContext { get; set; }

        public DbSet<T> _dbSet { get; set; }

        public BaseRepository(DbContext context)
        {
            _dataContext = context;
            _dbSet = context.Set<T>();
        }

        public T Add(T item)
        {
                _dbSet.Add(item);
                Commit();
                _dataContext.Entry(item).GetDatabaseValues();

            return item;
        }

        public virtual Task Add(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public virtual T GetByID(Guid id)
        {
            return _dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetByFilter(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public virtual Task<IEnumerable<T>> GetByFilterAndPaging(System.Linq.Expressions.Expression<Func<T, bool>> predicate, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<T> GetAll
        {
            get { return _dbSet; }
        }

        public virtual T Update(T item)
        {
            var entry = _dataContext.Entry(item);
            _dbSet.Attach(item);

            Commit();

            return item;
        }

        public bool Delete(Guid id)
        {
            try
            {
                T item = GetByID(id);
                _dbSet.Remove(item);
                Commit();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public virtual Task Delete(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public virtual async Task Delete(T item)
        {
            _dbSet.Remove(item);
            Commit();
        }

        public virtual Task DeleteAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> ItemsCountByFilter(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<int> ItemsCountAll()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            _dataContext.SaveChanges();
        }
    }
}
