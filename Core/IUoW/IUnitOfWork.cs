using Core.Entities;
using Core.Entities.Application;
using Core.IRepositories;

namespace Core.IUoW
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        // Repository Factory
        IRepository<T> Repository<T>() where T : class;

        Task<int> CompleteAsync();
    }
}
