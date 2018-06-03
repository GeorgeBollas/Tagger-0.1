using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tagger.Entities;

namespace Tagger.Services
{
    public interface ILookupTables
    {
        Task InitializeAsync();

        IList<TagType> TagTypes { get; }

        TagType GetTagType(int id);

        Tag GetTag(int id);

    }

    public class LookupTablesProxy
    {
        static public ILookupTables Instance { get; set; }
    }
}
