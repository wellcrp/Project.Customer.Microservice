namespace Project.Customer.Domain.Persistence.Interface
{
    public interface IPersistenceUnitOfWork : IDisposable
    {
        public ICustomerRepositoryAsync Customer { get; }
        Task<int> CommitAsync();
    }
}
