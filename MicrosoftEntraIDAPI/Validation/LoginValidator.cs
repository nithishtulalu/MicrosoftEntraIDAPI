using FluentValidation;
namespace MicrosoftEntraIDAPI.Validation
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}
