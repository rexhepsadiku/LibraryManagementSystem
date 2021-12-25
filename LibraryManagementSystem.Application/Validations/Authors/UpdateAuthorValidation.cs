using FluentValidation;
using LibraryManagementSystem.Shared.Models.Authors;

namespace LibraryManagementSystem.Application.Validations.Authors
{
    public class UpdateAuthorValidation : AbstractValidator<UpdateAuthorModel>
    {
        public UpdateAuthorValidation()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.BirthDate).NotEmpty();
        }
    }
}
