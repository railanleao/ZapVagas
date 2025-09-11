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

        public CandidateService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<IEnumerable<CandidateResponse>> GetAllAsync()
        {
            var candidates = await _uow.Candidates.GetAllAsync();

            if (candidates is null) return Enumerable.Empty<CandidateResponse>();

            return candidates.Select(candidate => new CandidateResponse
            {
                Name = candidate.Name,
                Phone = candidate.Phone,
                Education = candidate.Education
            });
        }

        public async Task<CandidateResponse> CreateAsync(CandidateCreateRequest dto)
        {
            var candidate = new Candidate(dto.name, dto.phone, dto.education);

            //foreach (var pref in dto.preference.Take(3))
            //    candidate.AddJobPreference(pref.area, pref.location); 

            await _uow.Candidates.AddAsync(candidate);
            await _uow.CommitAsync();

            return new CandidateResponse
            {
                Name = candidate.Name,
                Phone = candidate.Phone,
                Education = candidate.Education
            };
        }

        public async Task<CandidateResponse> GetByIdAsync(Guid id)
        {
            var candidate = await _uow.Candidates.GetByIdAsync(id);

            if (candidate is null) return null;

            return new CandidateResponse
            {
                Name = candidate.Name,
                Phone = candidate.Phone,
                Education = candidate.Education
            };
        }

        public async Task<CandidateResponse> Update(Guid id, CandidateUpdateRequest dto)
        {
            var candidate = await _uow.Candidates.GetByIdAsync(id);

            if (candidate is null) return null;

            candidate.UpdateName(dto.name);
            candidate.UpdatePhone(dto.phone);
            candidate.UpdateEducation(dto.education);

            //for (int i = 0; i < candidate.JobPreferences.Count; i++)
            //{
            //    var prefs = candidate.JobPreferences.ToList();

            //    var currentPref = prefs[i];
            //    var dtoPref = dto.preference.ElementAtOrDefault(i);

            //    if (dtoPref is not null)
            //        candidate.UpdateJobPreference(currentPref.PreferenceId, dtoPref.area, dtoPref.location);
            //}

            await _uow.CommitAsync();

            return new CandidateResponse
            {
                Name = candidate.Name,
                Phone = candidate.Phone,
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
