using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args); // método construtor

builder.Services.AddControllersWithViews(); // permite usar o padrão MVC

builder.Services.AddDbContext<CasaRepousoDatabase>(options => options.UseInMemoryDatabase("db"));

var app = builder.Build(); // transforma o que foi definido anteriormente em uma aplicação real

app.MapControllerRoute("default", "/{controller=Ala}/{action=Read}/{id?}"); // define a rota padrão

app.Run(); // roda a aplicação