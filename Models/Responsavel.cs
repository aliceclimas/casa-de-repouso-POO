namespace CasaRepousoWeb.Models;

public class Responsavel
{
    public int ResponsavelId { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string CPF { get; set; }
    public string Telefone { get; set; }
    public string? Email { get; set; }
    public int IdosoId { get; set; }

    // Relacionamentos
    public Idoso Idoso { get; set; }

    // Um responsável pode ter vários endereços
    public ICollection<Endereco> Enderecos { get; set; }
}
