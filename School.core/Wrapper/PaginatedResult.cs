namespace School.core.Wrapper
{
    public class PaginatedResult<T>
    {

        #region Properties
        public List<T> Data { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public object Meta { get; set; }
        public int TotalPages { get; set; }
        public bool Succeeded { get; set; }
        public List<string> Messages { get; set; } = new List<string>();


        #endregion
        #region Constructors
        public PaginatedResult(List<T> data)
        {
            Data = data;
        }

        internal PaginatedResult(bool succeeded, List<T> data = default!, List<string> messages = null, int count = 0, int page = 1, int pageSize = 10, object meta = null)
        {
            Succeeded = succeeded;
            Data = data;
            TotalCount = count;
            CurrentPage = page;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Messages = messages;
            Meta = meta;

        }
        #endregion
        #region Methods
        public static PaginatedResult<T> Success(List<T> data, int count, int page, int pageSize)
        {
            return new PaginatedResult<T>(true, data, null, count, page, pageSize);
        }
        #endregion

    }
}
