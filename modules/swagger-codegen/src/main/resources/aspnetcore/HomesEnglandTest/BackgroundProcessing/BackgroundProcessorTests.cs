﻿using System.Threading;
using System.Threading.Tasks;
using HomesEngland.BackgroundProcessing;
using HomesEngland.UseCase.ImportDocuments;
using HomesEngland.UseCase.ImportDocuments.Models;
using Moq;
using NUnit.Framework;

namespace HomesEnglandTest.BackgroundProcessing
{
    [TestFixture]
    public class BackgroundProcessorTests
    {
        private IBackgroundProcessor _classUnderTest;
        private Mock<IImportAssetsUseCase> _mockImportAssetsUseCase;

        [SetUp]
        public void Setup()
        {
            _classUnderTest = new BackgroundProcessor();
            _mockImportAssetsUseCase = new Mock<IImportAssetsUseCase>();
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task GivenOneTask_WhenTaskIsQueued_ThenTaskIsExecuted(int count)
        {
            //arrange
            
            //act
            for (int i = 0; i < count; i++)
            {
                await _classUnderTest.QueueBackgroundTask(async () => await _mockImportAssetsUseCase.Object.ExecuteAsync(new ImportAssetsRequest(), CancellationToken.None));
            }

           await Task.Delay(500);
            //assert
            _mockImportAssetsUseCase.Verify(v=>v.ExecuteAsync(It.IsAny<ImportAssetsRequest>(), It.IsAny<CancellationToken>()), Times.Exactly(count));
        }
    }
}
