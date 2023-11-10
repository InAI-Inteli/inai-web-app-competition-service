using System;
using System.Collections.Generic;

namespace WebAPICompetitionService.Domain.Entities
{
    public partial class Inscricoes
    {
        public int Id { get; set; }
        public int IdCompeticao { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? InstituicaoEnsino { get; set; }
        public string? Cursos { get; set; }
        public string? Profissao { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual Competicoes IdCompeticaoNavigation { get; set; } = null!;
    }
}
