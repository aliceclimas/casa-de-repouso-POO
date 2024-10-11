namespace CasaRepousoWeb.Models;

public class Idoso
{
    public int IdosoId { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string CPF { get; set; }
    public DateTime DataNascimento { get; set; }
    public int AlaId { get; set; }
    public int SituacaoId { get; set; }
    public string? ProblemasDeSaude { get; set; }
    public string? Nutricao { get; set; }
    public string? Alergia { get; set; }
    public string? CuidadosEspeciais { get; set; }

    // Relacionamentos
    public Ala Ala { get; set; }
    public Situacao Situacao { get; set; }
    public ICollection<Relatorio> Relatorios { get; set; }
    public ICollection<Medicacao> Medicacoes { get; set; }
}
