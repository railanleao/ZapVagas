using ZapVagas.Application.IRepository;

namespace ZapVagas.Application.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICandidateRepository Candidates { get; }

        Task<int> CommitAsync();
    }
}
