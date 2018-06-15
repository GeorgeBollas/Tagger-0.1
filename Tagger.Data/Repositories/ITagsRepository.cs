using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TagDocs.Data;
using Tagger.Entities;

namespace Tagger.Data
{
    public interface ITagsRepository
    {
        #region Tag Types

        Task<TagType> GetTagTypeAsync(long id, bool includeTags = false);

        Task<IList<TagType>> GetTagTypesAsync(DataRequest<TagType> request = null, bool includeTags = false, int skip = 0, int take = 100000);
        
        Task InsertTagTypeAsync(TagType tagType);

        void UpdateTagType(TagType tagType);

        Task DeleteTagTypeAsync(long tagTypeId);

        #endregion

        #region Tags

        Task<Tag> GetTagAsync(long id);

        Task<IEnumerable<Tag>> GetTagsForTagTypeAsync(long tagTypeId, int skip = 0, int take = 100000);


        Task<int> InsertTagAsync(Tag tag);

        void UpdateTag(Tag tag);

        Task DeleteTagAsync(long tagId);


        #endregion

    }
}
