namespace CasaRepousoWeb.Models;

public class Idoso
{
    public int IdosoId { get; set; }
    public int PessoaId { get; set; }
    public DateTime dataNascimento { get; set; }
    public int AlaId { get; set; }
    public int SituacaoId { get; set; }
    public string? ProblemasDeSaude { get; set; }
    public string? Nutricao { get; set; }
    public string? Alergia { get; set; }
    public string? CuidadosEspeciais { get; set; }

    // Relacionamentos
    public Pessoa Pessoa { get; set; }
    public Ala Ala { get; set; }
    public Situacao Situacao { get; set; }
    public ICollection<Relatorio> Relatorios { get; set; }
    public ICollection<Medicacao> Medicacoes { get; set; }
}
