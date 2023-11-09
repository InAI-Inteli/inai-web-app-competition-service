using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPICompetitionService.Domain.Entities;

namespace WebAPICompetitionService.Infra.Data.Repository.Interfaces
{
    public interface ICompeticoesRepository
    {
        Task<IEnumerable<Competicoes>> GetAllCompeticoesAsync();
        Task<Competicoes> GetCompeticaoByIdAsync(int id);
        void PostCompeticoes(Competicoes competicoes);
        void UpdateCompeticao(Competicoes competicoes);
        void DeleteCompeticao(int id);
    }
}
