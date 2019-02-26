﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bogus;
using FluentAssertions;
using HomesEngland.Gateway.Notifications;
using HomesEngland.BackgroundProcessing;
using HomesEngland.UseCase.GetDocumentVersions;
using HomesEngland.UseCase.GetDocumentVersions.Models;
using HomesEngland.UseCase.ImportDocuments;
using HomesEngland.UseCase.ImportDocuments.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Moq;
using NUnit.Framework;
using WebApi.Controllers;

namespace WebApiTest.Controller.AssetRegisterVersions.Get
{
    [TestFixture]
    public class AssetRegisterVersionControllerTests
    {
        private readonly DocumentVersionController _classUnderTest;
        private readonly Mock<IGetDocumentVersionsUseCase> _mockUseCase;
        private readonly Mock<IImportAssetsUseCase> _mockImportAssetsUseCase;
        private readonly ITextSplitter _textSplitter;
        private readonly Mock<BackgroundProcessor> _mockBackgroundProcessor;

        public AssetRegisterVersionControllerTests()
        {
            _mockUseCase = new Mock<IGetDocumentVersionsUseCase>();
            _mockImportAssetsUseCase = new Mock<IImportAssetsUseCase>();
            Mock<IAssetRegisterUploadProcessedNotifier> mockNotifier = new Mock<IAssetRegisterUploadProcessedNotifier>();
            _mockBackgroundProcessor = new Mock<BackgroundProcessor>();
            _textSplitter = new TextSplitter();
            _classUnderTest = new DocumentVersionController(_mockUseCase.Object, _mockImportAssetsUseCase.Object, _textSplitter,mockNotifier.Object, _mockBackgroundProcessor.Object);
        }

        [Test]
        public async Task GivenValidRequest_ThenReturnsGetAssetResponse()
        {
            //arrange
            _mockUseCase.Setup(s =>
                    s.ExecuteAsync(It.IsAny<GetAssetRegisterVersionsRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new GetAssetRegisterVersionsResponse());
            var request = new GetAssetRegisterVersionsRequest();
            //act
            var response = await _classUnderTest.Get(request);
            //assert
            response.Should().NotBeNull();
        }

        [Test]
        public async Task GivenValidRequestWithAcceptTextCsvHeader_ThenReturnsListOfAssetOutputModel()
        {
            //arrange
            var assetOutputModel = new AssetRegisterVersionOutputModel
            {
                Id = Faker.GlobalUniqueIndex
            };
            _mockUseCase.Setup(s =>
                    s.ExecuteAsync(It.IsAny<GetAssetRegisterVersionsRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new GetAssetRegisterVersionsResponse
                {
                    AssetRegisterVersions = new List<AssetRegisterVersionOutputModel> {assetOutputModel}
                });
            _classUnderTest.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };
            _classUnderTest.ControllerContext.HttpContext.Request.Headers.Add(
                new KeyValuePair<string, StringValues>("accept", "text/csv"));
            var request = new GetAssetRegisterVersionsRequest();
            //act
            var response = await _classUnderTest.Get(request).ConfigureAwait(false);
            //assert
            response.Should().NotBeNull();
            var result = response as ObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().BeOfType<List<AssetRegisterVersionOutputModel>>();
        }

        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(null, 1)]
        [TestCase(1, null)]
        [TestCase(null, null)]
        [TestCase(-1, 1)]
        [TestCase(1, -1)]
        public async Task GivenInValidRequest_WhenValidatingRequest_ThenReturnsBadRequest(int? page, int? pageSize)
        {
            //arrange
            var assetOutputModel = new AssetRegisterVersionOutputModel
            {
                Id = Faker.GlobalUniqueIndex
            };
            _mockUseCase.Setup(s =>
                    s.ExecuteAsync(It.IsAny<GetAssetRegisterVersionsRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new GetAssetRegisterVersionsResponse
                {
                    AssetRegisterVersions = new List<AssetRegisterVersionOutputModel> {assetOutputModel}
                });
            _classUnderTest.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };

            var request = new GetAssetRegisterVersionsRequest
            {
                Page = page,
                PageSize = pageSize
            };
            //act
            var response = await _classUnderTest.Get(request).ConfigureAwait(false);
            //assert
            response.Should().NotBeNull();
            var result = response as StatusCodeResult;
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(400);
        }

        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(null, 1)]
        [TestCase(1, null)]
        [TestCase(null, null)]
        [TestCase(-1, 1)]
        [TestCase(1, -1)]
        public void GivenInvalidRequest_ThenIsInvalid(int? page, int? pageSize)
        {
            var apiRequest = new GetAssetRegisterVersionsRequest
            {
                Page = page,
                PageSize = pageSize,
            };

            apiRequest.IsValid().Should().BeFalse();
        }

        [TestCase(1, 1)]
        [TestCase(10, 10)]
        [TestCase(1, 11)]
        public void GivenInvalidRequest_ThenIsValid(int? page, int? pageSize)
        {
            var apiRequest = new GetAssetRegisterVersionsRequest
            {
                Page = page,
                PageSize = pageSize,
            };

            apiRequest.IsValid().Should().BeTrue();
        }
    }
}
