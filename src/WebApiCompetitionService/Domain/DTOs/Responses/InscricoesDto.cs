namespace WebAPICompetitionService.Domain.DTOs.Responses
{
    public class InscricoesDto
    {
        public int Id { get; set; }
        public int IdCompeticao { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? InstituicaoEnsino { get; set; }
        public string? Curos { get; set; }
        public string? Profissao { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
