using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HomesEngland.Domain;
using HomesEngland.UseCase.CreateDocumentVersion.Models;
using HomesEngland.UseCase.GetDocumentVersions.Models;

namespace HomesEngland.UseCase.GetDocumentVersions.Impl
{
    public class GetDocumentVersionsUseCase: IGetDocumentVersionsUseCase
    {
        private readonly IAssetRegisterVersionSearcher _assetRegisterVersionSearcher;

        public GetDocumentVersionsUseCase(IAssetRegisterVersionSearcher assetRegisterVersionSearcher)
        {
            _assetRegisterVersionSearcher = assetRegisterVersionSearcher;
        }
        public async Task<GetAssetRegisterVersionsResponse> ExecuteAsync(GetAssetRegisterVersionsRequest requests, CancellationToken cancellationToken)
        {
            var query = new PagedQuery();

            if (requests.Page != null) query.Page = requests.Page;
            if (requests.PageSize != null) query.PageSize = requests.PageSize;

            var response = await _assetRegisterVersionSearcher.Search(query, cancellationToken).ConfigureAwait(false) 
               ?? new PagedResults<IDocumentVersion>
               {
                   Results = new List<IDocumentVersion>(),
                   NumberOfPages = 0,
                   TotalCount = 0
               };

            var useCaseReponse = new GetAssetRegisterVersionsResponse
            {
                AssetRegisterVersions = response.Results.Select(s => new AssetRegisterVersionOutputModel(s)).ToList(),
                TotalCount = response.TotalCount,
                Pages = response.NumberOfPages
            };
            return useCaseReponse;
        }
    }
}
