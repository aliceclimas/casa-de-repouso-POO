﻿// <auto-generated />
using System;
using CasaRepousoWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CasaRepousoWeb.Migrations
{
    [DbContext(typeof(CasaRepousoDatabase))]
    [Migration("20241109203915_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("CasaRepousoWeb.Models.Ala", b =>
                {
                    b.Property<int>("AlaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AlaId");

                    b.ToTable("Alas");
                });

            modelBuilder.Entity("CasaRepousoWeb.Models.Cuidadora", b =>
                {
                    b.Property<int>("CuidadoraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AlaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan?>("HorarioEntrada")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan?>("HorarioSaida")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("CuidadoraId");

                    b.HasIndex("AlaId");

                    b.ToTable("Cuidadoras");
                });

            modelBuilder.Entity("CasaRepousoWeb.Models.Endereco", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Complemento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NumeroCasa")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ResponsavelId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("EnderecoId");

                    b.HasIndex("ResponsavelId");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("CasaRepousoWeb.Models.Idoso", b =>
                {
                    b.Property<int>("IdosoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Alergia")
                        .HasColumnType("TEXT");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CuidadosEspeciais")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("IdImagem")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nutricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProblemasDeSaude")
                        .HasColumnType("TEXT");

                    b.Property<int>("SituacaoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdosoId");

                    b.HasIndex("AlaId");

                    b.HasIndex("SituacaoId");

                    b.ToTable("Idosos");
                });

            modelBuilder.Entity("CasaRepousoWeb.Models.Medicacao", b =>
                {
                    b.Property<int>("MedicacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Dosagem")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Horario")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdosoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NomeMedicamento")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MedicacaoId");

                    b.HasIndex("IdosoId");

                    b.ToTable("Medicacoes");
                });

            modelBuilder.Entity("CasaRepousoWeb.Models.Relatorio", b =>
                {
                    b.Property<int>("RelatorioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdosoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("RelatorioId");

                    b.HasIndex("IdosoId");

                    b.ToTable("Relatorios");
                });

            modelBuilder.Entity("CasaRepousoWeb.Models.RelatorioCuidadora", b =>
                {
                    b.Property<int>("RelatorioCuidadoraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Acao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CuidadoraId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RelatorioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RelatorioCuidadoraId");

                    b.HasIndex("CuidadoraId");

                    b.HasIndex("RelatorioId");

                    b.ToTable("RelatorioCuidadora");
                });

            modelBuilder.Entity("CasaRepousoWeb.Models.Responsavel", b =>
                {
                    b.Property<int>("ResponsavelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdosoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ResponsavelId");

                    b.HasIndex("IdosoId");

                    b.ToTable("Responsaveis");
                });

            modelBuilder.Entity("CasaRepousoWeb.Models.Situacao", b =>
                {
                    b.Property<int>("SituacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SituacaoId");

                    b.ToTable("Situacoes");
                });

            modelBuilder.Entity("CasaRepousoWeb.Models.Cuidadora", b =>
                {
                    b.HasOne("CasaRepousoWeb.Models.Ala", "Ala")
                        .WithMany("Cuidadoras")
                        .HasForeignKey("AlaId");

                    b.Navigation("Ala");
                });

            modelBuilder.Entity("CasaRepousoWeb.Models.Endereco", b =>
                {
                    b.HasOne("CasaRepousoWeb.Models.Responsavel", "Responsavel")
                        .WithMany("Enderecos")
                        .HasForeignKey("ResponsavelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Responsavel");
                });

            modelBuilder.Entity("CasaRepousoWeb.Models.Idoso", b =>
                {
                    b.HasOne("CasaRepousoWeb.Models.Ala", "Ala")
                        .WithMany("Idosos")
                        .HasForeignKey("AlaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CasaRepousoWeb.Models.Situacao", "Situacao")
                        .WithMany("Idosos")
                        .HasForeignKey("SituacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ala");

                    b.Navigation("Situacao");
                });

            modelBuilder.Entity("CasaRepousoWeb.Models.Medicacao", b =>
                {
                    b.HasOne("CasaRepousoWeb.Models.Idoso", "Idoso")
                        .WithMany("Medicacoes")
                        .HasForeignKey("IdosoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Idoso");
                });

            modelBuilder.Entity("CasaRepousoWeb.Models.Relatorio", b =>
                {
                    b.HasOne("CasaRepousoWeb.Models.Idoso", "Idoso")
                        .WithMany("Relatorios")
                        .HasForeignKey("IdosoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Idoso");
                });

            modelBuilder.Entity("CasaRepousoWeb.Models.RelatorioCuidadora", b =>
                {
                    b.HasOne("CasaRepousoWeb.Models.Cuidadora", "Cuidadora")
                        .WithMany()
                        .HasForeignKey("CuidadoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CasaRepousoWeb.Models.Relatorio", "Relatorio")
                        .WithMany()
                        .HasForeignKey("RelatorioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuidadora");

                    b.Navigation("Relatorio");
                });

            modelBuilder.Entity("CasaRepousoWeb.Models.Responsavel", b =>
                {
                    b.HasOne("CasaRepousoWeb.Models.Idoso", "Idoso")
                        .WithMany()
                        .HasForeignKey("IdosoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Idoso");
                });

            modelBuilder.Entity("CasaRepousoWeb.Models.Ala", b =>
                {
                    b.Navigation("Cuidadoras");

                    b.Navigation("Idosos");
                });

            modelBuilder.Entity("CasaRepousoWeb.Models.Idoso", b =>
                {
                    b.Navigation("Medicacoes");

                    b.Navigation("Relatorios");
                });

            modelBuilder.Entity("CasaRepousoWeb.Models.Responsavel", b =>
                {
                    b.Navigation("Enderecos");
                });

            modelBuilder.Entity("CasaRepousoWeb.Models.Situacao", b =>
                {
                    b.Navigation("Idosos");
                });
#pragma warning restore 612, 618
        }
    }
}
