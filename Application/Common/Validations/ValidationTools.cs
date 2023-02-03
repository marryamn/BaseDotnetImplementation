using FluentValidation.Results;

namespace Application.Common.Validations;

public static class ValidationTools
{
    public static bool Failed(this ValidationResult validationResult)
    {
        return !validationResult.IsValid;
    }
    
    public static IEnumerable<ValidationFailure> Messages(this ValidationResult validationResult)
    {
        return validationResult.Errors.Select(x => new ValidationFailure
        {
            PropertyName = x.PropertyName,
            ErrorMessage = x.ErrorMessage,
        }).ToList();
    }
}
