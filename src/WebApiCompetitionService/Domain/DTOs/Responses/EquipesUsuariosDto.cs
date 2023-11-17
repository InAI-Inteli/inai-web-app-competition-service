namespace WebAPICompetitionService.Domain.DTOs.Responses
{
    public class EquipesUsuariosDto
    {
        public int Id { get; set; }
        public int? IdUsuario { get; set; }
        public int IdEquipe { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
