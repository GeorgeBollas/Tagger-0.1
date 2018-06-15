using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TagDocs.Data;
using TagDocs.Services;
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

        public async Task<TagType> CreateTagTypeAsync(string name, string description, int minCount, int maxCount)
        {
            try
            {

                var tt = new TagType()
                {
                    Name = name,
                    Description = description,
                    MinCount = minCount,
                    MaxCount = maxCount
                };

                tt.Initialize(UIDGenerator.Next(1));

                await taggerDataContext.TagsRepository.InsertTagTypeAsync(tt);

                await taggerDataContext.SaveChangesAsync();

                return tt;
            }
            catch (Exception ex)
            {
                //todo log error
                throw;
            }

        }

        private IEnumerable<ResponseMessage> ValidateTagType(TagType tt)
        {
            //todo add validation
            return new List<ResponseMessage>();
        }

        public async Task<IList<TagType>> GetTagTypesAsync()
        {
            return await taggerDataContext.TagsRepository.GetTagTypesAsync(new DataRequest<TagType>()
            {
                Where = tt => tt.EntityState != EntityState.Deleted && tt.EntityState != EntityState.New
            });
        }

        public async Task<TagType> UpdateTagTypeAsync(long id, string name, string description, int minCount = 0, int maxCount = 9999999)
        {

            //todo validate

            var tt = await taggerDataContext.TagsRepository.GetTagTypeAsync(id);

            if (tt == null)
                return null;

            tt.Name = name;
            tt.Description = description;
            tt.MinCount = minCount;
            tt.MaxCount = maxCount;

            tt.MarkModified();

            try
            {
                taggerDataContext.TagsRepository.UpdateTagType(tt);

                await taggerDataContext.SaveChangesAsync();

                return tt;
            }
            catch (Exception ex)
            {
                //todo log the error
                throw;
            }
        }
    }
}
