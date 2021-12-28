using FluentValidation.TestHelper;
using LibraryManagementSystem.Application.Validations.Accounts;
using LibraryManagementSystem.Shared.Models.Accounts;
using Xunit;

namespace LibraryManagementSystem.Tests.Validations.Accounts
{
    public class LoginValidationTest
    {
        private readonly LoginValidation _validation;
        public LoginValidationTest()
        {
            _validation = new LoginValidation();
        }

        [Fact]
        public void Email_Inuput_Null()
        {
            var loginModel = new LoginModel { Email = "" };
            _validation.TestValidate(loginModel).ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void Email_Input_Value()
        {
            var loginModel = new LoginModel { Email = "test@test.com" };
            _validation.TestValidate(loginModel).ShouldNotHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void Password_Input_Null()
        {
            var loginModel = new LoginModel { Password = "" };
            _validation.TestValidate(loginModel).ShouldHaveValidationErrorFor(x => x.Password);
        }

        [Fact]
        public void Password_Input_Value()
        {
            var loginModel = new LoginModel { Password = "Password!23" };
            _validation.TestValidate(loginModel).ShouldNotHaveValidationErrorFor(x => x.Password);
        }

        [Fact]
        public void Password_Minimum_Length_False()
        {
            var loginModel = new LoginModel { Password = "Pasi2" };
            _validation.TestValidate(loginModel).ShouldHaveValidationErrorFor(x => x.Password);
        }

        [Fact]
        public void Password_Minimum_Length_True()
        {
            var loginModel = new LoginModel { Password = "Password!23" };
            _validation.TestValidate(loginModel).ShouldNotHaveValidationErrorFor(x => x.Password);
        }
    }
}
