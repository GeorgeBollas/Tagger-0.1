using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tagger.Entities;

namespace Tagger.Services
{
    public class LookupTables : ILookupTables
    {

        public LookupTables()
        {

        }

        public IList<TagType> TagTypes { get; private set; }
        public IList<Tag> Tags { get; private set; }


        public Tag GetTag(int id)
        {
            return Tags.SingleOrDefault(t => t.Id == id);
        }

        public TagType GetTagType(int id)
        {
            return TagTypes.SingleOrDefault(tt => tt.Id == id);
        }

        public async Task InitializeAsync()
        {
            TagTypes = await GetTagTypesAsync();
        }


        private async Task<IList<TagType>> GetTagTypesAsync()
        {
            throw new NotImplementedException();
        }

    }
}
