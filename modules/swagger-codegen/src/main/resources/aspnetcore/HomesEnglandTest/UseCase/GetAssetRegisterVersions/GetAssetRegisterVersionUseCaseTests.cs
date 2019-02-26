using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using HomesEngland.Domain;
using HomesEngland.Gateway;
using HomesEngland.Gateway.AssetRegisterVersions;
using HomesEngland.UseCase.CreateDocumentVersion.Models;
using HomesEngland.UseCase.GetDocumentVersions;
using HomesEngland.UseCase.GetDocumentVersions.Impl;
using HomesEngland.UseCase.GetDocumentVersions.Models;
using Moq;
using NUnit.Framework;

namespace HomesEnglandTest.UseCase.GetAssetRegisterVersions
{
    [TestFixture]
    public class GetAssetRegisterVersionUseCaseTests
    {
        private IGetDocumentVersionsUseCase _classUnderTest;
        private Mock<IAssetRegisterVersionSearcher> _mockGateway;

        [SetUp]
        public void Setup()
        {
            _mockGateway = new Mock<IAssetRegisterVersionSearcher>();
            _classUnderTest = new GetDocumentVersionsUseCase(_mockGateway.Object);
        }

        [TestCase(1, 1)]
        [TestCase(10, 10)]
        [TestCase(1, 11)]
        public async Task GivenValidRequest_WhenWeExecute_ThenWeCallGatewayWithParams(int? page, int? pageSize)
        {
            //arrange
            _mockGateway.Setup(s => s.Search(It.IsAny<IPagedQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new PagedResults<IDocumentVersion>
            {
                NumberOfPages = 1,
                Results = new List<IDocumentVersion>(),
                TotalCount = 1
            });

            var request = new GetAssetRegisterVersionsRequest
            {
                Page = page,
                PageSize = pageSize
            };
            //act
            var response = await _classUnderTest.ExecuteAsync(request, CancellationToken.None)
                .ConfigureAwait(false);
            //assert
            response.Should().NotBeNull();
            _mockGateway.Verify(v=> v.Search(It.Is<IPagedQuery>(i => i.Page == page && i.PageSize == pageSize), It.IsAny<CancellationToken>()));
        }

        [TestCase(null, null)]
        public async Task GivenNullParams_WhenWeExecute_ThenWeCallGatewayWithDefaultParams(int? page, int? pageSize)
        {
            //arrange
            _mockGateway.Setup(s => s.Search(It.IsAny<IPagedQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new PagedResults<IDocumentVersion>
            {
                NumberOfPages = 1,
                Results = new List<IDocumentVersion>(),
                TotalCount = 1
            });

            var request = new GetAssetRegisterVersionsRequest
            {
                Page = page,
                PageSize = pageSize
            };
            //act
            var response = await _classUnderTest.ExecuteAsync(request, CancellationToken.None)
                .ConfigureAwait(false);
            //assert
            response.Should().NotBeNull();
            _mockGateway.Verify(v => v.Search(It.Is<IPagedQuery>(i => i.Page == 1 && i.PageSize == 25), It.IsAny<CancellationToken>()));
        }

        [TestCase(1, 1)]
        [TestCase(10, 10)]
        [TestCase(1, 11)]
        public async Task GivenValidRequest_WhenGatewayReturnsNull_ThenResponseNotNull(int? page, int? pageSize)
        {
            //arrange
            _mockGateway.Setup(s => s.Search(It.IsAny<IPagedQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync((PagedResults<IDocumentVersion>)null);

            var request = new GetAssetRegisterVersionsRequest
            {
                Page = page,
                PageSize = pageSize
            };
            //act
            var response = await _classUnderTest.ExecuteAsync(request, CancellationToken.None)
                .ConfigureAwait(false);
            //assert
            response.Should().NotBeNull();
            response.AssetRegisterVersions.Count.Should().Be(0);
            response.TotalCount.Should().Be(0);
            response.Pages.Should().Be(0);
        }
    }
}
