using Microsoft.AspNetCore.Mvc;
using CasaRepousoWeb.Models;

namespace CasaRepousoWeb.Controllers;

public class PessoaController : Controller
{
    private readonly CasaRepousoDatabase db;

    public PessoaController(CasaRepousoDatabase db) {
        this.db = db;
    }

    // controller = classe
    // action = método
    public ActionResult Read()
    {        
        return View(db.Pessoas.ToList()); // ~ SELECT * FROM Pessoas
    }

    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Pessoa model)
    {
        db.Pessoas.Add(model); // ~ INSERT INTO Pessoas VALUES ()
        db.SaveChanges(); // commit
        return RedirectToAction("Read");
    }

    // sem POST pois em exclusão a solicitação é do tipo GET
    public ActionResult Delete(int id){

        var pessoa = db.Pessoas.Where(e => e.PessoaId == id).First();
        return View(pessoa); // Retorna uma view de confirmação
    }
    // Método que confirma a exclusão com uma view e um segundo método que realiza a exclusão
    [HttpPost]
    public ActionResult ConfirmarDelete(int id){

        var pessoa = db.Pessoas.Where(e => e.PessoaId == id).First();;
        db.Pessoas.Remove(pessoa);
        db.SaveChanges();
        return RedirectToAction("Read");

    }

    [HttpGet]
    public ActionResult Update(int id)
    {
        Pessoa pessoa = db.Pessoas.Single(e => e.PessoaId == id);
        return View(pessoa);
    }

    [HttpPost]
    public ActionResult Update(int id,Pessoa model)
    {
        var pessoa = db.Pessoas.Single(e => e.PessoaId == id);
        pessoa.Nome = model.Nome;
        pessoa.Sobrenome = model.Sobrenome;
        pessoa.CPF = model.CPF;
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
            .Where(x => x.Nome.Contains(texto) || x.Sobrenome.Contains(texto) || x.CPF.Contains(texto))
            .OrderBy(x => x.Nome)
            .ToList(); // retorna resultado como uma lista
        return View(resultado);
    }
}