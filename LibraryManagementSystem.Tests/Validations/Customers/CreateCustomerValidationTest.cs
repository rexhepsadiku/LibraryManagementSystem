using FluentValidation.TestHelper;
using LibraryManagementSystem.Application.Validations.Customers;
using LibraryManagementSystem.Shared.Models.Customers;
using Xunit;

namespace LibraryManagementSystem.Tests.Validations.Customers
{
    public class CreateCustomerValidationTest
    {
        private readonly CreateCustomerValidation _validation;
        public CreateCustomerValidationTest()
        {
            _validation = new CreateCustomerValidation();
        }

        [Fact]
        public void FirstName_Input_Null()
        {
            var customerModel = new CreateCustomerModel { FirstName = "" };
            _validation.TestValidate(customerModel).ShouldHaveValidationErrorFor(x => x.FirstName);
        }

        [Fact]
        public void FirstName_Input_Value()
        {
            var customerModel = new CreateCustomerModel { FirstName = "test" };
            _validation.TestValidate(customerModel).ShouldNotHaveValidationErrorFor(x => x.FirstName);
        }

        [Fact]
        public void LastName_Input_Null()
        {
            var customerModel = new CreateCustomerModel { LastName = "" };
            _validation.TestValidate(customerModel).ShouldHaveValidationErrorFor(x => x.LastName);
        }

        [Fact]
        public void LastName_Input_Value()
        {
            var customerModel = new CreateCustomerModel { LastName = "test" };
            _validation.TestValidate(customerModel).ShouldNotHaveValidationErrorFor(x => x.LastName);
        }

        [Fact]
        public void Email_Input_Null()
        {
            var customerModel = new CreateCustomerModel { Email = "" };
            _validation.TestValidate(customerModel).ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void Email_Input_Value()
        {
            var customerModel = new CreateCustomerModel { Email = "test@test.com" };
            _validation.TestValidate(customerModel).ShouldNotHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void Email_Input_Invalid_Email_Type()
        {
            var customerModel = new CreateCustomerModel { Email = "test.com" };
            _validation.TestValidate(customerModel).ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void Phone_Input_Null()
        {
            var customerModel = new CreateCustomerModel { Phone = "" };
            _validation.TestValidate(customerModel).ShouldHaveValidationErrorFor(x => x.Phone);
        }

        [Fact]
        public void Phone_Input_Value()
        {
            var customerModel = new CreateCustomerModel { Phone = "412413123" };
            _validation.TestValidate(customerModel).ShouldNotHaveValidationErrorFor(x => x.Phone);
        }
    }
}
