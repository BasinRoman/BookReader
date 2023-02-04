
using BookReader.DAL;
using BookReader.DAL.Interfaces;
using BookReader.DAL.Repositories;
using BookReader.Service.Interfaces;
using BookReader.Service.Implementations;
using Microsoft.EntityFrameworkCore;
using Westwind.AspNetCore.LiveReload;
using BookReader.Domain.Entity;

var builder = WebApplication.CreateBuilder(args);


//AutoUpdate pages..
builder.Services.AddLiveReload();
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();
builder.Services.AddMvc().AddRazorRuntimeCompilation();

// Add services to the container.
builder.Services.AddControllersWithViews();





//var connectionString = builder.Configuration["DefaultConnection"];
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    
    options.LogTo(Console.WriteLine);
    options.UseSqlServer(connectionString);
    

});

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IBaseRepository<User>, AccountRepository>();



var app = builder.Build();
app.UseLiveReload();
app.UseStaticFiles();



using var scope = app.Services.CreateScope();
ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//dbContext.Database.EnsureCreated();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePages();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
