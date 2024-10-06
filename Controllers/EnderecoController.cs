using Microsoft.AspNetCore.Mvc;
using CasaRepousoWeb.Models;

namespace CasaRepousoWeb.Controllers;

public class EnderecoController : Controller
{
    private readonly CasaRepousoDatabase db;

    public EnderecoController(CasaRepousoDatabase db) {
        this.db = db;
    }

    public ActionResult Read() {
        return View(db.Enderecos.ToList());
    }

    [HttpGet]
    public ActionResult Create() {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Endereco model) {
        db.Enderecos.Add(model); 
        db.SaveChanges();
        return RedirectToAction("Read");
    }

    public ActionResult Delete(int id) {
        var endereco = db.Enderecos.Single(e => e.EnderecoId == id); 

        db.Endereco.Remove(endereco);
        db.SaveChanges();

        return RedirectToAction("Read");
    }

        [HttpGet]
    public ActionResult Update(int id) {
        Endereco endereco = db.Enderecos.Single(e => id == e.EnderecoId);
        return View(endereco);
    }

    [HttpPost]
    public ActionResult Update(int id, Endereco model) {
        var endereco = db.Enderecos.Single(e => e.EnderecoId == id);
        enderco.Rua = model.Rua;
        enderco.Numero = model.Numero;
        enderco.Bairro = model.Bairro;
        enderco.CEP = model.CEP;
        enderco.Complemento = model.Complemento;

        db.SaveChanges();

        return RedirectToAction("Read");
    }
}