using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ZapVagas.Application.IRepository;
using ZapVagas.Domain.Entities;
using ZapVagas.Infrastructure.DataContext;
using ZapVagas.Infrastructure.Repository.Base;

namespace ZapVagas.Infrastructure.Repository
{
    public class JobPreferenceRepository : RepositoryBase<JobPreference>, IJobPreferenceRepository
    {
        public JobPreferenceRepository(ZapVagasDbContext context) : base(context) { }

        public async Task<ICollection<JobPreference>> GetPreferencesByCandidateIdAsync(Guid candidateId)
        {
            return  _context.JobPreferences
                .Include(jp => jp.Candidate)
                .Where(jp => jp.CandidateId == candidateId)
                .AsNoTracking()
                .ToList();
                
        }
    }
}
