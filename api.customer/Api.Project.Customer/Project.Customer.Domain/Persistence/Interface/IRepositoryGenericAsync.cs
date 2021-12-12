namespace Project.Customer.Domain.Persistence.Interface
{
    public interface IRepositoryGenericAsync<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
    }
}
