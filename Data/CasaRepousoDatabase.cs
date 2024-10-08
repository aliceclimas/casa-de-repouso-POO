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
    // Adicione outros DbSets conforme necessário
}

