namespace CasaRepousoWeb.Models;

public class Endereco
{
    public int EnderecoId { get; set; }
    public string Rua { get; set; }
    public string NumeroCasa { get; set; }
    public string Bairro { get; set; }
    public string CEP { get; set; }
    public string? Complemento { get; set; }

    // Relacionamento com Cuidadora e Responsável
    public ICollection<Cuidadora> Cuidadoras { get; set; }
    public ICollection<Responsavel> Responsaveis { get; set; }
}
