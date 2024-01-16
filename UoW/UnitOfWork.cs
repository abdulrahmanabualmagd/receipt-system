using MVC_Core.Data;
using MVC_Core.Models;
using MVC_Core.Repositories;

namespace MVC_Core.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Injection
        private readonly ApplicationDbContext _context;
        public IRepository<School> Schools { get; private set; }
        public IRepository<Student> Students { get; private set; }  // private set to be assignable only through this class (unit of work)
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Schools = new Repository<School>(_context);
            Students = new Repository<Student>(_context);
        }
        #endregion

        #region Complete
        public async Task<int> CompleteAsync()
        {
            // Returns the number of the affected rows in database
            return await _context.SaveChangesAsync();
        }
        #endregion

        #region Dispose
        public ValueTask DisposeAsync()
        {
            return _context.DisposeAsync();
        } 
        #endregion
    }
}
