using System.Collections.Generic;
using FluentAssertions;
using HomesEngland.UseCase.ImportDocuments.Models;
using HomesEngland.UseCase.ImportDocuments.Validation;
using NUnit.Framework;

namespace HomesEnglandTest.UseCase.ImportAssets.Validation
{
    [TestFixture]
    public class ImportAssetsRequestValidatorTests
    {
        private readonly ImportAssetsRequestValidator _classUnderTest;
        public ImportAssetsRequestValidatorTests()
        {
            _classUnderTest = new ImportAssetsRequestValidator();
        }

        [TestCase("id;dsd;",";")]
        [TestCase("id;dsd;",";")]
        [TestCase("id;dsd;",";")]
        public void GivenValidInput_ThenIsValidIsTrue(string csvLines, string delimiter)
        {
            //arrange
            var request = new ImportAssetsRequest
            {
                Delimiter = delimiter,
                AssetLines = new List<string>{csvLines}
            };
            //act
            var response = _classUnderTest.Validate(request);
            //assert
            response.Should().NotBeNull();
            response.IsValid.Should().BeTrue();
        }

        [TestCase(null, ";")]
        [TestCase("id;dsd;", null)]
        [TestCase(null, null)]
        public void GivenInValidRequest_ThenIsValidIsFalse(string csvLines, string delimiter)
        {
            //arrange
            IList<string> csvLinesList = null;
            if(!string.IsNullOrEmpty(csvLines))
                csvLinesList = new List<string>();
            var request = new ImportAssetsRequest
            {
                Delimiter = delimiter,
                AssetLines = csvLinesList
            };
            //act
            var response = _classUnderTest.Validate(request);
            //assert
            response.Should().NotBeNull();
            response.IsValid.Should().BeFalse();
            response.Errors.Should().NotBeNullOrEmpty();
        }
    }
}
