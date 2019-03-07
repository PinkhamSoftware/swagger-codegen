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
    public class CreateDocumentVersionUseCase : ICreateDocumentVersionUseCase
    {
        private readonly IDocumentVersionCreator _documentVersionCreator;

        public CreateDocumentVersionUseCase(IDocumentVersionCreator documentVersionCreator)
        {
            _documentVersionCreator = documentVersionCreator;
        }

        public async Task<IList<CreateDocumentResponse>> ExecuteAsync(IList<CreateDocumentRequest> requests, CancellationToken cancellationToken)
        {
            List<IDocument> assets = requests.Select(s => new Document(s) as IDocument).ToList();

            IDocumentVersion documentVersion = new DocumentVersion
            {
                Documents = assets,
                ModifiedDateTime = DateTime.UtcNow
            };
            Console.WriteLine($" Inserting Document Version Start {DateTime.UtcNow.TimeOfDay.ToString("g")}");
            var result = await _documentVersionCreator.CreateAsync(documentVersion, cancellationToken).ConfigureAwait(false);
            if (result == null)
                throw new CreateAssetRegisterVersionException();
            Console.WriteLine($" Inserting Document Version Finish {DateTime.UtcNow.TimeOfDay.ToString("g")}");
            List<CreateDocumentResponse> responses = result.Documents.Select(s => new CreateDocumentResponse
            {
                Document = new DocumentOutputModel(s)
            }).ToList();

            return responses;
        }
    }
}
