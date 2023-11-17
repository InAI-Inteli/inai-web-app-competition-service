using System;
using System.Collections.Generic;

namespace WebAPICompetitionService.Domain.Entities
{
    public partial class Equipes
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int IdCompeticao { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? Colocacao { get; set; }

        public virtual Competicoes IdCompeticaoNavigation { get; set; } = null!;
    }
}
