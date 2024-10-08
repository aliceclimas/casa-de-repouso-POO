using Microsoft.AspNetCore.Mvc;
using CasaRepousoWeb.Models;

namespace CasaRepousoWeb.Controllers;

public class CuidadoraController : Controller
{
    private readonly CasaRepousoDatabase db;

    public  CuidadoraController(CasaRepousoDatabase db) {
        this.db = db;
    }

    public ActionResult Read()
    {        
        return View(db.Cuidadoras.ToList());
    }

    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Cuidadora model)
    {
        db.Cuidadoras.Add(model);

        db.SaveChanges();
        return RedirectToAction("Read");
    }

    public ActionResult Delete(int id){

        var cuidadora = db.Cuidadoras.Where(e => e.CuidadoraId == id).First();
        return View(cuidadora);
    }

    [HttpPost]
    public ActionResult ConfirmarDelete(int id){

        var cuidadora = db.Cuidadoras.Where(e => e.CuidadoraId == id).First();;
        db.Cuidadoras.Remove(cuidadora);

        db.SaveChanges();
        return RedirectToAction("Read");

    }

    [HttpGet]
    public ActionResult Update(int id)
    {
        Cuidadora cuidadora = db.Cuidadoras.Single(e => e.CuidadoraId == id);
        return View(cuidadora);
    }

    [HttpPost]
    public ActionResult Update(int id, Cuidadora model)
    {
        var cuidadora = db.Cuidadoras.Single(e => e.CuidadoraId == id);
        cuidadora.Nome = model.Nome;
        cuidadora.Telefone = model.Telefone;
        cuidadora.Turno = model.Turno;
        cuidadora.Email = model.Email;
        cuidadora.senha = model.senha;
        
        db.SaveChanges();
        return RedirectToAction("Read");
    }


    public IActionResult Login()
        {
            return View();
        }
}