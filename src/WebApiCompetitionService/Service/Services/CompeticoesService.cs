using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPICompetitionService.Domain.Entities;
using WebAPICompetitionService.Infra.Data.Repository.Interfaces;
using WebAPICompetitionService.Infra.Data.UnitOfWork;
using WebAPICompetitionService.Service.Interfaces;

namespace WebAPICompetitionService.Service.Services
{
    public class CompeticoesService : ICompeticoesService
    {
        private readonly ICompeticoesRepository _competicoesRepository;
        private readonly IUnitOfWork _uow;

        public CompeticoesService(ICompeticoesRepository competicoesRepository, IUnitOfWork uow)
        {
            _competicoesRepository = competicoesRepository;
            _uow = uow;
        }

        public async Task<IEnumerable<Competicoes>> GetAllCompeticoesAsync()
        {
            return await _competicoesRepository.GetAllCompeticoesAsync();
        }

        public async Task<Competicoes> GetCompeticaoByIdAsync(int id)
        {
            return await _competicoesRepository.GetCompeticaoByIdAsync(id);
        }

        public async Task PostCompeticoesAsync(Competicoes competicoes)
        {
            _competicoesRepository.PostCompeticoes(competicoes);
            await _uow.Commit();
        }

        public async Task UpdateCompeticaoAsync(Competicoes competicoes)
        {
            _competicoesRepository.UpdateCompeticao(competicoes);
            await _uow.Commit();
        }

        public async Task DeleteCompeticaoAsync(int id)
        {
            _competicoesRepository.DeleteCompeticao(id);
            await _uow.Commit();
        }
    }
}
