namespace CasaRepousoWeb.Models;
public class Medicacao
{
    public int MedicacaoId { get; set; }
    public int IdosoId { get; set; }
    public string NomeMedicamento { get; set; }
    public string Descricao { get; set; }

    // Relacionamento
    public Idoso Idoso { get; set; }
}