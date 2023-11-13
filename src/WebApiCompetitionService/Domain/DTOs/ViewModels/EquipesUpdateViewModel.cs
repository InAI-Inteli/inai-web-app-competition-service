using System.ComponentModel.DataAnnotations;

namespace WebAPICompetitionService.Domain.DTOs.ViewModels
{
    public class EquipesUpdateViewModel
    {
        [Required(ErrorMessage = "O campo 'Id' é obrigatório.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo 'IdCompeticao' é obrigatório.")]
        public int IdCompeticao { get; set; }

        [Required(ErrorMessage = "O campo 'Colocacao' é obrigatório.")]
        public int Colocacao { get; set; }
    }
}
