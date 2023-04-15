using Application.Common.Response;
using MediatR;

namespace Application.User.Auth.Login
{
    public class LoginCommand : IRequest<StdResponse<LoginDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}