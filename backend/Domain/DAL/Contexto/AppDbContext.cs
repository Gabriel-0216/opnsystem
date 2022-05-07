using Dominio.DAL.Contexto.Mapeamentos;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Dominio.DAL.Contexto
{
    public class AppDbContext : DbContext
    {
        public DbSet<Sugestao> Sugestoes { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
            @"Server=localhost,1433;Database=ProSugestoes-App;User ID=sa;Password=1q2w3e4r@#$; TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new SugestaoMap());
            modelBuilder.ApplyConfiguration(new DepartamentoMap());
        }
    }
}
