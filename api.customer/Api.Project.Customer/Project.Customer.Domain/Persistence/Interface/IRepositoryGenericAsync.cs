namespace Project.Customer.Domain.Persistence.Interface
{
    public interface IRepositoryGenericAsync<TEntity> where TEntity : BaseEntity
    {
        Task AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
    }
}
