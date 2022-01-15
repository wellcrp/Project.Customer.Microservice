using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Application.Interfaces;
using RabbitMQ.Domain;
using System.Net;

namespace RabbitMQ.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomer _customer;

        public CustomerController(ICustomer customer)
        {
            _customer = customer;
        }

        [HttpPost("[action]")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PublishCustomer([FromBody] ICollection<CustomerPublish> customerPublish)
        {
            var result = await _customer.publish(customerPublish);

            return Accepted(result);
        }
    }
}
