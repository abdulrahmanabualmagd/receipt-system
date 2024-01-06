using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MVC_Core.Models;

namespace MVC_Core.Data
{
    public class ApplicationDbContext : DbContext
    {
        #region Ctor
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions options): base(options) { }
        #endregion

        #region DbSet
        public DbSet<Student> students { get; set; }
        public DbSet<School> Schools { get; set; }
        #endregion

        #region Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .HasOne(student => student.School)
                .WithMany(school => school.Students)
                .HasForeignKey(student => student.SchoolId);

            modelBuilder.Entity<Student>()
                .Property(s => s.SchoolId)
                .HasColumnName("SchId");
        }
        #endregion
    }
}
