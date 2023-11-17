using System.ComponentModel.DataAnnotations;

namespace WebAPICompetitionService.Domain.DTOs.ViewModels
{
    public class CompeticoesUpdateViewModel
    {
        [Required(ErrorMessage = "O campo 'Id' é obrigatório.")]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public DateOnly? Data { get; set; }
        public string? Tipo { get; set; }
        public string? Local { get; set; }
        public string? Descricao { get; set; }
        public string? Imagem { get; set; }
        public string? Resumo { get; set; }
        public string? ResultadoObtido { get; set; }
    }
}