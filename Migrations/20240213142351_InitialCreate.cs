using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CuidandoDoMeuCarro.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Montadoras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Marca = table.Column<string>(type: "TEXT", nullable: false)
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
                    Modelo = table.Column<string>(type: "TEXT", nullable: false),
                    Placa = table.Column<string>(type: "TEXT", nullable: false),
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

            migrationBuilder.InsertData(
                table: "Montadoras",
                columns: new[] { "Id", "Marca" },
                values: new object[,]
                {
                    { 1, "Nissan" },
                    { 2, "Volkswagen" },
                    { 3, "Fiat" },
                    { 4, "GM" },
                    { 5, "Ford" }
                });

            migrationBuilder.InsertData(
                table: "Motoristas",
                columns: new[] { "Id", "Cnh", "Nome", "TipoCNH", "ValidadeCnh" },
                values: new object[,]
                {
                    { 1, 1234567890L, "Antonio Souza", 4, new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 7894561230L, "Daniela Campos", 2, new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 5201789652L, "Eduardo Souza", 1, new DateTime(2026, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Carros",
                columns: new[] { "Id", "AnoFabricacao", "AnoModelo", "CodigoFipe", "Cor", "Modelo", "MontadoraId", "MotoristaId", "Placa" },
                values: new object[,]
                {
                    { 1, 2018, 2018, "023140-1", "Prata", "Versa", 1, 1, "ABC1D234" },
                    { 2, 2019, 2021, "054409-7", "Vermelho", "MOBI", 3, 2, "VDA0E751" }
                });

            migrationBuilder.InsertData(
                table: "Manutencoes",
                columns: new[] { "Id", "CarroId", "Data", "Descricao", "ManutencaoCorretiva", "Quilometragem", "Valor" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Troca de óleo", false, 70251L, 258.21m },
                    { 2, 1, new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Troca de Filtros", false, 70251L, 115.50m },
                    { 3, 1, new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Troca de Velas", true, 80557L, 321.99m },
                    { 4, 1, new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Troca de Pastilhas de Freio", true, 85521L, 299.99m },
                    { 5, 2, new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Troca de óleo", false, 52225L, 199.99m },
                    { 6, 2, new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Troca de Filtros", false, 52225L, 99.99m },
                    { 7, 2, new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Troca da Correia Dentada", true, 60002L, 517.25m }
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
                name: "Carros");

            migrationBuilder.DropTable(
                name: "Montadoras");

            migrationBuilder.DropTable(
                name: "Motoristas");
        }
    }
}
