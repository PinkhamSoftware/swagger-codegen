using FluentAssertions;
using HomesEngland.UseCase.ImportDocuments.Impl;
using HomesEngland.UseCase.ImportDocuments.Models;
using NUnit.Framework;
using HomesEngland.UseCase.Models;

namespace HomesEnglandTest.UseCase.GenerateAssets
{
    [TestFixture]
    public class ImportAssetsInputParserTests
    {
        private IInputParser<ImportAssetConsoleInput> _classUnderTest;
        public ImportAssetsInputParserTests()
        {
            _classUnderTest = new ImportAssetInputParser();
        }

        [TestCase("--file", "100", "--delimiter", ";")]
        [TestCase("--file", "200", "--delimiter", ",")]
        [TestCase("--file", "200", "--delimiter", "\t")]
        public void GivenValidInput_InputSanitizer_ReturnsRequest(string arg1, string arg2, string arg3, string arg4)
        {
            //arrange
            string[] args = new string[] { arg1, arg2, arg3,arg4 };
            //act
            var response = _classUnderTest.Parse(args);
            //assert
            response.Should().NotBeNull();
            response.Delimiter.Should().Be(arg4);
        }

        [TestCase("--file", "100", "--delimite", ";")]
        [TestCase("--file", "200", "--delimter", ",")]
        [TestCase("--file", "200", "--delimier", "\t")]
        public void GivenInValidInput_InputSanitizer_ReturnsRequest(string arg1, string arg2, string arg3, string arg4)
        {
            //arrange
            string[] args = new string[] { arg1, arg2, arg3, arg4 };
            //act
            var response = _classUnderTest.Parse(args);
            //assert
            response.Should().NotBeNull();
            response.Delimiter.Should().NotBe(arg4);
        }
    }
}
