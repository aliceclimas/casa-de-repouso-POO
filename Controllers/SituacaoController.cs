using CasaRepousoWeb.Models; 
using Microsoft.AspNetCore.Mvc; 
using Microsoft.EntityFrameworkCore;
using CasaRepousoWeb.Data;

namespace CasaRepousoWeb.Controllers;

public class SituacaoController : Controller 
{ 
    private readonly CasaRepousoDatabase db; 

    public SituacaoController(CasaRepousoDatabase db) 
    { 
        this.db = db; 
    } 

    // GET: Situacao/Read 
    public IActionResult Read() 
    { 
        return View(db.Situacoes.ToList()); 
    } 
    // GET: Situacao/Create 
    [HttpGet]
    public IActionResult Create() 
    { 
        return View(); 
    } 
    // POST: Situacao/Create 
    [HttpPost] 
    public IActionResult Create(Situacao situacao) 
    { 
        db.Situacoes.Add(situacao);
        db.SaveChanges();
        return RedirectToAction("Read");
    } 

    // delete
    public ActionResult Delete(int id)
    {
        var situacao = db.Situacoes.Single(e => e.SituacaoId == id);
        db.Situacoes.Remove(situacao);
        db.SaveChanges();
        return RedirectToAction("Read");
    }

    [HttpGet]
    public ActionResult Update(int id)
    {
        Situacao book = db.Situacoes.Single(e => e.SituacaoId == id);
        return View(book);
    }

    [HttpPost]
    public ActionResult Update(int id, Situacao model)
    {
        var situacao = db.Situacoes.Single(e => e.SituacaoId == id);

        situacao.Nome = model.Nome;
        situacao.Descricao = model.Descricao;
        situacao.Cor = model.Cor;

        db.SaveChanges();

        return RedirectToAction("Read");
    }
} 

