using Core.Entities;
using Core.IRepositories;
using Core.IUoW;
using Infrastructure.Data.Contexts.Application;
using Infrastructure.Repositories;

namespace Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Injection
        private readonly ApplicationDbContext _context;
        public IRepository<School> Schools { get; private set; }
        public IRepository<Student> Students { get; private set; }  
        public IRepository<Department> Departments { get; private set; }
        public IRepository<Teacher> Teachers { get; private set; }
        public IRepository<Course> Courses { get; private set; }
        public IRepository<Classroom> Classrooms { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Schools = new Repository<School>(_context);
            Students = new Repository<Student>(_context);
            Departments = new Repository<Department>(_context);
            Teachers = new Repository<Teacher>(_context);
            Courses = new Repository<Course>(_context);
            Classrooms = new Repository<Classroom>(_context);
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
