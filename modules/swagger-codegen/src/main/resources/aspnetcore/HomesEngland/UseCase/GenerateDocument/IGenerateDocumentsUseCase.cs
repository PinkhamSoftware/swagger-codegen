using HomesEngland.Boundary.UseCase;
using HomesEngland.UseCase.GenerateDocument.Models;

namespace HomesEngland.UseCase.GenerateDocument
{
    public interface IGenerateDocumentsUseCase:IAsyncUseCaseTask<GenerateDocumentsRequest, GenerateAssetsResponse>
    {

    }
}
