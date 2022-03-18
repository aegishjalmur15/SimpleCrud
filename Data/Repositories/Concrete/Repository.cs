using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Concrete
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        protected readonly DbContext _context;
        protected DbSet<T> DbSetInstance;
        public Repository(CrudContext context)
        {
            _context = context;
            DbSetInstance = _context.Set<T>();
        }
        public void Add(T entity)
        {
            DbSetInstance.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSetInstance.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetBy(Expression<Func<T,bool>> predicate)
        {
            return DbSetInstance.Where(predicate);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await DbSetInstance.ToListAsync();
        }

        public void Update(T entity)
        {
            DbSetInstance.Update(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
