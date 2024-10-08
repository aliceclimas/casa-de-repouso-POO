using Microsoft.EntityFrameworkCore;
using CasaRepousoWeb.Models;

namespace CasaRepousoWeb.Data;
public class CasaRepousoDatabase : DbContext
{
    public CasaRepousoDatabase(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Cuidadora> Cuidadoras { get; set; }
    public DbSet<Situacao> Situacoes { get; set; }

    public DbSet<Pessoa> Pessoas { get; set; }   
    public DbSet<Medicacao> Medicacoes { get; set; }
    public DbSet<Ala> Alas { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    // Adicione outros DbSets conforme necessário
}

