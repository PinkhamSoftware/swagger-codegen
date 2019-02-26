using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using FluentAssertions;
using HomesEngland.Gateway.Migrations;
using HomesEngland.UseCase.GenerateAssets;
using HomesEngland.UseCase.GenerateAssets.Models;
using HomesEngland.UseCase.GetAsset.Models;
using Main;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using TestHelper;

namespace AssetRegisterTests.HomesEngland.UseCases
{
    [TestFixture]
    public class GenerateAssetsUseCaseTest
    {
        private readonly IGenerateDocumentsUseCase _classUnderTest;
        //private readonly ISearchAssetUseCase _searchAssetUseCase;
        public GenerateAssetsUseCaseTest()
        {
            var assetRegister = new DependencyRegister();
            
            _classUnderTest = assetRegister.Get<IGenerateDocumentsUseCase>();
            //_searchAssetUseCase = assetRegister.Get<ISearchAssetUseCase>();

            var context = assetRegister.Get<DocumentContext>();
            context.Database.Migrate();
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        public async Task GivenWeGenerateSomeAssets_ThenWeKnowHowManyAssetsWereCreated(int recordCount)
        {
            //arrange 
            var request = new GenerateDocumentsRequest
            {
                Records = recordCount
            };
            //act
            using (var trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var response = await _classUnderTest.ExecuteAsync(request, CancellationToken.None)
                    .ConfigureAwait(false);
                
                //assert
                response.Should().NotBeNull();
                response.RecordsGenerated.Count.Should().Be(recordCount);
                trans.Dispose();
            }
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        public async Task GivenWeGenerateSomeAssets_WhenWeSearchForAssets_ThenWeCanFindThoseRecords(int recordCount)
        {
            //arrange 
            var request = new GenerateDocumentsRequest
            {
                Records = recordCount
            };
            //act
            using (var trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var response = await _classUnderTest.ExecuteAsync(request, CancellationToken.None).ConfigureAwait(false);
                //assert
                for (int i = 0; i < response.RecordsGenerated.Count; i++)
                {
                    var generatedAsset = response.RecordsGenerated.ElementAtOrDefault(i);

                    var record = await FindAsset(generatedAsset);

                    record.Should().NotBeNull();
                    record.AssetOutputModelIsEqual(generatedAsset);
                }
                trans.Dispose();
            }
        }

        private async Task<DocumentOutputModel> FindAsset(DocumentOutputModel generatedDocument)
        {
            //var record = await _searchAssetUseCase.ExecuteAsync(new SearchAssetRequest
            //{
            //    SchemeId = generatedDocument?.SchemeId,
            //    AssetRegisterVersionId = generatedDocument.AssetRegisterVersionId
            //}, CancellationToken.None).ConfigureAwait(false);
            //return record.Assets.ElementAtOrDefault(0);
            return null;
        }
    }
}
