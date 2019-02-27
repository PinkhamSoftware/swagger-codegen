using System.Collections.Generic;
using System.Linq;
using HomesEngland.Domain;
using HomesEngland.UseCase.CreateAsset.Models;
using HomesEngland.UseCase.GetDocument.Models;

namespace TestHelper
{
    public static class AssetRegisterVersionExtensions
    {
        public static int GetAssetRegisterVersionId(this IList<IDocument> assets)
        {
            return assets.Select(s => s.DocumentVersionId.Value).FirstOrDefault();
        }

        public static int GetAssetRegisterVersionId(this IList<DocumentOutputModel> assets)
        {
            return assets.Select(s => s.DocumentVersionId.Value).FirstOrDefault();
        }

        public static int GetAssetRegisterVersionId(this IList<CreateDocumentResponse> assets)
        {
            return assets.Select(s => s.Document.DocumentVersionId.Value).FirstOrDefault();
        }
    }
}
