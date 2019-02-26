using System.Collections.Generic;
using HomesEngland.UseCase.GetDocument.Models;
using HomesEngland.UseCase.Models;

namespace HomesEngland.UseCase.ImportDocuments.Models
{
    public class ImportAssetsResponse : IResponse<DocumentOutputModel>
    {
        public IList<DocumentOutputModel> AssetsImported { get; set; }

        public IList<DocumentOutputModel> ToCsv()
        {
            return AssetsImported;
        }
    }
}
