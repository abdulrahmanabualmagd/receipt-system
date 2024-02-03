using Core.IServices;
using Core.IUoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Services
{
    public class CountsService : ICountsSerivce
    {
        #region Injection
        private IUnitOfWork _unitOfWork;

        public CountsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        public async Task<Counts> GetCountsAsync()
        {
            return new Counts(
                await _unitOfWork.Students.CountAsync(),
                await _unitOfWork.Schools.CountAsync(),
                await _unitOfWork.Departments.CountAsync(),
                await _unitOfWork.Courses.CountAsync(),
                await _unitOfWork.Teachers.CountAsync(),
                await _unitOfWork.Classrooms.CountAsync()
                );
        }
    }
}
