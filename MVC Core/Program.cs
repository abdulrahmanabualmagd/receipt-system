using Microsoft.EntityFrameworkCore;
using MVC_Core.Data;
using MVC_Core.IRepositories;
using MVC_Core.Models;
using MVC_Core.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Add DbContext To Services

var DefaultConnection = builder.Configuration.GetConnectionString("Connection");

builder.Services.AddDbContext<ApplicationDbContext>(options => 
        options.UseSqlServer(
            DefaultConnection,
            options => options.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
            // This line is used for determining where to look for migration configurations
);
#endregion

#region Repositories Injection
// Takes two arguments => Service (Abstraction of the repository) & Concrete Repository
// Adding it to the service to inject each Repository with its Service in the repository contructor
builder.Services.AddScoped(typeof(IRepository<Student>), typeof(StudentRepository));
builder.Services.AddScoped(typeof(IRepository<School>), typeof(SchoolRepository));
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Home}/{id?}");

app.Run();
