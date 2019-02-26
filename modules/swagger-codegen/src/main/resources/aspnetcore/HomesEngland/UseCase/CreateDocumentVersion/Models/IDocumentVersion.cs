using System.Collections.Generic;
using HomesEngland.Domain;

namespace HomesEngland.UseCase.CreateDocumentVersion.Models
{
    public interface IDocumentVersion : IDatabaseEntity<int>
    {
        IList<IDocument> Assets { get; set; }
    }
}
