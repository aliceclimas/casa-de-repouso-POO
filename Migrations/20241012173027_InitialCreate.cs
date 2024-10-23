using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasaRepousoWeb.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alas",
                columns: table => new
                {
                    AlaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alas", x => x.AlaId);
                });

            migrationBuilder.CreateTable(
                name: "Situacoes",
                columns: table => new
                {
                    SituacaoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    Cor = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Situacoes", x => x.SituacaoId);
                });

            migrationBuilder.CreateTable(
                name: "Idosos",
                columns: table => new
                {
                    IdosoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: false),
                    CPF = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AlaId = table.Column<int>(type: "INTEGER", nullable: false),
                    SituacaoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProblemasDeSaude = table.Column<string>(type: "TEXT", nullable: true),
                    Nutricao = table.Column<string>(type: "TEXT", nullable: true),
                    Alergia = table.Column<string>(type: "TEXT", nullable: true),
                    CuidadosEspeciais = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idosos", x => x.IdosoId);
                    table.ForeignKey(
                        name: "FK_Idosos_Alas_AlaId",
                        column: x => x.AlaId,
                        principalTable: "Alas",
                        principalColumn: "AlaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Idosos_Situacoes_SituacaoId",
                        column: x => x.SituacaoId,
                        principalTable: "Situacoes",
                        principalColumn: "SituacaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicacoes",
                columns: table => new
                {
                    MedicacaoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdosoId = table.Column<int>(type: "INTEGER", nullable: false),
                    NomeMedicamento = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    Dosagem = table.Column<string>(type: "TEXT", nullable: true),
                    Horario = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicacoes", x => x.MedicacaoId);
                    table.ForeignKey(
                        name: "FK_Medicacoes_Idosos_IdosoId",
                        column: x => x.IdosoId,
                        principalTable: "Idosos",
                        principalColumn: "IdosoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Responsaveis",
                columns: table => new
                {
                    ResponsavelId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: false),
                    CPF = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    IdosoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsaveis", x => x.ResponsavelId);
                    table.ForeignKey(
                        name: "FK_Responsaveis_Idosos_IdosoId",
                        column: x => x.IdosoId,
                        principalTable: "Idosos",
                        principalColumn: "IdosoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    Rua = table.Column<string>(type: "TEXT", nullable: false),
                    NumeroCasa = table.Column<string>(type: "TEXT", nullable: false),
                    Bairro = table.Column<string>(type: "TEXT", nullable: false),
                    CEP = table.Column<string>(type: "TEXT", nullable: false),
                    Complemento = table.Column<string>(type: "TEXT", nullable: true),
                    ResponsavelId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.EnderecoId);
                    table.ForeignKey(
                        name: "FK_Enderecos_Responsaveis_ResponsavelId",
                        column: x => x.ResponsavelId,
                        principalTable: "Responsaveis",
                        principalColumn: "ResponsavelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cuidadoras",
                columns: table => new
                {
                    CuidadoraId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: false),
                    CPF = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true),
                    Turno = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    EnderecoId = table.Column<int>(type: "INTEGER", nullable: false),
                    senha = table.Column<string>(type: "TEXT", nullable: false),
                    AlaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuidadoras", x => x.CuidadoraId);
                    table.ForeignKey(
                        name: "FK_Cuidadoras_Alas_AlaId",
                        column: x => x.AlaId,
                        principalTable: "Alas",
                        principalColumn: "AlaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cuidadoras_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "EnderecoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Relatorio",
                columns: table => new
                {
                    RelatorioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    IdosoId = table.Column<int>(type: "INTEGER", nullable: false),
                    CuidadoraId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatorio", x => x.RelatorioId);
                    table.ForeignKey(
                        name: "FK_Relatorio_Cuidadoras_CuidadoraId",
                        column: x => x.CuidadoraId,
                        principalTable: "Cuidadoras",
                        principalColumn: "CuidadoraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Relatorio_Idosos_IdosoId",
                        column: x => x.IdosoId,
                        principalTable: "Idosos",
                        principalColumn: "IdosoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuidadoras_AlaId",
                table: "Cuidadoras",
                column: "AlaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuidadoras_EnderecoId",
                table: "Cuidadoras",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_ResponsavelId",
                table: "Enderecos",
                column: "ResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_Idosos_AlaId",
                table: "Idosos",
                column: "AlaId");

            migrationBuilder.CreateIndex(
                name: "IX_Idosos_SituacaoId",
                table: "Idosos",
                column: "SituacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicacoes_IdosoId",
                table: "Medicacoes",
                column: "IdosoId");

            migrationBuilder.CreateIndex(
                name: "IX_Relatorio_CuidadoraId",
                table: "Relatorio",
                column: "CuidadoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Relatorio_IdosoId",
                table: "Relatorio",
                column: "IdosoId");

            migrationBuilder.CreateIndex(
                name: "IX_Responsaveis_IdosoId",
                table: "Responsaveis",
                column: "IdosoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicacoes");

            migrationBuilder.DropTable(
                name: "Relatorio");

            migrationBuilder.DropTable(
                name: "Cuidadoras");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Responsaveis");

            migrationBuilder.DropTable(
                name: "Idosos");

            migrationBuilder.DropTable(
                name: "Alas");

            migrationBuilder.DropTable(
                name: "Situacoes");
        }
    }
}
