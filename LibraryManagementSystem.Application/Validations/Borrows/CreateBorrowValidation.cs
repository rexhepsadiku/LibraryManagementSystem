using FluentValidation;
using LibraryManagementSystem.Shared.Models.Borrows;

namespace LibraryManagementSystem.Application.Validations.Borrows
{
    public class CreateBorrowValidation : AbstractValidator<CreateBorrowModel>
    {
        public CreateBorrowValidation()
        {
            RuleFor(x => x.BookId).NotEmpty();
            RuleFor(x => x.CustomerId).NotEmpty();
        }
    }
}
