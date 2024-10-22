using Microsoft.AspNetCore.Mvc;
using CasaRepousoWeb.Models;
using CasaRepousoWeb.Data;
using CasaRepousoWeb.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CasaRepousoWeb.Controllers;

[Authorize]
public class ResponsavelController : Controller
{
    private readonly CasaRepousoDatabase db;

    public ResponsavelController(CasaRepousoDatabase db)
    {
        this.db = db;
    }

    public IActionResult Read(int id)
    {   
        var idoso = db.Idosos.SingleOrDefault(i => i.IdosoId == id);
        
        ViewBag.Idoso = idoso;

        var responsaveis = db.Responsaveis.Include(r => r.Enderecos).Where(e => e.IdosoId == id).ToList();
        return View(responsaveis);
    }

    public IActionResult Create(int id)
    {
        ViewBag.IdosoId = id; 
        return View();
    }

    [HttpPost]
    public IActionResult Create(int id, Responsavel responsavel)
    {
        responsavel.IdosoId = id;
        db.Responsaveis.Add(responsavel);
        db.SaveChanges();

        return RedirectToAction("Read", new { id = responsavel.IdosoId });
    }

    public IActionResult Update(int id)
    {
        var responsavel = db.Responsaveis.Single(e => e.ResponsavelId == id);

        ViewBag.IdosoId = responsavel.IdosoId; 
        ViewBag.ResponsavelId = responsavel.ResponsavelId;
        return View(responsavel);
    }

    [HttpPost]
    public IActionResult Update(Responsavel responsavel)
    {
        db.Responsaveis.Update(responsavel);
        db.SaveChanges();
        ViewBag.IdosoId = responsavel.IdosoId;
        return RedirectToAction("Read", new { id = responsavel.IdosoId });
    }

    public IActionResult Delete(int id)
    {
        var responsavel = db.Responsaveis.Single(e => e.ResponsavelId == id);

        db.Responsaveis.Remove(responsavel);
        db.SaveChanges();

        return RedirectToAction("Read", new { id = responsavel.IdosoId });
    }
}