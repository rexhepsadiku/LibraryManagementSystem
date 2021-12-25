﻿using FluentValidation;
using LibraryManagementSystem.Shared.Models.Books;

namespace LibraryManagementSystem.Application.Validations.Books
{
    public class UpdateBookValidation : AbstractValidator<UpdateBookModel>
    {
        public UpdateBookValidation()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.ISBN).NotEmpty();
            RuleFor(x => x.AuthorId).NotEmpty();
            RuleFor(x => x.Publisher).NotEmpty();
            RuleFor(x => x.Language).NotEmpty();
            RuleFor(x => x.PagesNumber).NotEmpty();
        }
    }
}
