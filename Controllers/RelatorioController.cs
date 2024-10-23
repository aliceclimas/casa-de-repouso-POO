using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CasaRepousoWeb.Models;
using CasaRepousoWeb.Data;
using System.Linq;

namespace CasaRepousoWeb.Controllers
{
    [Authorize]
    public class RelatorioController : Controller
    {
        private readonly CasaRepousoDatabase db;

        public RelatorioController(CasaRepousoDatabase db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Read(int id)
        {
            var idoso = db.Idosos.SingleOrDefault(i => i.IdosoId == id);

            // Pega todos os relatórios associados ao IdosoId
            var relatorios = db.Relatorios
                .Where(r => r.IdosoId == id)
                .OrderByDescending(r => r.Data)
                .ToList();

            // Cria um dicionário para associar cada relatório às cuidadoras
            var relatorioComCuidadoras = new List<dynamic>();

            foreach (var relatorio in relatorios)
            {
                var relatorioCuidadora = db.RelatorioCuidadora
                    .Where(rc => rc.RelatorioId == relatorio.RelatorioId)
                    .ToList();

                foreach (var rc in relatorioCuidadora)
                {
                    rc.Cuidadora = db.Cuidadoras
                        .SingleOrDefault(c => c.CuidadoraId == rc.CuidadoraId);
                }

                // Adiciona um objeto anônimo contendo o relatório e suas cuidadoras
                relatorioComCuidadoras.Add(new 
                {
                    Relatorio = relatorio,
                    Cuidadoras = relatorioCuidadora
                });
            }

            ViewBag.Idoso = idoso;
            return View(relatorioComCuidadoras); // Passa o novo objeto para a view
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            var idoso = db.Idosos.SingleOrDefault(i => i.IdosoId == id);
            ViewBag.IdosoId = id;
            return View();
        }

        [HttpPost]
        public IActionResult Create(int id, Relatorio relatorio)
        {
            // Pega o id da cuidadora logada
            var cuidadoraId = int.Parse(User.FindFirst("CuidadoraId")?.Value);

            relatorio.IdosoId = id;
            relatorio.Data = DateTime.Now; // Define a data de criação

            // Adiciona o relatório
            db.Relatorios.Add(relatorio);
            db.SaveChanges();

            // Cria a relação na tabela RelatorioCuidadora
            var relatorioCuidadora = new RelatorioCuidadora
            {
                RelatorioId = relatorio.RelatorioId,
                CuidadoraId = cuidadoraId,
                Acao = "Criada"
            };

            db.RelatorioCuidadora.Add(relatorioCuidadora);
            db.SaveChanges();

            return RedirectToAction("Read", new { id = relatorio.IdosoId });
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var relatorio = db.Relatorios.SingleOrDefault(r => r.RelatorioId == id);
            var idoso = db.Idosos.SingleOrDefault(i => i.IdosoId == relatorio.IdosoId);
            ViewBag.Idoso = idoso;

            return View(relatorio);
        }

        [HttpPost]
        public IActionResult Update(Relatorio relatorio)
        {
            var existingRelatorio = db.Relatorios.SingleOrDefault(r => r.RelatorioId == relatorio.RelatorioId);

            existingRelatorio.Titulo = relatorio.Titulo;
            existingRelatorio.Descricao = relatorio.Descricao;
            existingRelatorio.Data = DateTime.Now; // Atualiza a data para a edição

            // Pega o id da cuidadora logada
            var cuidadoraId = int.Parse(User.FindFirst("CuidadoraId")?.Value);

            // Verifica se foi a mesma cuidadora que criou ou editou o relatório
            var relatorioCuidadora = db.RelatorioCuidadora
                .SingleOrDefault(rc => rc.RelatorioId == relatorio.RelatorioId && rc.CuidadoraId == cuidadoraId);

            if (relatorioCuidadora == null)
            {
                // Se não foi a mesma cuidadora, registra a ação de edição
                var novaRelacao = new RelatorioCuidadora
                {
                    RelatorioId = relatorio.RelatorioId,
                    CuidadoraId = cuidadoraId,
                    Acao = "Editada"
                };

                db.RelatorioCuidadora.Add(novaRelacao);
            }

            db.SaveChanges();

            return RedirectToAction("Read", new { id = relatorio.IdosoId });
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var relatorio = db.Relatorios.SingleOrDefault(r => r.RelatorioId == id);

            db.Relatorios.Remove(relatorio);
            db.SaveChanges();

            return RedirectToAction("Read", new { id = relatorio.IdosoId });
        }
    }
}
