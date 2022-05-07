using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dominio.DAL.Contexto.Mapeamentos
{
    public class SugestaoMap : IEntityTypeConfiguration<Sugestao>
    {
        public void Configure(EntityTypeBuilder<Sugestao> builder)
        {
            builder.ToTable("[Sugestoes]");
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

            builder.OwnsOne(p => p.NomeColaborador, nomeColaborador =>
             {
                 nomeColaborador.Property(p => p.Descricao)
                 .HasColumnName("NomeColaborador")
                 .HasColumnType("varchar")
                 .HasMaxLength(256)
                 .IsRequired();
                 nomeColaborador.Ignore(p => p.Notifications);
             });

            builder.HasOne(p=> p.Departamento)
                .WithMany(p=> p.Sugestoes)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnName("TextoSugestao")
                .HasColumnType("TEXT")
                .IsRequired();

            builder.Property(p => p.Justificativa)
                .HasColumnName("Justificativa")
                .HasColumnType("TEXT")
                .IsRequired();

            builder.Ignore(p => p.Notifications);


        }
    }
}
