using System.Collections.Generic;
using System.Threading.Tasks;
using Tagger.Entities;

namespace Tagger.Services
{
    public interface ITagsService
    {
        Task<IList<TagType>> GetTagTypesAsync();

        Task<ServiceResponse<TagType>> CreateTagType(string name, string description, int minCount = 0, int maxCount = 9999999);
    }
}