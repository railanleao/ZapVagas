using ZapVagas.Application.IRepository.Base;
using ZapVagas.Domain.Entities;

namespace ZapVagas.Application.IRepository
{
    public interface IJobPreferenceRepository : IRepositoryBase<JobPreference>
    {
        public Task<ICollection<JobPreference>> GetPreferencesByCandidateIdAsync(Guid candidateId);
    }
}
