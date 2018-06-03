﻿using System;
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

        public async Task<ServiceResponse<TagType>> CreateTagType(string name, string description, int minCount, int maxCount)
        {
            var response = new ServiceResponse<TagType>();

            try
            {

                var tt = new TagType()
                {
                    Id = UIDGenerator.Next(1),
                    Name = name,
                    Description = description,
                    MinCount = minCount,
                    MaxCount = maxCount
                };

                tt.MarkModified();

                response.Messages.AddRange(ValidateTagType(tt));

                await taggerDataContext.TagsRepository.InsertTagTypeAsync(tt);

                await taggerDataContext.SaveChangesAsync();

                response.ReturnValue = tt;
            }
            catch (Exception ex)
            {
                var m = new ResponseMessage()
                {
                    MessageId = ResponseMessage.ExceptionMessageId,
                    Message = ex.Message,
                    ResultLevel = MessageLevel.Critical,
                };
                response.Messages.Add(m);
            }

            return response;
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
    }
}