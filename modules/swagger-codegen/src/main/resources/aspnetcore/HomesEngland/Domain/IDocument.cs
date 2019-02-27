using System;

namespace HomesEngland.Domain
{
    public interface IDocument:IDatabaseEntity<int>
    {
        int? DocumentVersionId { get; set; }
        //todo vars here
    }
}
