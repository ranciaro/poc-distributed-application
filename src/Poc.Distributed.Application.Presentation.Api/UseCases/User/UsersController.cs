using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poc.Distributed.Application.Business.Application;
using System.Net;
using System.Threading.Tasks;

namespace Poc.Distributed.Application.Presentation.Api.UseCases.User
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string nome, string email)
        {
            var userRequest = new InsertUserCommandRequest(nome, email);
            await _mediator.Send(userRequest);
            return new OkResult();
            
        }
    }
}
