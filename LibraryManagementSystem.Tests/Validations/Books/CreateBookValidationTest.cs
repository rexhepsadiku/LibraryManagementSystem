using FluentValidation.TestHelper;
using LibraryManagementSystem.Application.Validations.Books;
using LibraryManagementSystem.Shared.Models.Books;
using Xunit;

namespace LibraryManagementSystem.Tests.Validations.Books
{
    public class CreateBookValidationTest
    {
        private readonly CreateBookValidaton _validation;
        public CreateBookValidationTest()
        {
            _validation = new CreateBookValidaton();
        }

        [Fact]
        public void Title_Input_Null()
        {
            var bookModel = new CreateBookModel { Title = "" };
            _validation.TestValidate(bookModel).ShouldHaveValidationErrorFor(x => x.Title);
        }

        [Fact]
        public void Title_Input_Value()
        {
            var bookModel = new CreateBookModel { Title = "test" };
            _validation.TestValidate(bookModel).ShouldNotHaveValidationErrorFor(x => x.Title);
        }

        [Fact]
        public void Description_Input_Null()
        {
            var bookModel = new CreateBookModel { Description = "" };
            _validation.TestValidate(bookModel).ShouldHaveValidationErrorFor(x => x.Description);
        }

        [Fact]
        public void Description_Input_Value()
        {
            var bookModel = new CreateBookModel { Description = "test" };
            _validation.TestValidate(bookModel).ShouldNotHaveValidationErrorFor(x => x.Description);
        }

        [Fact]
        public void ISBN_Input_Null()
        {
            var bookModel = new CreateBookModel { ISBN = "" };
            _validation.TestValidate(bookModel).ShouldHaveValidationErrorFor(x => x.ISBN);
        }

        [Fact]
        public void ISBN_Input_Value()
        {
            var bookModel = new CreateBookModel { ISBN = "test" };
            _validation.TestValidate(bookModel).ShouldNotHaveValidationErrorFor(x => x.ISBN);
        }

        [Fact]
        public void AuthorId_Input_Null()
        {
            var bookModel = new CreateBookModel { AuthorId = 0 };
            _validation.TestValidate(bookModel).ShouldHaveValidationErrorFor(x => x.AuthorId);
        }

        [Fact]
        public void AuthorId_Input_Value()
        {
            var bookModel = new CreateBookModel { AuthorId = 2 };
            _validation.TestValidate(bookModel).ShouldNotHaveValidationErrorFor(x => x.AuthorId);
        }

        [Fact]
        public void Publisher_Input_Null()
        {
            var bookModel = new CreateBookModel { Publisher = "" };
            _validation.TestValidate(bookModel).ShouldHaveValidationErrorFor(x => x.Publisher);
        }

        [Fact]
        public void Publisher_Input_Value()
        {
            var bookModel = new CreateBookModel { Publisher = "test" };
            _validation.TestValidate(bookModel).ShouldNotHaveValidationErrorFor(x => x.Publisher);
        }

        [Fact]
        public void Language_Input_Null()
        {
            var bookModel = new CreateBookModel { Language = "" };
            _validation.TestValidate(bookModel).ShouldHaveValidationErrorFor(x => x.Language);
        }

        [Fact]
        public void Language_Input_Value()
        {
            var bookModel = new CreateBookModel { Language = "test" };
            _validation.TestValidate(bookModel).ShouldNotHaveValidationErrorFor(x => x.Language);
        }

        [Fact]
        public void PagesNumber_Input_Null()
        {
            var bookModel = new CreateBookModel { PagesNumber = "" };
            _validation.TestValidate(bookModel).ShouldHaveValidationErrorFor(x => x.PagesNumber);
        }

        [Fact]
        public void PagesNumber_Input_Value()
        {
            var bookModel = new CreateBookModel { PagesNumber = "test" };
            _validation.TestValidate(bookModel).ShouldNotHaveValidationErrorFor(x => x.PagesNumber);
        }
    }
}
