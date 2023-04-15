using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Validations
{
    public abstract class Validator<T, TC> : AbstractValidator<T> where TC : DbContext
    {
        public static string Default = "درخواست معتبر نیست.";

        protected Validator(TC context = null)
        {
            Context = context;
        }

        protected TC Context { get; set; }

        public ValidationResult StdValidate(ValidationContext<T> context)
        {
            return Validate(context);
        }

        public Task<ValidationResult> StdValidateAsync(ValidationContext<T> context,
            CancellationToken cancellation = default)
        {
            return ValidateAsync(context, cancellation)
                .ContinueWith(
                    x => x.Result, cancellation
                );
        }


        public ValidationResult StdValidate(T instance)
        {
            return ValidationTools.FromFluentValidationResult(Validate(instance));
        }

        public Task<ValidationResult> StdValidateAsync(T instance, CancellationToken cancellation = default)
        {
            return ValidateAsync(instance, cancellation)
                .ContinueWith(x => {
                    return ValidationTools.FromFluentValidationResult(x.Result);
                },cancellation);
        }
    }
}