﻿// <auto-generated />
using System;
using GrilsRide.Web.Percistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GirlsRide.Web.Migrations
{
    [DbContext(typeof(GirlsRideContext))]
    [Migration("20221106161311_Inicio")]
    partial class Inicio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GrilsRide.Web.Models.Carro", b =>
                {
                    b.Property<int>("CarroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarroId"), 1L, 1);

                    b.Property<int?>("CarroId1")
                        .HasColumnType("int");

                    b.Property<string>("ModeloCarro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenhaPorta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarroId");

                    b.HasIndex("CarroId1");

                    b.ToTable("Carros");
                });

            modelBuilder.Entity("GrilsRide.Web.Models.Cartao", b =>
                {
                    b.Property<int>("CartaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartaoId"), 1L, 1);

                    b.Property<int?>("CartaoId1")
                        .HasColumnType("int");

                    b.Property<int>("cvv")
                        .HasColumnType("int");

                    b.Property<string>("nomeImpresso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nrCartao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("validade")
                        .HasColumnType("datetime2");

                    b.HasKey("CartaoId");

                    b.HasIndex("CartaoId1");

                    b.ToTable("Cartoes");
                });

            modelBuilder.Entity("GrilsRide.Web.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarroId")
                        .HasColumnType("int");

                    b.Property<int>("CartaoId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PagamentosId")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("chegada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("partida")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarroId");

                    b.HasIndex("CartaoId");

                    b.HasIndex("PagamentosId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("GrilsRide.Web.Models.Pagamento", b =>
                {
                    b.Property<int>("PagamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PagamentoId"), 1L, 1);

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<string>("metodoPagamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PagamentoId");

                    b.ToTable("pagamentos");
                });

            modelBuilder.Entity("GrilsRide.Web.Models.Carro", b =>
                {
                    b.HasOne("GrilsRide.Web.Models.Carro", null)
                        .WithMany("Carros")
                        .HasForeignKey("CarroId1");
                });

            modelBuilder.Entity("GrilsRide.Web.Models.Cartao", b =>
                {
                    b.HasOne("GrilsRide.Web.Models.Cartao", null)
                        .WithMany("Cartoes")
                        .HasForeignKey("CartaoId1");
                });

            modelBuilder.Entity("GrilsRide.Web.Models.Cliente", b =>
                {
                    b.HasOne("GrilsRide.Web.Models.Carro", "Carros")
                        .WithMany()
                        .HasForeignKey("CarroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GrilsRide.Web.Models.Cartao", "Cartoes")
                        .WithMany()
                        .HasForeignKey("CartaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GrilsRide.Web.Models.Pagamento", "Pagamentos")
                        .WithMany()
                        .HasForeignKey("PagamentosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carros");

                    b.Navigation("Cartoes");

                    b.Navigation("Pagamentos");
                });

            modelBuilder.Entity("GrilsRide.Web.Models.Carro", b =>
                {
                    b.Navigation("Carros");
                });

            modelBuilder.Entity("GrilsRide.Web.Models.Cartao", b =>
                {
                    b.Navigation("Cartoes");
                });
#pragma warning restore 612, 618
        }
    }
}