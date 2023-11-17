using WebAPICompetitionService.Domain.Entities;
using WebAPICompetitionService.Infra.Data.Repository.Interfaces;
using WebAPICompetitionService.Infra.Data.UnitOfWork;

namespace WebAPICompetitionService.Service.Interfaces
{
    public class EquipesService : IEquipesService
    {
        private readonly IEquipesRepository _equipesRepository;
        private readonly IUnitOfWork _uow;

        public EquipesService(IEquipesRepository equipesRepository, IUnitOfWork uow)
        {
            _equipesRepository = equipesRepository;
            _uow = uow;
        }

        public async Task<IEnumerable<Equipes>> GetAllEquipesAsync()
        {
            return await _equipesRepository.GetAllEquipesAsync();
        }

        public async Task<Equipes> GetEquipeByIdAsync(int id)
        {
            return await _equipesRepository.GetEquipeByIdAsync(id);
        }

        public async Task PostEquipes(Equipes equipe)
        {
            _equipesRepository.PostEquipes(equipe);
            await _uow.Commit();
        }

        public async Task UpdateEquipeAsync(Equipes equipe)
        {
            _equipesRepository.UpdateEquipe(equipe);
            await _uow.Commit();
        }

        public async Task DeleteEquipeAsync(int id)
        {
            _equipesRepository.DeleteEquipe(id);
            await _uow.Commit();
        }
    }
}
