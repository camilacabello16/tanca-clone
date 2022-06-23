using MongoDB.Bson;
using MongoDB.Driver;
using Service.Models.ReponseModel;
using Service.Models.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repository
{
    public static class BuilderHelper
    {
        public static FilterDefinition<T> GenerateFilter<T>(this IMongoCollection<T> collection, List<FilterParams> filterParams)
        {
            var builder = Builders<T>.Filter;
            FilterDefinition<T> filter = null;
            if (!filterParams.Any())
            {
                filter = builder.Empty;
                return filter;
            }

            // trường hợp muốn search một ô từ khóa cho nhiều trường trong DB
            filterParams.ForEach(o =>
            {
                var listProp = o.Prop.Split(',').ToList();
                FilterDefinition<T> ft = builder.Empty;
                var index = 0;
                foreach (var x in listProp)
                {
                    var itemFilter = o.Type == (int)FilterType.EQUAL ?
                    builder.Eq(x, o.Value) :
                    o.Type == (int)FilterType.CONTAIN ? builder.Regex(x, new BsonRegularExpression($".*{o.Value}.*", "i"))
                    : o.Type == (int)FilterType.LESS ? builder.Lt(x, o.Value) :
                    o.Type == (int)FilterType.GREATER ? builder.Gt(x, o.Value) :
                    o.Type == (int)FilterType.NOT ? builder.Nin(x, new List<object>() { o.Value }) :
                    builder.AnyEq(x, o.Value);
                    if (index == 0)
                    {
                        ft &= itemFilter;
                    }
                    else
                    {
                        ft |= itemFilter;
                    }
                    index++;
                }

                if (filter == null)
                {
                    filter = ft;
                }
                else
                {
                    filter &= ft;
                }
            });
            return filter;
        }
        public static FilterResponse<T> Filter<T>(this IMongoCollection<T> collection, List<FilterParams> filterParams, Pager pager)
        {
            var response = new FilterResponse<T>();
            try
            {
                var asc = Builders<T>.Sort.Ascending(!string.IsNullOrEmpty(pager.SortBy) ? pager.SortBy : "Id");
                var desc = Builders<T>.Sort.Descending(!string.IsNullOrEmpty(pager.SortBy) ? pager.SortBy : "Id");
                var filter = collection.GenerateFilter<T>(filterParams);
                var result = collection.Find<T>(filter).Sort(!string.IsNullOrEmpty(pager.OrderBy) ? (pager.OrderBy == "desc" ? desc : asc) : desc);
                response.TotalRecord = (int)result.CountDocuments();
                response.Data = result.Skip((pager.PageIndex - 1) * pager.PageSize).Limit(pager.PageSize).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return response;
        }
    }
    public class FilterParams
    {
        public string Prop { get; set; }
        public object Value { get; set; }
        public int Type { get; set; }
    }
    public enum FilterType
    {
        EQUAL = 1,
        CONTAIN = 2,
        LESS = 3,
        GREATER = 4,
        NOT = 5
    }
}
