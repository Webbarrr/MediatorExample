using MediatorExample.Models.HelloWorld;
using MediatR;

namespace MediatorExample.Features.Handlers
{
    public class HelloWorldHandler : IRequestHandler<HelloWorldRequest, HelloWorldResponse>
    {
        public Task<HelloWorldResponse> Handle(HelloWorldRequest request, CancellationToken cancellationToken) 
            => Task.FromResult(new HelloWorldResponse { Message = "Hello, World!" });
    }
}
