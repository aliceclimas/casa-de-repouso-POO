using Microsoft.AspNetCore.Mvc;
using CasaRepousoWeb.Models;

namespace CasaRepousoWeb.Controllers;

public class MedicacaoController : Controller
{
    private readonly CasaRepousoDatabase db;

    public  MedicacaoController(CasaRepousoDatabase db) {
        this.db = db;
    }

    // controller = classe
    // action = método
    public ActionResult Read()
    {        
        return View(db.Medicacoes.ToList()); // ~ SELECT * FROM Medicações
    }

    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Medicacao model)
    {
        db.Medicacoes.Add(model); // ~ INSERT INTO Medicacao VALUES ()
        db.SaveChanges(); // commit
        return RedirectToAction("Read");
    }

    // sem POST pois em exclusão a solicitação é do tipo GET
    public ActionResult Delete(int id){

        var medicacao = db.Medicacoes.Where(e => e.MedicacaoId == id).First();
        return View(medicacao); // Retorna uma view de confirmação
    }
    // Método que confirma a exclusão com uma view e um segundo método que realiza a exclusão
    [HttpPost]
    public ActionResult ConfirmarDelete(int id){

        var medicacao = db.Medicacoes.Where(e => e.MedicacaoId == id).First();;
        db.Medicacoes.Remove(medicacao);
        db.SaveChanges();
        return RedirectToAction("Read");

    }

    [HttpGet]
    public ActionResult Update(int id)
    {
        Medicacao medicacao = db.Medicacoes.Single(e => e.MedicacaoId == id);
        return View(medicacao);
    }

    [HttpPost]
    public ActionResult Update(int id,Medicacao model)
    {
        var medicacao = db.Medicacoes.Single(e => e.MedicaoId == id);
        medicacao.IdosoId = model.IdosoId;
        medicacao.NomeMedicamento = model.NomeMedicamento;
        medicacao.Descricao = model.Descricao;
        
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
        var resultado = db.Medicacao
            .Where(x => x.NomeMedicamento.Contains(texto) || x.Descricao.Contains(texto))
            .OrderBy(x => x.Nome)
            .ToList(); // retorna resultado como uma lista
        return View(resultado);
    }

}