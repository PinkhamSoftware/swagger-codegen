using HomesEngland.Boundary.UseCase;
using HomesEngland.UseCase.GetDocumentVersions.Models;

namespace HomesEngland.UseCase.GetDocumentVersions
{
    public interface IGetDocumentVersionsUseCase : 
        IAsyncUseCaseTask<GetAssetRegisterVersionsRequest,GetAssetRegisterVersionsResponse>
    {

    }
}
