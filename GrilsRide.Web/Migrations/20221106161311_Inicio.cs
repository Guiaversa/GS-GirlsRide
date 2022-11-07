using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GirlsRide.Web.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    CarroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModeloCarro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenhaPorta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarroId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.CarroId);
                    table.ForeignKey(
                        name: "FK_Carros_Carros_CarroId1",
                        column: x => x.CarroId1,
                        principalTable: "Carros",
                        principalColumn: "CarroId");
                });

            migrationBuilder.CreateTable(
                name: "Cartoes",
                columns: table => new
                {
                    CartaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nrCartao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    validade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cvv = table.Column<int>(type: "int", nullable: false),
                    nomeImpresso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CartaoId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartoes", x => x.CartaoId);
                    table.ForeignKey(
                        name: "FK_Cartoes_Cartoes_CartaoId1",
                        column: x => x.CartaoId1,
                        principalTable: "Cartoes",
                        principalColumn: "CartaoId");
                });

            migrationBuilder.CreateTable(
                name: "pagamentos",
                columns: table => new
                {
                    PagamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    metodoPagamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pagamentos", x => x.PagamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    partida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    chegada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarroId = table.Column<int>(type: "int", nullable: false),
                    CartaoId = table.Column<int>(type: "int", nullable: false),
                    PagamentosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Carros_CarroId",
                        column: x => x.CarroId,
                        principalTable: "Carros",
                        principalColumn: "CarroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clientes_Cartoes_CartaoId",
                        column: x => x.CartaoId,
                        principalTable: "Cartoes",
                        principalColumn: "CartaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clientes_pagamentos_PagamentosId",
                        column: x => x.PagamentosId,
                        principalTable: "pagamentos",
                        principalColumn: "PagamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carros_CarroId1",
                table: "Carros",
                column: "CarroId1");

            migrationBuilder.CreateIndex(
                name: "IX_Cartoes_CartaoId1",
                table: "Cartoes",
                column: "CartaoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CarroId",
                table: "Clientes",
                column: "CarroId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CartaoId",
                table: "Clientes",
                column: "CartaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_PagamentosId",
                table: "Clientes",
                column: "PagamentosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "Cartoes");

            migrationBuilder.DropTable(
                name: "pagamentos");
        }
    }
}
