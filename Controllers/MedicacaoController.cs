using Microsoft.AspNetCore.Mvc;
using CasaRepousoWeb.Models;
using CasaRepousoWeb.Data;
using CasaRepousoWeb.Services;
using Microsoft.AspNetCore.Authorization;

namespace CasaRepousoWeb.Controllers;

[Authorize]
public class MedicacaoController : Controller
{
    private readonly CasaRepousoDatabase db;

    public MedicacaoController(CasaRepousoDatabase db)
    {
        this.db = db;
    }

    public IActionResult Read(int id)
    {
        ViewBag.IdosoId = id;
        var medicacoes = db.Medicacoes.Where(e => e.IdosoId == id).ToList();
        
        return View(medicacoes);
    }

    public IActionResult Create(int id)
    {
        ViewBag.IdosoId = id; 
        return View();
    }
    [HttpPost]
    public IActionResult Create(int id, Medicacao medicacao)
    {
        medicacao.IdosoId = id;
        // Salvar a nova medicação no banco de dados
        db.Medicacoes.Add(medicacao);
        db.SaveChanges();
        
        // Redirecionar para a lista de medicações após a criação
        return RedirectToAction("Read", new { id = medicacao.IdosoId });
    }

    public ActionResult Update(int id)
    {
        var medicacao = db.Medicacoes.Single(e => e.MedicacaoId == id);
        ViewBag.IdosoId = medicacao.IdosoId;
        return View(medicacao);
    }

    [HttpPost]
    public IActionResult Update(Medicacao medicacao)
    {
        db.Medicacoes.Update(medicacao);
        db.SaveChanges();
        
        return RedirectToAction("Read", new { id = medicacao.IdosoId });
    }

    public ActionResult Delete(int id)
    {
        var medicacao = db.Medicacoes.Single(e => e.MedicacaoId == id);

        db.Medicacoes.Remove(medicacao);
        db.SaveChanges();

        return RedirectToAction("Read", new { id = medicacao.IdosoId });
    }
}
