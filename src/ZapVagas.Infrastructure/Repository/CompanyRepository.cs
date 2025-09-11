using Microsoft.EntityFrameworkCore;
using ZapVagas.Application.IRepository;
using ZapVagas.Domain.Entities;
using ZapVagas.Infrastructure.DataContext;
using ZapVagas.Infrastructure.Repository.Base;

namespace ZapVagas.Infrastructure.Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(ZapVagasDbContext context) : base(context)
        {
        }
    }
}
