using ZapVagas.Application.Dtos.JobPreference.Request;
using ZapVagas.Application.Dtos.JobPreference.Response;

namespace ZapVagas.Application.Services
{
    public interface IJobPreferenceService
    {
        Task<IEnumerable<JobPreferenceResponse>> GetAllAsync();
        Task<JobPreferenceResponse> CreateAsync(Guid id, JobPreferenceCreateRequest dto);
        Task<IEnumerable<JobPreferenceResponse>> GetPreferencesByCandidateIdAsync(Guid id);
        Task<JobPreferenceResponse> GetByIdAsync(Guid id);
        Task<JobPreferenceResponse> Update(Guid id, JobPreferenceUpdateRequest dto);
        Task<bool> DeleteById(Guid id);
    }
}
