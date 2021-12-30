using Microsoft.EntityFrameworkCore;
using Project.Customer.Domain;
using Project.Customer.Domain.Entities;

namespace Project.Customer.Infra.Persistence.Context
{
    public class CustomerSqlContext : DbContext
    {
        public CustomerSqlContext(DbContextOptions<CustomerSqlContext> opt) : base(opt) { }

        public DbSet<CustomerEntities> Customers { get; set; }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added when entry.Entity is BaseEntity:
                        entry.Property(nameof(BaseEntity.CreatedDate)).CurrentValue = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
