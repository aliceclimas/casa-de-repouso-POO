using Microsoft.AspNetCore.Mvc;
using CasaRepousoWeb.Models;
using CasaRepousoWeb.Data;
using CasaRepousoWeb.Services;

namespace CasaRepousoWeb.Controllers;

public class IdosoController : Controller
{
    private readonly CasaRepousoDatabase db;
    private readonly IdosoService _idosoService;

    public IdosoController(CasaRepousoDatabase db, IdosoService idosoService)
    {
        this.db = db;
        _idosoService = idosoService;
    }

    // public IActionResult Read()
    // {
    //     var alas = db.Alas.ToList();
    //     var situacoes = db.Situacoes.ToList();
    //     var idosos = db.Idosos.ToList();

    //     var idososComIdade = new List<object>();

    //     foreach (var idoso in idosos)
    //     {
    //         int idade = _idosoService.CalcularIdade(idoso.DataNascimento);
    //         idososComIdade.Add(new 
    //         {
    //             Idoso = idoso,
    //             Idade = idade
    //         });
    //     }

    //     ViewBag.Alas = alas; 
    //     ViewBag.Situacoes = situacoes;
    //     ViewBag.Idosos = idososComIdade;

    //     return View();
    // }

    public IActionResult Read(string? nome, int? ala, int? situacao)
    {
        var query = db.Idosos.AsQueryable();

        // Filtrando por Nome
        if (!string.IsNullOrWhiteSpace(nome))
        {
            query = query.Where(i => i.Nome.Contains(nome));
        }

        // Filtrando por Ala
        if (ala.HasValue)
        {
            query = query.Where(i => i.AlaId == ala.Value);
        }

        // Filtrando por Situação
        if (situacao.HasValue)
        {
            query = query.Where(i => i.SituacaoId == situacao.Value);
        }

        var idososComIdade = query.ToList().Select(idoso => new 
        {
            Idoso = idoso,
            Idade = _idosoService.CalcularIdade(idoso.DataNascimento)
        }).ToList();

        ViewBag.Idosos = idososComIdade;
        ViewBag.Alas = db.Alas.ToList();
        ViewBag.Situacoes = db.Situacoes.ToList();

        return View();
    }



    [HttpGet]
    public IActionResult Create() 
    { 
        ViewBag.Situacoes = db.Situacoes.ToList();
        ViewBag.Alas = db.Alas.ToList();
        return View(); 
    } 

    

    [HttpPost] 
    public IActionResult Create(Idoso idoso) 
    { 
        db.Idosos.Add(idoso);
        db.SaveChanges();
        return RedirectToAction("Read");
    }

    [HttpGet]   
    public IActionResult Update(int id)
    {
        Idoso idoso = db.Idosos.Single(e => e.IdosoId == id);

        ViewBag.Alas = db.Alas.ToList();
        ViewBag.Situacoes = db.Situacoes.ToList();

        return View(idoso);
    }

    [HttpPost]
    public ActionResult Update(int id, Idoso model)
    {

        var idoso = db.Idosos.Single(e => e.IdosoId == id);
           
        // Atualizando as propriedades
        idoso.Nome = model.Nome;
        idoso.Sobrenome = model.Sobrenome;
        idoso.CPF = model.CPF;
        idoso.DataNascimento = model.DataNascimento;
        idoso.AlaId = model.AlaId;
        idoso.SituacaoId = model.SituacaoId;
        idoso.ProblemasDeSaude = model.ProblemasDeSaude;
        idoso.Nutricao = model.Nutricao;
        idoso.Alergia = model.Alergia;
        idoso.CuidadosEspeciais = model.CuidadosEspeciais;

        // Salvando as alterações no banco de dados
        db.SaveChanges();

        return RedirectToAction("Read");
    }

    public ActionResult Delete(int id)
    {
        var idoso = db.Idosos.Single(e => e.IdosoId == id);

        db.Idosos.Remove(idoso);

        db.SaveChanges();

        return RedirectToAction("Read");
    }
}
