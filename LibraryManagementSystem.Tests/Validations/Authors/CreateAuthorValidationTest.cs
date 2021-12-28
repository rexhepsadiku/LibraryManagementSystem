using FluentValidation.TestHelper;
using LibraryManagementSystem.Application.Validations.Authors;
using LibraryManagementSystem.Shared.Models.Authors;
using System;
using Xunit;

namespace LibraryManagementSystem.Tests.Validations.Authors
{
    public class CreateAuthorValidationTest
    {
        private readonly CreateAuthorValidation _validation;
        public CreateAuthorValidationTest()
        {
            _validation = new CreateAuthorValidation();
        }

        [Fact]
        public void FirstName_Input_Null()
        {
            var authorModel = new CreateAuthorModel { FirstName = "" };
            _validation.TestValidate(authorModel).ShouldHaveValidationErrorFor(x => x.FirstName);
        }

        [Fact]
        public void FirstName_Input_Value()
        {
            var authorModel = new CreateAuthorModel { FirstName = "test" };
            _validation.TestValidate(authorModel).ShouldNotHaveValidationErrorFor(x => x.FirstName);
        }

        [Fact]
        public void LastName_Input_Null()
        {
            var authorModel = new CreateAuthorModel { LastName = "" };
            _validation.TestValidate(authorModel).ShouldHaveValidationErrorFor(x => x.LastName);
        }

        [Fact]
        public void LastName_Input_Value()
        {
            var authorModel = new CreateAuthorModel { LastName = "test" };
            _validation.TestValidate(authorModel).ShouldNotHaveValidationErrorFor(x => x.LastName);
        }

        [Fact]
        public void BirthDate_Input_Null()
        {
            var authorModel = new CreateAuthorModel { BirthDate = DateTime.MinValue };
            _validation.TestValidate(authorModel).ShouldHaveValidationErrorFor(x => x.BirthDate);
        }

        [Fact]
        public void BirthDate_Input_Value()
        {
            var authorModel = new CreateAuthorModel { BirthDate = DateTime.Now };
            _validation.TestValidate(authorModel).ShouldNotHaveValidationErrorFor(x => x.BirthDate);
        }

        [Fact]
        public void Country_Input_Null()
        {
            var authorModel = new CreateAuthorModel { Country = "" };
            _validation.TestValidate(authorModel).ShouldHaveValidationErrorFor(x => x.Country);
        }

        [Fact]
        public void Country_Input_Value()
        {
            var authorModel = new CreateAuthorModel { Country = "test" };
            _validation.TestValidate(authorModel).ShouldNotHaveValidationErrorFor(x => x.Country);
        }
    }
}
