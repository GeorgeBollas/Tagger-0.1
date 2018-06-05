using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tagger.Models.Common
{
    public abstract class EditableItemModel:ObservableObject
    {
        public abstract void Merge(object item);
    }
}
