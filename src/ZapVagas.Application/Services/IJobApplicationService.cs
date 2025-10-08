using ZapVagas.Application.Dtos.JobApplication.Request;
using ZapVagas.Application.Dtos.JobApplication.Response;

namespace ZapVagas.Application.Services
{
    public interface IJobApplicationService
    {
        public Task<JobApplicationResponse> CreateAsync(JobApplicationCreateRequest jobApplication);
        public Task<JobApplicationResponse> GetByIdAsync(Guid id);
        public Task<IEnumerable<JobApplicationResponse>> GetAllAsync();
        public Task<JobApplicationResponse> UpdateAsync(Guid id, JobApplicationCreateRequest jobApplication);
        public Task<bool> DeleteByIdAsync(Guid id);
    }
}
