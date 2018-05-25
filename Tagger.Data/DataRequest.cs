using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TagDocs.Data
{
    public class DataRequest<T>
    {
        public string Query { get; set; }

        public int Skip { get; set; } = 0;

        public int Take { get; set; } = 100000;

        public Expression<Func<T, bool>> Where { get; set; }
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDesc { get; set; }
    }
}
