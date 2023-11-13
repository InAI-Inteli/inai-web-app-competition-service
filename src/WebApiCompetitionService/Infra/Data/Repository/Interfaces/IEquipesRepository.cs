using WebAPICompetitionService.Domain.Entities;

namespace WebAPICompetitionService.Infra.Data.Repository.Interfaces
{
    public interface IEquipesRepository
    {
        Task<IEnumerable<Equipes>> GetAllEquipesAsync();
        Task<Equipes> GetEquipeByIdAsync(int id);
        void PostEquipes(Equipes equipe);
        void UpdateEquipe(Equipes equipe);
        void DeleteEquipe(int id);
    }
}
