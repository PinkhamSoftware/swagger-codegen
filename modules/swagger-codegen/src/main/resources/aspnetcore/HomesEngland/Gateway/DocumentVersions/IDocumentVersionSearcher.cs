using System.Threading;
using System.Threading.Tasks;
using HomesEngland.Domain;
using HomesEngland.UseCase.CreateDocumentVersion.Models;

namespace HomesEngland.Gateway.AssetRegisterVersions
{
    public interface IDocumentVersionSearcher
    {
        Task<IPagedResults<IDocumentVersion>> Search(IPagedQuery searchRequest, CancellationToken cancellationToken);
    }
}