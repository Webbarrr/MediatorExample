using MediatorExample.Models.HelloPerson;
using MediatorExample.Models.HelloWorld;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExampleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("hello-world")]
        [ProducesResponseType(typeof(HelloWorldResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> HelloWorld(CancellationToken cancellationToken) => 
            Ok(await _mediator.Send(new HelloWorldRequest(), cancellationToken));

        [HttpPost("hello-person")]
        [ProducesResponseType(typeof(HelloPersonResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> HelloPerson(HelloPersonRequest request, CancellationToken cancellationToken) =>
            Ok(await _mediator.Send(request, cancellationToken));
    }
}
