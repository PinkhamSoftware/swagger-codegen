using FluentAssertions;
using HomesEngland.UseCase.GenerateDocument.Models;
using HomesEngland.UseCase.GenerateDocument.Models.Validation;
using NUnit.Framework;

namespace HomesEnglandTest.UseCase.GenerateAssets.Validation
{
    [TestFixture]
    public class GenerateAssetsRequestValidatorTests
    {
        private readonly GenerateAssetsRequestValidator _classUnderTest;
        public GenerateAssetsRequestValidatorTests()
        {
            _classUnderTest = new GenerateAssetsRequestValidator();
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void GivenValidInput_ThenIsValidIsTrue(int? id)
        {
            //arrange
            var request = new GenerateDocumentsRequest
            {
                Records = id
            };
            //act
            var response = _classUnderTest.Validate(request);
            //assert
            response.Should().NotBeNull();
            response.IsValid.Should().BeTrue();
        }

        [TestCase(0, "Records must not be null and must be greater than 0.")]
        [TestCase(-1, "Records must not be null and must be greater than 0.")]
        [TestCase(null, "'Records' must not be empty.")]
        public void GivenInValidRequest_ThenIsValidIsFalse(int? id, string message)
        {
            //arrange
            var request = new GenerateDocumentsRequest
            {
                Records = id
            };
            //act
            var response = _classUnderTest.Validate(request);
            //assert
            response.Should().NotBeNull();
            response.IsValid.Should().BeFalse();
            response.Errors.Should().NotBeNullOrEmpty();
            response.Errors[0].PropertyName.Should().BeEquivalentTo("Records");
            response.Errors[0].ErrorMessage.Should().BeEquivalentTo(message);
        }
    }
}
