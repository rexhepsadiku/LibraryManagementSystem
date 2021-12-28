using FluentValidation.TestHelper;
using LibraryManagementSystem.Application.Validations.Authors;
using LibraryManagementSystem.Shared.Models.Authors;
using System;
using Xunit;

namespace LibraryManagementSystem.Tests.Validations.Authors
{
    public class UpdateAuthorValidationTest
    {
        private readonly UpdateAuthorValidation _validation;
        public UpdateAuthorValidationTest()
        {
            _validation = new UpdateAuthorValidation();
        }

        [Fact]
        public void FirstName_Input_Null()
        {
            var authorModel = new UpdateAuthorModel { FirstName = "" };
            _validation.TestValidate(authorModel).ShouldHaveValidationErrorFor(x => x.FirstName);
        }

        [Fact]
        public void FirstName_Input_Value()
        {
            var authorModel = new UpdateAuthorModel { FirstName = "test" };
            _validation.TestValidate(authorModel).ShouldNotHaveValidationErrorFor(x => x.FirstName);
        }

        [Fact]
        public void LastName_Input_Null()
        {
            var authorModel = new UpdateAuthorModel { LastName = "" };
            _validation.TestValidate(authorModel).ShouldHaveValidationErrorFor(x => x.LastName);
        }

        [Fact]
        public void LastName_Input_Value()
        {
            var authorModel = new UpdateAuthorModel { LastName = "test" };
            _validation.TestValidate(authorModel).ShouldNotHaveValidationErrorFor(x => x.LastName);
        }

        [Fact]
        public void BirthDate_Input_Null()
        {
            var authorModel = new UpdateAuthorModel { BirthDate = DateTime.MinValue };
            _validation.TestValidate(authorModel).ShouldHaveValidationErrorFor(x => x.BirthDate);
        }

        [Fact]
        public void BirthDate_Input_Value()
        {
            var authorModel = new UpdateAuthorModel { BirthDate = DateTime.Now };
            _validation.TestValidate(authorModel).ShouldNotHaveValidationErrorFor(x => x.BirthDate);
        }

        [Fact]
        public void Country_Input_Null()
        {
            var authorModel = new UpdateAuthorModel { Country = "" };
            _validation.TestValidate(authorModel).ShouldHaveValidationErrorFor(x => x.Country);
        }

        [Fact]
        public void Country_Input_Value()
        {
            var authorModel = new UpdateAuthorModel { Country = "test" };
            _validation.TestValidate(authorModel).ShouldNotHaveValidationErrorFor(x => x.Country);
        }
    }
}
