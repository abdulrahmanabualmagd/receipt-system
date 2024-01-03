using EF_FluentAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_FluentAPI.Data
{
    internal class Context : DbContext
    {
        #region Ctor
        public Context() { }
        public Context(DbContextOptions options) :base(options) { }
        #endregion

        #region DbSet Entities
        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }
        #endregion

        #region Configuring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Testingggg;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        #endregion

        #region Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Student

            #region Composite Primary Key
            modelBuilder.Entity<Student>()
                .HasKey(s => new { s.Id, s.Id2 });      // Composite Primary Key 
            #endregion

            #region One-To-Many Relation | Cascade On Delete
            modelBuilder.Entity<Student>()
            .HasOne(student => student.School)          // one property school
            .WithMany(school => school.Students)        // many property Students
            .HasForeignKey(student => student.SchoolId) // SchoolId foreign key
            .OnDelete(DeleteBehavior.Cascade);          // Cascade on delete  
            #endregion

            #region Change Table Column Name
            modelBuilder.Entity<Student>()
                .Property(s => s.Id)
                .HasColumnName("ID_ONE");

            modelBuilder.Entity<Student>()
                .Property(s => s.Id2)
                .HasColumnName("ID_TWO");

            modelBuilder.Entity<Student>()
                .Property(s => s.SchoolId)
                .HasColumnName("ForeignToSchool");

            modelBuilder.Entity<Student>()
                .Property(s => s.Name)
                .HasColumnName("STUDENT_NAME");
            #endregion

            #region Default Value for Name
            modelBuilder.Entity<Student>()
                .Property(s => s.Name)
                .HasDefaultValue("N/A");
            #endregion

            #endregion

            #region School

            #endregion

        }
        #endregion
    }
}
