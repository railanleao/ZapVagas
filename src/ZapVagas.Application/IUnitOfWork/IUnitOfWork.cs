using ZapVagas.Application.IRepository;

namespace ZapVagas.Application.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICandidateRepository Candidates { get; }
        IJobPreferenceRepository JobPreferences { get; }
        ICompanyRepository Companies { get; }
        IJobVacancyRepository JobVacancies { get; }

        Task<int> CommitAsync();
    }
}
