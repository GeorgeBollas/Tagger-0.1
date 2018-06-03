using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tagger.Models.Common
{
    public abstract class EditableItemModel
    {
        public abstract void Merge(object item);
    }
}
