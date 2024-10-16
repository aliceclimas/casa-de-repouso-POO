using Microsoft.AspNetCore.Mvc;
using CasaRepousoWeb.Models;
using Microsoft.EntityFrameworkCore;
using CasaRepousoWeb.Data;
using Microsoft.AspNetCore.Authorization;

namespace CasaRepousoWeb.Controllers;

[Authorize]
public class AlaController : Controller 
{ 
    private readonly CasaRepousoDatabase db; 

    public AlaController(CasaRepousoDatabase db) 
    { 
        this.db = db; 
    } 

    // GET: Ala/Read 
    public IActionResult Read() 
    { 
        return View(db.Alas.ToList()); 
    } 
    // GET: Ala/Create 
    [HttpGet]
    public IActionResult Create() 
    { 
        return View(); 
    } 

    // POST: Situacao/Create 
    [HttpPost] 
    public IActionResult Create(Ala ala) 
    { 
        db.Alas.Add(ala);
        db.SaveChanges();
        return RedirectToAction("Read");
    } 

    // delete
    public ActionResult Delete(int id)
    {
        var ala = db.Alas.Single(e => e.AlaId == id);
        db.Alas.Remove(ala);
        db.SaveChanges();
        return RedirectToAction("Read");
    }

    [HttpGet("ala/update/{id}")]
    public ActionResult Update(int id)
    {
        Ala ala = db.Alas.Single(e => e.AlaId == id);
        return View(ala);
    }

    [HttpPost]
    public ActionResult Update(int id, Ala model)
    {
        var ala = db.Alas.Single(e => e.AlaId == id);

        ala.Nome = model.Nome;  
        ala.Descricao = model.Descricao;

        db.SaveChanges();

        return RedirectToAction("Read");
    }
} 

