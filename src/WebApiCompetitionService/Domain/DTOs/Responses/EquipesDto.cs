namespace WebAPICompetitionService.Domain.DTOs.Responses
{
    public class EquipesDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int IdCompeticao { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? Colocacao { get; set; }
    }
}
