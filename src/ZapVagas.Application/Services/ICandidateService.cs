using ZapVagas.Application.Dtos.Candidate.Request;
using ZapVagas.Application.Dtos.Candidate.Response;

namespace ZapVagas.Application.Services
{
    public interface ICandidateService
    {
        Task<IEnumerable<CandidateResponse>> GetAllAsync();
        Task<CandidateResponse> CreateAsync(CandidateCreateRequest dto);
        Task<CandidateResponse> GetByIdAsync(Guid id);
        Task<CandidateResponse> Update(Guid id, CandidateUpdateRequest dto);
        Task<bool> DeleteById(Guid id);
    }
}
