using System;

namespace CasaRepousoWeb.Services
{
    public class IdosoService
    {
        public int CalcularIdade(DateTime dataNascimento)
        {
            var idade = DateTime.Now.Year - dataNascimento.Year;
            if (DateTime.Now.DayOfYear < dataNascimento.DayOfYear)
            {
                idade--;
            }
            return idade;
        }
    }
}
