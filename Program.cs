var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(); //suportar MVC

var app = builder.Build();

app.Run();
