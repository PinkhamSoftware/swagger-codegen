using System.Collections.Generic;
using HomesEngland.Boundary.UseCase;
using HomesEngland.UseCase.CreateAsset.Models;

namespace HomesEngland.UseCase.CreateDocumentVersion
{
    public interface ICreateAssetRegisterVersionUseCase : IAsyncUseCaseTask<IList<CreateDocumentRequest>, IList<CreateDocumentResponse>>
    {
    }
}
