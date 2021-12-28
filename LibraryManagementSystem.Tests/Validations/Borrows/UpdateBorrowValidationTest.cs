using FluentValidation.TestHelper;
using LibraryManagementSystem.Application.Validations.Borrows;
using LibraryManagementSystem.Shared.Models.Borrows;
using System;
using Xunit;

namespace LibraryManagementSystem.Tests.Validations.Borrows
{
    public class UpdateBorrowValidationTest
    {
        private readonly UpdateBorrowValidation _validation;
        public UpdateBorrowValidationTest()
        {
            _validation = new UpdateBorrowValidation();
        }

        [Fact]
        public void BookId_Input_Null()
        {
            var borrowModel = new UpdateBorrowModel { BookId = 0 };
            _validation.TestValidate(borrowModel).ShouldHaveValidationErrorFor(x => x.BookId);
        }

        [Fact]
        public void BookId_Input_Value()
        {
            var borrowModel = new UpdateBorrowModel { BookId = 2 };
            _validation.TestValidate(borrowModel).ShouldNotHaveValidationErrorFor(x => x.BookId);
        }

        [Fact]
        public void CustomerId_Input_Null()
        {
            var borrowModel = new UpdateBorrowModel { CustomerId = 0 };
            _validation.TestValidate(borrowModel).ShouldHaveValidationErrorFor(x => x.CustomerId);
        }

        [Fact]
        public void CustomerId_Input_Value()
        {
            var borrowModel = new UpdateBorrowModel { CustomerId = 2 };
            _validation.TestValidate(borrowModel).ShouldNotHaveValidationErrorFor(x => x.CustomerId);
        }

        [Fact]
        public void EndDate_Input_Null()
        {
            var borrowModel = new UpdateBorrowModel { EndDate = DateTime.MinValue };
            _validation.TestValidate(borrowModel).ShouldHaveValidationErrorFor(x => x.EndDate);
        }

        [Fact]
        public void EndDate_Input_Value()
        {
            var borrowModel = new UpdateBorrowModel { EndDate = DateTime.Now };
            _validation.TestValidate(borrowModel).ShouldNotHaveValidationErrorFor(x => x.EndDate);
        }
    }
}
