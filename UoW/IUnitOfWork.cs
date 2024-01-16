using MVC_Core.IRepositories;
using MVC_Core.Models;

namespace MVC_Core.UoW
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        ISchoolRepository Schools { get; }
        IStudentRepository Students { get; }

        Task<int> CompleteAsync();
    }
}
