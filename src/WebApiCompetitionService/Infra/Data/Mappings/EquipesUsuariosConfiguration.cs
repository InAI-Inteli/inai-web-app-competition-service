using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPICompetitionService.Domain.Entities;

namespace WebAPICompetitionService.Infra.Data.Mappings
{
    public class EquipesUsuariosConfiguration : IEntityTypeConfiguration<EquipesUsuarios>
    {
        public void Configure(EntityTypeBuilder<EquipesUsuarios> builder)
        {
            builder.HasNoKey();

            builder.ToTable("equipes_usuarios");

            builder.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            builder.Property(e => e.IdEquipe)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_equipe");

            builder.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            builder.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            builder.HasOne(d => d.IdEquipeNavigation)
                .WithMany()
                .HasForeignKey(d => d.IdEquipe)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_equipe");
        }
    }
}
