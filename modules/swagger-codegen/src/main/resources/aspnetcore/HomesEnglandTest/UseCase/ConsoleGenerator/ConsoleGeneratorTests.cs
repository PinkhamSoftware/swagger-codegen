using System.Threading;
using System.Threading.Tasks;
using HomesEngland.UseCase.GenerateDocument;
using HomesEngland.UseCase.GenerateDocument.Impl;
using HomesEngland.UseCase.GenerateDocument.Models;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using HomesEngland.UseCase.Models;

namespace HomesEnglandTest.UseCase.ConsoleGenerator
{
    [TestFixture]
    public class ConsoleGeneratorTests
    {
        private IConsoleGenerator _classUnderTest;
        private IInputParser<GenerateDocumentsRequest> _inputParser;
        private Mock<IGenerateDocumentsUseCase> _mockGenerateAssetUseCase;
        private Mock<ILogger<ConsoleAssetGenerator>> _mockLogger;

        [SetUp]
        public void Setup()
        {
            _inputParser = new InputParser();
            _mockGenerateAssetUseCase = new Mock<IGenerateDocumentsUseCase>();
            _mockLogger = new Mock<ILogger<ConsoleAssetGenerator>>();
            _classUnderTest = new ConsoleAssetGenerator(_inputParser, _mockGenerateAssetUseCase.Object, _mockLogger.Object);
        }

        [TestCase("--records", "1")]
        [TestCase("--records", "2")]
        [TestCase("--records", "3")]
        public async Task GivenWeNeedToGenerateAssets_WhenWeDoSoThroughAConsoleInterface_ThenWeCallGenerateAssets(string arg1, string arg2)
        {
            //arrange
            var args = new string[] { arg1, arg2 };
            //act
            await _classUnderTest.ProcessAsync(args).ConfigureAwait(false);
            //assert
            _mockGenerateAssetUseCase.Verify(s=> s.ExecuteAsync(It.IsAny<GenerateDocumentsRequest>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestCase("--records", "1")]
        [TestCase("--records", "2")]
        [TestCase("--records", "3")]
        public async Task GivenValidInput_WhenWeRunTheGenerator_ThenTheArgumentsArePassedIn(string arg1, string arg2)
        {
            //arrange
            var args = new string[] { arg1, arg2 };
            //act
            await _classUnderTest.ProcessAsync(args).ConfigureAwait(false);
            //assert
            _mockGenerateAssetUseCase.Verify(s => s.ExecuteAsync(It.Is<GenerateDocumentsRequest>(i=> i.Records == int.Parse(arg2)), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
