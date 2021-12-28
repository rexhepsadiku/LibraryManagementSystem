using FluentValidation;
using LibraryManagementSystem.Shared.Models.Borrows;

namespace LibraryManagementSystem.Application.Validations.Borrows
{
    public class UpdateBorrowValidation : AbstractValidator<UpdateBorrowModel>
    {
        public UpdateBorrowValidation()
        {
            RuleFor(x => x.BookId).NotEmpty();
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.EndDate).NotEmpty();
        }
    }
}
