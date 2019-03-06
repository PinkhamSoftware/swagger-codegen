using System;
using System.Collections.Generic;
using HomesEngland.Domain;

namespace HomesEngland.UseCase.CreateDocumentVersion.Models
{
    public class DocumentVersion : IDocumentVersion
    {
        public int Id { get; set; }

        public DateTime ModifiedDateTime { get; set; }

        public virtual IList<IDocument> Documents { get; set; }

        public DocumentVersion()
        {

        }

        public DocumentVersion(IDocumentVersion documentVersion)
        {
            Id = documentVersion.Id;
            ModifiedDateTime = documentVersion.ModifiedDateTime;
            Documents = documentVersion.Documents;
        }
    }
}
