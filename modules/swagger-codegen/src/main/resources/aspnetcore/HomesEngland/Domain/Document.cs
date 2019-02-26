using System;
using HomesEngland.UseCase.CreateAsset.Models;

namespace HomesEngland.Domain
{
    public class Document:IDocument
    {
        public int Id { get; set; }
        public DateTime ModifiedDateTime { get; set; }

        public Document() { }
        public Document(CreateDocumentRequest request)
        {
            //map to document
        }

        public Document(IDocument request)
        {
            Id = request.Id;
            //map to document
        }
    }
}
