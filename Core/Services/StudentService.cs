using Infrastructure.IServices;
using Infrastructure.Models;
using System.Linq.Expressions;
using System.Web.Mvc;
using Infrastructure.UoW;

namespace Web.Services
{
    public class StudentService : IStudentService
    {
        #region Injection
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region GetAll
        public async Task<IEnumerable<Student>> GetAll()
        {
            var list = await _unitOfWork.Students.GetAllAsync(["School"]);

            return list;
        }
        #endregion

        #region GetPage
        public async Task<IEnumerable<Student>> GetPage(int pageIndex, int pageSize)
        {
            return await _unitOfWork.Students.GetPageAsync(pageIndex, pageSize, ["School"]);
        }
        #endregion

        #region GetById
        public async Task<Student> GetById(int id)
        {
            return await _unitOfWork.Students.GetByIdAsync(id);

        }
        #endregion

        #region Find
        public async Task<Student> Find(Expression<Func<Student, bool>> predicate)
        {
            return await _unitOfWork.Students.FindAsync(predicate, ["School"]);
        }
        #endregion

        #region Add
        public async Task<bool> Add(Student entity)
        {
            if (entity == null)
                return false;

            await _unitOfWork.Students.AddAsync(entity);
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
        public async Task<bool> Delete(Student entity)
        {
            if (entity == null)
                return false;

            if ((_unitOfWork.Students.Delete(entity)) == false)
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
        public async Task<bool> Update(Student entity)
        {
            if (entity == null)
                return false;

            if ((_unitOfWork.Students.Update(entity)) == false)
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
            return await _unitOfWork.Students.CountAsync();
        }
        #endregion

        #region GetListItems
        public async Task<IEnumerable<SelectListItem>> GetListItems()
        {
            return await _unitOfWork.Students
                .GetListItems(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name });
        } 
        #endregion
    }
}
