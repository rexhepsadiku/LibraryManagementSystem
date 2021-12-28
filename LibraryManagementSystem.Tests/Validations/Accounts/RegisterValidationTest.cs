using FluentValidation.TestHelper;
using LibraryManagementSystem.Application.Validations.Accounts;
using LibraryManagementSystem.Shared.Models.Accounts;
using System.Text.RegularExpressions;
using Xunit;

namespace LibraryManagementSystem.Tests.Validations.Accounts
{
    public class RegisterValidationTest
    {
        private readonly RegisterValidation _validation;
        public RegisterValidationTest()
        {
            _validation = new RegisterValidation();
        }

        [Fact]
        public void HasValidPassword()
        {
            var lowercase = new Regex("[a-z]+");
            var uppercase = new Regex("[A-Z]+");
            var digit = new Regex("(\\d)+");
            var symbol = new Regex("(\\W)+");
            string pw = "Password!123";

            var validate = (lowercase.IsMatch(pw) && uppercase.IsMatch(pw) && digit.IsMatch(pw) && symbol.IsMatch(pw));
            Assert.True(validate);
        }

        [Fact]
        public void FirstName_Input_Null()
        {
            var registerModel = new RegisterModel { FirstName = "" };
            _validation.TestValidate(registerModel).ShouldHaveValidationErrorFor(x => x.FirstName);
        }

        [Fact]
        public void FirstName_Input_Value()
        {
            var registerModel = new RegisterModel { FirstName = "test" };
            _validation.TestValidate(registerModel).ShouldNotHaveValidationErrorFor(x => x.FirstName);
        }

        [Fact]
        public void LastName_Input_Null()
        {
            var registerModel = new RegisterModel { LastName = "" };
            _validation.TestValidate(registerModel).ShouldHaveValidationErrorFor(x => x.LastName);
        }

        [Fact]
        public void LastName_Input_Value()
        {
            var registerModel = new RegisterModel { LastName = "test" };
            _validation.TestValidate(registerModel).ShouldNotHaveValidationErrorFor(x => x.LastName);
        }

        [Fact]
        public void Email_Input_Null()
        {
            var registerModel = new RegisterModel { Email = "" };
            _validation.TestValidate(registerModel).ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void Email_Input_Value()
        {
            var registerModel = new RegisterModel { Email = "test@test.com" };
            _validation.TestValidate(registerModel).ShouldNotHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void Email_Input_Invalid_Email_Type()
        {
            var registerModel = new RegisterModel { Email = "test" };
            _validation.TestValidate(registerModel).ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void Password_Input_Null()
        {
            var registerModel = new RegisterModel { Password = "" };
            _validation.TestValidate(registerModel).ShouldHaveValidationErrorFor(x => x.Password);
        }

        [Fact]
        public void Password_Input_Value()
        {
            var registerModel = new RegisterModel { Password = "Password!23" };
            _validation.TestValidate(registerModel).ShouldNotHaveValidationErrorFor(x => x.Password);
        }

        [Fact]
        public void Password_Input_Minimum_Length_False()
        {
            var registerModel = new RegisterModel { Password = "Pass" };
            _validation.TestValidate(registerModel).ShouldHaveValidationErrorFor(x => x.Password);
        }

        [Fact]
        public void Password_Input_Minimum_Length_True()
        {
            var registerModel = new RegisterModel { Password = "Password!23" };
            _validation.TestValidate(registerModel).ShouldNotHaveValidationErrorFor(x => x.Password);
        }

        [Fact]
        public void ConfirmPassword_Input_Null()
        {
            var registerModel = new RegisterModel { ConfirmPassword = "" };
            _validation.TestValidate(registerModel).ShouldHaveValidationErrorFor(x => x.ConfirmPassword);
        }

        [Fact]
        public void ConfirmPassword_Input_Value()
        {
            var registerModel = new RegisterModel { ConfirmPassword = "Password!23" };
            registerModel.Password = "Password!23";
            _validation.TestValidate(registerModel).ShouldNotHaveValidationErrorFor(x => x.ConfirmPassword);
        }

        [Fact]
        public void ConfirmPassword_Input_Minimum_Length_False()
        {
            var registerModel = new RegisterModel { ConfirmPassword = "Pass" };
            _validation.TestValidate(registerModel).ShouldHaveValidationErrorFor(x => x.ConfirmPassword);
        }

        [Fact]
        public void ConfirmPassword_Input_Minimum_Length_True()
        {
            var registerModel = new RegisterModel { ConfirmPassword = "Password!23" };
            registerModel.Password = "Password!23";
            _validation.TestValidate(registerModel).ShouldNotHaveValidationErrorFor(x => x.ConfirmPassword);
        }
    }
}
