using ZapVagas.Application.Dtos.JobPreference.Request;
using ZapVagas.Application.Dtos.JobPreference.Response;
using ZapVagas.Application.IUnitOfWork;
using ZapVagas.Application.Services;

namespace ZapVagas.Infrastructure.Service.JobPreferenceSerive
{
    public class JobPreferenceService : IJobPreferenceService
    {
        private IUnitOfWork _uow;

        public JobPreferenceService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<JobPreferenceResponse> CreateAsync(Guid id, JobPreferenceCreateRequest dto)
        {
            var candidate = await _uow.Candidates.GetByIdAsync(id);

            if (candidate is null) return null;

            candidate.AddJobPreference(dto.area, dto.location);

            await _uow.CommitAsync();

            return new JobPreferenceResponse
            {
                Area = dto.area
            };
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var preference = await _uow.JobPreferences.GetByIdAsync(id);

                if (preference is null)
                    return false;

            _uow.JobPreferences.Delete(preference);

            await _uow.CommitAsync();

            return true;
        }

        public async Task<IEnumerable<JobPreferenceResponse>> GetAllAsync()
        {
            var preferences = await _uow.JobPreferences.GetAllAsync();

            if (preferences is null)
                return Enumerable.Empty<JobPreferenceResponse>();

            return preferences.Select(preference => new JobPreferenceResponse
                {
                    Area = preference.Area,
                    Location = preference.Location,
                });
        }

        public async Task<JobPreferenceResponse> GetByIdAsync(Guid id)
        {
            var preference = await _uow.JobPreferences.GetByIdAsync(id);

            if (preference is null)
                return null;

            return new JobPreferenceResponse
            {
                Area = preference.Area,
                Location = preference.Location,
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

        public async Task<JobPreferenceResponse> Update(Guid id, JobPreferenceUpdateRequest dto)
        {
            var preference = await _uow.JobPreferences.GetByIdAsync(id);

            if (preference is null) return null;

            preference.UpdateLocation(dto.location);
            preference.UpdateArea(dto.area);

            await _uow.CommitAsync();

            return new JobPreferenceResponse
            {
                Area = preference.Area,
                Location = preference.Location,
            };
        }
    }
}
