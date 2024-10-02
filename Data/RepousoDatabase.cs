using CasaRespousoWeb.Models; // importando namespace do projeto
using Microsoft.EntityFrameworkCore; // permite usar classes e funcionalidades do EntityFramework (biblioteca que permite interagir com o Banco de Dados)

// DbContext - classe base responsável por gerenciar o banco de dados
public class RepousoDatabase: DbContext{

     public RepousoDatabase(DbContextOptions options) : base(options) {} // método construtor

    public DbSet<Pessoa> Pessoas { get; set; }   

    public DbSet<Ficha> Fichas { get; set; }
}