using FluentAssertions;
using FluentValidation.Results;
using Infrastructure.Api.Response.Validation;
using NUnit.Framework;

namespace InfrastructureTest.Api.Response.Validation
{
    [TestFixture]
    public class ValidationErrorTests
    {

        [Test]
        public void GivenValidationError_ThenFieldsAreNullOrEmpty()
        {
            //arrange
            //act
            var error = new ValidationError();
            //assert
            error.Message.Should().BeNullOrEmpty();
            error.FieldName.Should().BeNullOrEmpty();
        }

        [TestCase("message")]
        [TestCase("test")]
        public void GivenValidationError_WhenIInstantiateItWithMessage_ThenMessageIsCorrect(string message)
        {
            //arrange
            //act
            var error = new ValidationError(message);
            //assert
            error.Message.Should().BeEquivalentTo(message);
            error.FieldName.Should().BeNullOrEmpty();
        }

        [TestCase("Name", "IsNullOrEmpty")]
        [TestCase("LastName", "Is longer than 32 character")]
        [TestCase("Initials", "Is longer than 1 character")]
        public void WhenRequestValidationResponse_ThenHasValidationErrors(string field, string message)
        {
            //arrange
            //act
            var error = new ValidationError(new ValidationFailure(field, message));
            //assert
            error.FieldName.Should().BeEquivalentTo(field);
            error.Message.Should().BeEquivalentTo(message);
        }

    }
}