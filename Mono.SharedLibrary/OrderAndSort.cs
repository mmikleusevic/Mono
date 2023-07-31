using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Mono.SharedLibrary
{
    public class OrderAndSort
    {
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [JsonPropertyName("Filter")]
        public string Filter { get; set; } = string.Empty!;
        [JsonPropertyName("OrderByValue")]
        public OrderByValue OrderByValue { get; set; } = OrderByValue.ASC;
        [JsonPropertyName("OrderBy")]
        public string OrderBy { get; set; } = "Name";

        /// <summary>
        /// Returns sorted list of data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<IEnumerable<T>> Order<T>(IQueryable<T> data)
        {
            PropertyInfo? propertyInfo = typeof(T).GetProperty(OrderBy);

            IEnumerable<T> orderedData = data.AsEnumerable();

            if (propertyInfo != null)
            {
                if (OrderByValue == OrderByValue.ASC)
                {
                    orderedData = orderedData.OrderBy(a => propertyInfo.GetValue(a, null));
                }
                else if (OrderByValue == OrderByValue.DESC)
                {
                    orderedData = orderedData.OrderByDescending(a => propertyInfo.GetValue(a, null));
                }
            }

            return Task.FromResult(orderedData);
        }
    }

    public enum OrderByValue
    {
        ASC = 1,
        DESC = 2
    }
}
