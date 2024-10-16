using Microsoft.AspNetCore.Mvc;
using CasaRepousoWeb.Models;
using CasaRepousoWeb.Data;
using Microsoft.AspNetCore.Authentication; 
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace CasaRepousoWeb.Controllers;

public class CuidadoraController : Controller
{
    private readonly CasaRepousoDatabase db;

    public CuidadoraController(CasaRepousoDatabase db)
    {
        this.db = db;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Login(CuidadoraViewModel model)
    {   
        var user = db.Cuidadoras.SingleOrDefault(e => e.Email == model.Email && e.Senha == model.Senha);

        if (user == null){
            ViewBag.Autenticado = false;
            return View(model);
        } 

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Nome),
            new Claim("CuidadoraId", user.CuidadoraId.ToString())
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));


        // HttpContext.Session.SetInt32("userId", user.CuidadoraId);
        // HttpContext.Session.SetString("userName", user.Nome);

        return RedirectToAction("Read", "Idoso");
    }   

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        HttpContext.Session.Clear();
        return RedirectToAction("Login"); // Redireciona para a página de login
    }

    [HttpGet]
    public ActionResult Create()
    {   
        ViewBag.Alas = db.Alas.ToList();
        return View();
    }

    [HttpPost]
    public ActionResult Create(Cuidadora cuidadora)
    {
        db.Cuidadoras.Add(cuidadora);
        db.SaveChanges();
        return RedirectToAction("Read", "Idoso");
    }

}