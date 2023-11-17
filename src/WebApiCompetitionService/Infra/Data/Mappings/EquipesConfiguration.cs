using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPICompetitionService.Domain.Entities;

namespace WebAPICompetitionService.Infra.Data.Mappings
{
    public class EquipesConfiguration : IEntityTypeConfiguration<Equipes>
    {
        public void Configure(EntityTypeBuilder<Equipes> builder)
        {
            builder.ToTable("equipes");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Colocacao).HasColumnName("colocacao");

            builder.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");

            builder.Property(e => e.IdCompeticao)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_competicao");

            builder.Property(e => e.Nome)
                .HasColumnType("character varying")
                .HasColumnName("nome");

            builder.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            builder.HasOne(d => d.IdCompeticaoNavigation)
                .WithMany(p => p.Equipes)
                .HasForeignKey(d => d.IdCompeticao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_competicao");
        }
    }
}
