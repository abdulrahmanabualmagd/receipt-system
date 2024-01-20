/*
 * Services
 * Look for specification Pattern
 * 
 * external authentication providers
 * external login 
 * email vertification code 
 * number vertification code 
 * cookie and cache 
 */
using Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

#region Serivces Container

// Configure Controllers with Views
builder.Services.AddControllersWithViews();

// Configure DbContext
builder.Services.ConfigureDbContext(builder.Configuration.GetConnectionString("Connection"));

// Configure Identity
builder.Services.ConfigureIdentity();

// Configure Repositories
builder.Services.ConfigureRepositories();

// Configure AutoMapper
builder.Services.ConfigureAutoMapper();

builder.Services.ConfigureAuthentication(builder.Configuration);

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

// Use Map Get
app.UseMapGet();

// Run Application
app.Run();
