using System.Threading.Tasks;
using HomesEngland.Domain;
using HomesEngland.Exception;
using HomesEngland.Gateway.Assets;
using HomesEngland.UseCase.GetDocument.Models;

namespace HomesEngland.UseCase.GetDocument.Impl
{
    public class GetDocumentUseCase : IGetDocumentUseCase
    {
        private readonly IDocumentReader _documentReader;

        public GetDocumentUseCase(IDocumentReader documentReader)
        {
            _documentReader = documentReader;
        }

        public async Task<GetDocumentResponse> ExecuteAsync(GetDocumentRequest request)
        {
            IDocument document = await _documentReader.ReadAsync(request.Id).ConfigureAwait(false);

            if (document == null)
            {
                throw new AssetNotFoundException();
            }

            return new GetDocumentResponse
            {
                Document = new DocumentOutputModel(document)
            };
        }
    }
}
