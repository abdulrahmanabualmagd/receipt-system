using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Core.Data;
using MVC_Core.IRepositories;
using MVC_Core.Models;

namespace MVC_Core.Repositories
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
