namespace CasaRepousoWeb.Models;

public class Responsavel
{
    public int ResponsavelId { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string CPF { get; set; }
    public string Telefone { get; set; }
    public string? Email { get; set; }
    public int EnderecoId { get; set; }
    public int IdosoId { get; set; }

    // Relacionamentos
    public Endereco Endereco { get; set; }
    public Idoso Idoso { get; set; }
}
