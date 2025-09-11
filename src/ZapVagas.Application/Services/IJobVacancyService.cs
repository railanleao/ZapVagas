using ZapVagas.Application.Dtos.JobVacancy.Request;
using ZapVagas.Application.Dtos.JobVacancy.Response;

namespace ZapVagas.Application.Services
{
    public interface IJobVacancyService
    {
        public Task<IEnumerable<JobVacancyResponse>> GetAllAsync();
        public Task<JobVacancyResponse> CreateAsync(JobVacancyCreateRequest request);
        public Task<JobVacancyResponse> GetByIdAsync(Guid id);
        public Task<JobVacancyResponse> Update(Guid id, JobVacancyUpdateRequest dto);
        public Task<bool> DeleteById(Guid id);
    }
}
