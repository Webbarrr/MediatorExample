using FluentValidation;
using MediatorExample.Models.HelloPerson;

namespace MediatorExample.Features.Validators
{
    public class HelloPersonRequestValidator : AbstractValidator<HelloPersonRequest>
    {
        public HelloPersonRequestValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}
