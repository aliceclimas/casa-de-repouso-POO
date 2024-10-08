namespace CasaRepousoWeb.Models;

public class Cuidadora
{
    public string? Nome { get; set; }
    public int CuidadoraId { get; set; }
    public string? Telefone { get; set; }
    public string? Turno { get; set; }
    public string Email { get; set; }
    public int PessoaId { get; set; }
    public int EnderecoId { get; set; }
    public string senha { get; set; }
    public int AlaId { get; set; }

    // Relacionamentos
    public Pessoa Pessoa { get; set; }
    public Endereco Endereco { get; set; }
    public Ala Ala { get; set; }
    public ICollection<Relatorio> Relatorios { get; set; }
}
