using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Core.Repositories
{
    public interface IBaseRepository<T> where T:class
    {
        T Add(T item);
        Task Add(IEnumerable<T> items);

        //Task<T> GetByID(Expression<Func<T, bool>> expression);
        T GetByID(Guid id);
        IEnumerable<T> GetByFilter(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetByFilterAndPaging(Expression<Func<T, bool>> predicate, int page, int pageSize);
        IQueryable<T> GetAll { get; }

        T Update(T item);

        //Task Delete(Expression<Func<T, bool>> expression);
        bool Delete(Guid id);
        Task Delete(T item);
        Task DeleteAll();

        Task<int> ItemsCountByFilter(Expression<Func<T, bool>> predicate);

        Task<int> ItemsCountAll();
    }
}
