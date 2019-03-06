using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using FluentAssertions;
using HomesEngland.Domain;
using HomesEngland.Gateway.AssetRegisterVersions;
using HomesEngland.Gateway.Migrations;
using HomesEngland.Gateway.Sql;
using HomesEngland.UseCase.CreateDocumentVersion.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using TestHelper;

namespace HomesEngland.Gateway.Test
{
    [TestFixture]
    public class BulkAssetCreatorTests
    {
        private readonly IGateway<IDocument, int> _gateway;
        private readonly IDocumentVersionCreator _classUnderTest;

        public BulkAssetCreatorTests()
        {
            var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
            var assetGateway = new EfDocumentGateway(databaseUrl);
            _classUnderTest = new EFDocumentVersionGateway(databaseUrl);
            _gateway = assetGateway;

            var assetRegisterContext = new DocumentContext(databaseUrl);
            assetRegisterContext.Database.Migrate();
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task GivenAnAssetHasBeenCreated_WhenTheAssetIsReadFromTheGateway_ThenItIsTheSame(int count)
        {
            //arrange 
            using (var trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                
                IList<IDocument> assets = new List<IDocument>();
                for (int i = 0; i < count; i++)
                {
                    var entity = TestData.Domain.GenerateAsset();
                    assets.Add(entity);
                }
                
                var createdAssets = await _classUnderTest.CreateAsync(new DocumentVersion
                {
                    Documents = assets
                }, CancellationToken.None).ConfigureAwait(false);
                //act
                for (int i = 0; i < count; i++)
                {
                    var createdAsset = createdAssets.Documents.ElementAtOrDefault(i);
                    var readAsset = await _gateway.ReadAsync(createdAsset.Id).ConfigureAwait(false);
                    //assert
                    createdAsset.Id.Should().NotBe(0);
                    readAsset.AssetIsEqual(createdAsset.Id, readAsset);
                }
                
                trans.Dispose();
            }
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task GivenEntities_WhenImporting_ThenAndAssetRegisterVersionIsCreated(int count)
        {
            //arrange 
            using (var trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                IList<IDocument> assets = new List<IDocument>();
                for (int i = 0; i < count; i++)
                {
                    var entity = TestData.Domain.GenerateAsset();
                    assets.Add(entity);
                }

                var createdAssets = await _classUnderTest.CreateAsync(new DocumentVersion
                {
                    Documents = assets,
                }, CancellationToken.None).ConfigureAwait(false);
                //act
                for (int i = 0; i < count; i++)
                {
                    var createdAsset = createdAssets.Documents.ElementAtOrDefault(i);
                    var readAsset = await _gateway.ReadAsync(createdAsset.Id).ConfigureAwait(false);
                    //assert
                    readAsset.DocumentVersionId.Should().NotBeNull();
                }

                trans.Dispose();
            }
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task GivenEntities_WhenImporting_ThenAndAssetRegisterVersionIsTimeStamped(int count)
        {
            //arrange 
            using (var trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                IList<IDocument> assets = new List<IDocument>();
                for (int i = 0; i < count; i++)
                {
                    var entity = TestData.Domain.GenerateAsset();
                    assets.Add(entity);
                }

                var timeStamp = DateTime.UtcNow;
                var assetRegisterVersion = await _classUnderTest.CreateAsync(new DocumentVersion
                {
                    Documents = assets,
                    ModifiedDateTime = timeStamp
                }, CancellationToken.None).ConfigureAwait(false);
                //act
                for (int i = 0; i < count; i++)
                {
                    var createdAsset = assetRegisterVersion.Documents.ElementAtOrDefault(i);
                    var readAsset = await _gateway.ReadAsync(createdAsset.Id).ConfigureAwait(false);
                    //assert
                    readAsset.DocumentVersionId.Should().NotBeNull();
                }

                trans.Dispose();
            }
        }
    }
}
