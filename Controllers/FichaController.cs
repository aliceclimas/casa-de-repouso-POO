using Microsoft.AspNetCore.Mvc;
using CasaRepousoWeb.Models;

namespace CasaRepousoWeb.Controllers;

public class FichaController : Controller
{
    private readonly RepousoDatabase db;

    public PessoaController(RepousoDatabase db) {
        this.db = db;
    }

    // controller = classe
    // action = método
    public ActionResult Read()
    {        
        return View(db.Fichas.ToList()); // ~ SELECT * FROM Fichas
    }

    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Ficha model)
    {
        db.Fichas.Add(model); // ~ INSERT INTO Ficha VALUES ()
        db.SaveChanges(); // commit
        return RedirectToAction("Read");
    }

    // sem POST pois em exclusão a solicitação é do tipo GET
    public ActionResult Delete(int id){

        var ficha = db.Fichas.Where(e => e.FichaId == id).First();
        return View(ficha); // Retorna uma view de confirmação
    }
    // Método que confirma a exclusão com uma view e um segundo método que realiza a exclusão
    [HttpPost]
    public ActionResult ConfirmarDelete(int id){

        var ficha = db.Fichas.Where(e => e.FichaId == id).First();;
        db.Fichas.Remove(ficha);
        db.SaveChanges();
        return RedirectToAction("Read");

    }

    [HttpGet]
    public ActionResult Update(int id)
    {
        Ficha ficha = db.Fichas.Single(e => e.FichaId == id);
        return View(ficha);
    }

    [HttpPost]
    public ActionResult Update(int id,Ficha model)
    {
        var ficha = db.Fichas.Single(e => e.FichaId == id);
        ficha.Nutricao = model.Nutricao;
        ficha.Saude = model.Saude;
        ficha.DataEntrada = model.DataEntrada;
        ficha.DataSaida = model.DataSaida;
        db.SaveChanges();
        return RedirectToAction("Read");
    }

    [HttpGet]
    public ActionResult Pesquisa()
    {
        return View();
    }
    [HttpPost]
    public ActionResult Pesquisa(string texto)
    {
        var resultado = db.Pessoas
            .Where(x => x.Nome.Contais(texto) || x.Cpf.Contais(texto)).
            .OrderBy(x => x.Nome)
            .ToList(); // retorna resultado como uma lista
        return View(resultado);
    }

}

