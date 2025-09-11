using ZapVagas.Application.IRepository.Base;
using ZapVagas.Domain.Entities;

namespace ZapVagas.Application.IRepository
{
    public interface ICandidateRepository : IRepositoryBase<Candidate>
    {
        public Task<IEnumerable<Candidate>> GetAllCandidatesWithPreferencesAsync();
    }
}
