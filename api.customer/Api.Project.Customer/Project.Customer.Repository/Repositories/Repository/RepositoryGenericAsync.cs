using Microsoft.EntityFrameworkCore;
using Project.Customer.Domain.Persistence.Interface;
using Project.Customer.Infra.Persistence.Context;

namespace Project.Customer.Infra.Repository.Repositories.Repository
{
    public class RepositoryGenericAsync<TEntity> : IRepositoryGenericAsync<TEntity> where TEntity : class
    {
        private readonly CustomerSqlContext _customerContext;
        public RepositoryGenericAsync(CustomerSqlContext customerContext)
        {
            _customerContext = customerContext;
        }
        public async Task<IEnumerable<TEntity>> GetAll() => await _customerContext.Set<TEntity>().ToListAsync();
        public async Task<TEntity> GetById(int id) => await _customerContext.Set<TEntity>().FindAsync(id);
        public void Dispose() => _customerContext.Dispose();
    }
}
