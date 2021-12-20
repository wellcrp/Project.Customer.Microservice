using Project.Customer.Domain.Persistence.Interface;
using Project.Customer.Infra.Persistence.Context;

namespace Project.Customer.Infra.Persistence.Repositories.UnitOfWork
{
    public class PersistenceUnitOfWork : IPersistenceUnitOfWork
    {
        private readonly CustomerSqlContext _customerDbContext;
        public ICustomerRepositoryAsync Customer { get; }

        public PersistenceUnitOfWork(CustomerSqlContext customerDbContext, ICustomerRepositoryAsync customer)
        {
            _customerDbContext = customerDbContext;
            Customer = customer;
        }

        public async Task<int> CommitAsync()
        {
            return await _customerDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _customerDbContext.Dispose();
            GC.SuppressFinalize(this);
        }   
    }
}
