using HomesEngland.Boundary.UseCase;
using HomesEngland.UseCase.GetDocument.Models;

namespace HomesEngland.UseCase.GetDocument
{
    public interface IGetDocumentUseCase : IUseCaseTask<GetDocumentRequest, GetDocumentResponse>
    {
        
    }
}
