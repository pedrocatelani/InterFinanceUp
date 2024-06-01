using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(); //suportar MVC
builder.Services.AddDbContext<DataBaseContext>( options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
var app = builder.Build();
app.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}");
app.UseStaticFiles();
app.Run();
