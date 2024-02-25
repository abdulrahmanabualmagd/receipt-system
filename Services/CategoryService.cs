using Core.Entities.Application;
using Core.IServices;
using Core.IUoW;
using System.Linq.Expressions;
using System.Security.Claims;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        #region Dependency Injection
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Basic Operations
        public async Task<IEnumerable<Category>> GetAllAsync()
            => await _unitOfWork.Repository<Category>().GetAllAsync(["Items"]);
        #endregion
    }
}
