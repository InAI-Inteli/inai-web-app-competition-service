using WebAPICompetitionService.Domain.Entities;
using WebAPICompetitionService.Domain.DTOs;
using WebAPICompetitionService.Domain.DTOs.ViewModels;

namespace WebAPICompetitionService.Service.Interfaces
{
    public interface ICompeticoesService
    {
        Task<IEnumerable<Competicoes>> GetAllCompeticoesAsync();
        Task<Competicoes> GetCompeticaoByIdAsync(int id);
        Task PostCompeticoesAsync(Competicoes competicoes);
        Task UpdateCompeticaoAsync(Competicoes competicoes);
        Task DeleteCompeticaoAsync(int id);
    }
}
