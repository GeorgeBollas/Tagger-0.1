using System;

namespace Tagger.Data
{
    public interface IDataContextFactory: IDisposable
    {
        ITaggerDataContext GetContext();
    }
}