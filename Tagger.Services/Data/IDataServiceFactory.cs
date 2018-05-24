using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tagger.Services.Data
{
    public interface IDataServiceFactory
    {
        IDataContext GetContect(DataProviderType type);
    }
}
