using ZapVagas.Application.Dtos.Candidate.Request;
using ZapVagas.Application.Dtos.Candidate.Response;
using ZapVagas.Application.IUnitOfWork;
using ZapVagas.Application.Services;

namespace ZapVagas.Infrastructure.Service.CandidateService
{
    public class CandidateService : ICandidateService
    {
        private IUnitOfWork _uow;

        public CandidateService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public Task<CandidateResponseDto> CreateAsync(CandidateCreateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<CandidateResponseDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CandidateResponseDto> Update(Guid id, CandidateUpdateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<CandidateResponseDto> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
