using FluentValidation;
using LibraryManagementSystem.Shared.Models.Authors;

namespace LibraryManagementSystem.Application.Validations.Authors
{
    public class CreateAuthorValidation : AbstractValidator<CreateAuthorModel>
    {
        public CreateAuthorValidation()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.BirthDate).NotEmpty();
            RuleFor(x => x.Country).NotEmpty();
        }
    }
}
