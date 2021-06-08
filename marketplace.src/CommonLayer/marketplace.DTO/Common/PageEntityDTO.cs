using System.Collections.Generic;
namespace marketplace.DTO.Common
{
    public class PageEntityDTO<T>
    {
        public int Page { get; set; }
        public int TotalPage { get; set; }
        public List<T> PageContent { get; set; }
    }
}