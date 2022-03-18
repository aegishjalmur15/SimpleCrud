using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {
        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);

        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> GetBy(Expression<Func<T,bool>> predicate);

        Task SaveAsync();
    }
}
