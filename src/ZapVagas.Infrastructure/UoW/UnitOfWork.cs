using ZapVagas.Application.IRepository;
using ZapVagas.Application.IUnitOfWork;
using ZapVagas.Infrastructure.DataContext;

namespace ZapVagas.Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ZapVagasDbContext _context;
        public ICandidateRepository Candidates { get; }
        public IJobPreferenceRepository JobPreferences { get; }
        public ICompanyRepository Companies { get; }
        public IJobVacancyRepository JobVacancies { get; }
        //public IApplicationRepository Applications { get; }

        public UnitOfWork(ZapVagasDbContext context,
                          ICandidateRepository candidateRepository,
                          IJobPreferenceRepository jobPreferenceRepository,
                          ICompanyRepository companyRepository,
                          IJobVacancyRepository jobVacancyRepository
                          //IApplicationRepository applicationRepository
                          )
        {
            _context = context;

            Candidates = candidateRepository;
            JobPreferences = jobPreferenceRepository;
            Companies = companyRepository;
            JobVacancies = jobVacancyRepository;
            //Applications = applicationRepository;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
