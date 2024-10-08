namespace CasaRepousoWeb.Models;

public class Situacao
{
    public int SituacaoId { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Cor { get; set; }
    
    // Relacionamento 
    public ICollection<Idoso> Idosos { get; set; }
}
