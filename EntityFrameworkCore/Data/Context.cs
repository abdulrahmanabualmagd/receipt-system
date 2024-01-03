using EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Data
{
    internal class Context : DbContext
    {

        #region Ctor
        public Context() { }

        // Not used in Console Application we could remove it 
        // Takes DbContextOptions which defines Database Provider & Connection String
        public Context(DbContextOptions<Context> options): base(options) { }
        #endregion

        // Defining Entities(Tables)
        #region Entities DbSet
        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }
        #endregion


        #region OnConfiguring
        // This method could be used instead of Ctor which takes parameter DbContextOptions in ASP.Net application
        // Specifying the database provider and connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=JustForTest;trusted_connection=true;TrustServerCertificate=True;");
        }
        #endregion
    }
}
