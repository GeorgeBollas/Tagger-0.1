using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagDocs.Data;
using Tagger.Entities;

namespace Tagger.Data.Sql
{
    public class TagsRepository : ITagsRepository
    {
        private TaggerDataContext context;
        public TagsRepository(TaggerDataContext context)
        {
            this.context = context;
        }

        #region Tag Types
        public Task<TagType> GetTagTypeAsync(long id, bool includeTags)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<TagType>> GetTagTypesAsync(DataRequest<TagType> request = null, bool includeTags = false, int skip = 0, int take = 100000)
        {
            return await GetTagTypesQueryable(skip, take, request, includeTags).AsNoTracking().ToListAsync();
        }


        public Task<IEnumerable<Tag>> GetTagsForTagTypeAsync(long tagTypeId)
        {
            throw new NotImplementedException();
        }

        public Task InsertTagTypeAsync(TagType tagType)
        {
            throw new NotImplementedException();
        }

        public void UpdateTagType(TagType tagType)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTagTypeAsync(long tagTypeId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Tags

        public Task<Tag> GetTagAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tag>> GetTagsForTagTypeAsync(long tagTypeId, int skip = 0, int take = 100000)
        {
            throw new NotImplementedException();
        }
        
        public Task<int> InsertTagAsync(Tag tag)
        {
            throw new NotImplementedException();
        }
        
        public void UpdateTag(Tag tag)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTagAsync(long tagId)
        {
            throw new NotImplementedException();
        }

        #endregion

        private IQueryable<TagType> GetTagTypesQueryable(int skip, int take, DataRequest<TagType> request, bool includeTags)
        {
            var req = request ?? new DataRequest<TagType>();

            IQueryable<TagType> items;
            if (includeTags)
                items = context.TagTypes.Include(tt => tt.Tags);
            else
                items = context.TagTypes;

            // Query
            if (!String.IsNullOrEmpty(req.Query))
            {
                items = items.Where(r => r.SearchTerms.Contains(req.Query.ToLower()));
            }

            // Where
            if (req.Where != null)
            {
                items = items.Where(req.Where);
            }

            // Order By
            if (req.OrderBy != null)
            {
                items = items.OrderBy(req.OrderBy);
            }
            if (req.OrderByDesc != null)
            {
                items = items.OrderByDescending(req.OrderByDesc);
            }

            return items;
        }
    }
}
