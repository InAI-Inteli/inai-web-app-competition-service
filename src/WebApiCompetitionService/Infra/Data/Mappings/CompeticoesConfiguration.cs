using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPICompetitionService.Domain.Entities;

namespace WebAPICompetitionService.Infra.Data.Mappings
{
    public class CompeticoesConfiguration : IEntityTypeConfiguration<Competicoes>
    {
        public void Configure(EntityTypeBuilder<Competicoes> builder)
        {
            builder.ToTable("competicoes");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");

            builder.Property(e => e.Data).HasColumnName("data");

            builder.Property(e => e.Descricao)
                .HasColumnType("character varying")
                .HasColumnName("descricao");

            builder.Property(e => e.Imagem)
                .HasColumnType("character varying")
                .HasColumnName("imagem");

            builder.Property(e => e.Local)
                .HasColumnType("character varying")
                .HasColumnName("local");

            builder.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");

            builder.Property(e => e.ResultadoObtido)
                .HasColumnType("character varying")
                .HasColumnName("resultado_obtido");

            builder.Property(e => e.Resumo)
                .HasColumnType("character varying")
                .HasColumnName("resumo");

            builder.Property(e => e.Tipo)
                .HasColumnType("character varying")
                .HasColumnName("tipo");

            builder.Property(e => e.UpdateAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
        }
    }
}
