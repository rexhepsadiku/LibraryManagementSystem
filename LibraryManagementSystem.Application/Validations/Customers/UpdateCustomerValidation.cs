using FluentValidation;
using LibraryManagementSystem.Shared.Models.Customers;

namespace LibraryManagementSystem.Application.Validations.Customers
{
    public class UpdateCustomerValidation : AbstractValidator<UpdateCustomerModel>
    {
        public UpdateCustomerValidation()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
        }
    }
}
