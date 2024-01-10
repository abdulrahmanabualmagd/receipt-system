using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MVC_Core.Models;

namespace MVC_Core.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        #region Ctor
        public ApplicationDbContext() { }

        /*
         * [Dependency Injection]
         * This Constructor is Called using the program Services which Affected by this line of code
         * => builder.Services(options=> options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStringName")));
         */
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }
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

            #region Identity Tables
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
            #endregion
        }
        #endregion
    }
}
