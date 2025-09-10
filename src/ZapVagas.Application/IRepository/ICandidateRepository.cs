using ZapVagas.Application.IRepository.Base;
using ZapVagas.Domain.Entities;

namespace ZapVagas.Application.IRepository
{
    public interface ICandidateRepository : IRepositoryBase<Candidate>
    {
        public Task<Candidate> GetCandidateWithPreferencesAsync(Guid candidateId);
        public Task<IEnumerable<Candidate>> GetAllCandidatesWithPreferencesAsync();
        public Task<Candidate> GetCandidateByIdAsync(Guid id);
    }
}
