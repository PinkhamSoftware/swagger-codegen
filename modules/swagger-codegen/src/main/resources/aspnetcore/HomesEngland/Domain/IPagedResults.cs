using System.Collections.Generic;

namespace HomesEngland.Domain
{
    public interface IPagedResults<T>
    {
        IList<T> Results { get; set; }
        int TotalCount { get; set; }
        int NumberOfPages { get; set; }
    }
}
