using FluentValidation;

namespace MicrosoftEntraIDAPI.Validation
{
    public class RegisterValidator: AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty();
            RuleFor(x => x.LastName)
                .NotEmpty();
            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty();
            RuleFor(x => x.Password)
                .MinimumLength(6)
                .NotEmpty();
            RuleFor(x => x.PhoneNumber)
                .NotEmpty();
        }
    }
}
