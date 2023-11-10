using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPICompetitionService.Domain.Entities;

namespace WebAPICompetitionService.Infra.Data.Mappings
{
    public class InscricoesConfiguration : IEntityTypeConfiguration<Inscricoes>
    {
        public void Configure(EntityTypeBuilder<Inscricoes> builder)
        {
            builder.ToTable("inscricoes");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");

            builder.Property(e => e.Cursos)
                .HasColumnType("character varying")
                .HasColumnName("cursos");

            builder.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");

            builder.Property(e => e.IdCompeticao)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_competicao");

            builder.Property(e => e.InstituicaoEnsino)
                .HasColumnType("character varying")
                .HasColumnName("instituicao_ensino");

            builder.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");

            builder.Property(e => e.Profissao)
                .HasColumnType("character varying")
                .HasColumnName("profissao");

            builder.Property(e => e.UpdateAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");

            builder.HasOne(d => d.IdCompeticaoNavigation)
                .WithMany(p => p.Inscricos)
                .HasForeignKey(d => d.IdCompeticao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_competicao");
        }
    }
}
