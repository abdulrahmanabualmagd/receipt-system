/*
 * Fix List of items 
 * Look for specification Pattern
 * how to use unit of work and what is complete and dispose methods and how to use each one 
 * what is the generic repository and what is the base repository
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

// Build Application
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


// Use Default Middleware
app.UseDefaultMiddleware();

// Use Routes
app.UseRoutes();

// Run Application
app.Run();
