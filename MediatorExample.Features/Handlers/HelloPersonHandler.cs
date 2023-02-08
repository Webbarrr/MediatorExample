using FluentValidation;
using MediatorExample.Models.HelloPerson;
using MediatR;

namespace MediatorExample.Features.Handlers
{
    public class HelloPersonHandler : IRequestHandler<HelloPersonRequest, HelloPersonResponse>
    {
        private readonly IValidator<HelloPersonRequest> _validator;

        public HelloPersonHandler(IValidator<HelloPersonRequest> validator)
        {
            _validator = validator;
        }

        public async Task<HelloPersonResponse> Handle(HelloPersonRequest request, CancellationToken cancellationToken)
        {
            // validate the request model (see Validators > HelloPersonRequestValidator)
            await _validator.ValidateAndThrowAsync(request, cancellationToken);

            return new HelloPersonResponse { Message = $"Hello, {request.Name}" };
        }
    }
}
