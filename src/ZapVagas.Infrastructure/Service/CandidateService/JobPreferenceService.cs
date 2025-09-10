using ZapVagas.Application.Dtos.Candidate.Request;
using ZapVagas.Application.Dtos.Candidate.Response;
using ZapVagas.Application.IUnitOfWork;
using ZapVagas.Application.Services;

namespace ZapVagas.Infrastructure.Service.CandidateService
{
    public class JobPreferenceService : IJobPreferenceService
    {
        private IUnitOfWork _uow;

        public JobPreferenceService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<JobPreferenceResponse> CreateAsync(Guid id, JobPreferenceRequest dto)
        {
            var candidate = await _uow.Candidates.GetCandidateByIdAsync(id);

            if (candidate is null) return null;

            candidate.AddJobPreference(dto.area, dto.location);

            await _uow.CommitAsync();

            return new JobPreferenceResponse
            {
                Area = dto.area
            };
        }

        public async Task<IEnumerable<JobPreferenceResponse>> GetPreferencesByCandidateIdAsync(Guid id)
        {
            var preferences = await _uow.JobPreferences.GetPreferencesByCandidateIdAsync(id);

            if(preferences is null)
                return Enumerable.Empty<JobPreferenceResponse>();

            return preferences
                .Select(jp =>  new JobPreferenceResponse
                {
                    Area = jp.Area,
                });
        }
    }
}
