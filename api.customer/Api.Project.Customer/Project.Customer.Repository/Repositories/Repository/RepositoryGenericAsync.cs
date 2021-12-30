using Microsoft.EntityFrameworkCore;
using Project.Customer.Domain;
using Project.Customer.Domain.Persistence.Interface;
using Project.Customer.Infra.Persistence.Context;

namespace Project.Customer.Infra.Repository.Repositories.Repository
{
    public class RepositoryGenericAsync<TEntity> : IRepositoryGenericAsync<TEntity> where TEntity : BaseEntity
    {
        private readonly CustomerSqlContext _customerContext;
        public RepositoryGenericAsync(CustomerSqlContext customerContext)
        {
            _customerContext = customerContext;
        }
        public async Task<IEnumerable<TEntity>> GetAll() => await _customerContext.Set<TEntity>().ToListAsync();
        public async Task<TEntity> GetById(int id) => await _customerContext.Set<TEntity>().FindAsync(id);
        public async Task AddAsync(TEntity entity)
        {
            await _customerContext.Set<TEntity>().AddAsync(entity);
            await _customerContext.SaveChangesAsync();            
        }

        public void Dispose() => _customerContext.Dispose();
    }
}
