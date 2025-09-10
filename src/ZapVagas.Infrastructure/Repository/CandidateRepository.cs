using Microsoft.EntityFrameworkCore;
using ZapVagas.Application.IRepository;
using ZapVagas.Domain.Entities;
using ZapVagas.Infrastructure.DataContext;
using ZapVagas.Infrastructure.Repository.Base;

namespace ZapVagas.Infrastructure.Repository
{
    public class CandidateRepository : RepositoryBase<Candidate>, ICandidateRepository
    {
        public CandidateRepository(ZapVagasDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<Candidate>> GetAllCandidatesWithPreferencesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Candidate> GetCandidateByIdAsync(Guid id)
        {
            return await _context.Candidates
                           .Include(c => c.JobPreferences)
                           .FirstOrDefaultAsync(c => c.CandidateId == id);
        }

        public Task<Candidate> GetCandidateWithPreferencesAsync(Guid candidateId)
        {
            throw new NotImplementedException();
        }
    }
}
