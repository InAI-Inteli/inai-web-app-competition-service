using WebAPICompetitionService.Infra.Data.Context;

namespace WebAPICompetitionService.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CompetitionContext _context;

        public UnitOfWork(CompetitionContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Rollback()
        {

        }
    }
}
