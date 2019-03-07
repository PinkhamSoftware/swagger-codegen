using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HomesEngland.Domain.Factory;
using HomesEngland.UseCase.CreateAsset.Models;
using HomesEngland.UseCase.CreateAsset.Models.Factory;
using HomesEngland.UseCase.CreateDocumentVersion;
using HomesEngland.UseCase.ImportDocuments.Models;

namespace HomesEngland.UseCase.ImportDocuments.Impl
{
    public class ImportAssetsUseCase : IImportAssetsUseCase
    {
        private readonly ICreateDocumentVersionUseCase _createDocumentVersionUseCase;
        private readonly IFactory<CreateDocumentRequest, CsvAsset> _createAssetRequestFactory;

        public ImportAssetsUseCase(ICreateDocumentVersionUseCase createDocumentVersionUseCase, IFactory<CreateDocumentRequest, CsvAsset> createAssetRequestFactory)
        {
            _createDocumentVersionUseCase = createDocumentVersionUseCase;
            _createAssetRequestFactory = createAssetRequestFactory;
        }

        public async Task<ImportAssetsResponse> ExecuteAsync(ImportAssetsRequest requests, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{DateTime.UtcNow.TimeOfDay.ToString("g")}: Start Creating asset Requests");
            List<CreateDocumentRequest> createAssetRequests = new List<CreateDocumentRequest>();
            for (int i = 0; i < requests.AssetLines.Count; i++)
            {
                var requestAssetLine = requests.AssetLines.ElementAtOrDefault(i);
                var createAssetRequest = CreateAssetForLine(requests, cancellationToken, requestAssetLine);
                createAssetRequests.Add(createAssetRequest);
                Console.WriteLine($"{DateTime.UtcNow.TimeOfDay.ToString("g")}: Creating asset Request: {i} of {requests.AssetLines.Count}");
            }
            Console.WriteLine($"{DateTime.UtcNow.TimeOfDay.ToString("g")}: Finished Creating asset Requests");

            Console.WriteLine($"{DateTime.UtcNow.TimeOfDay.ToString("g")}: Start Creating AssetRegisterVersion");
            var responses = await _createDocumentVersionUseCase.ExecuteAsync(createAssetRequests, cancellationToken).ConfigureAwait(false);
            Console.WriteLine($"{DateTime.UtcNow.TimeOfDay.ToString("g")}: Finished Creating AssetRegisterVersion");


            ImportAssetsResponse response = new ImportAssetsResponse
            {
                AssetsImported = responses.Select(s=> s.Document).ToList()
            };

            return response;
        }

        private CreateDocumentRequest CreateAssetForLine(ImportAssetsRequest request, CancellationToken cancellationToken, string requestAssetLine)
        {
            CsvAsset csvAsset = new CsvAsset
            {
                CsvLine = requestAssetLine,
                Delimiter = request.Delimiter
            };

            CreateDocumentRequest createDocumentRequest = _createAssetRequestFactory.Create(csvAsset);

            return createDocumentRequest;
        }
    }
}
