using MediatR;

namespace MediatorExample.Models.HelloWorld
{
    public record HelloWorldRequest : IRequest<HelloWorldResponse>
    {
    }
}
