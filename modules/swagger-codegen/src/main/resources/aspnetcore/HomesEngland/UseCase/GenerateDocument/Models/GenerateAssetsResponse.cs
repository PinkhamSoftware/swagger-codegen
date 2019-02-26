using System.Collections.Generic;
using HomesEngland.UseCase.GetDocument.Models;

namespace HomesEngland.UseCase.GenerateDocument.Models
{
    public class GenerateAssetsResponse
    {
        public IList<DocumentOutputModel> RecordsGenerated { get; set; }
    }
}
