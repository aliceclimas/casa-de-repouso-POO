namespace CasaRepousoWeb.Models;

public class Cuidadora
{
    public int CuidadoraId { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string CPF { get; set; }
    public string? Telefone { get; set; }
    public TimeSpan? HorarioEntrada { get; set; }
    public TimeSpan? HorarioSaida { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public int? AlaId { get; set; }

    // Relacionamentos
    public Ala Ala { get; set; }
    public ICollection<Relatorio> Relatorios { get; set; }
}
