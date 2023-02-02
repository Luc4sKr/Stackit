using Microsoft.EntityFrameworkCore;
using Stackit.Application.Services.SQLServerServices;
using Stackit.Domain.IRepositories;
using Stackit.Domain.IServices;
using Stackit.Infra.Data.Context;
using Stackit.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SQLServerContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));

// ** Dependency Injection
// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPublicationRepotitory, PublicationRepository>();

// Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPublicationService, PublicationService>();


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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
