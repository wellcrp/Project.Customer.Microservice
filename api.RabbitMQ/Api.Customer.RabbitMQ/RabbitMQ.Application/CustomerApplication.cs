using MassTransit;
using RabbitMQ.Application.Interfaces;
using RabbitMQ.Domain;

namespace RabbitMQ.Application
{
    public class CustomerApplication : ICustomer
    {
        private readonly ICustomer _customer;
        private readonly IPublishEndpoint _publishEndpoint;

        public CustomerApplication(ICustomer customer, IPublishEndpoint publishEndpoint)
        {
            _customer = customer;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<bool> publish(ICollection<CustomerPublish> customerPublish)
        {
            await _publishEndpoint.Publish<CustomerPublish>(customerPublish);

            return true;
        }
    }
}
