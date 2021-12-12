using Project.Customer.Domain.Entities;
using Project.Customer.Domain.Persistence.Interface;
using Project.Customer.Infra.Persistence.Context;
using Project.Customer.Infra.Repository.Repositories.Repository;

namespace Project.Customer.Infra.Repository.Repositories.Query.Repositories
{
    public class CustomerRepositoryAsync : RepositoryGenericAsync<CustomerEntities>, ICustomerRepositoryAsync
    {
        private readonly CustomerSqlContext _customerContext;
        public CustomerRepositoryAsync(CustomerSqlContext customerContext) : base(customerContext)
        {
            _customerContext = customerContext;
        }

        //public override string GetStringTeste()
        //{
        //    return "Wellington Override";
        //}
    }
}
