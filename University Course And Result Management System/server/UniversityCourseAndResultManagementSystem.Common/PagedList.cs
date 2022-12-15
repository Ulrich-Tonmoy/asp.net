namespace UniversityCourseAndResultManagementSystem.Common
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            CurrentPage = pageNumber;

            AddRange(items);
        }

        public static PagedList<T> ToPagedList(List<T> source, int count, int pageNumber, int pageSize)
        {
            return new PagedList<T>(source, count, pageNumber, pageSize);
        }
    }
}
