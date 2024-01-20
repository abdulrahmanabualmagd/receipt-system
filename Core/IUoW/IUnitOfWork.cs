using Core.IRepositories;

namespace Core.IUoW
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        ISchoolRepository Schools { get; }
        IStudentRepository Students { get; }

        Task<int> CompleteAsync();
    }
}
