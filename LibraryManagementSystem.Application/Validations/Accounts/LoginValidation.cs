using FluentValidation;
using LibraryManagementSystem.Shared.Models.Accounts;

namespace LibraryManagementSystem.Application.Validations.Accounts
{
    public class LoginValidation : AbstractValidator<LoginModel>
    {
        public LoginValidation()
        {
            RuleFor(x => x.Email).EmailAddress().NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
