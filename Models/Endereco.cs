namespace CasaRepousoWeb.Models;

public class Endereco
{
    public int EnderecoId { get; set; }
    public string Descricao { get; set; }
    public string Rua { get; set; }
    public string NumeroCasa { get; set; }
    public string Bairro { get; set; }
    public string CEP { get; set; }
    public string? Complemento { get; set; }
    public int ResponsavelId { get; set; }

    // Relacionamento com o responsável
    public Responsavel Responsavel { get; set; }
}
