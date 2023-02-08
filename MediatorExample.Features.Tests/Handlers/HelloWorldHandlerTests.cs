using MediatorExample.Features.Handlers;
using MediatorExample.Models.HelloWorld;
using MediatR;
using Moq;

namespace MediatorExample.Features.Tests.Handlers
{
    public class HelloWorldHandlerTests
    {
        private readonly Mock<IMediator> _mediator = new();
        private readonly HelloWorldHandler _handler;

        public HelloWorldHandlerTests()
        {
            _handler = new HelloWorldHandler();
        }

        [Fact]
        public async Task WhenCalled_ValidResponseModel()
        {
            var request = new HelloWorldRequest();

            var response = await _handler.Handle(request, CancellationToken.None);

            Assert.Equal("Hello, World!", response.Message);
        }
    }
}
