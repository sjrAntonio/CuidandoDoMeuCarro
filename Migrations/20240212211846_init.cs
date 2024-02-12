using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CuidandoDoMeuCarro.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManutencoesCarro",
                columns: table => new
                {
                    CarroId = table.Column<int>(type: "INTEGER", nullable: false),
                    ManutencaoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManutencoesCarro", x => new { x.CarroId, x.ManutencaoId });
                });

            migrationBuilder.CreateTable(
                name: "Montadoras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Montadoras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motoristas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Cnh = table.Column<long>(type: "INTEGER", nullable: false),
                    TipoCNH = table.Column<int>(type: "INTEGER", nullable: false),
                    ValidadeCnh = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motoristas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MotoristaId = table.Column<int>(type: "INTEGER", nullable: false),
                    MontadoraId = table.Column<int>(type: "INTEGER", nullable: false),
                    Placa = table.Column<string>(type: "TEXT", nullable: false),
                    Modelo = table.Column<string>(type: "TEXT", nullable: false),
                    Cor = table.Column<string>(type: "TEXT", nullable: false),
                    AnoFabricacao = table.Column<int>(type: "INTEGER", nullable: false),
                    AnoModelo = table.Column<int>(type: "INTEGER", nullable: false),
                    CodigoFipe = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carros_Montadoras_MontadoraId",
                        column: x => x.MontadoraId,
                        principalTable: "Montadoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Carros_Motoristas_MotoristaId",
                        column: x => x.MotoristaId,
                        principalTable: "Motoristas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Manutencoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CarroId = table.Column<int>(type: "INTEGER", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quilometragem = table.Column<long>(type: "INTEGER", nullable: false),
                    ProximaQuilometragem = table.Column<long>(type: "INTEGER", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ManutencaoCorretiva = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manutencoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manutencoes_Carros_CarroId",
                        column: x => x.CarroId,
                        principalTable: "Carros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carros_MontadoraId",
                table: "Carros",
                column: "MontadoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Carros_MotoristaId",
                table: "Carros",
                column: "MotoristaId");

            migrationBuilder.CreateIndex(
                name: "IX_Manutencoes_CarroId",
                table: "Manutencoes",
                column: "CarroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manutencoes");

            migrationBuilder.DropTable(
                name: "ManutencoesCarro");

            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "Montadoras");

            migrationBuilder.DropTable(
                name: "Motoristas");
        }
    }
}
