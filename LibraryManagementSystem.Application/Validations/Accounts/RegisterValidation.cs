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
                .Must(x => HasValidPassword(x))
                .NotEmpty();
            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage("Confirm Password should match password!")
                .NotEmpty();
        }

        private bool HasValidPassword(string pw)
        {
            var lowercase = new Regex("[a-z]+");
            var uppercase = new Regex("[A-Z]+");
            var digit = new Regex("(\\d)+");
            var symbol = new Regex("(\\W)+");

            return (lowercase.IsMatch(pw) && uppercase.IsMatch(pw) && digit.IsMatch(pw) && symbol.IsMatch(pw));
        }
    }
}
