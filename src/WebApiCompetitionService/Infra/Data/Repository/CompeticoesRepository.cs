using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPICompetitionService.Domain.Entities;
using WebAPICompetitionService.Infra.Data.Context;
using WebAPICompetitionService.Infra.Data.Repository.Interfaces;

namespace WebAPICompetitionService.Infra.Data.Repository
{
    public class CompeticoesRepository : ICompeticoesRepository
    {
        private readonly CompetitionContext _context;

        public CompeticoesRepository(CompetitionContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Competicoes>> GetAllCompeticoesAsync()
        {
            return await _context.Competicoes.ToListAsync();
        }

        public async Task<Competicoes> GetCompeticaoByIdAsync(int id)
        {
            return await _context.Competicoes.FindAsync(id);
        }

        public void PostCompeticoes(Competicoes competicoes)
        {
            competicoes.CreatedAt = DateTime.Now;
            competicoes.UpdateAt = DateTime.Now;
            _context.Competicoes.Add(competicoes);
        }

        public void UpdateCompeticao(Competicoes competicoes)
        {
            competicoes.UpdateAt = DateTime.Now;
            _context.Entry(competicoes).State = EntityState.Modified;
        }

        public void DeleteCompeticao(int id)
        {
            Competicoes competicao = _context.Competicoes.Find(id);
            _context.Competicoes.Remove(competicao);
        }
    }
}
