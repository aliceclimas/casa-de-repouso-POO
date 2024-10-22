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
    public DbSet<Ala> Alas { get; set; }
    public DbSet<Responsavel> Responsaveis { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Idoso> Idosos { get; set; }
    public DbSet<Medicacao> Medicacoes { get; set; }
    public DbSet<Relatorio> Relatorios { get; set; }
}

