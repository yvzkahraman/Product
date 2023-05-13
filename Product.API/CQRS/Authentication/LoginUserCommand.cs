using MediatR;

namespace Product.API.CQRS.Authentication
{
    public class LoginUserCommand : IRequest<LoginUserResult>
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
