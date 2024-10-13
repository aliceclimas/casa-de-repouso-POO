using Microsoft.AspNetCore.Mvc;
using CasaRepousoWeb.Models;
using CasaRepousoWeb.Data;

namespace CasaRepousoWeb.Controllers;

public class EnderecoController : Controller
{
    private readonly CasaRepousoDatabase db;

    public EnderecoController(CasaRepousoDatabase db)
    {
        this.db = db;
    }

    public IActionResult Create(int id)
    {   
        var responsavel = db.Responsaveis.Single(r => r.ResponsavelId == id);
        ViewBag.IdosoId = responsavel.IdosoId;
        ViewBag.ResponsavelId = id; 
        return View();
    }

    [HttpPost]
    public IActionResult Create(int id, Endereco endereco)
    {   
        var responsavel = db.Responsaveis.Single(r => r.ResponsavelId == id);
        ViewBag.IdosoId = responsavel.IdosoId;
        ViewBag.ResponsavelId = id;
        endereco.ResponsavelId = id;
        db.Enderecos.Add(endereco); 
        db.SaveChanges();

        return RedirectToAction("Read", "Responsavel", new { id = responsavel.IdosoId }); // Redireciona para a lista de responsáveis com o ID do responsável
    }
}
