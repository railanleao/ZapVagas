using ZapVagas.Application.IRepository;
using ZapVagas.Domain.Entities;
using ZapVagas.Infrastructure.DataContext;
using ZapVagas.Infrastructure.Repository.Base;

namespace ZapVagas.Infrastructure.Repository
{
    public class JobVacancyRepository : RepositoryBase<JobVacancy>, IJobVacancyRepository
    {
        public JobVacancyRepository(ZapVagasDbContext context) : base(context)
        {
        }
    }
}
