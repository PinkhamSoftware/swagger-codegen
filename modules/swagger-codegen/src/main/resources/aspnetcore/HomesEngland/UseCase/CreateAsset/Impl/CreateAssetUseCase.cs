using System.Threading;
using System.Threading.Tasks;
using HomesEngland.Domain;
using HomesEngland.Exception;
using HomesEngland.Gateway.Assets;
using HomesEngland.UseCase.CreateAsset.Models;
using HomesEngland.UseCase.GetDocument.Models;

namespace HomesEngland.UseCase.CreateAsset.Impl
{
    public class CreateAssetUseCase : ICreateAssetUseCase
    {
        private readonly IDocumentCreator _documentCreator;

        public CreateAssetUseCase(IDocumentCreator documentCreator)
        {
            _documentCreator = documentCreator;
        }

        public async Task<CreateDocumentResponse> ExecuteAsync(CreateDocumentRequest requests, CancellationToken cancellationToken)
        {
            IDocument document = new Document(requests);

            var createdAsset = await _documentCreator.CreateAsync(document);
            if(createdAsset == null)
                throw new CreateAssetException();
            
            var assetOutputModel = new DocumentOutputModel(createdAsset);
            var createdAssetResponse = new CreateDocumentResponse
            {
                Document = assetOutputModel
            };
            return createdAssetResponse;
        }
    }
}
