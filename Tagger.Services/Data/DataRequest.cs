using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tagger.Entities.Tags;

namespace Tagger.Services.Data
{
    public interface IDataRequest
    {
        string SearchTerm { get; }

        Expression<Action<TagType, bool>> Where { get; }

        Expression<Action<TagType, bool>> OrderBy { get; }
    }
}
