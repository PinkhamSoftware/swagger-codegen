using HomesEngland.Boundary.UseCase;
using HomesEngland.UseCase.ImportDocuments.Models;

namespace HomesEngland.UseCase.ImportDocuments
{
    public interface IImportAssetsUseCase:IAsyncUseCaseTask<ImportAssetsRequest, ImportAssetsResponse>
    {

    }
}
