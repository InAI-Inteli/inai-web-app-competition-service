using System.ComponentModel.DataAnnotations;

namespace WebAPICompetitionService.Domain.DTOs.ViewModels
{
    public class CompeticoesAddViewModel
    {
        [Required(ErrorMessage = "O campo 'Nome' é obrigatório.")]
        public string Nome { get; set; }
        public DateOnly? Data { get; set; }
        public string? Tipo { get; set; }
        public string? Local { get; set; }
        [Required(ErrorMessage = "O campo 'Descrição' é obrigatório.")]
        public string? Descricao { get; set; }
        public string? Imagem { get; set; }
        public string? Resumo { get; set; }
        public string? ResultadoObtido { get; set; }
    }
}
