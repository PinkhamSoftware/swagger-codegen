using System.Threading;
using System.Threading.Tasks;
using HomesEngland.UseCase.CreateDocumentVersion.Models;

namespace HomesEngland.Gateway.AssetRegisterVersions
{
    public interface IDocumentVersionCreator
    {
        Task<IDocumentVersion> CreateAsync(IDocumentVersion documentVersion, CancellationToken cancellationToken);
    }
}
