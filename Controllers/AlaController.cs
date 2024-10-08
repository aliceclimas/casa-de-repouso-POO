using CasaRepousoWeb.Models; 
using Microsoft.AspNetCore.Mvc; 
using Microsoft.EntityFrameworkCore;
using CasaRepousoWeb.Data;
using CasaRepousoWeb.Models;

namespace CasaRepousoWeb.Controllers;

public class AlaController : Controller
{
    private readonly CasaRepousoDatabase db;

    public AlaController(CasaRepousoDatabase db) {
        this.db = db;
    }

    public ActionResult Read() {
        return View(db.Alas.ToList());
    }

    [HttpGet]
    public ActionResult Create() {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Ala model) {
        db.Alas.Add(model); 
        db.SaveChanges();
        return RedirectToAction("Read");
    }

    public ActionResult Delete(int id) {
        var ala = db.Alas.Single(e => e.AlaId == id); 

        db.Alas.Remove(ala);
        db.SaveChanges();

        return RedirectToAction("Read");
    }

        [HttpGet]
    public ActionResult Update(int id) {
        Ala ala = db.Alas.Single(e => id == e.AlaId);
        return View(ala);
    }

    [HttpPost]
    public ActionResult Update(int id, Ala model) {
        var ala = db.Alas.Single(e => e.AlaId == id);
        ala.Nome = model.Nome;

        db.SaveChanges();

        return RedirectToAction("Read");
    }
}