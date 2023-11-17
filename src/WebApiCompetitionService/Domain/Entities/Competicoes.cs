using System;
using System.Collections.Generic;

namespace WebAPICompetitionService.Domain.Entities
{
    public partial class Competicoes
    {
        public Competicoes()
        {
            Equipes = new HashSet<Equipes>();
            Inscricos = new HashSet<Inscricoes>();
        }

        public int Id { get; set; }
        public string? Nome { get; set; }
        public DateOnly? Data { get; set; }
        public string? Tipo { get; set; }
        public string? Local { get; set; }
        public string? Descricao { get; set; }
        public string? Imagem { get; set; }
        public string? Resumo { get; set; }
        public string? ResultadoObtido { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual ICollection<Equipes> Equipes { get; set; }
        public virtual ICollection<Inscricoes> Inscricos { get; set; }
    }
}
