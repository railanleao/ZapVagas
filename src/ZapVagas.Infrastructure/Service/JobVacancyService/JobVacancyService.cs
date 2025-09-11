using ZapVagas.Application.Dtos.JobVacancy.Request;
using ZapVagas.Application.Dtos.JobVacancy.Response;
using ZapVagas.Application.IUnitOfWork;
using ZapVagas.Application.Services;
using ZapVagas.Domain.Entities;

namespace ZapVagas.Infrastructure.Service.JobVacancyService
{
    public class JobVacancyService : IJobVacancyService
    {
        private readonly IUnitOfWork _uow;
        public JobVacancyService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<IEnumerable<JobVacancyResponse>> GetAllAsync()
        {
            var vacancies = await _uow.JobVacancies.GetAllAsync();

            if (vacancies is null) return Enumerable.Empty<JobVacancyResponse>();

            return vacancies.Select(vacancy => new JobVacancyResponse
            {
                Title = vacancy.Title,
                Requirement = vacancy.Requirement,
                EducationLevel = vacancy.EducationLevel,
                OpenPosition = vacancy.OpenPosition,
                Status = vacancy.Status
            });
        }
        public async Task<JobVacancyResponse> CreateAsync(JobVacancyCreateRequest request)
        {
            var vacancy = new JobVacancy(Guid.NewGuid(), request.title, request.requirement, request.educationLevel, request.openPosition);
           
            await _uow.JobVacancies.AddAsync(vacancy);
            await _uow.CommitAsync();

            return new JobVacancyResponse
            {
                Title = vacancy.Title,
                Requirement = vacancy.Requirement,
                EducationLevel = vacancy.EducationLevel,
                OpenPosition = vacancy.OpenPosition,
                Status = vacancy.Status
            };
        }
        public async Task<bool> DeleteById(Guid id)
        {
            var vacancy = await _uow.JobVacancies.GetByIdAsync(id);

            if (vacancy is null) return false;
            
            _uow.JobVacancies.Delete(vacancy);
            await _uow.CommitAsync();
            
            return true;
        }
        public async Task<JobVacancyResponse> GetByIdAsync(Guid id)
        {
            var vacancy = await _uow.JobVacancies.GetByIdAsync(id);
            
            if (vacancy is null) return null;

            return new JobVacancyResponse
            {
                Title = vacancy.Title,
                Requirement = vacancy.Requirement,
                EducationLevel = vacancy.EducationLevel,
                OpenPosition = vacancy.OpenPosition,
                Status = vacancy.Status
            };
        }

        public Task<JobVacancyResponse> Update(Guid id, JobVacancyUpdateRequest dto)
        {
            throw new NotImplementedException();
        }
    }
}
