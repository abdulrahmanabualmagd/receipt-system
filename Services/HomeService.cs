using Core.Entities.Application;
using Core.IServices;
using Core.IUoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Services
{
    public class HomeService : IHomeService
    {
        #region Ctor
        private readonly IUnitOfWork _unitOfWork;
        public HomeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        public async Task<Counts> GetCountsAsync()
            => new Counts( await _unitOfWork.Repository<Category>().CountAsync(), await _unitOfWork.Repository<Item>().CountAsync());
    }
}
