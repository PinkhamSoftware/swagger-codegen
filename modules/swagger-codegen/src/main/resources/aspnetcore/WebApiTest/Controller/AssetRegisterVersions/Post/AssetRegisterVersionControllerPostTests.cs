﻿using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using HomesEngland.Domain;
using HomesEngland.Gateway.Notifications;
using HomesEngland.BackgroundProcessing;
using HomesEngland.UseCase.GetDocument.Models;
using HomesEngland.UseCase.GetDocumentVersions;
using HomesEngland.UseCase.ImportDocuments;
using HomesEngland.UseCase.ImportDocuments.Impl;
using HomesEngland.UseCase.ImportDocuments.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Moq;
using NUnit.Framework;
using WebApi.Controllers;

namespace WebApiTest.Controller.AssetRegisterVersions.Post
{
    [TestFixture]
    public class AssetRegisterVersionControllerPostTests
    {
        private DocumentVersionController _classUnderTest;
        private Mock<IImportAssetsUseCase> _mockUseCase;
        private Mock<IGetDocumentVersionsUseCase> _mockGetUseCase;
        private ITextSplitter _textSplitter;
        private Mock<IAssetRegisterUploadProcessedNotifier> _assetRegisterUploadProcessedNotifier;
        private IBackgroundProcessor _backgroundProcessor;

        [SetUp]
        public void Setup()
        {
            _mockUseCase = new Mock<IImportAssetsUseCase>();
            _mockGetUseCase = new Mock<IGetDocumentVersionsUseCase>();
            _textSplitter = new TextSplitter();
            _assetRegisterUploadProcessedNotifier = new Mock<IAssetRegisterUploadProcessedNotifier>();
            _backgroundProcessor = new BackgroundProcessor();
            _classUnderTest = new DocumentVersionController(_mockGetUseCase.Object, _mockUseCase.Object,
                _textSplitter, _assetRegisterUploadProcessedNotifier.Object, _backgroundProcessor);
        }

        [TestCase(1, "asset-register-1-rows.csv")]
        [TestCase(5, "asset-register-5-rows.csv")]
        [TestCase(10, "asset-register-10-rows.csv")]
        public async Task GivenValidFile_WhenUploading_ThenCallImport(int expectedCount, string fileValue)
        {
            //arrange
            _mockUseCase.Setup(s => s.ExecuteAsync(It.IsAny<ImportAssetsRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ImportAssetsResponse
                {
                    AssetsImported = new List<DocumentOutputModel>()
                });
            AddTokenToHeaderForEmail("stub@stub.com");
            var formFiles = await GetFormFiles(fileValue);
            //act
            var response = await _classUnderTest.Post(formFiles);
            //asset
            response.Should().NotBeNull();
        }

        [TestCase("asset-register-1-rows.csv", "test@test.com")]
        [TestCase("asset-register-5-rows.csv", "dog@woof.com")]
        [TestCase("asset-register-10-rows.csv", "cat@meow.com")]
        public async Task GivenValidFile_WhenUploading_NotifyThePersonWhoUploadedIt(string fileValue, string email)
        {
            //arrange
            _mockUseCase.Setup(s => s.ExecuteAsync(It.IsAny<ImportAssetsRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ImportAssetsResponse
                {
                    AssetsImported = new List<DocumentOutputModel>()
                });
            AddTokenToHeaderForEmail(email);

            var formFiles = await GetFormFiles(fileValue);
            //act
            await _classUnderTest.Post(formFiles);
            await Task.Delay(100);
            //asset
            _assetRegisterUploadProcessedNotifier.Verify(o =>
                o.SendUploadProcessedNotification(It.Is<IUploadProcessedNotification>(n => n.Email.Equals(email)),
                    It.IsAny<CancellationToken>()));
        }

        [TestCase(1, "asset-register-1-rows.csv")]
        [TestCase(5, "asset-register-5-rows.csv")]
        [TestCase(10, "asset-register-10-rows.csv")]
        public async Task GivenValidFile_WhenUploading_ThenReturn200(int expectedCount, string fileValue)
        {
            //arrange
            _mockUseCase.Setup(s => s.ExecuteAsync(It.IsAny<ImportAssetsRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ImportAssetsResponse
                {
                    AssetsImported = new List<DocumentOutputModel>
                    {
                        new DocumentOutputModel
                        {
                            Id = 1
                        }
                    }
                });

            AddTokenToHeaderForEmail("stub@stub.com");


            var formFiles = await GetFormFiles(fileValue);
            //act
            var response = await _classUnderTest.Post(formFiles);
            //asset
            var result = response as StatusCodeResult;
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
        }

        private async Task<List<IFormFile>> GetFormFiles(string fileValue)
        {
            var directory = Directory.GetCurrentDirectory();
            var path = Path.Combine(directory, "Controller", "AssetRegisterVersions", "Post", fileValue);
            var fileStream = await File.ReadAllBytesAsync(path).ConfigureAwait(false);
            var memoryStream = new MemoryStream(fileStream);
            var formFiles = new List<IFormFile>
                {new FormFile(memoryStream, 0, memoryStream.Length, fileValue, fileValue)};
            return formFiles;
        }

        private void AddTokenToHeaderForEmail(string email)
        {
            _classUnderTest.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };
            _classUnderTest.ControllerContext.HttpContext.Request.Headers.Add(
                new KeyValuePair<string, StringValues>("Authorization", $"Bearer {CreateAuthTokenForEmail(email)}"));
        }

        private string CreateAuthTokenForEmail(string email)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            Claim emailClaim = new Claim("email", email);

            List<Claim> claims = new List<Claim> {emailClaim};

            string tokenString = tokenHandler.WriteToken(tokenHandler.CreateJwtSecurityToken(
                subject: new ClaimsIdentity(claims)
            ));

            return tokenString;
        }
    }
}
