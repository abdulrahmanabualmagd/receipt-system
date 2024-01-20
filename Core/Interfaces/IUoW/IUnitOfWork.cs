using Infrastructure.IRepositories;
using Infrastructure.Models;

namespace Core.Interfaces.IUoW
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        ISchoolRepository Schools { get; }
        IStudentRepository Students { get; }

        Task<int> CompleteAsync();
    }
}
