using Microsoft.AspNetCore.Mvc;
using CasaRepousoWeb.Models;

namespace CasaRepousoWeb.Controllers;

public class IdosoController : Controller
{
    private readonly CasaRepousoDatabase db;

    public  IdosoController(CasaRepousoDatabase db) {
        this.db = db;
    }

    public ActionResult Read()
    {        
        return View(db.Idosos.ToList());
    }

    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Idoso model)
    {
        db.Idosos.Add(model);

        db.SaveChanges();
        return RedirectToAction("Read");
    }

    public ActionResult Delete(int id){

        var ficha = db.Idosos.Where(e => e.IdosoId == id).First();
        return View(ficha);
    }

    [HttpPost]
    public ActionResult ConfirmarDelete(int id){

        var idoso = db.Idosos.Where(e => e.IdosoId == id).First();;
        db.Idosos.Remove(idoso);

        db.SaveChanges();
        return RedirectToAction("Read");

    }

    [HttpGet]
    public ActionResult Update(int id)
    {
        Idoso idoso = db.Idosos.Single(e => e.IdosoId == id);
        return View(idoso);
    }

    [HttpPost]
    public ActionResult Update(int id, Idoso model)
    {
        var idoso = db.Idosos.Single(e => e.IdosoId == id);
        idoso.Nome = model.Nome;
        idoso.ProblemasDeSaude = model.ProblemasDeSaude;
        idoso.Nutricao = model.Nutricao;
        idoso.Alergia = model.Alergia;
        idoso.CuidadosEspeciais = model.CuidadosEspeciais;

        db.SaveChanges();
        return RedirectToAction("Read");
    }

}
