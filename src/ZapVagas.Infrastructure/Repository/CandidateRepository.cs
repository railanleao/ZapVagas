using ZapVagas.Application.IRepository;
using ZapVagas.Domain.Entities;
using ZapVagas.Infrastructure.DataContext;
using ZapVagas.Infrastructure.Repository.Base;

namespace ZapVagas.Infrastructure.Repository
{
    internal class CandidateRepository : RepositoryBase<Candidate>, ICandidateRepository
    {
        public CandidateRepository(ZapVagasDbContext context) : base(context)
        {
        }
    }
}
