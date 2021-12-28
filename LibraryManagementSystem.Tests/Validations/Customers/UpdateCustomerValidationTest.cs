using FluentValidation.TestHelper;
using LibraryManagementSystem.Application.Validations.Customers;
using LibraryManagementSystem.Shared.Models.Customers;
using Xunit;

namespace LibraryManagementSystem.Tests.Validations.Customers
{
    public class UpdateCustomerValidationTest
    {
        private readonly UpdateCustomerValidation _validation;
        public UpdateCustomerValidationTest()
        {
            _validation = new UpdateCustomerValidation();
        }

        [Fact]
        public void FirstName_Input_Null()
        {
            var customerModel = new UpdateCustomerModel { FirstName = "" };
            _validation.TestValidate(customerModel).ShouldHaveValidationErrorFor(x => x.FirstName);
        }

        [Fact]
        public void FirstName_Input_Value()
        {
            var customerModel = new UpdateCustomerModel { FirstName = "test" };
            _validation.TestValidate(customerModel).ShouldNotHaveValidationErrorFor(x => x.FirstName);
        }

        [Fact]
        public void LastName_Input_Null()
        {
            var customerModel = new UpdateCustomerModel { LastName = "" };
            _validation.TestValidate(customerModel).ShouldHaveValidationErrorFor(x => x.LastName);
        }

        [Fact]
        public void LastName_Input_Value()
        {
            var customerModel = new UpdateCustomerModel { LastName = "test" };
            _validation.TestValidate(customerModel).ShouldNotHaveValidationErrorFor(x => x.LastName);
        }

        [Fact]
        public void Email_Input_Null()
        {
            var customerModel = new UpdateCustomerModel { Email = "" };
            _validation.TestValidate(customerModel).ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void Email_Input_Value()
        {
            var customerModel = new UpdateCustomerModel { Email = "test@test.com" };
            _validation.TestValidate(customerModel).ShouldNotHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void Email_Input_Invalid_Email_Type()
        {
            var customerModel = new UpdateCustomerModel { Email = "test.com" };
            _validation.TestValidate(customerModel).ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void Phone_Input_Null()
        {
            var customerModel = new UpdateCustomerModel { Phone = "" };
            _validation.TestValidate(customerModel).ShouldHaveValidationErrorFor(x => x.Phone);
        }

        [Fact]
        public void Phone_Input_Value()
        {
            var customerModel = new UpdateCustomerModel { Phone = "412413123" };
            _validation.TestValidate(customerModel).ShouldNotHaveValidationErrorFor(x => x.Phone);
        }
    }
}
