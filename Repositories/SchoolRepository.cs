using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using MVC_Core.Data;
using MVC_Core.IRepositories;
using MVC_Core.Models;

namespace MVC_Core.Repositories
{
    public class SchoolRepository : IRepository<School>
    {
        #region Dependency Injection
        private readonly ApplicationDbContext _context;

        /*
         * This Constructor is Injected using ASP.NET Core Dependency Injection system (Built-in Feature in ASP.NET)
         * builder.Services.AddScooped(typeof(IRepository<School>, typeof(SchoolRepository))); => Register Injection of type generic
         */
        public SchoolRepository(ApplicationDbContext context)
        {
            _context = context;
        } 
        #endregion

        public async Task<IEnumerable<School>> GetAll()
        {
            return await _context.Schools.Include(s=> s.Students).ToListAsync();
        }

        public async Task<IEnumerable<School>> GetPage(int pageIndex, int pageSize)
        {
            IEnumerable<School> schools = await _context.Schools
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize).ToListAsync();

            return schools;
        }

        public async Task<School> GetById(int id)
        {
            return await _context.Schools.FindAsync(id);
        }

        public async Task<bool> Add(School entity)
        {
            #region Null Exception
            if (entity == null)
            {
                return false;
            }
            #endregion

            #region Check if data deleted Successfully
            try
            {
                await _context.Schools.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
            #endregion
        }

        public async Task<bool> Delete(School entity)
        {
            #region Null Exception
            if (entity == null)
            {
                return false;
            }
            #endregion

            #region Check if data deleted successfully
            try
            {
                _context.Schools.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
            #endregion
        }

        public async Task<bool> Update(School entity)
        {
            #region Null Exception
            if (entity == null)
            {
                return false;
            }
            #endregion

            #region Check if data updated successfully
            try
            {
                _context.Schools.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
            #endregion
        }

        public async Task<int> Count()
        {
            return await _context.Schools.CountAsync();
        }


        public async Task<IEnumerable<SelectListItem>> GetListItems()
        {
            return await _context.Schools.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name }).ToListAsync();
        }
    }
}
