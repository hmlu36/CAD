using System;
using System.Collections.Generic;
using System.Linq;

namespace Dotnet.Utils.Paging {

    public class PagedResult<T> : PagedResultBase where T : class {

        public IList<T> Results { get; set; }

        public PagedResult() {

            Results = new List<T>();
        }
    }

    public static class PagedExtention {

        // 預設固定10筆
        public static PagedResult<T> GetPaged<T>(this IQueryable<T> query, int page, int pageSize = 3) where T : class {

            var result = new PagedResult<T>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.RowCount = query.Count();

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }
    }
}