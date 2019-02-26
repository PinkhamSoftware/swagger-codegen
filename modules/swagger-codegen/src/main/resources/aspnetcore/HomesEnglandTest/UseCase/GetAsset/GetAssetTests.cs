using System.Threading.Tasks;
using HomesEngland.Domain;
using NSubstitute;
using NUnit.Framework;
using TestHelper;
using FluentAssertions;
using HomesEngland.Exception;
using HomesEngland.Gateway.Assets;
using HomesEngland.UseCase.GetDocument;
using HomesEngland.UseCase.GetDocument.Impl;
using HomesEngland.UseCase.GetDocument.Models;

namespace HomesEnglandTest.UseCase.GetAsset
{
    [TestFixture]
    public class GetAssetTests
    {
        private readonly IGetDocumentUseCase _classUnderTest;
        private readonly IDocumentReader _mockGateway;
        public GetAssetTests()
        {
            _mockGateway = Substitute.For<IDocumentReader>();
            _classUnderTest = new GetDocumentUseCase(_mockGateway);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task GivenValidRequestId_UseCaseReturnsCorrectlyMappedAsset(int id)
        {
            //arrange
            var asset = TestData.Domain.GenerateAsset();
            asset.Id = id;
            _mockGateway.ReadAsync(id).Returns(asset);
            //act
            var response = await _classUnderTest.ExecuteAsync(new GetDocumentRequest
            {
                Id = id
            });
            //assert
            response.Should().NotBeNull();
            response.Document.Should().NotBeNull();
            response.Document.AssetOutputModelIsEqual(new DocumentOutputModel(asset));
        }

        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        public void GivenValidRequest_WhenAssetCannotBeFound_ThenUseCaseThrowsAssetNotFoundException(int id)
        {
            //arrange
            var getAssetRequest = new GetDocumentRequest
            {
                Id = id
            };
            _mockGateway.ReadAsync(id).Returns((IDocument)null);
            //act
            //assert
            Assert.ThrowsAsync<AssetNotFoundException>(async () => await _classUnderTest.ExecuteAsync(getAssetRequest));
        }
    }
}
