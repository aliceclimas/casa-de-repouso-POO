namespace CasaRepousoWeb.Models;

public class Ala
{
    public int AlaId { get; set; }
    public string Nome { get; set; }
    public string? Descricao { get; set; }

    // Relacionamento com Idoso e Cuidadora
    public ICollection<Idoso> Idosos { get; set; }
    public ICollection<Cuidadora> Cuidadoras { get; set; }
}
