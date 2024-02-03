﻿using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Core.IRepositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Infrastructure.Data.Contexts.Application;

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