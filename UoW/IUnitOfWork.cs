using MVC_Core.Models;
using MVC_Core.Repositories;

namespace MVC_Core.UoW
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<School> Schools { get; }
        IRepository<Student> Students { get; }
        Task<int> CompleteAsync();
    }
}
