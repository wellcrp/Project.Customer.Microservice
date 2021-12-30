using AutoMapper;
using MediatR;
using Project.Customer.Application.Commands;
using Project.Customer.Domain.Entities;
using Project.Customer.Domain.Persistence.Interface;

namespace Project.Customer.Application.Handlers.CommandHandler
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, bool>
    {
        private readonly IPersistenceUnitOfWork _customerUnitOfWork;
        private readonly IMapper _mapper;

        public CreateCustomerHandler(IPersistenceUnitOfWork customerUnitOfWork, IMapper mapper)
        {
            _customerUnitOfWork = customerUnitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var mapper = _mapper.Map<CustomerEntities>(request);
            await _customerUnitOfWork.Customer.AddAsync(mapper);

            return true;
        }
    }
}
