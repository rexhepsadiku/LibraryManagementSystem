using FluentValidation.TestHelper;
using LibraryManagementSystem.Application.Validations.Books;
using LibraryManagementSystem.Shared.Models.Books;
using Xunit;

namespace LibraryManagementSystem.Tests.Validations.Books
{
    public class UpdateBookValidationTest
    {
        private readonly UpdateBookValidation _validation;
        public UpdateBookValidationTest()
        {
            _validation = new UpdateBookValidation();
        }

        [Fact]
        public void Title_Input_Null()
        {
            var bookModel = new UpdateBookModel { Title = "" };
            _validation.TestValidate(bookModel).ShouldHaveValidationErrorFor(x => x.Title);
        }

        [Fact]
        public void Title_Input_Value()
        {
            var bookModel = new UpdateBookModel { Title = "test" };
            _validation.TestValidate(bookModel).ShouldNotHaveValidationErrorFor(x => x.Title);
        }

        [Fact]
        public void Description_Input_Null()
        {
            var bookModel = new UpdateBookModel { Description = "" };
            _validation.TestValidate(bookModel).ShouldHaveValidationErrorFor(x => x.Description);
        }

        [Fact]
        public void Description_Input_Value()
        {
            var bookModel = new UpdateBookModel { Description = "test" };
            _validation.TestValidate(bookModel).ShouldNotHaveValidationErrorFor(x => x.Description);
        }

        [Fact]
        public void ISBN_Input_Null()
        {
            var bookModel = new UpdateBookModel { ISBN = "" };
            _validation.TestValidate(bookModel).ShouldHaveValidationErrorFor(x => x.ISBN);
        }

        [Fact]
        public void ISBN_Input_Value()
        {
            var bookModel = new UpdateBookModel { ISBN = "test" };
            _validation.TestValidate(bookModel).ShouldNotHaveValidationErrorFor(x => x.ISBN);
        }

        [Fact]
        public void AuthorId_Input_Null()
        {
            var bookModel = new UpdateBookModel { AuthorId = 0 };
            _validation.TestValidate(bookModel).ShouldHaveValidationErrorFor(x => x.AuthorId);
        }

        [Fact]
        public void AuthorId_Input_Value()
        {
            var bookModel = new UpdateBookModel { AuthorId = 2 };
            _validation.TestValidate(bookModel).ShouldNotHaveValidationErrorFor(x => x.AuthorId);
        }

        [Fact]
        public void Publisher_Input_Null()
        {
            var bookModel = new UpdateBookModel { Publisher = "" };
            _validation.TestValidate(bookModel).ShouldHaveValidationErrorFor(x => x.Publisher);
        }

        [Fact]
        public void Publisher_Input_Value()
        {
            var bookModel = new UpdateBookModel { Publisher = "test" };
            _validation.TestValidate(bookModel).ShouldNotHaveValidationErrorFor(x => x.Publisher);
        }

        [Fact]
        public void Language_Input_Null()
        {
            var bookModel = new UpdateBookModel { Language = "" };
            _validation.TestValidate(bookModel).ShouldHaveValidationErrorFor(x => x.Language);
        }

        [Fact]
        public void Language_Input_Value()
        {
            var bookModel = new UpdateBookModel { Language = "test" };
            _validation.TestValidate(bookModel).ShouldNotHaveValidationErrorFor(x => x.Language);
        }

        [Fact]
        public void PagesNumber_Input_Null()
        {
            var bookModel = new UpdateBookModel { PagesNumber = "" };
            _validation.TestValidate(bookModel).ShouldHaveValidationErrorFor(x => x.PagesNumber);
        }

        [Fact]
        public void PagesNumber_Input_Value()
        {
            var bookModel = new UpdateBookModel { PagesNumber = "test" };
            _validation.TestValidate(bookModel).ShouldNotHaveValidationErrorFor(x => x.PagesNumber);
        }
    }
}
