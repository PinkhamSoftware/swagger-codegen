using FluentAssertions;
using HomesEngland.UseCase.ImportDocuments;
using HomesEngland.UseCase.ImportDocuments.Impl;
using NUnit.Framework;

namespace HomesEnglandTest.UseCase.ImportAssets
{
    [TestFixture]
    public class TextSplitterTests
    {
        private ITextSplitter _classUnderTest;

        [SetUp]
        public void Setup()
        {
            _classUnderTest = new TextSplitter();
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void GivenNullEmptyOrWhitespaceString_WhenCallingSplitIntoLines_ThenReturnsNull(string text)
        {
            //arrange
            //act
            var response = _classUnderTest.SplitIntoLines(text);
            //assert
            response.Should().BeNull();
        }

        [TestCase(3, "Line1\nLine2\nLine3")]
        [TestCase(2, "Line1\nLine2")]
        [TestCase(1, "Line1")]
        public void GivenValidString_WhenCallingSplitIntoLines_ThenReturnsListOfStrings(int expectedLines, string text)
        {
            //arrange
            //act
            var response = _classUnderTest.SplitIntoLines(text);
            //assert
            response.Should().NotBeNullOrEmpty();
            response.Count.Should().Be(expectedLines);
        }
    }
}
