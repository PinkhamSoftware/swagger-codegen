using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using HomesEngland.Domain;
using HomesEngland.Exception;
using HomesEngland.Gateway.AssetRegisterVersions;
using HomesEngland.UseCase.CreateAsset.Models;
using HomesEngland.UseCase.CreateDocumentVersion;
using HomesEngland.UseCase.CreateDocumentVersion.Models;
using Moq;
using NUnit.Framework;
using TestHelper;

namespace HomesEnglandTest.UseCase.CreateAsset
{
    public class BulkCreateAssetTests
    {

        private readonly ICreateAssetRegisterVersionUseCase _classUnderTest;
        private readonly Mock<IDocumentVersionCreator> _gateway;

        public BulkCreateAssetTests()
        {
            _gateway = new Mock<IDocumentVersionCreator>();

            _classUnderTest = new CreateAssetRegisterVersionUseCase(_gateway.Object);
        }

        [TestCase(1, 2)]
        [TestCase(2, 3)]
        [TestCase(3, 4)]
        public async Task GivenValidRequest_UseCaseCallsGatewayWithCorrectDomainObject(int schemeId, int createdAssetId)
        {
            //arrange
            var request = TestData.UseCase.GenerateCreateAssetRequest();
            request.SchemeId = schemeId;
            _gateway.Setup(s => s.CreateAsync(It.IsAny<IDocumentVersion>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new DocumentVersion{ Assets = new List<IDocument>(){ new Document(request)}});

            var list = new List<CreateDocumentRequest> {request};
            
            //act
            var useCaseResponse = await _classUnderTest.ExecuteAsync(list, CancellationToken.None);
            //assert
            _gateway.Verify(s => s.CreateAsync(It.Is<IDocumentVersion>(i => i.Assets[0].SchemeId.Equals(schemeId)), It.IsAny<CancellationToken>()));
            useCaseResponse.Should().NotBeNull();
            useCaseResponse[0].Document.Should().NotBeNull();
            useCaseResponse[0].Document.AssetOutputModelIsEqual(request);
        }

        [TestCase(1, 2)]
        [TestCase(2, 3)]
        [TestCase(3, 4)]
        public async Task GivenValidRequest_UseCaseReturnsAssetOutputModels(int schemeId, int createdAssetId)
        {
            //arrange
            var request = TestData.UseCase.GenerateCreateAssetRequest();
            request.SchemeId = schemeId;
            _gateway.Setup(s => s.CreateAsync(It.IsAny<IDocumentVersion>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new DocumentVersion { Assets = new List<IDocument>() { new Document(request) } });
            var list = new List<CreateDocumentRequest> {request};
            //act
            var useCaseResponse = await _classUnderTest.ExecuteAsync(list, CancellationToken.None);
            //assert
            useCaseResponse.Should().NotBeNull();
            useCaseResponse[0].Document.Should().NotBeNull();
            useCaseResponse[0].Document.AssetOutputModelIsEqual(request);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void GivenValidRequest_WhenGatewayReturnsNull_ThenUseCaseThrowsAssetNotCreatedException(int schemeId)
        {
            //arrange
            var request = TestData.UseCase.GenerateCreateAssetRequest();
            request.SchemeId = schemeId;
            var list = new List<CreateDocumentRequest> {request};
            _gateway.Setup(s => s.CreateAsync(It.IsAny<IDocumentVersion>(), It.IsAny<CancellationToken>())).ReturnsAsync((IDocumentVersion)null);
            //act
            //assert
            Assert.ThrowsAsync<CreateAssetRegisterVersionException>(async () => await _classUnderTest.ExecuteAsync(list, CancellationToken.None));
        }

        [Test]
        public async Task GivenValidRequest_WhenUseCaseCallsGateway_ThenModifiedDateIsSet()
        {
            //arrange
            var request = TestData.UseCase.GenerateCreateAssetRequest();
            var list = new List<CreateDocumentRequest> { request };
            _gateway.Setup(s => s.CreateAsync(It.IsAny<IDocumentVersion>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new DocumentVersion { Assets = new List<IDocument>() { new Document(request) } });
            //act
            await _classUnderTest.ExecuteAsync(list, CancellationToken.None);
            //assert
            _gateway.Verify(s => s.CreateAsync(It.Is<IDocumentVersion>(i => i.ModifiedDateTime != DateTime.MinValue), It.IsAny<CancellationToken>()));
        }

        [Test]
        public async Task GivenValidRequest_WhenUseCaseCallsGateway_ThenAssetsAreSet()
        {
            //arrange
            var request = TestData.UseCase.GenerateCreateAssetRequest();
            var list = new List<CreateDocumentRequest> { request };
            _gateway.Setup(s => s.CreateAsync(It.IsAny<IDocumentVersion>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new DocumentVersion { Assets = new List<IDocument>() { new Document(request) } });
            //act
            await _classUnderTest.ExecuteAsync(list, CancellationToken.None);
            //assert
            _gateway.Verify(s => s.CreateAsync(It.Is<IDocumentVersion>(i => i.Assets[0].AssetIsEqual(request)), It.IsAny<CancellationToken>()));
        }
    }
}
