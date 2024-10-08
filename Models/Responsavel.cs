namespace CasaRepousoWeb.Models;

public class Responsavel
{
    public int ResponsavelId { get; set; }
    public string Telefone { get; set; }
    public string? Email { get; set; }
    public int PessoaId { get; set; }
    public int EnderecoId { get; set; }
    public int IdosoId { get; set; }

    // Relacionamentos
    public Pessoa Pessoa { get; set; }
    public Endereco Endereco { get; set; }
    public Idoso Idoso { get; set; }
}
