using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Customer.Application.Commands;
using Project.Customer.Application.Queries;

namespace Project.Customer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostInsertCustomer([FromBody]CreateCustomerCommand customerCommand)
        {
            var result = await _mediator.Send(customerCommand);

            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllCustomerQueryCommand());

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var result = await _mediator.Send(new GetCustomerByIdQueryCommand(id));

            return Ok(result);
        }
    }
}
