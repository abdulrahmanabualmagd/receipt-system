using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace Infrastructure.Data.Contexts.Application
{
    public class ApplicationDbContext : DbContext
    {
        #region Ctor
        /*
         * [Dependency Injection]
         * This Constructor is Called using the program Services which Affected by this line of code
         * => builder.Services(options=> options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStringName")));
         */
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        #endregion

        #region DbSet
        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }
        #endregion

        #region Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Student Entity

            modelBuilder.Entity<Student>()
            .HasOne(student => student.School)
            .WithMany(school => school.Students)
            .HasForeignKey(student => student.SchoolId);

            modelBuilder.Entity<Student>()
                .Property(s => s.SchoolId)
                .HasColumnName("SchoolId");

            #endregion
        }
        #endregion
    }
}
