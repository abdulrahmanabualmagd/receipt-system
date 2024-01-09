/*
 * First check about input validation using if (entity == null) 
 * Second check if the context saved Successfully
 * It returns false if the entity is null of there is an issue with sql server 
 */
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVC_Core.Data;
using MVC_Core.IRepositories;
using MVC_Core.Models;

namespace MVC_Core.Repositories
{
    public class StudentRepository : IRepository<Student>
    {

        #region Dependency Injection (Constructor Injection)
        private readonly ApplicationDbContext _context;

        /*
         * This Constructor is Injected using ASP.NET Core Dependency Injection system (Built-in Feature in ASP.NET)
         * builder.Services.AddScooped(typeof(IRepository<Student>, typeof(StudentRepository))); => Register Injection of type generic
         */
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _context.Students.Include(s=> s.School).ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetPage(int pageIndex, int pageSize)
        {
            IEnumerable<Student> students = await _context.Students
                .Include(s => s.School)
                .Skip((pageIndex - 1) * pageSize)
                .Take(3).ToListAsync();
            
            return students;
        }


        public async Task<Student> GetById(int id)
        {
            return await _context.Students.Include(s=> s.School).FirstOrDefaultAsync(s=> s.Id == id);
        }

        public async Task<bool> Add(Student entity)
        {
            #region Null Exception
            if (entity == null)
            {
                return false;
            }
            #endregion

            #region Check if the data successfully added
            try
            {
                await _context.Students.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
            #endregion
        }

        public async Task<bool> Delete(Student entity)
        {
            #region Null Exception
            if (entity == null)
            {
                return false;
            }
            #endregion

            #region Check if the data successfully deleted
            try
            {
                _context.Students.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
            #endregion
        }

        public async Task<bool> Update(Student entity)
        {
            #region Null Exception
            if (entity == null)
            {
                return false;
            }
            #endregion

            #region Check if the data successfully updated
            try
            {
                _context.Students.Update(entity);
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
            return await _context.Students.CountAsync();
        }
        public async Task<IEnumerable<SelectListItem>> GetListItems()
        {
            return await _context.Students.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name}).ToListAsync();
        }

    }
}
