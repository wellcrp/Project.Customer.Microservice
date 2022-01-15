using RabbitMQ.Domain;

namespace RabbitMQ.Application.Interfaces
{
    public interface ICustomer
    {
        Task<bool> publish(ICollection<CustomerPublish> customerPublish);
    }
}
