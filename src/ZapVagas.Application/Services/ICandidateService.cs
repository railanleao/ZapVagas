using ZapVagas.Application.Dtos.Candidate.Request;
using ZapVagas.Application.Dtos.Candidate.Response;

namespace ZapVagas.Application.Services
{
    public interface ICandidateService
    {
        Task<CandidateResponseDto> CreateAsync(CandidateCreateDto dto);
        Task<CandidateResponseDto> GetByIdAsync(Guid id);
        Task<CandidateResponseDto> Update(Guid id, CandidateUpdateDto dto);
        Task<CandidateResponseDto> Delete(Guid id);
    }
}
