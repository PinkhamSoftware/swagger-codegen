using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HomesEngland.Domain;
using HomesEngland.Exception;
using HomesEngland.Gateway.AssetRegisterVersions;
using HomesEngland.UseCase.CreateAsset.Models;
using HomesEngland.UseCase.CreateDocumentVersion.Models;
using HomesEngland.UseCase.GetDocument.Models;

namespace HomesEngland.UseCase.CreateDocumentVersion
{
    public class CreateAssetRegisterVersionUseCase : ICreateAssetRegisterVersionUseCase
    {
        private readonly IDocumentVersionCreator _assetRegisterVersionCreator;

        public CreateAssetRegisterVersionUseCase(IDocumentVersionCreator assetRegisterVersionCreator)
        {
            _assetRegisterVersionCreator = assetRegisterVersionCreator;
        }

        public async Task<IList<CreateAssetResponse>> ExecuteAsync(IList<CreateDocumentRequest> requests, CancellationToken cancellationToken)
        {
            List<IDocument> assets = requests.Select(s => new Document(s) as IDocument).ToList();

            IDocumentVersion documentVersion = new DocumentVersion
            {
                Assets = assets,
                ModifiedDateTime = DateTime.UtcNow
            };
            Console.WriteLine($" Inserting AssetRegisterVersion Start {DateTime.UtcNow.TimeOfDay.ToString("g")}");
            var result = await _assetRegisterVersionCreator.CreateAsync(documentVersion, cancellationToken).ConfigureAwait(false);
            if (result == null)
                throw new CreateAssetRegisterVersionException();
            Console.WriteLine($" Inserting AssetRegisterVersion Finish {DateTime.UtcNow.TimeOfDay.ToString("g")}");
            List<CreateAssetResponse> responses = result.Assets.Select(s => new CreateAssetResponse
            {
                Document = new DocumentOutputModel(s)
            }).ToList();

            return responses;
        }
    }
}
