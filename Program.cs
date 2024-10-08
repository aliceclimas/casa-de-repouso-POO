using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using CasaRepousoWeb.Data; 

var builder = WebApplication.CreateBuilder(args); // método construtor

builder.Services.AddControllersWithViews(); // permite usar o padrão MVC

// builder.Services.AddDbContext<CasaRepousoDatabase>(options => options.UseInMemoryDatabase("db"));
builder.Services.AddDbContext<CasaRepousoDatabase>(options => options.UseSqlite("Data Source=casa_repouso.db"));

var app = builder.Build(); // transforma o que foi definido anteriormente em uma aplicação real

app.MapControllerRoute("default", "/{controller=Cuidadora}/{action=Login}/{id?}");
app.MapControllerRoute("situacoes", "/{controller=Situacao}/{action=Read}/{id?}");
// define a rota padrão

app.Run(); // roda a aplicação

