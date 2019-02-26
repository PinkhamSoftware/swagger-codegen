using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using WebApi.Controllers;
using FluentAssertions;
using HomesEngland.UseCase.GetDocument;
using HomesEngland.UseCase.GetDocument.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using TestHelper;
using WebApi.Extensions.Requests;

namespace WebApiTest.Controller.Asset.Get
{
    [TestFixture]
    public class AssetControllerTests
    {
        private readonly DocumentController _classUnderTest;
        private readonly Mock<IGetDocumentUseCase> _mockUseCase;

        public AssetControllerTests()
        {
            _mockUseCase = new Mock<IGetDocumentUseCase>();
            _classUnderTest = new DocumentController(_mockUseCase.Object);
        }

        [Test]
        public async Task GivenValidRequest_ThenReturnsGetAssetResponse()
        {
            //arrange
            _mockUseCase.Setup(s => s.ExecuteAsync(It.IsAny<GetDocumentRequest>())).ReturnsAsync(new GetDocumentResponse());
            var request = new GetDocumentApiRequest();
            //act
            var response = await _classUnderTest.Get(request);
            //assert
            response.Should().NotBeNull();
        }

        [TestCase(1)]
        [TestCase(2)]
        public async Task GivenValidRequestWithAcceptTextCsvHeader_ThenReturnsListOfAssetOutputModel(int id)
        {
            //arrange
            DocumentOutputModel documentOutputModel = new DocumentOutputModel(TestData.Domain.GenerateAsset()) {Id = id};
            _mockUseCase.Setup(s => s.ExecuteAsync(It.IsAny<GetDocumentRequest>())).ReturnsAsync(new GetDocumentResponse
            {
                Document = documentOutputModel
            });
            _classUnderTest.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };
            _classUnderTest.ControllerContext.HttpContext.Request.Headers.Add(
                new KeyValuePair<string, StringValues>("accept", "text/csv"));
            var request = new GetDocumentApiRequest
            {
                Id = id
            };
            //act
            IActionResult response = await _classUnderTest.Get(request).ConfigureAwait(false);
            //assert
            response.Should().NotBeNull();
            var result = response as ObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().BeOfType<List<DocumentOutputModel>>();
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(null)]
        public void GivenInValidRequest_ThenThrowsBadRequestException(int id)
        {
            //arrange
            var request = new GetDocumentApiRequest
            {
                Id = id
            };

            request.IsValid().Should().BeFalse();
        }
    }
}
