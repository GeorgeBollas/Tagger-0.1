using System;
using System.Threading.Tasks;

namespace Tagger.Data
{
    public interface ITaggerDataContext: IDisposable
    {
        ITagsRepository TagsRepository { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}