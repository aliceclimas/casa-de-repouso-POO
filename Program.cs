using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using CasaRepousoWeb.Data; 
using CasaRepousoWeb.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args); // método construtor

builder.Services.AddControllersWithViews(); // permite usar o padrão MVC

// builder.Services.AddDbContext<CasaRepousoDatabase>(options => options.UseInMemoryDatabase("db"));
builder.Services.AddDbContext<CasaRepousoDatabase>(options => options.UseSqlite("Data Source=casa_repouso.db"));
builder.Services.AddSession();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Cuidadora/Login"; // caminho para a página de login
    });

builder.Services.AddScoped<IdosoService>();

var app = builder.Build(); // transforma o que foi definido anteriormente em uma aplicação real

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles(); // Para servir arquivos da wwwroot

app.MapControllerRoute("default", "/{controller=Cuidadora}/{action=Login}/{id?}");

// define a rota padrão

app.Run(); // roda a aplicação

