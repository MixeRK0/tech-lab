namespace NewWebApp.Models
{
    public class PaginationParameterModel
    {  
        private const int MaxPageSize = 20;
        private const int DefaultPageNumber = 1;
        private const int DefaultPageSize = 10;
  
        public int pageNumber { get; set; }
  
        public int pageSize { get; set; }

        public int perPage { get; set; }
        public int page { get; set; }


        public int GetPerPage()
        {
            if (perPage > 0)
            {
                return perPage;
            }

            if (pageSize > 0)
            {
                return pageSize;
            }

            return DefaultPageSize;
        }

        public int GetPage()
        {
            if (page > 0)
            {
                return page;
            }

            if (pageNumber > 0)
            {
                return pageNumber;
            }

            return DefaultPageNumber;
        }
    }  
}
