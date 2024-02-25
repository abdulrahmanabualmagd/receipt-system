using Core.IRepositories;
using Core.IUoW;
using Infrastructure.Data.Contexts.Application;
using Infrastructure.Repositories;
using System.Collections;

namespace Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Injection
        private readonly ApplicationDbContext _context;
        private Hashtable _repositories;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _repositories = new Hashtable();
        }
        #endregion

        #region Complete
        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync(); // returns number of affected rows
        #endregion

        #region Dispose
        public ValueTask DisposeAsync() => _context.DisposeAsync();
        #endregion

        #region Repository Factory
        public IRepository<T> Repository<T>() where T : class
        {
            var type = typeof(T).Name;
            if(!_repositories.ContainsKey(type))
            {
                // Create new repo 
                var repo = new Repository<T>(_context);
                // Add reopsitory to the hashtable repositories
                _repositories.Add(type, repo);
            }
            return (IRepository<T>) _repositories[type];
        }
        #endregion
    }
}
