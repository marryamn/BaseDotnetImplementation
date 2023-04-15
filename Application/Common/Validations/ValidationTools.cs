using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Common.Validations;

public static class ValidationTools
{
   
    public static bool Failed(this ValidationResult validationResult)
    {
        return !validationResult.IsValid;
    }
    public static ValidationResult FromFluentValidationResult(ValidationResult result)
    {
        return new ValidationResult(result.Errors);
    }
    public static IEnumerable<ValidationFailure> Messages(this ValidationResult validationResult)
    {
        return validationResult.Errors.Select(x => new ValidationFailure
        {
            PropertyName = x.PropertyName,
            ErrorMessage = x.ErrorMessage,
        }).ToList();
    }
    
    public static IRuleBuilderOptions<T, TProperty> WhenNotNull<T, TProperty>(
        this IRuleBuilderOptions<T, TProperty> rule)
    {
        return rule.Configure(config =>
            config.ApplyCondition(x => config.GetPropertyValue(x.InstanceToValidate) != null)
        );
    }
    
  
}
