using AwesomeSocialMedia.Users.Application.Commands.SignUpUser;
using AwesomeSocialMedia.Users.Application.Commands.UpdateUser;
using AwesomeSocialMedia.Users.Application.Queries.GetUserById;
using AwesomeSocialMedia.Users.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Prometheus;

namespace AwesomeSocialMedia.Users.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private static readonly Counter _userCreatedCounter = Metrics.CreateCounter("userscreated", "count of users created.");
        private static readonly Counter _userCreationFailedCounter = Metrics.CreateCounter("usersfailed", "count of users creation failures.");
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetUserByIdQuery(id);

            var result = await _mediator.Send(query);

            if (!result.Success && result.Data == null) {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SignUpUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.Success)
            {
                _userCreatedCounter.Inc();
            } else
            {
                _userCreationFailedCounter.Inc();
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        // api/users/123124 HTTP PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateUserCommand command)
        {
            command.Id = id;

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
