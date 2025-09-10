using ZapVagas.Application.Dtos.Candidate.Request;
using ZapVagas.Application.Dtos.Candidate.Response;

namespace ZapVagas.Application.Services
{
    public interface IJobPreferenceService
    {
        Task<JobPreferenceResponse> CreateAsync(Guid id, JobPreferenceRequest dto);
        Task<IEnumerable<JobPreferenceResponse>> GetPreferencesByCandidateIdAsync(Guid id);
        //Task<JobPreferenceResponse> GetByIdAsync(Guid id);
        //Task<JobPreferenceResponse> Update(Guid id, JobPreferenceUpdateRequest dto);
        //Task<bool> DeleteById(Guid id);
    }
}
