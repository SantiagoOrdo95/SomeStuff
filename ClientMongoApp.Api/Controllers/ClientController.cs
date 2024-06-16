using ClientMongoApp.Application.Client.Commands;
using ClientMongoApp.Application.Client.Responses;
using ClientMongoApp.Application.Common.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClientMongoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ClientController : ControllerBase
    {
        public readonly IMediator _mediator;

        /// <summary>
        /// Controller that manage the clients on the platform
        /// </summary>
        /// <param name="mediator"></param>
        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<Response<ClientResponse>> Get()
        //{
        //    return await _mediator.Send(new )
        //}

        /// <summary>
        /// Api for creating clients
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Response<ClientResponse>>> Post([FromBody] CreateClientCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
