using Microsoft.EntityFrameworkCore;
using ZapVagas.Application.IRepository.Base;
using ZapVagas.Infrastructure.DataContext;

namespace ZapVagas.Infrastructure.Repository.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly ZapVagasDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(ZapVagasDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
           await _dbSet.AddAsync(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var entity = GetByIdAsync(id);

            if (entity == null)
                throw new Exception("O registro não existe na base de dados!");
            Delete(await entity);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
