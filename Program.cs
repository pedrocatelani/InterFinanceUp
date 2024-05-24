var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(); //suportar MVC
var app = builder.Build();
app.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}");
app.UseStaticFiles();
app.Run();
