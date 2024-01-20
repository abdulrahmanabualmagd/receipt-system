using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Core.Models;
using Core.IRepositories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Infrastructure.Repositories
{
    public class SchoolRepository : Repository<School>, ISchoolRepository
    {
        #region Injection
        public SchoolRepository(ApplicationDbContext context) : base(context) { } 
        #endregion

        public async Task<IEnumerable<SelectListItem>> GetListItems()
            => await _context.Schools
                .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name })
                .ToListAsync();
    }
}
