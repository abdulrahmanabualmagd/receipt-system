using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Core.IServices
{
    public interface ICountsSerivce
    {
        Task<Counts> GetCountsAsync();
    }
}
