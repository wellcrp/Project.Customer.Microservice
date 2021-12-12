using AutoMapper;
using MediatR;
using Project.Customer.Application.Queries;
using Project.Customer.Domain.Persistence.Interface;
using Project.Customer.Domain.Response;

namespace Project.Customer.Application.Handlers.QueryHandler
{
    public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerQueryCommand, IEnumerable<CustomerResponse>>
    {
        private readonly IPersistenceUnitOfWork _customerUnitOfWork;
        private readonly IMapper _mapper;

        public GetAllCustomerHandler(IMapper mapper, IPersistenceUnitOfWork customerUnitOfWork)
        {
            _customerUnitOfWork = customerUnitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerResponse>> Handle(GetAllCustomerQueryCommand request, CancellationToken cancellationToken)
        {
            var result = await _customerUnitOfWork.Customer.GetAll();
            var mapper = _mapper.Map<IEnumerable<CustomerResponse>>(result);      

            return mapper;
        }
    }
}


