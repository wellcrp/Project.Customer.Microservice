using MediatR;

namespace Project.Customer.Application.Commands
{
    public class CreateCustomerCommand : IRequest<bool>
    {
        public string CustomerName { get; set; } = default!;
        public int CustomerAge { get; set; }
        public string? CustomerEmail { get; set; }
    }
}
