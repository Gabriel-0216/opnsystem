
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dominio.DAL.Contexto.Mapeamentos
{
    public class DepartamentoMap : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.ToTable("[Departamento]");

            builder.Property(p => p.Id)
                 .ValueGeneratedOnAdd()
                 .UseIdentityColumn();

            builder.Property(p => p.Data_Criacao)
                .HasColumnName("Data_Criacao")
                .HasColumnType("DATETIME")
                .IsRequired();

            builder.Property(p => p.Data_Atualizacao)
               .HasColumnName("Data_Atualizacao")
               .HasColumnType("DATETIME")
               .IsRequired();

            builder.OwnsOne(p => p.NomeDepartamento, nomeDepartamento =>
             {
                 nomeDepartamento.Property(p => p.Descricao)
                 .HasColumnName("NomeDepartamento")
                 .HasColumnType("varchar")
                 .HasMaxLength(256)
                 .IsRequired();
                 nomeDepartamento.Ignore(p => p.Notifications);
             });

            builder.HasMany(p => p.Sugestoes)
                .WithOne(p => p.Departamento)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Ignore(p => p.Notifications);

        }
    }
}
