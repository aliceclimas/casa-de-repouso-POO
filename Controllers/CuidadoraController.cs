using Microsoft.AspNetCore.Mvc;
using CasaRepousoWeb.Models;

namespace CasaRepousoWeb.Controllers;

public class CuidadoraController : Controller
{
    public IActionResult Login()
    {
        return View();
    }
}