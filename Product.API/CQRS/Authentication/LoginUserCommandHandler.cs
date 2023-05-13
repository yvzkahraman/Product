using MediatR;
using Microsoft.EntityFrameworkCore;
using Product.API.Data;

namespace Product.API.CQRS.Authentication
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand,LoginUserResult>
    {
        private readonly ProductDbContext context;

        public LoginUserCommandHandler(ProductDbContext context)
        {
            this.context = context;
        }

        public async Task<LoginUserResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var response = new LoginUserResult();

            var user = await this.context.Users.AsNoTracking().SingleOrDefaultAsync(x => x.Username == request.Username && x.Password == request.Password);
            if(user == null)
            {
                response.IsExist = false;
            }
            else
            {
                response.Username = user.Username;
                response.Id = user.Id;
                response.IsExist = true;
            }

            return response;
        }
    }
}
