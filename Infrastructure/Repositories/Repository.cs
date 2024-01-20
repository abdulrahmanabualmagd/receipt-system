using System.Web.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using System.Linq.Expressions;
using Core.IRepositories;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class 
    {
        #region Dependency Injection
        protected readonly ApplicationDbContext _context;  

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region AddAsync
        public async Task<bool> AddAsync(T entity)
            => (await _context.Set<T>().AddAsync(entity)).State == EntityState.Added; 
        #endregion

        #region Update
        public bool Update(T entity)
            => (_context.Set<T>().Update(entity)).State == EntityState.Modified;
        #endregion

        #region Delete
        public bool Delete(T entity)
            => (_context.Set<T>().Remove(entity)).State == EntityState.Deleted;
        #endregion

        #region GetByIdAsync
        public async Task<T> GetByIdAsync(int id)
            => await _context.Set<T>().FindAsync(id);
        #endregion

        #region GetAllAsync
        public async Task<IEnumerable<T>> GetAllAsync(string[]? include = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (include != null)
                foreach (var item in include)
                    query = query.Include(item);

            return await query.ToListAsync();
        }
        #endregion

        #region GetPageAsync
        public async Task<IEnumerable<T>> GetPageAsync(int pageIndex, int pageSize, string[]? include = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (include != null)
                foreach (var item in include)
                    query = query.Include(item);

            return await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        #endregion

        #region FindAsync
        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate, string[]? include = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (include != null)
                foreach (var item in include)
                    query = query.Include(item);

            return await query.FirstOrDefaultAsync(predicate);
        }
        #endregion

        #region CountAsync
        public async Task<int> CountAsync()
            => await _context.Set<T>().CountAsync();
        #endregion

        #region FirstOrDefaultAsync
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
            => await _context.Set<T>().FirstOrDefaultAsync(predicate);
        #endregion

        #region SingleOrDefaultAsync
        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
            => await _context.Set<T>().SingleOrDefaultAsync(predicate);
        #endregion

        #region AnyAsync
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
           => await _context.Set<T>().AnyAsync(predicate);
        #endregion

        #region Attach 
        public void Attach(T entity)
            => _context.Set<T>().Attach(entity);
        #endregion

        #region Detach
        public void Detach(T entity)
            => (_context.Entry(entity)).State = EntityState.Detached;
        #endregion

        #region GetListItems
        public async Task<IEnumerable<SelectListItem>> GetListItems(Expression<Func<T, SelectListItem>> predicate)
            => await _context.Set<T>().Select(predicate).ToListAsync();
        #endregion
    }
}
