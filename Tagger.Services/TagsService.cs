using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TagDocs.Data;
using Tagger.Data;
using Tagger.Entities;

namespace Tagger.Services
{
    public class TagsService : ITagsService
    {
        private readonly ITaggerDataContext taggerDataContext;

        public TagsService(ITaggerDataContext taggerDataContext)
        {
            this.taggerDataContext = taggerDataContext;
        }

        public async Task<IList<TagType>> GetTagTypesAsync()
        {
            return await taggerDataContext.TagsRepository.GetTagTypesAsync(new DataRequest<TagType>()
                                                                                {
                                                                                    Where = tt => tt.EntityState != EntityState.Deleted && tt.EntityState != EntityState.New
                                                                                });
        }
    }
}
