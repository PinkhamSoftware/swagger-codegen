using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using HomesEngland.Domain;
using HomesEngland.Exception;
using HomesEngland.Gateway.Assets;
using HomesEngland.UseCase.CreateAsset;
using HomesEngland.UseCase.CreateAsset.Impl;
using Moq;
using NUnit.Framework;
using TestHelper;

namespace HomesEnglandTest.UseCase.CreateAsset
{
    public class CreateAssetTests
    {

        private readonly ICreateAssetUseCase _classUnderTest;
        private readonly Mock<IDocumentCreator> _gateway;

        public CreateAssetTests()
        {
            _gateway = new Mock<IDocumentCreator>();
            
            _classUnderTest = new CreateAssetUseCase(_gateway.Object);
        }

        [TestCase(1, 2)]
        [TestCase(2, 3)]
        [TestCase(3, 4)]
        public async Task GivenValidRequest_UseCaseCallsGatewayWithCorrectDomainObject(int schemeId, int createdAssetId)
        {
            //arrange
            var request = TestData.UseCase.GenerateCreateAssetRequest();
            
            _gateway.Setup(s => s.CreateAsync(It.IsAny<IDocument>())).ReturnsAsync(new Document(request));
            //act
            var useCaseResponse = await _classUnderTest.ExecuteAsync(request, CancellationToken.None);
            //assert
            _gateway.Verify(s=> s.CreateAsync(It.Is<IDocument>(i=> i.AssetIsEqual(request))));
            useCaseResponse.Should().NotBeNull();
            useCaseResponse.Document.Should().NotBeNull();
            useCaseResponse.Document.AssetOutputModelIsEqual(request);
        }

        [TestCase(1, 2)]
        [TestCase(2, 3)]
        [TestCase(3, 4)]
        public async Task GivenValidRequest_UseCaseReturnsAssetOutputModel(int schemeId, int createdAssetId)
        {
            //arrange
            var request = TestData.UseCase.GenerateCreateAssetRequest();
            
            _gateway.Setup(s => s.CreateAsync(It.IsAny<IDocument>())).ReturnsAsync(new Document(request));
            //act
            var useCaseResponse = await _classUnderTest.ExecuteAsync(request, CancellationToken.None);
            //assert
            useCaseResponse.Should().NotBeNull();
            useCaseResponse.Document.Should().NotBeNull();
            useCaseResponse.Document.AssetOutputModelIsEqual(request);
        }

        [TestCase(1, 2)]
        [TestCase(2, 3)]
        [TestCase(3, 4)]
        public void GivenValidRequest_WhenGatewayReturnsNull_ThenUseCaseThrowsAssetNotCreatedException(int schemeId, int createdAssetId)
        {
            //arrange
            var request = TestData.UseCase.GenerateCreateAssetRequest();
            
            _gateway.Setup(s => s.CreateAsync(It.IsAny<IDocument>())).ReturnsAsync((IDocument)null);
            //act
            //assert
            Assert.ThrowsAsync<CreateAssetException>(async ()=> await _classUnderTest.ExecuteAsync(request, CancellationToken.None));
        }
    }
}
