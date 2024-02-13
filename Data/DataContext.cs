using CuidandoDoMeuCarro.Models;
using Microsoft.EntityFrameworkCore;
using static CuidandoDoMeuCarro.Models.Motorista;

namespace CuidandoDoMeuCarro.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
            //Nothing to do here!
        }

        /*****************************************
        * dotnet ef migrations add InitialCreate *
        * dotnet ef database update              *
        *****************************************/
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Manutencao> Manutencoes { get; set; }
        public DbSet<Montadora> Montadoras { get; set; }
        public DbSet<Motorista> Motoristas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Motorista>()
                   .HasKey(e => new { e.Id }); // PK

            modelBuilder.Entity<Montadora>()
                   .HasKey(e => new { e.Id }); // PK

            modelBuilder.Entity<Carro>(entity =>
            {
                entity.HasKey(e => e.Id); // PK

                entity.HasOne(e => e.Motorista)
                    .WithMany(e => e.Carros)
                    .HasForeignKey(e => e.MotoristaId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict); // FK - Motorista

                entity.HasOne(e => e.Montadora)
                    .WithMany(e => e.Carros)
                    .HasForeignKey(e => e.MontadoraId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict); // FK - Montadora

            });

            modelBuilder.Entity<Manutencao>(entity =>
            {
                entity.HasKey(e => e.Id); // PK

                entity.HasOne(e => e.Carro)
                    .WithMany(e => e.Manutencoes)
                    .HasForeignKey(e => e.CarroId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict); // FK - Carro
            });

            modelBuilder.Entity<Motorista>(entity =>
            {
                List<Motorista> data = new List<Motorista>()
                {
                    new Motorista() {Id = 1, Nome = "Antonio Souza", Cnh = 1234567890, TipoCNH = (int)enTipoCnh.D, ValidadeCnh = new DateTime(2025, 10, 1, 0, 0, 0) },
                    new Motorista() {Id = 2, Nome = "Daniela Campos", Cnh = 7894561230, TipoCNH = (int)enTipoCnh.B, ValidadeCnh = new DateTime(2024, 8, 15, 0, 0, 0) },
                    new Motorista() {Id = 3, Nome = "Eduardo Souza", Cnh = 5201789652, TipoCNH = (int)enTipoCnh.A, ValidadeCnh = new DateTime(2026, 7, 30, 0, 0, 0) }
                };

                entity.HasData(data);
            });

            modelBuilder.Entity<Montadora>(entity =>
            {
                List<Montadora> data = new List<Montadora>()
                {
                    new Montadora() {Id = 1, Marca = "Nissan"},
                    new Montadora() {Id = 2, Marca = "Volkswagen"},
                    new Montadora() {Id = 3, Marca = "Fiat"},
                    new Montadora() {Id = 4, Marca = "GM"},
                    new Montadora() {Id = 5, Marca = "Ford"}
                };

                entity.HasData(data);
            });

            modelBuilder.Entity<Carro>(entity =>
            {
                List<Carro> data = new List<Carro>()
                {
                    new Carro() {Id = 1, MotoristaId = 1, MontadoraId = 1, Modelo = "Versa", Placa = "ABC1D234", Cor = "Prata", AnoFabricacao = 2018, AnoModelo = 2018, CodigoFipe = "023140-1"},
                    new Carro() {Id = 2, MotoristaId = 2, MontadoraId = 3, Modelo = "MOBI", Placa = "VDA0E751", Cor = "Vermelho", AnoFabricacao = 2019, AnoModelo = 2021, CodigoFipe = "054409-7"}
                };

                entity.HasData(data);
            });

            modelBuilder.Entity<Manutencao>(entity =>
            {
                List<Manutencao> data = new List<Manutencao>()
                {
                    new Manutencao() {Id = 1, CarroId = 1, Descricao = "Troca de óleo", Valor = 258.21M, Quilometragem = 70251, Data = new DateTime(2023, 7, 10, 0, 0, 0), ManutencaoCorretiva = false},
                    new Manutencao() {Id = 2, CarroId = 1, Descricao = "Troca de Filtros", Valor = 115.50M, Quilometragem = 70251, Data = new DateTime(2023, 7, 10, 0, 0, 0), ManutencaoCorretiva = false},
                    new Manutencao() {Id = 3, CarroId = 1, Descricao = "Troca de Velas", Valor = 321.99M, Quilometragem = 80557, Data = new DateTime(2023, 9, 30, 0, 0, 0), ManutencaoCorretiva = true},
                    new Manutencao() {Id = 4, CarroId = 1, Descricao = "Troca de Pastilhas de Freio", Valor = 299.99M, Quilometragem = 85521, Data = new DateTime(2023, 11, 30, 0, 0, 0), ManutencaoCorretiva = true},
                    new Manutencao() {Id = 5, CarroId = 2, Descricao = "Troca de óleo", Valor = 199.99M, Quilometragem = 52225, Data = new DateTime(2023, 8, 25, 0, 0, 0), ManutencaoCorretiva = false},
                    new Manutencao() {Id = 6, CarroId = 2, Descricao = "Troca de Filtros", Valor = 99.99M, Quilometragem = 52225, Data = new DateTime(2023, 8, 25, 0, 0, 0), ManutencaoCorretiva = false},
                    new Manutencao() {Id = 7, CarroId = 2, Descricao = "Troca da Correia Dentada", Valor = 517.25M, Quilometragem = 60002, Data = new DateTime(2023, 12, 15, 0, 0, 0), ManutencaoCorretiva = true},
                };

                entity.HasData(data);
            });
        }
    }
}
