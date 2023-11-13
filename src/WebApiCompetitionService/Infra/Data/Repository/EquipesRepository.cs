using Microsoft.EntityFrameworkCore;
using WebAPICompetitionService.Domain.Entities;
using WebAPICompetitionService.Infra.Data.Context;
using WebAPICompetitionService.Infra.Data.Repository.Interfaces;

namespace WebAPICompetitionService.Infra.Data.Repository
{
    public class EquipesRepository : IEquipesRepository
    {
        private readonly CompetitionContext _context;

        public EquipesRepository(CompetitionContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Equipes>> GetAllEquipesAsync()
        {
            return await _context.Equipes.ToListAsync();
        }

        public async Task<Equipes> GetEquipeByIdAsync(int id)
        {
            return await _context.Equipes.FindAsync(id);
        }

        public void PostEquipes(Equipes equipe)
        {
            equipe.CreatedAt = DateTime.Now;
            equipe.UpdatedAt = DateTime.Now;
            _context.Equipes.Add(equipe);
        }

        public void UpdateEquipe(Equipes equipe)
        {
            equipe.UpdatedAt = DateTime.Now;
            _context.Entry(equipe).State = EntityState.Modified;
        }

        public void DeleteEquipe(int id)
        {
            Equipes equipe = _context.Equipes.Find(id);
            _context.Equipes.Remove(equipe);
        }
    }
}
