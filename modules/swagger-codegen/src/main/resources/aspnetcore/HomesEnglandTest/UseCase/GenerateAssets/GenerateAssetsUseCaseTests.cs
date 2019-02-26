using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using HomesEngland.UseCase.CreateAsset;
using HomesEngland.UseCase.CreateAsset.Models;
using HomesEngland.UseCase.CreateDocumentVersion;
using HomesEngland.UseCase.GenerateDocument;
using HomesEngland.UseCase.GenerateDocument.Impl;
using HomesEngland.UseCase.GenerateDocument.Models;
using Moq;
using NUnit.Framework;

namespace HomesEnglandTest.UseCase.GenerateAssets
{
    [TestFixture]
    public class GenerateAssetsUseCaseTest
    {
        private IGenerateDocumentsUseCase _classUnderTest;
        private Mock<ICreateAssetRegisterVersionUseCase> _mockUseCase;

        [SetUp]
        public void Setup()
        {
            _mockUseCase = new Mock<ICreateAssetRegisterVersionUseCase>();
            
            _classUnderTest = new GenerateDocumentsUseCase(_mockUseCase.Object);
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        public async Task GivenValidRequest_ThenUseCaseGeneratesCorrectNumberOfRecords(int recordCount)
        {
            //arrange 
            var request = new GenerateDocumentsRequest
            {
                Records = recordCount
            };
            var list = new List<CreateAssetResponse>();
            for (int i = 0; i < recordCount; i++)
            {
                list.Add(new CreateAssetResponse());
            }
            _mockUseCase
                .Setup(s => s.ExecuteAsync(It.IsAny<IList<CreateDocumentRequest>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(list);
            //act
            var response = await _classUnderTest.ExecuteAsync(request, CancellationToken.None).ConfigureAwait(false);
            //assert
            response.Should().NotBeNull();
            response.RecordsGenerated.Should().NotBeNull();
            response.RecordsGenerated.Count.Should().Be(recordCount);
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        public async Task GivenValidRequest_ThenUseCase_CallsCreateAssetUseCaseCorrectNumberOfTimes(int recordCount)
        {
            //arrange 
            var request = new GenerateDocumentsRequest
            {
                Records = recordCount
            };
            //act
            await _classUnderTest.ExecuteAsync(request, CancellationToken.None).ConfigureAwait(false);
            //assert
            _mockUseCase.Verify(s=> s.ExecuteAsync(It.IsAny<IList<CreateDocumentRequest>>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
