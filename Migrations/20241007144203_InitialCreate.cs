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
                name: "Ala",
                columns: table => new
                {
                    AlaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ala", x => x.AlaId);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rua = table.Column<string>(type: "TEXT", nullable: false),
                    NumeroCasa = table.Column<string>(type: "TEXT", nullable: false),
                    Bairro = table.Column<string>(type: "TEXT", nullable: false),
                    CEP = table.Column<string>(type: "TEXT", nullable: true),
                    Complemento = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.EnderecoId);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    PessoaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: false),
                    CPF = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.PessoaId);
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
                name: "Cuidadoras",
                columns: table => new
                {
                    CuidadoraId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true),
                    Turno = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PessoaId = table.Column<int>(type: "INTEGER", nullable: false),
                    EnderecoId = table.Column<int>(type: "INTEGER", nullable: false),
                    senha = table.Column<string>(type: "TEXT", nullable: false),
                    AlaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuidadoras", x => x.CuidadoraId);
                    table.ForeignKey(
                        name: "FK_Cuidadoras_Ala_AlaId",
                        column: x => x.AlaId,
                        principalTable: "Ala",
                        principalColumn: "AlaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cuidadoras_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "EnderecoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cuidadoras_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Idoso",
                columns: table => new
                {
                    IdosoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PessoaId = table.Column<int>(type: "INTEGER", nullable: false),
                    dataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AlaId = table.Column<int>(type: "INTEGER", nullable: false),
                    SituacaoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProblemasDeSaude = table.Column<string>(type: "TEXT", nullable: true),
                    Nutricao = table.Column<string>(type: "TEXT", nullable: true),
                    Alergia = table.Column<string>(type: "TEXT", nullable: true),
                    CuidadosEspeciais = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idoso", x => x.IdosoId);
                    table.ForeignKey(
                        name: "FK_Idoso_Ala_AlaId",
                        column: x => x.AlaId,
                        principalTable: "Ala",
                        principalColumn: "AlaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Idoso_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Idoso_Situacoes_SituacaoId",
                        column: x => x.SituacaoId,
                        principalTable: "Situacoes",
                        principalColumn: "SituacaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicacao",
                columns: table => new
                {
                    MedicacaoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdosoId = table.Column<int>(type: "INTEGER", nullable: false),
                    NomeMedicamento = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicacao", x => x.MedicacaoId);
                    table.ForeignKey(
                        name: "FK_Medicacao_Idoso_IdosoId",
                        column: x => x.IdosoId,
                        principalTable: "Idoso",
                        principalColumn: "IdosoId",
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
                        name: "FK_Relatorio_Idoso_IdosoId",
                        column: x => x.IdosoId,
                        principalTable: "Idoso",
                        principalColumn: "IdosoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Responsavel",
                columns: table => new
                {
                    ResponsavelId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    PessoaId = table.Column<int>(type: "INTEGER", nullable: false),
                    EnderecoId = table.Column<int>(type: "INTEGER", nullable: false),
                    IdosoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsavel", x => x.ResponsavelId);
                    table.ForeignKey(
                        name: "FK_Responsavel_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "EnderecoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Responsavel_Idoso_IdosoId",
                        column: x => x.IdosoId,
                        principalTable: "Idoso",
                        principalColumn: "IdosoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Responsavel_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "PessoaId",
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
                name: "IX_Cuidadoras_PessoaId",
                table: "Cuidadoras",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Idoso_AlaId",
                table: "Idoso",
                column: "AlaId");

            migrationBuilder.CreateIndex(
                name: "IX_Idoso_PessoaId",
                table: "Idoso",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Idoso_SituacaoId",
                table: "Idoso",
                column: "SituacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicacao_IdosoId",
                table: "Medicacao",
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
                name: "IX_Responsavel_EnderecoId",
                table: "Responsavel",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Responsavel_IdosoId",
                table: "Responsavel",
                column: "IdosoId");

            migrationBuilder.CreateIndex(
                name: "IX_Responsavel_PessoaId",
                table: "Responsavel",
                column: "PessoaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicacao");

            migrationBuilder.DropTable(
                name: "Relatorio");

            migrationBuilder.DropTable(
                name: "Responsavel");

            migrationBuilder.DropTable(
                name: "Cuidadoras");

            migrationBuilder.DropTable(
                name: "Idoso");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Ala");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Situacoes");
        }
    }
}
