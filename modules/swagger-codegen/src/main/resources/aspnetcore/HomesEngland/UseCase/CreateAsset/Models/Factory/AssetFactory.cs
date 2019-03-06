using System;
using System.Linq;
using HomesEngland.Domain.Factory;
using HomesEngland.UseCase.ImportDocuments.Models.ParserExtensions;

namespace HomesEngland.UseCase.CreateAsset.Models.Factory
{
    public class CreateAssetRequestFactory : IFactory<CreateDocumentRequest, CsvAsset>
    {
        public CreateDocumentRequest Create(CsvAsset csvAsset)
        {
            var createAssetRequest = new CreateDocumentRequest
            {
                
            };
            return createAssetRequest;
        }
    }
}
