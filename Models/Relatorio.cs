namespace CasaRepousoWeb.Models;

public class Relatorio
{
    public int RelatorioId { get; set; }
    public string Titulo { get; set; }
    public DateTime Data { get; set; }
    public string? Descricao { get; set; }
    public int IdosoId { get; set; }

    // Relacionamentos
    public Idoso Idoso { get; set; }

}
