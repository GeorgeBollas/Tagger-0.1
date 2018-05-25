using System.Collections.Generic;
using System.Threading.Tasks;
using Tagger.Entities;

namespace Tagger.Services
{
    public interface ITagsService
    {
        Task<IList<TagType>> GetTagTypesAsync();
    }
}