namespace CasaRepousoWeb.Models;

public class RelatorioCuidadora
{
    public int RelatorioCuidadoraId { get; set; }
    public int RelatorioId { get; set; }
    public int CuidadoraId { get; set; }
    public string Acao { get; set; }

    public Relatorio Relatorio { get; set; }
    public Cuidadora Cuidadora { get; set; }
}