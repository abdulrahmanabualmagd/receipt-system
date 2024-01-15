/*
 * Use Extension methods with the http pipline
 * 
 * Migration Seed used to initial the database with default data that is needed to run the application
 * Look for specification Pattern
 */
using Microsoft.EntityFrameworkCore;
using MVC_Core.Extensions;

var builder = WebApplication.CreateBuilder(args);

#region Serivces Registration
builder.Services.AddControllersWithViews();

// Configure DbContext
builder.Services.ConfigureDbContext(builder.Configuration.GetConnectionString("Connection"));

// Configure Identity
builder.Services.ConfigureIdentity();

// Configure Repositories
builder.Services.ConfigureRepositories();

// Configure AutoMapper
builder.Services.ConfigureAutoMapper(); 
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
