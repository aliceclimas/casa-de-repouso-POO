namespace CasaRepousoWeb.Models
{
    public class Ficha
    {
        public int FichaId { get; set; }
        public string Nutricao { get; set; }
        public string Saude { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
    }
}