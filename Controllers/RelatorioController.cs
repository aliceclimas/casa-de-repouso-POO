using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CasaRepousoWeb.Models;
using CasaRepousoWeb.Data;

namespace CasaRepousoWeb.Controllers;

[Authorize]
public class RelatorioController : Controller
{
    private readonly CasaRepousoDatabase db;

    public RelatorioController(CasaRepousoDatabase db)
    {
        this.db = db;
    }

    [HttpGet]
    public IActionResult Read(int id)
    {
        var idoso = db.Idosos.SingleOrDefault(i => i.IdosoId == id);

        var relatorios = db.Relatorios
        .Where(r => r.IdosoId == id)
        .OrderByDescending(r => r.Data)
        .ToList();

        ViewBag.Idoso = idoso;
        return View(relatorios);
    }


    [HttpGet]
    public IActionResult Create(int id)
    {
        var idoso = db.Idosos.SingleOrDefault(i => i.IdosoId == id);

        ViewBag.IdosoId = id;
        return View();
    }

    [HttpPost]
    public IActionResult Create(int id, Relatorio relatorio)
    {
        
        var cuidadoraId = int.Parse(User.FindFirst("CuidadoraId")?.Value);

        relatorio.IdosoId = id;
        relatorio.CuidadoraId = cuidadoraId;
        relatorio.Data = DateTime.Now; 

        db.Relatorios.Add(relatorio);
        db.SaveChanges();

        return RedirectToAction("Read", new { id = relatorio.IdosoId });
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var relatorio = db.Relatorios.SingleOrDefault(r => r.RelatorioId == id);

        var idoso = db.Idosos.SingleOrDefault(i => i.IdosoId == relatorio.IdosoId);

        ViewBag.Idoso = idoso;

        return View(relatorio);
    }

    [HttpPost]
    public IActionResult Update(Relatorio relatorio)
    {
        var existingRelatorio = db.Relatorios.SingleOrDefault(r => r.RelatorioId == relatorio.RelatorioId);

        existingRelatorio.Titulo = relatorio.Titulo;
        existingRelatorio.Descricao = relatorio.Descricao;
        existingRelatorio.Data = DateTime.Now; // Atualiza a data para o momento da edição

        db.SaveChanges();

        return RedirectToAction("Read", new { id = relatorio.IdosoId });
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var relatorio = db.Relatorios.SingleOrDefault(r => r.RelatorioId == id);

        db.Relatorios.Remove(relatorio);
        db.SaveChanges();

        return RedirectToAction("Read", new { id = relatorio.IdosoId });
    }
}