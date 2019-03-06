using System;
using HomesEngland.Domain;

namespace HomesEngland.UseCase.GetDocument.Models
{
    public class DocumentOutputModel
    {
        public int Id { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public int? DocumentVersionId { get; set; }

        public DocumentOutputModel(){}
        //todo vars here
        public DocumentOutputModel(IDocument document)
        {
            Id = document.Id;
            ModifiedDateTime = document.ModifiedDateTime;
            DocumentVersionId = document.DocumentVersionId;
        }
    }
}
