using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RabbitTest.Application.UseCases.LogNewMessage;

namespace RabbitTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HelloWorldController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(HelloWorldDto request)
        {
            var command = new LogNewMessageCommand()
            {
                message = request.Message
            };

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
