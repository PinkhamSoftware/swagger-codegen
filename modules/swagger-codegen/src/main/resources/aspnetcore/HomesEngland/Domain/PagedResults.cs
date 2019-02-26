using System.Collections.Generic;

namespace HomesEngland.Domain
{
    public class PagedResults<T>: IPagedResults<T>
    {
        public IList<T> Results { get; set; }
        public int TotalCount { get; set; }
        public int NumberOfPages { get; set; }
    }
}
