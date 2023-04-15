using Application.Common.Validations;
using Infrastructure;

namespace Application.User.Auth.Login
{
    public class LoginCommandValidator : Validator<LoginCommand, AppDbContext>
    {
        public LoginCommandValidator(AppDbContext context = null) : base(context)
        {
        }
    }
}