using Microsoft.AspNetCore.Mvc;
using CasaRepousoWeb.Models;

namespace CasaRepousoWeb.Controllers;

public class PessoaController : Controller
{
    private readonly BookDatabase db;

    public PessoaController(BookDatabase db) {
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
    public ActionResult Create(Book model)
    {
        db.Books.Add(model); // ~ INSERT INTO Books VALUES (mode.Title...)
        db.SaveChanges(); // commit
        return RedirectToAction("Read");
    }

    public ActionResult Delete(int id){

        // realizar a exclusão
        var book = db.Books.Where(e => e.BookId == id).First(); // or single -> apenas para um valor // SELECT * FROM Books WHERE BookId = id
        db.Books.Remove(book); // DELETE FROM Books WHERE BookId = id

        // db.Entry<Book>(book).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        db.SaveChanges(); // salva as operações feitas // commit

        // redirecionar para página de read novamente.
        return RedirectToAction("Read");
    }
    
    [HttpGet]
    public ActionResult Update(int id)
    {
        Book book = db.Books.Single(e => e.BookId == id);
        return View(book);
    }

    [HttpPost]
    public ActionResult Update(int id,Pessoa model)
    {
        var pessoa = db.Pessoas.Single(e => e.PessoaId == id);

        pessoa.Nome = model.Nome;
        pessoa.Cpf = model.Cpf;
        
    

        db.SaveChanges();

        return RedirectToAction("Read");
    }
}

