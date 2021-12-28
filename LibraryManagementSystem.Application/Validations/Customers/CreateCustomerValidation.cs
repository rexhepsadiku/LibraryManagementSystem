using FluentValidation;
using LibraryManagementSystem.Shared.Models.Customers;

namespace LibraryManagementSystem.Application.Validations.Customers
{
    public class CreateCustomerValidation : AbstractValidator<CreateCustomerModel>
    {
        public CreateCustomerValidation()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.Email).EmailAddress().NotEmpty();
        }
    }
}
