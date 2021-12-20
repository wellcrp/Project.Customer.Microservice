using MediatR;
using Project.Customer.Domain.Response;

namespace Project.Customer.Application.Queries
{
    public class GetCustomerByIdQueryCommand : IRequest<CustomerResponse>
    {
        public GetCustomerByIdQueryCommand(int customerId)
        {
            CustomerId = customerId;
        }

        public int CustomerId { get; private set; }
        public string CustomerName { get; set; }
        public int CustomerAge { get; set; }
        public string? CustomerEmail { get; set; }
    }
}
