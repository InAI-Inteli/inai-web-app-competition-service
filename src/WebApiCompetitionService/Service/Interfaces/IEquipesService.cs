using WebAPICompetitionService.Domain.Entities;

namespace WebAPICompetitionService.Service.Interfaces
{
    public interface IEquipesService
    {
        Task<IEnumerable<Equipes>> GetAllEquipesAsync();
        Task<Equipes> GetEquipeByIdAsync(int id);
        Task PostEquipes(Equipes equipe);
        Task UpdateEquipeAsync(Equipes equipe);
        Task DeleteEquipeAsync(int id);
    }
}
