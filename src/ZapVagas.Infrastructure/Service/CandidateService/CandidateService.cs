using ZapVagas.Application.Dtos.Candidate.Request;
using ZapVagas.Application.Dtos.Candidate.Response;
using ZapVagas.Application.IUnitOfWork;
using ZapVagas.Application.Services;
using ZapVagas.Domain.Entities;

namespace ZapVagas.Infrastructure.Service.CandidateService
{
    public class CandidateService : ICandidateService
    {
        private IUnitOfWork _uow;
        private Candidate _candidate;

        public CandidateService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<CandidateResponseDto> CreateAsync(CandidateCreateDto dto)
        {
            var candidate = new Candidate(dto.name, dto.phone, dto.education);

            //foreach (var pref in dto.JobPreferences.Take(3))
            //    candidate.AddJobPreference(pref); verificar a lógica de inclusão de preferências
        
            await _uow.Candidates.AddAsync(candidate);
            await _uow.CommitAsync();

            return new CandidateResponseDto
            {
                Name = candidate.Name,
                Phone = candidate.Phone,
                Education = candidate.Education
            };
        }

        public async Task<CandidateResponseDto> GetByIdAsync(Guid id)
        {
            var candidate = await _uow.Candidates.GetByIdAsync(id);

            if (candidate is null) return null;

            return new CandidateResponseDto
            {
                Name = candidate.Name,
                Phone = candidate.Phone,
                Education = candidate.Education
            };
        }

        public async Task<CandidateResponseDto> Update(Guid id, CandidateUpdateDto dto)
        {
            var candidate = await _uow.Candidates.GetByIdAsync(id);

            if (candidate is null) return null;

            if (!string.IsNullOrWhiteSpace(dto.name))
                candidate.UpdateName(dto.name);

            if (!string.IsNullOrWhiteSpace(dto.phone))
                candidate.UpdatePhone(dto.phone);

            if (!string.IsNullOrWhiteSpace(dto.education))
                candidate.UpdateEducation(dto.education);

            _uow.CommitAsync();

            return new CandidateResponseDto
            {
                Name = candidate.Name,
                Phone = candidate.Phone,
                //JobPreferences = candidate.JobPreferences.Select(p => p.Name).ToList(),
                Education = candidate.Education
            };
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var candidate = await _uow.Candidates.GetByIdAsync(id);

            if (candidate is null) return false;

            _uow.Candidates.Delete(candidate);

            await _uow.CommitAsync();

            return true;
        }
    }
}
