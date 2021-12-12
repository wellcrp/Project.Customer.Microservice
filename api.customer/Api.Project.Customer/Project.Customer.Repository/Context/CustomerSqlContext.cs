using Microsoft.EntityFrameworkCore;
using Project.Customer.Domain.Entities;

namespace Project.Customer.Infra.Persistence.Context
{
    public class CustomerSqlContext : DbContext
    {
        public CustomerSqlContext(DbContextOptions<CustomerSqlContext> opt) : base(opt) { }

        public DbSet<CustomerEntities> Customers { get; set; }
    }
}
