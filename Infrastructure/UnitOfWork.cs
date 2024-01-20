using Core.IRepositories;
using Core.IUoW;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Injection
        private readonly ApplicationDbContext _context;
        public ISchoolRepository Schools { get; private set; }
        public IStudentRepository Students { get; private set; }  

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Schools = new SchoolRepository(_context);
            Students = new StudentRepository(_context);
        }
        #endregion

        #region Complete
        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync(); // returns number of affected rows
        #endregion

        #region Dispose
        public ValueTask DisposeAsync() => _context.DisposeAsync();
        #endregion
    }
}
