using Microsoft.EntityFrameworkCore;
using Core.Models;
using Core.IRepositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Infrastructure.Data.Contexts.Application;

namespace Infrastructure.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        #region Injection
        public StudentRepository(ApplicationDbContext context) : base(context) { } 
        #endregion

        public async Task<IEnumerable<SelectListItem>> GetListItems()
            => await _context.Students
            .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name })
            .ToListAsync();

    }
}
