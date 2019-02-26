using System.Collections.Generic;
using FluentAssertions;
using FluentValidation.Results;
using Infrastructure.Api.Response.Validation;
using NUnit.Framework;

namespace InfrastructureTest.Api.Response.Validation
{
    [TestFixture]
    public class RequestValidationResponseTests
    {
        [TestCase("Name", "IsNullOrEmpty")]
        [TestCase("LastName", "Is longer than 32 character")]
        [TestCase("Initials", "Is longer than 1 character")]
        public void WhenRequestValidationResponse_ThenHasValidationErrors(string field, string message)
        {
            //arrange
            //act
            var error = new RequestValidationResponse(new ValidationResult(new List<ValidationFailure>
            {
                new ValidationFailure(field, message)
            }));
            //assert
            error.ValidationErrors.Should().NotBeNullOrEmpty();
            error.ValidationErrors[0].FieldName.Should().BeEquivalentTo(field);
            error.ValidationErrors[0].Message.Should().BeEquivalentTo(message);
        }

        [Test]
        public void GivenRequestValidationResponseIsValid__IsValidationErrorIsTrue()
        {
            //arrange
            //act
            var error = new RequestValidationResponse(true);
            //assert
            error.IsValid.Should().BeTrue();
            error.ValidationErrors.Should().BeNullOrEmpty();
        }

        [Test]
        public void GivenRequestValidationResponseIsNull_ApiErrorHas_IsValidationErrorIsTrue()
        {
            //arrange
            //act
            var error = new RequestValidationResponse(false);
            //assert
            error.IsValid.Should().BeFalse();
            error.ValidationErrors.Should().NotBeNullOrEmpty();
            error.ValidationErrors[0].Message.Should().BeEquivalentTo("Request is null or required sub objects are null");
        }

        [TestCase("test")]
        [TestCase("not test")]
        public void WhenInstantiatingRequestValidationResponse_WithMessage_ThenValidationErrorsHas_ErrorMessage(string message)
        {
            //arrange
            //act
            var error = new RequestValidationResponse(message);
            //assert
            error.IsValid.Should().BeFalse();
            error.ValidationErrors.Should().NotBeNullOrEmpty();
            error.ValidationErrors[0].Message.Should().BeEquivalentTo(message);
        }
    }
}