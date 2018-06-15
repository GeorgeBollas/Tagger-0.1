using System.Collections.Generic;
using System.Threading.Tasks;
using Tagger.Entities;

namespace Tagger.Services
{
    public interface ITagsService
    {
        Task<IList<TagType>> GetTagTypesAsync();

        Task<TagType> CreateTagTypeAsync(string name, string description, int minCount = 0, int maxCount = 9999999);
        Task<TagType> UpdateTagTypeAsync(long id, string name, string description, int minCount = 0, int maxCount = 9999999);
    }
}