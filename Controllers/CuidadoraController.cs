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
    public async Task<ActionResult> Login(CuidadoraViewModel model)
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
        if (db.Cuidadoras.Any(c => c.CPF == cuidadora.CPF))
        {
            ModelState.AddModelError("CPF", "O CPF já está em uso.");
            ViewBag.Alas = db.Alas.ToList();
            return View(cuidadora);
        }

        if (!string.IsNullOrEmpty(cuidadora.Telefone) && db.Cuidadoras.Any(c => c.Telefone == cuidadora.Telefone))
        {
            ModelState.AddModelError("Telefone", "O telefone já está em uso.");
            ViewBag.Alas = db.Alas.ToList();
            return View(cuidadora);
        }

        if (db.Cuidadoras.Any(c => c.Email == cuidadora.Email))
        {
            ModelState.AddModelError("Email", "O email já está em uso.");
            ViewBag.Alas = db.Alas.ToList();
            return View(cuidadora);
        }

        db.Cuidadoras.Add(cuidadora);
        db.SaveChanges();
        return RedirectToAction("Read", "Idoso");
    }

    [Authorize]
    [HttpGet]
    public IActionResult Read()
    {
        var cuidadoraId = User.FindFirst("CuidadoraId")?.Value;

        if (string.IsNullOrEmpty(cuidadoraId))
        {
            return RedirectToAction("Login");
        }

        int id = int.Parse(cuidadoraId);

        var cuidadora = db.Cuidadoras.SingleOrDefault(c => c.CuidadoraId == id);

        if (cuidadora == null)
        {
            return NotFound();
        }

        return View(cuidadora);
    }

    [Authorize]
    [HttpGet]
    public IActionResult Update()
    {
        // Obtém o ID da cuidadora a partir das claims do usuário autenticado
        var cuidadoraId = User.FindFirst("CuidadoraId")?.Value;

        if (string.IsNullOrEmpty(cuidadoraId))
        {
            return RedirectToAction("Login");
        }

        // Converte o ID para int
        int id = int.Parse(cuidadoraId);

        // Busca a cuidadora no banco de dados
        var cuidadora = db.Cuidadoras.SingleOrDefault(c => c.CuidadoraId == id);

        if (cuidadora == null)
        {
            return NotFound();
        }

        // Retorna a View para edição com os dados da cuidadora
        return View(cuidadora);
    }

    [Authorize]
    [HttpPost]
    public IActionResult Edit(Cuidadora cuidadora)
    {
        if (!ModelState.IsValid)
        {
            return View(cuidadora);
        }

        // Atualiza a cuidadora no banco de dados
        var existingCuidadora = db.Cuidadoras.SingleOrDefault(c => c.CuidadoraId == cuidadora.CuidadoraId);
        if (existingCuidadora == null)
        {
            return NotFound();
        }

        existingCuidadora.Nome = cuidadora.Nome;
        existingCuidadora.CPF = cuidadora.CPF;
        existingCuidadora.Telefone = cuidadora.Telefone;
        existingCuidadora.Email = cuidadora.Email;

        db.SaveChanges();

        return RedirectToAction("Read");
    }
}