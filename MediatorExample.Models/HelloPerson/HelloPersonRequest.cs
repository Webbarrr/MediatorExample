using MediatR;

namespace MediatorExample.Models.HelloPerson
{
    public record HelloPersonRequest : IRequest<HelloPersonResponse>
    {
        public string Name { get; init; } = string.Empty;
    }
}
