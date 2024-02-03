using Core.Entities;
using Core.IRepositories;

namespace Core.IUoW
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<Student> Students { get; }
        IRepository<School> Schools { get; }
        IRepository<Teacher> Teachers { get; }
        IRepository<Course> Courses { get; }
        IRepository<Department> Departments { get; }
        IRepository<Classroom> Classrooms { get; }

        Task<int> CompleteAsync();
    }
}
