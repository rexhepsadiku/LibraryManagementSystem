using FluentValidation;
using LibraryManagementSystem.Shared.Models.Accounts;
using System.Text.RegularExpressions;

namespace LibraryManagementSystem.Application.Validations.Accounts
{
    public class RegisterValidation : AbstractValidator<RegisterModel>
    {
        public RegisterValidation()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).EmailAddress().NotEmpty();
            RuleFor(x => x.Password)
                .MinimumLength(6)
                .NotEmpty();
            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage("Confirm Password should match password!")
                .NotEmpty();
        }
    }
}
