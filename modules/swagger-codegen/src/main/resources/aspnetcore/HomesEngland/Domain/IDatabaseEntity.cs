using System;

namespace HomesEngland.Domain
{
    public interface IDatabaseEntity<TIndex>
    {
        TIndex Id { get; set; }

        DateTime ModifiedDateTime { get; set; }
    }
}