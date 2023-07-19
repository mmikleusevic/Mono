using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mono.SharedLibrary
{
    public class Paging
    {
        public int PageSize { get; set; } = 10;
        public int CurrentPage { get; set; } = 0;
        public string Filter { get; set; } = string.Empty;
        public string OrderBy { get; set; } = string.Empty;
    }
}
