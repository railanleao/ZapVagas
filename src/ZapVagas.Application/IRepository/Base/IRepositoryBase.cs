namespace ZapVagas.Application.IRepository.Base
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        Task DeleteByIdAsync(Guid id);
        void Delete(TEntity entity);
    }
}
