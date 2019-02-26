using System.Collections.Generic;
using HomesEngland.UseCase.Models;

namespace HomesEngland.UseCase.GetDocument.Models
{
    public class GetDocumentResponse:IResponse<DocumentOutputModel>
    {
        public DocumentOutputModel Document { get; set; }
        public IList<DocumentOutputModel> ToCsv()
        {
            return new List<DocumentOutputModel>{Document};
        }
    }
}
