using MediatR;
using Microsoft.AspNetCore.Mvc;
using R.Application.Commands;
using R.Application.Queries;
using R.Application.Responses;
using R.Core.Entities;

namespace R.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<Person>> Get()
        {
            return await _mediator.Send(new GetPersonsQuery());
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PersonResponse>> CreateEmployee([FromBody] CreatePersonCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
