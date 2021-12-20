using AutoMapper;
using MediatR;
using Project.Customer.Application.Queries;
using Project.Customer.Domain.Persistence.Interface;
using Project.Customer.Domain.Response;

namespace Project.Customer.Application.Handlers.QueryHandler
{
    public class GetByIdCustomerHandler : IRequestHandler<GetCustomerByIdQueryCommand, CustomerResponse>
    {
        private readonly IPersistenceUnitOfWork _customerUnitOfWork;
        private readonly IMapper _mapper;

        public GetByIdCustomerHandler(IPersistenceUnitOfWork customerUnitOfWork, IMapper mapper)
        {
            _customerUnitOfWork = customerUnitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomerResponse> Handle(GetCustomerByIdQueryCommand request, CancellationToken cancellationToken)
        {
            var result = await _customerUnitOfWork.Customer.GetById(request.CustomerId);

            var mapper = _mapper.Map<CustomerResponse>(result);

            return mapper;
        }
    }
}
