using FluentValidation;
using MediatorExample.Features.Handlers;
using MediatorExample.Features.Validators;
using MediatorExample.Models.HelloPerson;
using MediatR;
using Moq;

namespace MediatorExample.Features.Tests.Handlers
{
    public class HelloPersonHandlerTests
    {
        private readonly Mock<IMediator> _mediator = new();
        private readonly HelloPersonHandler _handler;

        public HelloPersonHandlerTests()
        {
            _handler = new HelloPersonHandler(new HelloPersonRequestValidator());
        }

        public static IEnumerable<object[]> BadData()
        {
            return new List<object[]>
            {
                new object[] { new HelloPersonRequest { Name = string.Empty} },
                new object[] { new HelloPersonRequest { Name = " "} },
            };
        }

        [Theory]
        [MemberData(nameof(BadData))]
        public async Task WhenCalled_BadRequestData_ThrowsValidationException(HelloPersonRequest request)
        {
            await Assert.ThrowsAsync<ValidationException>(async () => await _handler.Handle(request, CancellationToken.None));
        }

        [Theory]
        [InlineData("Rob")]
        [InlineData("Albert")]
        [InlineData("Renan")]
        public async Task WhenCalled_GoodDataGiven_ReturnsExpectedResponse(string name)
        {
            var request = new HelloPersonRequest { Name = name};

            var response = await _handler.Handle(request, CancellationToken.None);

            Assert.True(response.Message.Equals($"Hello, {name}"));
        }
    }
}
