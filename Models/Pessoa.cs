namespace CasaRepousoWeb.Models;
public class Pessoa
{
    public int PessoaId { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string CPF { get; set; }

    // Relacionamento com Idoso, Cuidadora e Responsável
    public ICollection<Idoso> Idosos { get; set; }
    public ICollection<Cuidadora> Cuidadoras { get; set; }
    public ICollection<Responsavel> Responsaveis { get; set; }
}



