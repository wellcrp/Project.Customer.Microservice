using MediatR;
using Project.Customer.Domain.Response;

namespace Project.Customer.Application.Queries
{
    public class GetAllCustomerQueryCommand : IRequest<IEnumerable<CustomerResponse>>
    {  
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int CustomerAge { get; set; }
        public string? CustomerEmail { get; set; }
    }
}
