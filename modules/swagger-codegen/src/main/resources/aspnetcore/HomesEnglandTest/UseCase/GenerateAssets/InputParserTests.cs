using FluentAssertions;
using HomesEngland.UseCase.GenerateDocument;
using HomesEngland.UseCase.GenerateDocument.Models;
using NUnit.Framework;
using HomesEngland.UseCase.Models;

namespace HomesEnglandTest.UseCase.GenerateAssets
{
    [TestFixture]
    public class InputParserTests
    {
        private IInputParser<GenerateDocumentsRequest> _classUnderTest;
        public InputParserTests()
        {
            _classUnderTest = new InputParser();
        }

        [TestCase("--records", "1000", 1000)]
        [TestCase("--records", "200", 200)]
        [TestCase("--records", "100", 100)]
        public void GivenValidInput_InputSanitizer_ReturnsRequest(string string1, string string2, int expectedValue)
        {
            //arrange
            string [] args = new string[]{ string1, string2};
            //act
            var response = _classUnderTest.Parse(args);
            //assert
            response.Should().NotBeNull();
            response.Records.Should().NotBeNull();
            response.Records.Should().Be(expectedValue);
        }

        [TestCase("--record", "1000")]
        [TestCase("--record", "200")]
        [TestCase("", "t")]
        public void GivenInValidInput_InputSanitizer_ReturnsDetailedError(string string1, string string2)
        {
            //arrange
            string[] args = new string[] { string1, string2 };
            //act
            var response = _classUnderTest.Parse(args);
            //assert
            response.Should().NotBeNull();
        }
    }
}
