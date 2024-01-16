using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Core.IRepositories;
using MVC_Core.IServices;
using MVC_Core.Models;
using MVC_Core.UoW;
using System.Linq.Expressions;

namespace MVC_Core.Services
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
            => await _unitOfWork.Students.GetAll(["School"]);
        #endregion

        #region GetPage
        public async Task<IEnumerable<Student>> GetPage(int pageIndex, int pageSize)
            => await _unitOfWork.Students.GetPage(pageIndex, pageSize, ["School"]);
        #endregion

        #region GetById
        public async Task<Student> GetById(int id)
            => await _unitOfWork.Students.GetById(id);
        #endregion

        #region Find
        public async Task<Student> Find(Expression<Func<Student, bool>> match)
            => await _unitOfWork.Students.Find(match, ["School"]);
        #endregion

        #region Add
        public async Task<bool> Add(Student entity)
        {
            if (entity == null)
                return false;

            await _unitOfWork.Students.Add(entity);
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

            await _unitOfWork.Students.Delete(entity);

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

        #region Update
        public async Task<bool> Update(Student entity)
        {
            if (entity == null)
                return false;

            await _unitOfWork.Students.Update(entity);

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

        #region Count
        public async Task<int> Count()
        {
            return await _unitOfWork.Students.Count();
        }
        #endregion
    }
}
