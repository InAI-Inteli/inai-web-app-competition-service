using System;
using System.Collections.Generic;

namespace WebAPICompetitionService.Domain.Entities
{
    public partial class EquipesUsuarios
    {
        public int Id { get; set; }
        public int? IdUsuario { get; set; }
        public int IdEquipe { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Equipes IdEquipeNavigation { get; set; } = null!;
    }
}
