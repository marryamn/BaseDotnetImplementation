using Application.Common.Validations;
using FluentValidation;
using Infrastructure;

namespace Application.Admin.Auth.Commands.Login
{
    public class LoginCommandValidator : Validator<LoginCommand, AppDbContext>
    {
        public LoginCommandValidator(AppDbContext context = null) : base(context)
        {
            Phone();
            Password();
        }

        private void Phone()
        {
            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("ایمیل خالی است");
            RuleFor(x => x.Email)
                .EmailAddress()
                .WhenNotNull()
                .WithMessage("ایمیل معتبر نیست.");
        }

        private void Password()
        {
            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage("لطفا پسورد را وارد کنید.");
            RuleFor(x => x.Password)
                .MinimumLength(8)
                .WithMessage("رمز عبور باید از 8 کاراکتر بیشتر باشد.");
            RuleFor(x => x.Password)
                .MaximumLength(50)
                .WithMessage("پسورد طولانی است.");
        }
    }
}