using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleCRUD.Api.Handlers.Users;
using SimpleCRUD_NET_6.Api.Domains;
using SimpleCRUD_NET_6.Api.EFCoreInMemoryDbDemo;
using SimpleCRUD_NET_6.Api.Handlers.Users;

namespace SimpleCRUD_NET_6.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetUserRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);

        }

        [HttpPost("queryUsers")]
        public async Task<IActionResult> QueryUsers([FromBody] QueryUsersRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateUserRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok();

        }

        [HttpPost("deactivate")]
        public async Task<IActionResult> Delete([FromBody] DeactivateUserRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok();

        }

        [HttpPost("recover")]
        public async Task<IActionResult> Recover([FromBody] RecoverUserRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok();

        }
    }
}