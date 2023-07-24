using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Mono.SharedLibrary
{
    public class Paging
    {
        public int PageSize { get; set; } = 10;
        public int CurrentPage { get; set; } = 0;
        public string Filter { get; set; } = string.Empty;
        public OrderByValue OrderByValue { get; set; }
        public string OrderBy { get; set; } = string.Empty;


        public async Task<List<T>> SortToList<T>(IQueryable<T> data)
        {
            PropertyInfo? propertyInfo = typeof(T).GetProperty(OrderBy);

            IEnumerable<T> orderedData = data.AsEnumerable();

            if (propertyInfo != null)
            {
                if (OrderByValue == OrderByValue.ASC)
                {
                    orderedData = orderedData.OrderBy(a => propertyInfo.GetValue(a, null));
                }
                else if(OrderByValue == OrderByValue.DESC)
                {
                    orderedData = orderedData.OrderByDescending(a => propertyInfo.GetValue(a, null));
                }
            }

            orderedData = orderedData.Skip(PageSize * CurrentPage)
                .Take(PageSize);

            return await Task.Run(() => orderedData.ToList());
        }
    }

    public enum OrderByValue
    {
        ASC = 1,
        DESC = 2
    }
}
