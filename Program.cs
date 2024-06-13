using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(o => {
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true; 
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NCaF5cXmZCeUx3R3xbf1x0ZFREal1QTnVWUj0eQnxTdEFjX35ccnRQTmNbVkR3XA==");

var app = builder.Build();
app.UseSession();
app.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}");
app.UseStaticFiles();
app.Run();
