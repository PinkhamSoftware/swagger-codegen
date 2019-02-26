using FluentAssertions;
using HomesEngland.UseCase.ImportDocuments.Models.ParserExtensions;
using NUnit.Framework;

namespace HomesEnglandTest.UseCase.ImportAssets.Models.ParserExtensions
{
    public class DecimalParserExtensionTests
    {
        [TestCase("")]
        [TestCase(null)]
        [TestCase("Meowmeow")]
        [TestCase(" - ")]
        public void GivenInputThatShouldEvaluateToNull_ThenReturnNull(string input)
        {
            decimal? result = input.TryParseDecimalNullable();

            result.Should().BeNull();
        }

        [TestCase("10", 10)]
        [TestCase("10,000", 10000)]
        [TestCase("  22,222  ", 22222)]
        [TestCase("10.5%", 10.5)]
        [TestCase("(10)", -10)]
        public void GivenInputThatShouldEvaluateToDecimal_ThenReturnDecimal(string input, decimal expectedResult)
        {
            decimal? result = input.TryParseDecimalNullable();

            result.Should().Be(expectedResult);
        }
    }
}
