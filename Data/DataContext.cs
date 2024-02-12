using CuidandoDoMeuCarro.Models;
using Microsoft.EntityFrameworkCore;

namespace CuidandoDoMeuCarro.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
            //Nothing to do here!
        }

        public DbSet<Carro> Carros { get; set; }
        public DbSet<Manutencao> Manutencoes { get; set; }
        public DbSet<ManutencaoCarro> ManutencoesCarro { get; set; }
        public DbSet<Montadora> Montadoras { get; set; }
        public DbSet<Motorista> Motoristas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Motorista>()
                   .HasKey(e => new { e.Id }); // PK

            modelBuilder.Entity<Montadora>()
                   .HasKey(e => new { e.Id }); // PK

            modelBuilder.Entity<ManutencaoCarro>()
                    .HasKey(e => new { e.CarroId, e.ManutencaoId }); // PK

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
                    .OnDelete(DeleteBehavior.Restrict); // FK - Motorista
            });
        }
    }
}
