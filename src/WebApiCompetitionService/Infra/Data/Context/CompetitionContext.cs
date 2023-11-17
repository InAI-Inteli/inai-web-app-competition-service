using Microsoft.EntityFrameworkCore;
using WebAPICompetitionService.Domain.Entities;
using WebAPICompetitionService.Infra.Data.Mappings;

namespace WebAPICompetitionService.Infra.Data.Context
{
    public partial class CompetitionContext : DbContext
    {
        public CompetitionContext()
        {
        }

        public CompetitionContext(DbContextOptions<CompetitionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Competicoes> Competicoes { get; set; } = null!;
        public virtual DbSet<Equipes> Equipes { get; set; } = null!;
        public virtual DbSet<EquipesUsuarios> EquipesUsuarios { get; set; } = null!;
        public virtual DbSet<Inscricoes> Inscricoes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("btree_gin")
                .HasPostgresExtension("btree_gist")
                .HasPostgresExtension("citext")
                .HasPostgresExtension("cube")
                .HasPostgresExtension("dblink")
                .HasPostgresExtension("dict_int")
                .HasPostgresExtension("dict_xsyn")
                .HasPostgresExtension("earthdistance")
                .HasPostgresExtension("fuzzystrmatch")
                .HasPostgresExtension("hstore")
                .HasPostgresExtension("intarray")
                .HasPostgresExtension("ltree")
                .HasPostgresExtension("pg_stat_statements")
                .HasPostgresExtension("pg_trgm")
                .HasPostgresExtension("pgcrypto")
                .HasPostgresExtension("pgrowlocks")
                .HasPostgresExtension("pgstattuple")
                .HasPostgresExtension("tablefunc")
                .HasPostgresExtension("unaccent")
                .HasPostgresExtension("uuid-ossp")
                .HasPostgresExtension("xml2");

            modelBuilder.ApplyConfiguration(new CompeticoesConfiguration());
            modelBuilder.ApplyConfiguration(new EquipesConfiguration());
            modelBuilder.ApplyConfiguration(new EquipesUsuariosConfiguration());
            modelBuilder.ApplyConfiguration(new InscricoesConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
