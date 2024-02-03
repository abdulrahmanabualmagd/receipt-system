using Core.IUoW;
using Core.Entities;
using Core.SchoolServcie;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Services
{
    public class SchoolService : ISchoolService
    {
        #region Injection
        private readonly IUnitOfWork _unitOfWork;

        public SchoolService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region GetAll
        public async Task<IEnumerable<School>> GetAll()
        {
            var list = await _unitOfWork.Schools.GetAllAsync(["Students"]);

            return list;
        }
        #endregion

        #region GetPage
        public async Task<IEnumerable<School>> GetPage(int pageIndex, int pageSize)
        {
            return await _unitOfWork.Schools.GetPageAsync(pageIndex, pageSize, ["Students"]);
        }
        #endregion

        #region GetById
        public async Task<School> GetById(int id)
        {
            return await _unitOfWork.Schools.GetByIdAsync(id);

        }
        #endregion

        #region Find
        public async Task<School> Find(Expression<Func<School, bool>> predicate)
        {
            return await _unitOfWork.Schools.FindAsync(predicate, ["Students"]);
        }
        #endregion

        #region Add
        public async Task<bool> Add(School entity)
        {
            if (entity == null)
                return false;

            await _unitOfWork.Schools.AddAsync(entity);
            try
            {
                await _unitOfWork.CompleteAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Delete
        public async Task<bool> Delete(School entity)
        {
            if (entity == null)
                return false;

            if (_unitOfWork.Schools.Delete(entity) == false)
                return false;

            try
            {
                int affected = await _unitOfWork.CompleteAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Update
        public async Task<bool> Update(School entity)
        {
            if (entity == null)
                return false;

            if (_unitOfWork.Schools.Update(entity) == false)
                return false;

            try
            {
                int affected = await _unitOfWork.CompleteAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Count
        public async Task<int> Count()
        {
            return await _unitOfWork.Schools.CountAsync();
        }
        #endregion

        #region GetListItems
        public async Task<IEnumerable<SelectListItem>> GetListItems()
        {
            return await _unitOfWork.Schools.GetListItems();
        }
        #endregion
    }
}
