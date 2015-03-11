using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KojsInlineEditGridview.Models
{
    public class PageResult<T> where T:class
    {
        public List<T> Results { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
    }
}