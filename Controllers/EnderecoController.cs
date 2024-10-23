using Microsoft.AspNetCore.Mvc;
using CasaRepousoWeb.Models;
using CasaRepousoWeb.Data;
using Microsoft.AspNetCore.Authorization;

namespace CasaRepousoWeb.Controllers;

[Authorize]
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

        return RedirectToAction("Read", "Responsavel", new { id = responsavel.IdosoId });
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var endereco = db.Enderecos.SingleOrDefault(e => e.EnderecoId == id);
        var responsavel = db.Responsaveis.Single(r => r.ResponsavelId == endereco.ResponsavelId);
        ViewBag.IdosoId = responsavel.IdosoId;
        ViewBag.ResponsavelId = endereco.ResponsavelId; 

        return View(endereco);   
    }

    [HttpPost]
    public IActionResult Update(int id, Endereco endereco)
    {   
        var endereco2 = db.Enderecos.SingleOrDefault(e => e.EnderecoId == id);
        
        var responsavel = db.Responsaveis.Single(r => r.ResponsavelId == endereco2.ResponsavelId);

        endereco2.Descricao = endereco.Descricao;
        endereco2.Rua = endereco.Rua;
        endereco2.NumeroCasa = endereco.NumeroCasa;
        endereco2.Bairro = endereco.Bairro;
        endereco2.CEP = endereco.CEP;
        endereco2.Complemento = endereco.Complemento;
        
        db.SaveChanges();

        return RedirectToAction("Read", "Responsavel", new { id = responsavel.IdosoId }); 
    }

    public ActionResult Delete(int id)
    {
        var endereco = db.Enderecos.Single(e => e.EnderecoId == id);

        var responsavel = db.Responsaveis.Single(r => r.ResponsavelId == endereco.ResponsavelId);
        db.Enderecos.Remove(endereco);

        db.SaveChanges();

        return RedirectToAction("Read", "Responsavel", new { id = responsavel.IdosoId });
    }    
}
