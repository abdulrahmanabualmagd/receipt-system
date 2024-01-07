/*
 * First check about input validation using if (entity == null) 
 * Second check if the context saved Successfully
 * It returns false if the entity is null of there is an issue with sql server 
 */
using Microsoft.EntityFrameworkCore;
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
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            return await _context.Students.FindAsync(id);
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
    }
}
