using Microsoft.EntityFrameworkCore;
using Project.Customer.Infrastructure.Entities;
using Project.Customer.Repository.Entities;

namespace Project.Customer.Infrastructure.Context
{
    public class CustomerSqlContext : DbContext
    {
        public CustomerSqlContext(DbContextOptions<CustomerSqlContext> opt) : base(opt) { }

        public DbSet<CustomerEntities> Customers { get; set; }
    }
}
